using System.Windows;
using System.Windows.Navigation;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.UserControls;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LogonPage
    {
        public LogonPage()
        {
            InitializeComponent();
            kbrdLogin.KeyPressed += delegate(object sender, KeyPressedEventArgs e)
            {
                if (lblInfo != null)
                {
                    lblInfo.ClearValue(ContentProperty);
                }
            };
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
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

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(kbrdLogin.Value))
            {
                lblInfo.Content = Constants.MessageEmptyLogin;
            }
            else
            {
                NavigationService navigationService = NavigationService.GetNavigationService(this);
                Application.Current.Properties[Constants.ParameterLogin] = kbrdLogin.Value;
                if (navigationService != null)
                {
                    navigationService.Navigate(Constants.UriPasswordPage);
                }
            }
        }
    }
}