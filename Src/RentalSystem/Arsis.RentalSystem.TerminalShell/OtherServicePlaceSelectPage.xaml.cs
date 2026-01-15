using System.Configuration;
using System.Windows;
using System.Windows.Navigation;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Configuration;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class ServicePlaceSelectPage
    {
        public ServicePlaceSelectPage()
        {
            InitializeComponent();

			var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			TerminalConfiguration currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;


			if (currentTerminalConfig != null)
			{
				if (!currentTerminalConfig.RentalServiceEnable && currentTerminalConfig.OtherServiceEnable && !currentTerminalConfig.ParkingServiceEnable)
				{
					btnCancel.Visibility = Visibility.Hidden;
				}
			}


			nKeyBoard.KeyPressed += delegate
				{
					if (lblWarnMessage != null)
					{
						lblWarnMessage.ClearValue(ContentProperty);
					}
				};


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nKeyBoard.Value))
            {
                Application.Current.Properties[Constants.ParameterServicePlaceNumber] = null;
            }
            else
            {
                Application.Current.Properties[Constants.ParameterServicePlaceNumber] = int.Parse(nKeyBoard.Value);
            }
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriOtherServicePayPage);
            }
        }
    }
}