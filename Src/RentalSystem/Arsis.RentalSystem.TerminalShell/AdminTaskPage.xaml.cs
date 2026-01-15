using System;
using System.Configuration;
using System.Windows;
using System.Windows.Navigation;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.Configuration;
using Arsis.RentalSystem.TerminalShell.Helpers;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class AdminTaskPage
    {
        private readonly IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private readonly ITransactionService transactionService = AppRuntime.Instance.Container.GetComponent<ITransactionService>();

        public AdminTaskPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            btnXReport.IsEnabled =
                btnZReport.IsEnabled =
                btnZeroReceipt.IsEnabled =
                RentalPayReportToday.IsEnabled =
                RentalPayReport.IsEnabled =
                btnCloseApp.IsEnabled = false;
            btnCloseApp.Visibility = Visibility.Hidden;

            var roles = userService.GetUserRoles(Application.Current.Properties[Constants.ParameterLogin].ToString());
            foreach (var role in roles)
            {
                if (role.Name == Roles.CommercialAdmin.ToString())
                {
                    RentalPayReportToday.IsEnabled =
                        RentalPayReport.IsEnabled = true;
                }
                if (role.Name == Roles.Casher.ToString())
                {
                    btnXReport.IsEnabled =
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
                btnImportCardAccounts.IsEnabled = currentTerminalConfig.ParkingServiceEnable;
            }

        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void btnXReport_Click(object sender, RoutedEventArgs e)
        {
            fiscalRegister.PrintXReport();
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void btnZReport_Click(object sender, RoutedEventArgs e)
        {
            fiscalRegister.PrintZReport();
            fiscalRegister.PrintShiftSummaryReport();
            transactionService.Initialize();
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void RentalPayReportToday_Click(object sender, RoutedEventArgs e)
        {
            fiscalRegister.PrintUnpaidRentalPlacesReport(DateTime.Now);
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void RentalPayReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriDateSelectPage);
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

        private void btnImportCardAccounts_Click(object sender, RoutedEventArgs e)
        {
            ICardReaderService cardReader = null;

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;
            if (currentTerminalConfig != null)
            {
                if (currentTerminalConfig.ParkingServiceEnable)
                {
                    cardReader = AppRuntime.Instance.Container.GetComponent<ICardReaderService>();
                }
            }


            if (cardReader != null)
            {
                //запомним признак чтения карты при попадании в ридер
                bool reeadCardOnPresent = cardReader.ReadCardOnPresent;
                do
                {
                    //отключим авто чтение карты при появлении в ридере
                    cardReader.ReadCardOnPresent = false;

                    //на всякий случай выбросим карту
                    cardReader.EjectCard();

                    MessageBox.Show("Вставьте мастер-карту с тарифом 'Оплачено (15 минут на выезд)'.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    try
                    {
                        cardReader.ImportTariff(CardReaderHelper.GetTariffIdArray()[0]);
                    }
                    catch (Exception ex)
                    {
                        cardReader.EjectCard();
                        MessageBox.Show("Ошибка импорта тарифа 'Оплачено (15 минут на выезд)'.\n" + ex.Message + "\n" + ex.InnerException == null ? "" : ex.InnerException.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    cardReader.EjectCard();

                    MessageBox.Show("Вставьте мастер-карту с тарифом 'Внешняя оплата на ParkTime'.", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    try
                    {
                        cardReader.ImportTariff(CardReaderHelper.GetTariffIdArray()[1]);
                    }
                    catch (Exception ex)
                    {
                        cardReader.EjectCard();
                        MessageBox.Show("Ошибка импорта тарифа 'Внешняя оплата на ParkTime'.\n" + ex.Message + "\n" + ex.InnerException == null ? "" : ex.InnerException.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    cardReader.EjectCard();

                } while (false);

                //восстановим признак чтения карты при попадании в ридер
                cardReader.ReadCardOnPresent = reeadCardOnPresent;
            }

            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }
    }
}