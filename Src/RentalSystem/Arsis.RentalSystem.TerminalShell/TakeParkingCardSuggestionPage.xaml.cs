using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Helpers;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class TakeParkingCardSuggestionPage : INotifyPropertyChanged
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

        public TakeParkingCardSuggestionPage()
        {
            InitializeComponent();
            Time = TIMEOUT_SECONDS;
            var timeBinding = new Binding("TimeStr") {Source = this, Mode = BindingMode.OneWay};
            lblRedirectionTimer.SetBinding(ContentControl.ContentProperty, timeBinding);
            clockTimer.Interval = new TimeSpan(0, 0, 0, 1);
            clockTimer.Tick += delegate
                                   {
                                       Time -= 1;
                                       if (time == 0)
                                       {
                                           clockTimer.Stop();

                                           Redirect();
                                       }
                                   };
            clockTimer.Start();
        }

        private void Redirect()
        {
            Action action = () =>
                                {
                                    try
                                    {
                                        bool redirectToTakeRecepieSuggestionPage = (bool) Application.Current.Properties[Constants.RedirectToTakeRecepieSuggestionPage];

                                        if (redirectToTakeRecepieSuggestionPage)
                                        {
                                            WpfPageHelper.RedirectPage(this, Constants.UriTakeRecepieSuggestionPage);
                                        }
                                        else
                                        {
                                            WpfPageHelper.RedirectPage(this, Constants.UriMainPage);
                                        }
                                    }
                                    catch (Exception exc)
                                    {
                                        exc.ToString();
                                    }
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
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