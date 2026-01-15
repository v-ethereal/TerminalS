using System;
using System.Threading;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.BLL.Services;
using Arsis.RentalSystem.TerminalShell.Helpers;
using Arsis.RentalSystem.TerminalShell.MVP.View;
using log4net;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
    public class ParkingPerHourPresenter
    {
        private readonly ServiceInformation serviceInformation;
        private readonly IParkingPerHourView view;

        private readonly IServicesService servicesService =
            AppRuntime.Instance.Container.GetComponent<IServicesService>();

        private readonly IBanknoteAcceptor banknoteAcceptor =
            AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();

        private readonly IRentalFeeService rentalFeeService =
            AppRuntime.Instance.Container.GetComponent<IRentalFeeService>();

        private readonly ITransactionService transactionService =
            AppRuntime.Instance.Container.GetComponent<ITransactionService>();

        private readonly IParkingService parkingService = AppRuntime.Instance.Container.GetComponent<IParkingService>();
        private readonly IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();

        private readonly ICardReaderService cardReaderService =
            AppRuntime.Instance.Container.GetComponent<ICardReaderService>();

        private int totalReceiveMoney;
        private int currentReceiveMoney;
        private readonly ParkingTicketInfo parkingInfo;
        private bool inReceiveMoneyEventHandler;
    

        public ParkingPerHourPresenter(IParkingPerHourView view)
        {
            this.view = view;

            parkingInfo = this.view.ParkingTicketInfo;

            totalReceiveMoney = (int) parkingInfo.EarlyPaidSum;
            this.view.ShowParkingTicketInfo(parkingInfo);

            serviceInformation = servicesService.GetServiceInformationAboutParkingPerHour();
            this.view.ShowServiceInfo(serviceInformation);

            this.view.ShowAttentionMessage(Constants.MessagePayInformation);

            this.view.SetMoneyAmount(0, (int) parkingInfo.TotalSum - totalReceiveMoney);

            this.view.FinishPayEvent += ViewFinishPayButtonClickEvent;
            this.view.BackButtonEvent += ViewBackButtonEvent;
            this.view.ClosedViewEvent += ViewClosedView;

            transactionService.BeginServiceTransaction(null);

            banknoteAcceptor.ReceiveMoneyEvent += BanknoteAcceptorReceiveMoneyEvent;

            banknoteAcceptor.StartWaitMoney();
        }

        private void ViewClosedView(object sender, EventArgs e)
        {
            if (cardReaderService.IsCardPresent)
            {
                cardReaderService.EjectCard();
            }
        }

        private void BanknoteAcceptorReceiveMoneyEvent(object sender, BanknoteAcceptorEventArgs e)
        {
            inReceiveMoneyEventHandler = true;
            if (e.ReceiveMoney > 0)
            {
                view.UpdateGui();
            }

            totalReceiveMoney += e.ReceiveMoney;
            currentReceiveMoney += e.ReceiveMoney;

            var debt = (int) (parkingInfo.TotalSum - currentReceiveMoney - parkingInfo.EarlyPaidSum);

            view.SetMoneyAmount(currentReceiveMoney, debt < 0 ? 0 : debt);

            transactionService.ProceedServicePayment(serviceInformation.Id, serviceInformation.Name,
                                                     parkingInfo.CostPerHour, e.ReceiveMoney);

            if (totalReceiveMoney >= parkingInfo.TotalSum)
            {
                banknoteAcceptor.StopWaitMoney();
                EndParkingServiceTransaction();
            }
            inReceiveMoneyEventHandler = false;
        }


        /// логику закрытия транзакции по парковочному талону собираем в один метод
        private void EndParkingServiceTransaction()
        {
            if (transactionService.ServiceTransactionInformation == null)
            {
                return;
            }

            try
            {
                var serviceTransactionInformation = transactionService.ServiceTransactionInformation;

                if (serviceTransactionInformation.Fee == 0)
                {
                    return;
                }

                #region  сохранение в БД

                // сохраняем информацию о парковке в файл в диск
                XmlUtility.SerializeObjectToDisk(TransactionService.ParkingInfoFile, parkingInfo);

                var servicePayment = rentalFeeService.InsertServiceFeeRecord(
                    serviceTransactionInformation.ServiceId,
                    serviceTransactionInformation.Price,
                    serviceTransactionInformation.Fee,
                    serviceTransactionInformation.PlaceNumber);

                parkingService.BindParkingTicketWithPayments(parkingInfo, servicePayment);

                if ((parkingInfo.EarlyPaidSum + servicePayment.PaidSum) >= parkingInfo.TotalSum)
                {
                    parkingInfo.InternalId = CommonHelper.GetInternalPackedTicketId(cardReaderService.CardNumber.Value,
                                                                                    cardReaderService.EntranceDate.Value);


                    parkingService.CloseParkingTicket(parkingInfo);
                }

                serviceTransactionInformation.IsFeeRecordInserted = true;
                #endregion

                #region  печать чека и выездного талона

                fiscalRegister.PrintAdditionalServiceReceiptEx(
                    serviceInformation.Name,
                    parkingInfo.TotalSum,
                    servicePayment.PaidSum,
                    parkingInfo.ExtInfo4Check);

                serviceTransactionInformation.IsRecepiePrinted = true;

                // сохранение в БД успешно, печать чека успешна
                // тогда завершаем транзакцию
                transactionService.EndParkingServiceTransaction();

                if ((parkingInfo.EarlyPaidSum +
                     servicePayment.PaidSum) >=
                    parkingInfo.TotalSum)
                {
                    try
                    {
                        //печать выездного талона при полной оплате парковки
                        fiscalRegister.PrintParkingExitTicket(
                            parkingInfo.Number.ToString("X8"),
                            parkingInfo.DateFrom,
                            parkingInfo.DateTo,
                            false,
                            parkingInfo.EarlyPaidSum +
                            servicePayment.PaidSum);
                    }
                    catch (Exception err) // ловим ошибку печати выездного талона она не должна влиять на транзакцию
                    {
                        view.ShowErrorMessage(err);
                        return;
                    }
                }

                #region ShowAlertTakeCheckEvent ShowAlertTakeParkingCardEvent
                view.ShowAlertTakeCheckEvent += delegate
                                                    {
                                                        try
                                                        {
                                                            if ((parkingInfo.EarlyPaidSum + servicePayment.PaidSum) >=
                                                                parkingInfo.TotalSum)
                                                            {
                                                                int[] tariffIdArr = CardReaderHelper.GetTariffIdArray();

                                                                try
                                                                {
                                                                    // ошибку ловим, пишем в лог, но не показываем, клиент может выехать и так, предьявив чек и выездной талон если что...
                                                                    cardReaderService.WriteTariff(true, tariffIdArr[0]);
                                                                }
                                                                catch (CardReaderServiceException exc)
                                                                {
                                                                    LogManager.GetLogger(GetType()).Error(
                                                                        CommonHelper.GetErrorMessage(exc));
                                                                }
                                                            }

                                                            /// выброс карты
                                                            cardReaderService.EjectCard();

                                                            /// показываем сообщение про карту, после этого сообщения стрельнет ShowAlertTakeParkingCardEvent
                                                            view.ShowAlertTakeParkingCard();
                                                        }
                                                        catch (Exception err)
                                                        {
                                                            view.ShowErrorMessage(err);
                                                        }

                                                    };

                view.ShowAlertTakeParkingCardEvent += delegate
                                                          {
                                                              view.RedirectOnParentPage();
                                                          };
                #endregion

                /// сообщение заберите чек, после сообщения про чек стрельнет ShowAlertTakeCheckEvent
                view.ShowAlertTakeCheck();
                #endregion
            }
            catch (Exception err)
            {
                transactionService.SaveServiceInformationToDisk();
                view.ShowErrorMessage(err);
            }
        }

        private void ViewBackButtonEvent(object sender, EventArgs e)
        {
            if (currentReceiveMoney != 0 )
            {
                return;
            }

            banknoteAcceptor.StopWaitMoney();
            transactionService.EndParkingServiceTransaction();

            /// показываем сообщение про карту
            view.ShowAlertTakeParkingCard();
            view.ShowAlertTakeParkingCardEvent += delegate
                                                      {
                                                          /// переход на главную страницу
                                                          view.RedirectOnParentPage();
                                                      };
        }

        private void ViewFinishPayButtonClickEvent(object sender, EventArgs e)
        {
            if (currentReceiveMoney == 0 || inReceiveMoneyEventHandler)
            {
                return;
            }

            banknoteAcceptor.StopWaitMoney();
            EndParkingServiceTransaction();
        }
    }
}