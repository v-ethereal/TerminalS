using System;
using System.Threading;
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
using MessageBox=System.Windows.MessageBox;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for ServicePayPage.xaml
    /// </summary>
    public partial class OtherServicePayPage : IOtherServicePayView
    {
        #region Properties
        public int ServiceId
        {
            get
            {
                return int.Parse(Application.Current.Properties[Constants.ParameterServiceId].ToString());
            }
        }
        public string PlaceNumber
        {
            get
            {
                var placeNumber = Application.Current.Properties[Constants.ParameterServicePlaceNumber];
                return placeNumber != null ? placeNumber.ToString() : null;
            }
        }
        
        #endregion
        
        #region Constructors

        public OtherServicePayPage()
        {
            InitializeComponent();

            new OtherServicePayPresenter(this);
        }

        #endregion

        #region Private Methods
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (BackButtonEvent != null)
            {
                BackButtonEvent(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Implementation of IServicePayView

        public void ShowAttentionMessage(string[] messages)
        {
            tbInformation.Text = string.Join(Environment.NewLine, messages);
        }

        public event EventHandler<EventArgs> FinishPayEvent;
        public event EventHandler<EventArgs> BackButtonEvent;

        public void SetMoneyAmount(int feeAmount, int needAmount)
        {
            Action action = ()=>
            {
                lblEntered.Content = feeAmount.ToString("F0");
            };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void UpdateGui()
        {
            MethodInvoker methodInvoker = delegate
            {
                if (btnPay.Visibility != Visibility.Visible)
                {
                    btnPay.Visibility = Visibility.Visible;
                }
                if (btnCancel.Visibility != Visibility.Hidden)
                {
                    btnCancel.Visibility = Visibility.Hidden;
                }
            };

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, methodInvoker);
        }

        public void RedirectOnTakePage(bool redirectToTakeRecepieSuggestionPage)
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriTakeRecepieSuggestionPage);

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void RedirectOnTakePage(Action action)
        {
        }

        public void RedirectOnParentPage()
        {
            Action action = () => WpfPageHelper.RedirectPage(this, Constants.UriMainPage);

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }

        public void ShowServiceInfo(ServiceInformation serviceInformation)
        {
            lblService.Content = serviceInformation.Name;
            if (!string.IsNullOrEmpty(PlaceNumber))
            {
                lblService.Content = "Место №" + PlaceNumber;
            }
            lblDescription.Content = serviceInformation.Description;
            lblRate.Content = serviceInformation.Price.ToString("F0");
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

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);

        }

        public event EventHandler LoadedViewEvent;
        public event EventHandler ClosedViewEvent;

        #endregion

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

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите закончить оплату?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            if (FinishPayEvent != null)
            {
                FinishPayEvent(this, EventArgs.Empty);
            }
        }
    }
}
