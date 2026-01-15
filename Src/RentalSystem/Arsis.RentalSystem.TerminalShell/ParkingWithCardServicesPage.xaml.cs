using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Helpers;
using Arsis.RentalSystem.TerminalShell.MVP.Presenter;
using Arsis.RentalSystem.TerminalShell.MVP.View;
using Application=System.Windows.Application;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for OtherServicesPage.xaml
    /// </summary>
    public partial class ParkingWithCardServicesPage : IParkingWithCardServiceView
    {
        private readonly DispatcherTimer timer;

        public ParkingWithCardServicesPage()
        {
            InitializeComponent();

            timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1)};
            timer.Tick += delegate
                              {
                                  labelMessage.Visibility = Visibility.Hidden;
                                  timer.Stop();
                              };

            new ParkingWithCardPresenter(this);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (BackEvent != null)
            {
                BackEvent(sender, e);
            }
        }


        private void btnPayLocal_Click(object sender, RoutedEventArgs e)
        {
            if (PayLocal != null)
            {
                PayLocal(this, EventArgs.Empty);
            }
        }

        private void btnPayOnExternalTerminal_Click(object sender, RoutedEventArgs e)
        {
            if (PayExternal != null)
            {
                PayExternal(this, EventArgs.Empty);
            }
        }

        #region Implementation of IView

        public void ShowMessage(string message)
        {
            Action action = () =>
                                {
                                    labelMessage.Content = message;
                                    labelMessage.Foreground = Brushes.Green;
                                    labelMessage.Visibility = Visibility.Visible;

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

        #region Implementation of IParkingWithCardServiceView

        public event EventHandler BackEvent;
        public event EventHandler PayLocal;
        public event EventHandler PayExternal;
        public event EventHandler LoadedViewEvent;
        public event EventHandler ClosedViewEvent;

        public void RedirectToPayLocal(ParkingTicketInfo parkingTicketInfo)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.ParameterParkingTicketNumber] =
                                        parkingTicketInfo;
                                    WpfPageHelper.RedirectPage(this, Constants.UriParkingPerHourPayPage);
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectBack()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriMainPage);

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void ShowParkingTicketInfo(ParkingTicketInfo parkingTicketInfo)
        {
            Action action = () =>
                                {
                                    label_ParkingTicket.Content = parkingTicketInfo.Number.ToString("X8");
                                    label_DateFrom.Content = parkingTicketInfo.DateFrom.ToString("dd.MM.yy HH:mm");
                                    label_DateTo.Content = parkingTicketInfo.DateTo.ToString("dd.MM.yy HH:mm");
                                    label_TotalTime.Content = parkingTicketInfo.ParkingDuration;
                                    label_ServicePrice.Content = parkingTicketInfo.CostPerHour.ToString("F0");
                                    label_PaidSum.Content = parkingTicketInfo.EarlyPaidSum.ToString("F0");
                                    label_TotalSum.Content = parkingTicketInfo.TotalSum.ToString("F0");

                                    if (parkingTicketInfo.IsClose)
                                    {
                                        gridWithButtons.RowDefinitions[2].Height = new GridLength(0);
                                        gridWithButtons.RowDefinitions[3].Height = new GridLength(0);
                                        gridWithButtons.RowDefinitions[4].Height = new GridLength(0);

                                        labelMessage.Visibility = Visibility.Visible;
                                        labelMessage.FontSize = 48;
                                        labelMessage.Foreground = Brushes.DarkBlue;
                                        labelMessage.Content = "Парковочная карта закрыта.";
                                    }
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectToTakeParkingCardSuggestionPage(bool redirectToTakeRecepieSuggestionPage)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.RedirectToTakeRecepieSuggestionPage] =
                                        redirectToTakeRecepieSuggestionPage;
                                    WpfPageHelper.RedirectPage(this, Constants.UriTakeParkingCardSuggestionPage);
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void ShowAlertTakeParkingCard()
        {
            Action action = () =>
                                {
                                    new TakeDialogWindow("Пожалуйста, возьмите Вашу парковочную карту", 3).ShowDialog();

                                    if (ShowAlertTakeParkingCardEvent != null)
                                    {
                                        ShowAlertTakeParkingCardEvent(this, EventArgs.Empty);
                                    }
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void ShowAlertTakeCheck()
        {
            Action action = () =>
                                {
                                    new TakeDialogWindow("Пожалуйста, возьмите Ваш выездной талон", 3).ShowDialog();

                                    if (ShowAlertTakeCheckEvent != null)
                                    {
                                        ShowAlertTakeCheckEvent(this, EventArgs.Empty);
                                    }
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public event EventHandler ShowAlertTakeParkingCardEvent;
        public event EventHandler ShowAlertTakeCheckEvent;

        #endregion

        private void btnEjectCard_Click(object sender, RoutedEventArgs e)
        {
            if (BackEvent != null)
            {
                BackEvent(sender, e);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (ClosedViewEvent != null)
            {
                ClosedViewEvent(this, EventArgs.Empty);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LoadedViewEvent != null)
            {
                LoadedViewEvent(this, EventArgs.Empty);
            }
        }
    }
}