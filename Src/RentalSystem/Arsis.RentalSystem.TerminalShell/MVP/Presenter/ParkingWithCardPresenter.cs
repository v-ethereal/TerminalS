using System;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.Helpers;
using Arsis.RentalSystem.TerminalShell.MVP.View;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
    public class ParkingWithCardPresenter
    {
        private readonly IParkingWithCardServiceView view;

        private ParkingTicketInfo parkingTicketInfo;

        private readonly IParkingService parkingService = AppRuntime.Instance.Container.GetComponent<IParkingService>();
        private readonly IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
        private readonly ICardReaderService cardReaderService = AppRuntime.Instance.Container.GetComponent<ICardReaderService>();

        public ParkingWithCardPresenter(IParkingWithCardServiceView view)
        {
            this.view = view;

            this.view.PayExternal += view_PayExternal;
            this.view.PayLocal += view_PayLocal;
            this.view.BackEvent += view_BackEvent;
            this.view.LoadedViewEvent += view_LoadedViewEvent;
        }


        private void view_LoadedViewEvent(object sender, EventArgs e)
        {
            if (!cardReaderService.IsCardPresent)
            {
                view.ShowErrorMessage(new Exception("Отсутствует парковочная карта."));
                return;
            }

            parkingTicketInfo =
                parkingService.GetParkingTicket(
                    CommonHelper.GetInternalPackedTicketId(cardReaderService.CardNumber.Value,
                                                           cardReaderService.EntranceDate.Value));

            if (parkingTicketInfo == null)
            {
                parkingTicketInfo = parkingService.CreateParkingTicket(cardReaderService.CardNumber.Value,
                                                                       cardReaderService.EntranceDate.Value);
            }

            view.ShowParkingTicketInfo(parkingTicketInfo);
        }

        private void view_BackEvent(object sender, EventArgs e)
        {
            cardReaderService.EjectCard();

            view.RedirectToTakeParkingCardSuggestionPage(false);
        }

        private void view_PayLocal(object sender, EventArgs e)
        {
            if (parkingTicketInfo.IsClose)
            {
                view.ShowMessage("Парковочная карта закрыта.");
                return;
            }
            view.RedirectToPayLocal(parkingTicketInfo);
        }

        private void view_PayExternal(object sender, EventArgs e)
        {
            if (parkingTicketInfo.IsClose)
            {
                view.ShowMessage("Парковочная карта закрыта.");
                return;
            }

            try
            {
                int[] tarrifIdArr = CardReaderHelper.GetTariffIdArray();

                cardReaderService.WriteTariff(false, tarrifIdArr[1]);

                parkingService.SetDateTo(parkingTicketInfo);


                cardReaderService.EjectCard();

                view.ShowAlertTakeParkingCardEvent += delegate
                                                          {
                                                              //печать выездного талона для оплаты на внешнем паркомате ParkTime
                                                              fiscalRegister.PrintParkingExitTicket(parkingTicketInfo.Number.ToString("X8"),
                                                                                                    parkingTicketInfo.DateFrom,
                                                                                                    parkingTicketInfo.DateTo, true, 0);
                                                              view.ShowAlertTakeCheck();
                                                          };

                view.ShowAlertTakeCheckEvent += delegate { view.RedirectBack(); };

                view.ShowAlertTakeParkingCard();
            }
            catch(Exception err)
            {
                view.ShowErrorMessage(err);
            }
        }
    }
}