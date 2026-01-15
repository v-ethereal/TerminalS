using System;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.MVP.View;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
	public class MainPresenter
	{
		private readonly IMainView view;

        private ICardReaderService cardReaderService;
        private bool onCardPresentEventHandlerAdded;

		public MainPresenter(IMainView view)
		{
			this.view = view;

			this.view.ParkingServiceButtonClickEvent += ViewParkingServiceButtonClickEvent;
			this.view.RentalServiceButtonClickEvent += ViewRentalServiceButtonClickEvent;
			this.view.OtherServiceButtonClickEvent += ViewOtherServiceButtonClickEvent;
			this.view.AdminLoginButtonClickEvent += ViewAdminLoginButtonClickEvent;
            this.view.LoadedViewEvent += view_LoadedViewEvent;
            this.view.ClosedViewEvent += view_ClosedViewEvent;
		}

        void view_LoadedViewEvent(object sender, EventArgs e)
        {
            if (view.ParkingEnable)
            {
                cardReaderService = AppRuntime.Instance.Container.GetComponent<ICardReaderService>();
                if (cardReaderService.IsCardPresent)
                {
                    cardReaderService_CardPresentEvent(this, EventArgs.Empty);
                }
                else
                {
                    cardReaderService.CardPresentEvent += cardReaderService_CardPresentEvent;
                    onCardPresentEventHandlerAdded = true;
                }
            }
        }

        void view_ClosedViewEvent(object sender, EventArgs e)
        {
            if (view.ParkingEnable && onCardPresentEventHandlerAdded)
            {
                cardReaderService.CardPresentEvent -= cardReaderService_CardPresentEvent;
            }
        }

        void cardReaderService_CardPresentEvent(object sender, EventArgs e)
        {
            view.RedirectToParkingServicePage();
        }

		void ViewAdminLoginButtonClickEvent(object sender, EventArgs e)
		{
			view.RedirectToAdminLoginPage();
		}

		void ViewOtherServiceButtonClickEvent(object sender, EventArgs e)
		{
			view.RedirectToOtherServicePage();
		}

		void ViewRentalServiceButtonClickEvent(object sender, EventArgs e)
		{
			view.RedirectToRentalServicePage();
		}

		private void ViewParkingServiceButtonClickEvent(object sender, EventArgs e)
		{
			view.ShowMessage("Вставьте парковочную карту в терминал...");
        }
	}
}