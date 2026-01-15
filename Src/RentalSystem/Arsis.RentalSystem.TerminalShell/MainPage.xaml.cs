using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Configuration;
using Arsis.RentalSystem.TerminalShell.Helpers;
using Arsis.RentalSystem.TerminalShell.MVP.Presenter;
using Arsis.RentalSystem.TerminalShell.MVP.View;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class MainPage : IMainView
    {
        private readonly DispatcherTimer timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1)};
        private readonly TerminalConfiguration currentTerminalConfig;

        public MainPage()
        {
            InitializeComponent();

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;

            if (currentTerminalConfig != null)
            {
                if (!currentTerminalConfig.RentalServiceEnable)
                {
                    gridWithButtons.RowDefinitions[1].Height = new GridLength(0);
                }

                if (!currentTerminalConfig.OtherServiceEnable)
                {
                    gridWithButtons.RowDefinitions[2].Height = new GridLength(0);
                }

                if (!currentTerminalConfig.ParkingServiceEnable)
                {
                    gridWithButtons.RowDefinitions[3].Height = new GridLength(0);
                }

                if (currentTerminalConfig.RentalServiceEnable && !currentTerminalConfig.OtherServiceEnable &&
                    !currentTerminalConfig.ParkingServiceEnable)
                {
                    RedirectToRentalServicePage();
                    return;
                }

                if (!currentTerminalConfig.RentalServiceEnable && currentTerminalConfig.OtherServiceEnable &&
                    !currentTerminalConfig.ParkingServiceEnable)
                {
                    RedirectToOtherServicePage();
                    return;
                }

                if (!currentTerminalConfig.RentalServiceEnable && !currentTerminalConfig.OtherServiceEnable && currentTerminalConfig.ParkingServiceEnable)
                {
                    gridWithButtons.RowDefinitions[3].Height = new GridLength(0);

                    labelMessage.Content = "Пожалуйста, вставьте Вашу парковочную карту.";
                    labelMessage.Foreground = Brushes.DarkBlue;
                    labelMessage.FontSize = 48;
                }

            }

            lblClock.Content = DateTime.Now.ToString("HH:mm");
            DispatcherTimer clockTimer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 2)};
            clockTimer.Tick += delegate { lblClock.Content = DateTime.Now.ToString("HH:mm"); };
            clockTimer.Start();

            timer.Tick += delegate
                              {
                                  labelMessage.Content = "";
                                  timer.Stop();
                              };

            new MainPresenter(this);
        }

        private void btnRentalPayment_Click(object sender, RoutedEventArgs e)
        {
            if (RentalServiceButtonClickEvent != null)
            {
                RentalServiceButtonClickEvent(this, new EventArgs());
            }
        }

        private void btnAdminLogon_Click(object sender, RoutedEventArgs e)
        {
            if (AdminLoginButtonClickEvent != null)
            {
                AdminLoginButtonClickEvent(this, new EventArgs());
            }
        }

        private void btnOther_Click(object sender, RoutedEventArgs e)
        {
            if (OtherServiceButtonClickEvent != null)
            {
                OtherServiceButtonClickEvent(this, new EventArgs());
            }
        }

        private void btnParking_Click(object sender, RoutedEventArgs e)
        {
            if (ParkingServiceButtonClickEvent != null)
            {
                ParkingServiceButtonClickEvent(this, new EventArgs());
            }
        }

        #region Implementation of IMainView
        public bool ParkingEnable
        {
            get
            {
                if (currentTerminalConfig == null)
                {
                    throw new ArgumentNullException();
                }

                return currentTerminalConfig.ParkingServiceEnable;
            }
        }

        public event EventHandler<EventArgs> ParkingServiceButtonClickEvent;
        public event EventHandler<EventArgs> RentalServiceButtonClickEvent;
        public event EventHandler<EventArgs> OtherServiceButtonClickEvent;
        public event EventHandler<EventArgs> AdminLoginButtonClickEvent;
        public event EventHandler LoadedViewEvent;
        public event EventHandler ClosedViewEvent;

        public void RedirectToParkingPerHourPayPage(ParkingTicketInfo parkingTicketInfo)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.ParameterParkingTicketNumber] =
                                        parkingTicketInfo;

                                    WpfPageHelper.RedirectPage(this, Constants.UriParkingPerHourPayPage);
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectToParkingServicePage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriParkingWithCardServicePage);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectToRentalServicePage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriPlaceSelectPage);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectToOtherServicePage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriOtherServicesPage);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectToAdminLoginPage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriLogonPage);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        #endregion

        #region Implementation of IView

        public void ShowMessage(string message)
        {
            Action action = () =>
                                {
                                    if (timer.IsEnabled) return;

                                    labelMessage.Content = message;
                                    labelMessage.Foreground = Brushes.Green;

                                    timer.Start();
                                };
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void ShowErrorMessage(Exception err)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.ParameterLastError] = CommonHelper.GetErrorMessage(err);
                                    WpfPageHelper.RedirectPage(this, Constants.UriErrorPage);
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        #endregion

        private void gridWithButtons_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            if (ClosedViewEvent != null)
            {
                ClosedViewEvent(this, EventArgs.Empty);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LoadedEvent != null)
            {
                LoadedViewEvent(this, EventArgs.Empty);
            }
        }
    }
}