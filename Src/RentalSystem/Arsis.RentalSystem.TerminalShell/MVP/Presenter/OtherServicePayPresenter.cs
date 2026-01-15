using System;
using System.Threading;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.MVP.View;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
    public class OtherServicePayPresenter
    {
        private readonly IOtherServicePayView view;

        private readonly IServicesService servicesService = AppRuntime.Instance.Container.GetComponent<IServicesService>();
        private readonly IBanknoteAcceptor banknoteAcceptor = AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();
        private readonly ITransactionService transactionService = AppRuntime.Instance.Container.GetComponent<ITransactionService>();
        private int currentReceiveMoney;
        ServiceInformation serviceInformation;

        private bool inReceiveMoneyEventHandler;



        public OtherServicePayPresenter(IOtherServicePayView view)
        {
            this.view = view;

            this.view.LoadedViewEvent += ViewLoadedViewEvent;
            this.view.ClosedViewEvent += ViewClosedViewEvent;
            this.view.BackButtonEvent += ViewBackButtonEvent;
            this.view.FinishPayEvent += ViewFinishPayEvent;

            banknoteAcceptor.ReceiveMoneyEvent += BanknoteAcceptorReceiveMoneyEvent;
        }

        void ViewFinishPayEvent(object sender, EventArgs e)
        {
            if (currentReceiveMoney == 0 || inReceiveMoneyEventHandler)
            {
                return;
            }

            view.DisablePayButton();

            banknoteAcceptor.StopWaitMoney();
            transactionService.EndServiceTransaction();
            view.RedirectOnTakePage(true);
        }

        void BanknoteAcceptorReceiveMoneyEvent(object sender, BanknoteAcceptorEventArgs e)
        {
            
            if (e.ReceiveMoney == 0)
            {
                return;
            }

            inReceiveMoneyEventHandler = true;

            if (currentReceiveMoney == 0)
            {
                view.UpdateGui();
            }

            currentReceiveMoney += e.ReceiveMoney;

            view.SetMoneyAmount(currentReceiveMoney, 0);

            transactionService.ProceedServicePayment(serviceInformation.Id, serviceInformation.Name, serviceInformation.Price, e.ReceiveMoney);

            if (currentReceiveMoney >= serviceInformation.Price)
            {
                banknoteAcceptor.StopWaitMoney();
                transactionService.EndServiceTransaction();
                view.RedirectOnTakePage(true);
            }
            inReceiveMoneyEventHandler = false;
        }

        void ViewBackButtonEvent(object sender, EventArgs e)
        {
            if (currentReceiveMoney > 0)
            {
                return;
            }
            
            view.RedirectOnParentPage();
        }

        void ViewClosedViewEvent(object sender, EventArgs e)
        {
            banknoteAcceptor.StopWaitMoney();
        }

        void ViewLoadedViewEvent(object sender, EventArgs e)
        {
            
            serviceInformation = servicesService.GetServiceInformation(view.ServiceId);

            if (serviceInformation != null)
            {
                view.ShowServiceInfo(serviceInformation);
            }
            else
            {
                view.ShowErrorMessage(new ArgumentNullException("Не найдена информация о сервисе с id = " + view.ServiceId));
            }

            view.ShowAttentionMessage(Constants.MessagePayInformation);

            view.SetMoneyAmount(0, 0);

            transactionService.BeginServiceTransaction(view.PlaceNumber);

            banknoteAcceptor.StartWaitMoney();
        }

    }
}
