using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using System.Windows.Threading;
using Arsis.RentalSystem.TerminalShell.BLL;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for TakeRecepieSuggestionPage.xaml
    /// </summary>
    public partial class TakeRecepieSuggestionPage : INotifyPropertyChanged
    {
        private const int TIMEOUT_SECONDS = 3;

        private int time;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DispatcherTimer clockTimer = new DispatcherTimer();

        public delegate void RedirectCallback();

        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
                OnPropertyChanged("TimeStr");
            }
        }

        public string TimeStr
        {
            get { return time + " сек."; }
        }

        public TakeRecepieSuggestionPage()
        {
            InitializeComponent();
            Time = TIMEOUT_SECONDS;
            var timeBinding = new Binding("TimeStr") { Source = this, Mode = BindingMode.OneWay };
            lblRedirectionTimer.SetBinding(ContentControl.ContentProperty, timeBinding);
            clockTimer.Interval = new TimeSpan(0, 0, 0, 1);
            clockTimer.Tick +=
                    delegate
                    { 
                        Time -= 1;
                        if (time == 0)
                        {
                            lock (this)
                            {
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new RedirectCallback(Redirect));
                            }

                            clockTimer.Stop();
                        }
                    };
            clockTimer.Start();
        }

        private void Redirect()
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            if (navigationService != null)
            {
                navigationService.Navigate(Constants.UriMainPage);
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
