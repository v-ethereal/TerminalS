using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.MVP.View;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
    public class RentalPayPresenter
    {
        private readonly IRentalPayView view;

        private readonly IRentalFeeService rentalFeeService =
            AppRuntime.Instance.Container.GetComponent<IRentalFeeService>();

        private readonly ITransactionService transactionService =
            AppRuntime.Instance.Container.GetComponent<ITransactionService>();

        private readonly IBanknoteAcceptor banknoteAcceptor =
            AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();

        private List<PayDateInformation> payDatesInformation; // список дней за которые платим
        private int totalReceiveMoney; // всего оплачено за текущий сеанс
        private int fullSumma; // всего надо заплатить по договору
        private bool inReceiveMoneyEventHandler;

        public RentalPayPresenter(IRentalPayView view)
        {
            this.view = view;

            this.view.LoadedViewEvent += ViewLoadedViewEvent;
            this.view.FinishPayEvent += ViewFinishPayButtonClickEvent;
            this.view.BackButtonEvent += ViewBackButtonEvent;
        }

        #region events from GUI

        private void ViewLoadedViewEvent(object sender, EventArgs e)
        {
            view.ShowAttentionMessage(Constants.MessagePayInformation);

            payDatesInformation = rentalFeeService.GetPayDates(view.RentalPlaceInformation.ContractNumber,
                                                               view.RentalPlaceInformation.Number);
            if (payDatesInformation.Count == 0)
            {
                view.ShowErrorMessage(
                    new RentalSystemException("Ошибка при инциализации формы оплаты аренды.\n" +
                                              "payDatesInformation.Count = 0"));
                return;
            }

            view.Rate = payDatesInformation[0].Rate;

            // находим сколько всего нужно заплатиить по договору
            fullSumma = payDatesInformation.Sum(item => item.Rate);

            // то же самое за вычетом частично оплаченного дня (как правило первого дня из массива)
            fullSumma = fullSumma - payDatesInformation[0].PaidAmount;

            view.InitView(view.RentalPlaceInformation);

            transactionService.BeginRentalTransaction(view.RentalPlaceInformation.ContractNumber,
                                                      view.RentalPlaceInformation.Number);

            banknoteAcceptor.ReceiveMoneyEvent += BanknoteAcceptorReceiveMoneyEvent;

            banknoteAcceptor.StartWaitMoney();
        }

        private void ViewBackButtonEvent(object sender, EventArgs e)
        {
            if (totalReceiveMoney != 0)
            {
                return;
            }

            banknoteAcceptor.StopWaitMoney();
            transactionService.EndRentalTransaction();

            view.RedirectOnParentPage();
        }

        private void ViewFinishPayButtonClickEvent(object sender, EventArgs e)
        {
            if (totalReceiveMoney == 0 || inReceiveMoneyEventHandler)
            {
                return;
            }

            view.DisablePayButton();

            banknoteAcceptor.StopWaitMoney();
            transactionService.EndRentalTransaction();

            view.ShowAlertTakeCheck();
        }

        #endregion

        #region event from banknoteAcceptor

        private void BanknoteAcceptorReceiveMoneyEvent(object sender, BanknoteAcceptorEventArgs e)
        {
            inReceiveMoneyEventHandler = true;
            if (e.ReceiveMoney == 0)
            {
                inReceiveMoneyEventHandler = false;
                return;
            }

            totalReceiveMoney += e.ReceiveMoney;
            view.FeeAmount += e.ReceiveMoney;

            // сохраняем транзакцию на диск
            transactionService.ProceedRentalPayment(e.ReceiveMoney);

            // обновляем  прогресс бар
            view.UpdateProgressBar(e.ReceiveMoney);

            if (totalReceiveMoney >= fullSumma)
            {
                banknoteAcceptor.StopWaitMoney();
                transactionService.EndRentalTransaction();
                view.ShowAlertTakeCheck();
            }
            inReceiveMoneyEventHandler = false;
        }
        #endregion
    }
}