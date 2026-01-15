using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Arsis.RentalSystem.TerminalShell.Helpers
{
    public abstract class WpfPageHelper
    {
        public static void RedirectPage(DependencyObject dependencyObject, Uri uriPage)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(dependencyObject);
            if (navigationService != null)
            {
                navigationService.Navigate(uriPage);
            }
        }

        /// <summary>
        /// "правильный запуск" action
        /// </summary>
        /// <param name="dispatcher">диспетчер</param>
        /// <param name="action">action</param>
        public static void ExecuteAction(Dispatcher dispatcher, Action action)
        {
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
            }
        }

        /// <summary>
        /// "правильный запуск" action
        /// </summary>
        /// <param name="dispatcher">диспетчер</param>
        /// <param name="action">action</param>
        /// <param name="priority">приоритет выполения</param>
        public static void ExecuteAction(Dispatcher dispatcher, Action action, DispatcherPriority priority)
        {
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(priority, action);
            }
        }

    }
}