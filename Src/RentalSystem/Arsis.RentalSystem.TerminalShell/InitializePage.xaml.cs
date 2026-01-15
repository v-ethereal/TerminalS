using System;
using System.Configuration;
using System.Windows;
using System.Windows.Navigation;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.Configuration;
using Arsis.RentalSystem.TerminalShell.Helpers;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for InitializePage.xaml
    /// </summary>
    public partial class InitializePage
    {
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private readonly IBanknoteAcceptor banknoteAcceptor = AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();
        private readonly IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
        private readonly ITransactionService transactionService = AppRuntime.Instance.Container.GetComponent<ITransactionService>();
        private ICardReaderService cardReaderService;

        public InitializePage()
        {
            InitializeComponent();
            tblErrorMessage.Text = Application.Current.Properties[Constants.ParameterLastError].ToString();
            Init();
        }

        private void Init()
        {
            btnZReport.IsEnabled =
                btnZeroReceipt.IsEnabled =
                btnCloseApp.IsEnabled = false;
            btnCloseApp.Visibility = Visibility.Hidden;

            var roles = userService.GetUserRoles(Application.Current.Properties[Constants.ParameterLogin].ToString());
            foreach (var role in roles)
            {
                if (role.Name == Roles.Casher.ToString())
                {
                    btnZReport.IsEnabled =
                        btnZeroReceipt.IsEnabled = true;
                }
                if (role.Name == Roles.SystemAdmin.ToString())
                {
                    btnCloseApp.IsEnabled = true;
                    btnCloseApp.Visibility = Visibility.Visible;
                }
            }

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;
            if (currentTerminalConfig != null)
            {
                if (currentTerminalConfig.ParkingServiceEnable)
                {
                    cardReaderService = AppRuntime.Instance.Container.GetComponent<ICardReaderService>();
                }
            }

        }


        private void btnZReport_Click(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            try
            {
                fiscalRegister.PrintZReport();
                fiscalRegister.PrintShiftSummaryReport();
                transactionService.Initialize();

                //не работает переинициализация ридера, поэтому не будем ее выполнять, но если ридер еще не запущен, запустим его.
                //cardReaderService.Stop();
                if (cardReaderService != null && !cardReaderService.IsStarted)
                {
                    cardReaderService.Start(CardReaderHelper.GetPort());
                }
            }
            catch (ApplicationException ex)
            {
                tblErrorMessage.Text = CommonHelper.GetErrorMessage(ex);
                isError = true;
            }
            if (!isError)
            {
                tblErrorMessage.ClearValue(ContentProperty);
                Application.Current.Properties[Constants.ParameterLastError] = null;
                Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] = false;
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                if (navigationService != null)
                {
                    userService.Logoff();
                    navigationService.Navigate(Constants.UriMainPage);
                }
            }
        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                userService.Logoff();
                bool isInDiagnosticMode = Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] is bool ? (bool)Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] : false;
                if (!isInDiagnosticMode)
                {
                    navigationService.Navigate(Constants.UriMainPage);
                }
                else
                {
                    navigationService.Navigate(Constants.UriErrorPage);
                }
            }
        }

        private void btnReInitialize_Click(object sender, RoutedEventArgs e)
        {
            bool isError = false;
            try
            {
                fiscalRegister.Initialize();
                banknoteAcceptor.Initialize();
                transactionService.Initialize();

                //не работает переинициализация ридера, поэтому не будем ее выполнять, но если ридер еще не запущен, запустим его.
                //cardReaderService.Stop();
                if (cardReaderService != null && !cardReaderService.IsStarted)
                {
                    cardReaderService.Start(CardReaderHelper.GetPort());
                }
            }
            catch (ApplicationException ex)
            {
                tblErrorMessage.Text = CommonHelper.GetErrorMessage(ex);
                isError = true;
            }

            /* Проверим как работает переинициализация ридера
            try
            {
                cardReaderService.Stop();
                cardReaderService.Start(CardReaderHelper.GetPort());
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(GetType()).Error("Ошибка переинициализации ридера!!!!!!!!!!!!", ex);
                if(ex.InnerException != null)
                {
                    log4net.LogManager.GetLogger(GetType()).Error("Есть детализация ошибки!!!!!!!!!!!", ex.InnerException);
                }
            }*/

            if (!isError)
            {
                tblErrorMessage.ClearValue(ContentProperty);
                Application.Current.Properties[Constants.ParameterLastError] = null;
                Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] = false;
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                if (navigationService != null)
                {
                    userService.Logoff();
                    navigationService.Navigate(Constants.UriMainPage);
                }
            }
        }

        private void btnZeroReceipt_Click(object sender, RoutedEventArgs e)
        {
            fiscalRegister.PrintAdditionalServiceReceipt("Чек для открытия смены", 0, 0);
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
