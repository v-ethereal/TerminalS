using System;
using System.Windows;
using System.Windows.Forms;
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
    public partial class ParkingPerHourPayPage : IParkingPerHourView
    {
        public ParkingPerHourPayPage()
        {
            InitializeComponent();

            new ParkingPerHourPresenter(this);
        }



        #region IServicePayView

        public void ShowServiceInfo(ServiceInformation serviceInformation)
        {
            label_ServiceName.Content = serviceInformation.Name;
        }

        public void ShowAttentionMessage(string[] messages)
        {
            textBlock_Information.Text = string.Join(Environment.NewLine, messages);
        }

        public event EventHandler<EventArgs> FinishPayEvent;
        public event EventHandler<EventArgs> BackButtonEvent;

        public void SetMoneyAmount(int feeAmount, int needAmount)
        {
            MethodInvoker methodInvoker = delegate
                                              {
                                                  label_FeeMoney.Content = feeAmount.ToString("F0");
                                                  label_NeedMoney.Content = needAmount.ToString("F0");
                                              };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodInvoker);
        }

        public void UpdateGui()
        {
            MethodInvoker methodInvoker = delegate
                                              {
                                                  if (button_Pay.Visibility == Visibility.Hidden)
                                                  {
                                                      button_Pay.Visibility = Visibility.Visible;
                                                  }

                                                  if (button_Back.Visibility == Visibility.Visible)
                                                  {
                                                      button_Back.Visibility = Visibility.Hidden;
                                                  }
                                              };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodInvoker);
        }

        public void RedirectOnTakePage(bool redirectToTakeRecepieSuggestionPage)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.RedirectToTakeRecepieSuggestionPage] =
                                        redirectToTakeRecepieSuggestionPage;
                                    WpfPageHelper.RedirectPage(this, Constants.UriTakeParkingCardSuggestionPage);
                                };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectOnTakePage(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }


        public void RedirectOnParentPage()
        {
            MethodInvoker methodInvoker = () => WpfPageHelper.RedirectPage(this, Constants.UriMainPage);
            if (Dispatcher.CheckAccess())
            {
                methodInvoker();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodInvoker);
            }
        }

        public void DisablePayButton()
        {
            Action action = () =>
            {
                button_Pay.Visibility = Visibility.Hidden;
            };

            if (Application.Current.Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
            }
        }
        #endregion

        #region IParkingPerHourView

        public ParkingTicketInfo ParkingTicketInfo
        {
            get { return Application.Current.Properties[Constants.ParameterParkingTicketNumber] as ParkingTicketInfo; }
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

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
        }

        public void ShowAlertTakeCheck()
        {
            Action action = () =>
                                {
                                    new TakeDialogWindow("Пожалуйста, возьмите Ваш чек и выездной талон.", 3).ShowDialog();

                                    if (ShowAlertTakeCheckEvent != null)
                                    {
                                        ShowAlertTakeCheckEvent(this, EventArgs.Empty);
                                    }
                                };


            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
        }

        public event EventHandler ShowAlertTakeParkingCardEvent;
        public event EventHandler ShowAlertTakeCheckEvent;
        public event EventHandler LoadedViewEvent;
        public event EventHandler ClosedViewEvent;

        #endregion

        #region IView

        public void ShowMessage(string message)
        {
        }

        public void ShowErrorMessage(Exception err)
        {
            Action action = () =>
                                {
                                    Application.Current.Properties[Constants.ParameterLastError] = CommonHelper.GetErrorMessage(err);
                                    WpfPageHelper.RedirectPage(this, Constants.UriErrorPage);
                                };
            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        #endregion

        #region hadlers from GUI
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

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {
            if (BackButtonEvent != null)
            {
                BackButtonEvent(this, new EventArgs());
            }
        }

        private void button_Pay_Click(object sender, RoutedEventArgs e)
        {
            if (FinishPayEvent != null)
            {
                button_Pay.Visibility = Visibility.Hidden;
                FinishPayEvent(this, new EventArgs());
            }
        }
        #endregion
    }
}