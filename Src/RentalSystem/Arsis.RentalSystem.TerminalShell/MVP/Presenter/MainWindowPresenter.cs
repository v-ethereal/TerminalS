using System;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.MVP.View;
using log4net.Config;

namespace Arsis.RentalSystem.TerminalShell.MVP.Presenter
{
    public class MainWindowPresenter
    {
        private readonly IMainWindowView view;
        private readonly ITerminalService terminalService;

        public MainWindowPresenter(IMainWindowView view)
        {
            this.view = view;

            AppRuntime.Instance.Initialize();

            XmlConfigurator.Configure();

            terminalService = AppRuntime.Instance.Container.GetComponent<ITerminalService>();

            var fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
            fiscalRegister.Initialize();

            var banknoteAcceptor = AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();
            banknoteAcceptor.Initialize();

            var transactionService = AppRuntime.Instance.Container.GetComponent<ITransactionService>();
            transactionService.Initialize();

            this.view.LoadedWindow += view_LoadedWindow;
            this.view.ClosedWindow += view_ClosedWindow;
        }

        void view_ClosedWindow(object sender, EventArgs e)
        {
            terminalService.Stop();
        }

        void view_LoadedWindow(object sender, EventArgs e)
        {
            terminalService.Start();
        }
    }
}
