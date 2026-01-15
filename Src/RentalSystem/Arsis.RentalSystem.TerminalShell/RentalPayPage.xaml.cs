using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Threading;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.Helpers;
using Arsis.RentalSystem.TerminalShell.MVP.Presenter;
using Arsis.RentalSystem.TerminalShell.MVP.View;
using Application=System.Windows.Application;
using Binding=System.Windows.Data.Binding;

namespace Arsis.RentalSystem.TerminalShell
{
    public partial class RentalPayPage : IRentalPayView, INotifyPropertyChanged
    {
        #region Constructors
        public RentalPayPage()
        {
            InitializeComponent();

            Binding feeAmmountBinding = new Binding("FeeAmount") {Source = this, Mode = BindingMode.TwoWay};
            lblEntered.SetBinding(ContentControl.ContentProperty, feeAmmountBinding);

            Binding rateBinding = new Binding("Rate") {Source = this, Mode = BindingMode.TwoWay};
            lblRate.SetBinding(ContentControl.ContentProperty, rateBinding);

            new RentalPayPresenter(this);
        }
        #endregion

        #region handlers from GUI
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LoadedViewEvent != null)
            {
                LoadedViewEvent(this, EventArgs.Empty);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (ClosedViewEvent != null)
            {
                ClosedViewEvent(this, EventArgs.Empty);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (BackButtonEvent != null)
            {
                BackButtonEvent(this, new EventArgs());
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (FinishPayEvent != null)
            {
                FinishPayEvent(this, new EventArgs());
            }
        }

        #endregion

        #region Implementation of IRentalPayView

        #region properties

        public RentalPlaceInformation RentalPlaceInformation
        {
            get
            {
                return
                    Application.Current.Properties[Constants.ParameterRentalPlaceInformation] as RentalPlaceInformation;
            }
        }

        private int feeAmount;

        public int FeeAmount
        {
            get { return feeAmount; }
            set
            {
                if (feeAmount == 0 && value > 0)
                {
                    MethodInvoker methodInvoker = delegate
                                                      {
                                                          if (btnPay.Visibility == Visibility.Hidden)
                                                          {
                                                              btnPay.Visibility = Visibility.Visible;
                                                          }

                                                          if (btnCancel.Visibility == Visibility.Visible)
                                                          {
                                                              btnCancel.Visibility = Visibility.Hidden;
                                                          }
                                                      };

                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodInvoker);
                }

                feeAmount = value;
                OnPropertyChanged("FeeAmount");
            }
        }

        private int rate;

        public int Rate
        {
            get { return int.Parse(rate.ToString("F0")); }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        #endregion

        #region methods

        public void InitView(RentalPlaceInformation rentalPlaceInformation)
        {
            Action action = () =>
                                {
                                    lblContract.Content = rentalPlaceInformation.ContractNumber;
                                    lblRentalPropertyNumber.Content = rentalPlaceInformation.Number;

                                    progressBar.Initialize(rentalPlaceInformation.ContractNumber,rentalPlaceInformation.Number);
                                };

            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        
        public void ShowAlertTakeCheck()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriTakeRecepieSuggestionPage);
            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        public void ShowAttentionMessage(string[] messages)
        {
            Action action = ()=> tbInformation.Text = string.Join(Environment.NewLine, messages);
            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        public void UpdateProgressBar(int moneyAmmount)
        {
            Action action = ()=> progressBar.Update(moneyAmmount);
            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        public void RedirectOnParentPage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriMainPage);
            WpfPageHelper.ExecuteAction(Dispatcher, action);
        }

        public void DisablePayButton()
        {
            Action action = () =>
            {
                btnPay.Visibility = Visibility.Hidden;
            };

            if (Application.Current.Dispatcher.Thread == Thread.CurrentThread)
            {
                action.Invoke();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send, action);
            }
        }
        #endregion

        #region events
        public event EventHandler<EventArgs> FinishPayEvent;
        public event EventHandler<EventArgs> BackButtonEvent;
        #endregion

        #endregion

        #region Implementation of IView
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

        public event EventHandler LoadedViewEvent;
        public event EventHandler ClosedViewEvent;

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}