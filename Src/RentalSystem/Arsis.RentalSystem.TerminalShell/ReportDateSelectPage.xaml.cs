using System.Windows;
using System.Windows.Navigation;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class ReportDateSelectPage
    {
        private readonly IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();

        public ReportDateSelectPage()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            fiscalRegister.PrintUnpaidRentalPlacesReport(datePicker.CurrentlySelectedDate);
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            userService.Logoff();
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }
    }
}