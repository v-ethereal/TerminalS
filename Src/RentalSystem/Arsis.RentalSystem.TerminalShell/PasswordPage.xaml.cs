using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class PasswordPage
    {
        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();

        public PasswordPage()
        {
            InitializeComponent();
            kbrdPassword.KeyPressed += delegate
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
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            bool canLogin = false;
            IList<Role> roles = userService.GetUserRoles(Application.Current.Properties[Constants.ParameterLogin].ToString());
            foreach (Role role in roles)
            {
                if (role.Name == Roles.CommercialAdmin.ToString() 
                    || role.Name == Roles.Casher.ToString() 
                    || role.Name == Roles.SystemAdmin.ToString())
                {
                    canLogin = true;
                    break;
                }
            }
            if (canLogin)
            {
                if (userService.Logon(Application.Current.Properties[Constants.ParameterLogin].ToString(), kbrdPassword.Value))
                {
                    if (navigationService != null)
                    {
                        bool isInDiagnosticMode = Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] is bool ? (bool)Application.Current.Properties[Constants.ParameterIsInDiagnosticMode] : false;
                        if (!isInDiagnosticMode)
                        {
                            navigationService.Navigate(Constants.UriAdminTaskPage);
                        }
                        else
                        {
                            navigationService.Navigate(Constants.UriInitializePage);
                        }
                    }
                }
                else
                {
                    lblInfo.Content = Constants.MessageLoginException;
                }
            }
            else
            {
                lblInfo.Content = Constants.MessageCanLoginException;
            }
        }
    }
}