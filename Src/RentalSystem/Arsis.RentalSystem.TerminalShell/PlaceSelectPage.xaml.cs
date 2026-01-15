using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using Arsis.RentalSystem.TerminalShell.Configuration;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class PlaceSelectPage
    {
        public PlaceSelectPage()
        {
            InitializeComponent();

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            TerminalConfiguration currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;

            if (currentTerminalConfig != null)
            {
                if (currentTerminalConfig.RentalServiceEnable && !currentTerminalConfig.OtherServiceEnable && !currentTerminalConfig.ParkingServiceEnable)
                {
                    btnCancel.Visibility = Visibility.Hidden;
                }
            }


            nKeyBoard.KeyPressed += delegate
                                        {
                                            if (lblWarnMessage != null)
                                            {
                                                lblWarnMessage.ClearValue(Page.ContentProperty);
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
            IRentalPlaceService rentalPlaceService = AppRuntime.Instance.Container.GetComponent<IRentalPlaceService>();
            
            if (rentalPlaceService.CheckPayPossibility(nKeyBoard.Value))
            {
                var rentalPlaceInfo = rentalPlaceService.GetRentalPlaceInfo(nKeyBoard.Value);

                Application.Current.Properties[Constants.ParameterRentalPlaceInformation] = rentalPlaceInfo;

                Helpers.WpfPageHelper.RedirectPage(this, Constants.UriRentalPayPage);
            }
            else
            {
                lblWarnMessage.Content = Constants.MessageCanPay;
            }
        }
    }
}