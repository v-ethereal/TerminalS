using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL.Services;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL
{
    public static class Constants
	{
		#region Constants

		private const string LOGIN_EXCEPTION = "Message.LoginException";
        private const string CAN_LOGIN_EXCEPTION = "Message.CanLoginException";
        private const string ACCESS_DENIED = "Message.AccessDenied";
        private const string CAN_PAY_EXCEPTION = "Message.CanPayException";
        private const string PAY_INFORMATION = "Message.PayInformation";
        private const string EMPTY_LOGIN = "Message.EmptyLogin";

        #endregion

        #region Attributes

        private static volatile string messageEmptyLogin;
        private static readonly object messageEmptyLoginSyncRoot = new Object();

        private static volatile string messageLoginException;
        private static readonly object messagesLoginExceptionSyncRoot = new Object();

        private static volatile string messageCanLoginException;
        private static readonly object messageCanLoginExceptionSyncRoot = new Object();

        private static volatile string messageAccessDenied;
        private static readonly object messageAccessDeniedSyncRoot = new Object();

        private static volatile string messageCanPay;
        private static readonly object messageCanPayExceptionSyncRoot = new Object();

        private static volatile string[] messagePayInformation;
        private static readonly object messagePayInformationSyncRoot = new Object();

        private static readonly CustomizationDataService customizationDataService = new CustomizationDataService();

        #endregion

        #region Properties

        public static string MessageEmptyLogin
        {
            get
            {
                if (messageEmptyLogin == null)
                {
                    lock (messageEmptyLoginSyncRoot)
                    {
                        if (messageEmptyLogin == null)
                        {
                            if (customizationDataService.CheckDataExistance(EMPTY_LOGIN))
                            {
                                messageEmptyLogin = customizationDataService.GetData(EMPTY_LOGIN);
                            }
                            else
                            {
                                messageEmptyLogin = "Введите логин";
                            }
                        }
                    }
                }
                return messageEmptyLogin;
            }
        }

        public static string MessageLoginException
        {
            get
            {
                if (messageLoginException == null)
                {
                    lock (messagesLoginExceptionSyncRoot)
                    {
                        if (messageLoginException == null)
                        {
                            if (customizationDataService.CheckDataExistance(LOGIN_EXCEPTION))
                            {
                                messageLoginException = customizationDataService.GetData(LOGIN_EXCEPTION);
                            }
                            else
                            {
                                messageLoginException = "Неверный логин/пароль";
                            }
                        }
                    }
                }
                return messageLoginException;
            }
        }

        public static string MessageCanLoginException
        {
            get
            {
                if (messageCanLoginException == null)
                {
                    lock (messageCanLoginExceptionSyncRoot)
                    {
                        if (messageCanLoginException == null)
                        {
                            if (customizationDataService.CheckDataExistance(CAN_LOGIN_EXCEPTION))
                            {
                                messageCanLoginException = customizationDataService.GetData(CAN_LOGIN_EXCEPTION);
                            }
                            else
                            {
                                messageCanLoginException = "Вход в систему не возможен";
                            }
                        }
                    }
                }
                return messageCanLoginException;
            }
        }

        public static string MessageAccessDenied
        {
            get
            {
                if (messageAccessDenied == null)
                {
                    lock (messageAccessDeniedSyncRoot)
                    {
                        if (messageAccessDenied == null)
                        {
                            if (customizationDataService.CheckDataExistance(ACCESS_DENIED))
                            {
                                messageAccessDenied = customizationDataService.GetData(ACCESS_DENIED);
                            }
                            else
                            {
                                messageAccessDenied = "Доступ запрещен";
                            }
                        }
                    }
                }
                return messageAccessDenied;
            }
        }

        public static string MessageCanPay
        {
            get
            {
                if (messageCanPay == null)
                {
                    lock (messageCanPayExceptionSyncRoot)
                    {
                        if (messageCanPay == null)
                        {
                            if (customizationDataService.CheckDataExistance(CAN_PAY_EXCEPTION))
                            {
                                messageCanPay = customizationDataService.GetData(CAN_PAY_EXCEPTION);
                            }
                            else
                            {
                                messageCanPay = "Оплата за данное место невозможна";
                            }
                        }
                    }
                }
                return messageCanPay;
            }
        }

        public static string[] MessagePayInformation
        {
            get
            {
                if (messagePayInformation == null)
                {
                    lock (messagePayInformationSyncRoot)
                    {
                        if (messagePayInformation == null)
                        {
                            IBanknoteAcceptor banknoteAcceptor =
                                    AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();
                            IList<int> denominations = banknoteAcceptor.GetAcceptableBillDenominations();
                            List<string> nominals = new List<string>();
                            foreach (int denomination in denominations)
                            {
                                nominals.Add(denomination.ToString()); 
                            }
                            if (customizationDataService.CheckDataExistance(PAY_INFORMATION))
                            {
                                string data = customizationDataService.GetData(PAY_INFORMATION);
                                data = data.Replace("<%NOMINALS%>", string.Join(", ", nominals.ToArray()));
                                messagePayInformation = data.Split(';');
                            }
                            else
                            {
                                messagePayInformation = new[]{ "Возврат денег НЕ производится!",
                                                               "Автомат сдачу НЕ выдает!",
                                                                string.Format("Принимаются купюры достоинством {0} руб.", string.Join(", ",nominals.ToArray()))}; 
                            }
                        }
                    }
                }
                return messagePayInformation;
            }
        }

        #region Uri

        public static Uri UriMainPage
        {
            get
            {
                return new Uri("MainPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriPlaceSelectPage
        {
            get
            {
                return new Uri("PlaceSelectPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriPasswordPage
        {
            get
            {
                return new Uri("PasswordPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriAdminTaskPage
        {
            get
            {
                return new Uri("AdminTaskPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriRentalPayPage
        {
            get
            {
                return new Uri("RentalPayPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriLogonPage
        {
            get
            {
                return new Uri("LogonPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriOtherServicesPage
        {
            get
            {
                return new Uri("OtherServicesPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriDateSelectPage
        {
            get
            {
                return new Uri("ReportDateSelectPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriOtherServicePlaceSelectPage
        {
            get
            {
                return new Uri("OtherServicePlaceSelectPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriOtherServicePayPage
        {
            get
            {
                return new Uri("OtherServicePayPage.xaml", UriKind.Relative);
            }
        }

        public static Uri UriErrorPage
        {
            get
            {
                return new Uri("ErrorPage.xaml", UriKind.Relative);
            }
        }
        
        public static Uri UriInitializePage
        {
            get { return new Uri("InitializePage.xaml", UriKind.Relative); }
        }

        public static Uri UriTakeRecepieSuggestionPage
        {
            get { return new Uri("TakeRecepieSuggestionPage.xaml", UriKind.Relative); }
        }

        public static Uri UriTakeParkingCardSuggestionPage
        {
            get { return new Uri("TakeParkingCardSuggestionPage.xaml", UriKind.Relative); }
        }

		public static Uri UriParkingServicesPage
		{
			get { return new Uri("ParkingServicesPage.xaml", UriKind.Relative); }
		}

		public static Uri UriParkingTicketInputPage
		{
			get { return new Uri("ParkingTicketInputPage.xaml", UriKind.Relative); }
		}

		public static Uri UriParkingWithoutTimePayPage
		{
			get { return new Uri("ParkingWithoutTimePayPage.xaml", UriKind.Relative); }
		}

		public static Uri UriParkingPerHourPayPage
		{
			get { return new Uri("ParkingPerHourPayPage.xaml", UriKind.Relative); }
		}

        public static Uri UriParkingWithCardServicePage
        {
            get { return new Uri("ParkingWithCardServicesPage.xaml", UriKind.Relative); }
        }

        #endregion

        #region Parameters

        public static string ParameterLogin
        {
            get
            {
                return "Login";
            }
        }

        public static string ParameterServiceId
        {
            get
            {
                return "ServiceId";
            }
        }

        public static string ParameterRentalPlaceNumber
        {
            get
            {
                return "RentalPlaceNumber";
            }
        }

        public static string ParameterRentalPlaceInformation
        {
            get
            {
                return "RentalPlaceInformation";
            }
        }

        public static string ParameterServicePlaceNumber
        {
            get
            {
                return "ServicePlaceNumber";
            }
        }

        public static string ParameterIsInDiagnosticMode
        {
            get
            {
                return "RentalPlaceNumber";
            }
        }

        public static string ParameterLastError
        {
            get
            {
                return "LastErrorMessage";
            }
        }

		public static string ParameterParkingTicketNumber
		{
			get
			{
				return "ParkingTicket";
			}
		}

        public static string RedirectToTakeRecepieSuggestionPage
        {
            get
            {
                return "RedirectToTakeRecepieSuggestionPage";
            }
        }

		public static string ParameterUser
		{
			get
			{
				return "User";
			}
		}


        #endregion

        #endregion
    }
}
