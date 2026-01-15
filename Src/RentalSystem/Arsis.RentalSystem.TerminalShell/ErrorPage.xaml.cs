using System;
using System.Configuration;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Configuration;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage
    {
        private readonly DispatcherTimer clockTimer = new DispatcherTimer();

        public ErrorPage()
        {
            InitializeComponent();

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            TerminalConfiguration currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;

            if (currentTerminalConfig != null)
            {
                textBlockErrorMessage.Visibility = currentTerminalConfig.ShowError ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            }

            lblClock.Content = DateTime.Now.ToShortTimeString();
            clockTimer.Interval = new TimeSpan(0, 0, 0, 1);
            clockTimer.Tick += delegate { lblClock.Content = DateTime.Now.ToShortTimeString(); };
            clockTimer.Start();
        }

        private void btnAdminLogon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] = true;
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriLogonPage);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            textBlockErrorMessage.Text = Application.Current.Properties[Constants.ParameterLastError].ToString();
        }
    }
}