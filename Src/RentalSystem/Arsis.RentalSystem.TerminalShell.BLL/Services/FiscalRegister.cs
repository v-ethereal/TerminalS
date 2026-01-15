using System;
using System.Collections.Generic;
using System.Threading;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

using TermClasses;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class FiscalRegister : BaseService, IFiscalRegister
	{
		#region Fields

		private ITerminalFiscalRegister shtrihMiniFiscalRegister;
		private IRentalFeeService rentalFeeService;
		private IUserService userService;

		#endregion

		#region Properties

		public ITerminalFiscalRegister ShtrihMiniFiscalRegister
		{
			get { return shtrihMiniFiscalRegister; }
			set { shtrihMiniFiscalRegister = value; }
		}

		public IRentalFeeService RentalFeeService
		{
			get { return rentalFeeService; }
			set { rentalFeeService = value; }
		}

		public IUserService UserService
		{
			get { return userService; }
			set { userService = value; }
		}

		#endregion

		/// <summary>
		/// Prints the X report.
		/// </summary>
		public void PrintXReport()
		{
			if (userService.IsInRole(Roles.Casher.ToString()))
			{
				shtrihMiniFiscalRegister.PrintXReport();
				Thread.Sleep(5000);
				//shtrihMiniFiscalRegister.Initialize(); //asn commented 28.05.09
			}
			else
			{
				throw new ApplicationException(Constants.MessageAccessDenied);
			}
		}

		/// <summary>
		/// Prints the Z report.
		/// </summary>
		public void PrintZReport()
		{
			if (userService.IsInRole(Roles.Casher.ToString()))
			{
				shtrihMiniFiscalRegister.PrintZReport();
				Thread.Sleep(5000);
				//shtrihMiniFiscalRegister.Initialize(); //asn commented 28.05.09
				if (Dal.CheckTerminalExistance(Environment.MachineName))
				{
					Terminal terminal = Dal.GetTerminal(Environment.MachineName);
					terminal.ShiftNumber++;
					terminal.DateTime = DateTime.Now; //asn added 18.05.09
					Dal.UpdateTerminal(terminal);
				}
			}
			else
			{
				throw new ApplicationException(Constants.MessageAccessDenied);
			}
		}

		/// <summary>
		/// Initializes fiscal register.
		/// </summary>
		public void Initialize()
		{
			shtrihMiniFiscalRegister.Initialize();
		}

		/// <summary>
		/// Prints the additional service receipt.
		/// </summary>
		/// <param name="serviceName">Name of the service.</param>
		/// <param name="price">The price.</param>
		/// <param name="depositAmmount">The deposit ammount.</param>
		public void PrintAdditionalServiceReceipt(string serviceName, decimal price, decimal depositAmmount)
		{
			shtrihMiniFiscalRegister.PrintAdditionalServiceReceipt(serviceName, price, depositAmmount);
		}

		public void PrintAdditionalServiceReceiptEx(string serviceName,
		                                            decimal price,
		                                            decimal depositAmmount,
		                                            IList<string> infoItems)
        {

            shtrihMiniFiscalRegister.PrintAdditionalServiceReceiptEx(serviceName, price, depositAmmount, infoItems);
		}

		/// <summary>
		/// Prints the rental receipt.
		/// </summary>
		/// <param name="paymentsInfo">The payments info.</param>
		public void PrintRentalReceipt(List<DayRentalPaymentInfo> paymentsInfo)
		{
			if (paymentsInfo.Count != 0)
			{
				shtrihMiniFiscalRegister.PrintRentalReceipt(paymentsInfo);
			}
		}

		/// <summary>
		/// Prints the unpaid rental places report.
		/// </summary>
		/// <param name="controlDate">The control date.</param>
		public void PrintUnpaidRentalPlacesReport(DateTime controlDate)
		{
			if (userService.IsInRole(Roles.CommercialAdmin.ToString()))
			{
				List<int> unpaidPlaces = new List<int>();
				List<PayLogRecord> fees = rentalFeeService.GetNotPaidRentalFees(controlDate);
				foreach (PayLogRecord fee in fees)
				{
					unpaidPlaces.Add(Convert.ToInt32(fee.RentalPlaceNumber));
				}
				unpaidPlaces.Sort();
				List<string> sortedPlaces = new List<string>();
				foreach (int place in unpaidPlaces)
				{
					sortedPlaces.Add(place.ToString());
				}
				shtrihMiniFiscalRegister.PrintUnpaidRentalPlacesReport(controlDate, sortedPlaces);
			}
			else
			{
				throw new ApplicationException(Constants.MessageAccessDenied);
			}
		}

		/// <summary>
		/// Prints the shift summary report.
		/// </summary>
		public void PrintShiftSummaryReport()
		{
			if (userService.IsInRole(Roles.Casher.ToString()))
			{
				IList<ServiceShiftSummaryInfo> serviceShiftSummaryInfos = new List<ServiceShiftSummaryInfo>();

				List<ServiceSummary> serviceSummary =
						Dal.GetServiceSummary(
                            CurrentTerminal.ShiftNumber != null ? CurrentTerminal.ShiftNumber - 1 : CurrentTerminal.ShiftNumber, 
                            CurrentTerminal.Id);
				foreach (ServiceSummary summary in serviceSummary)
				{
					var item = new ServiceShiftSummaryInfo
					           	{
					           			ServiceName = summary.ServiceName,
					           			ServiceQuantity = summary.Quantity,
					           			ServicePaidTotal = summary.Amount
					           	};
					serviceShiftSummaryInfos.Add(item);
				}
				shtrihMiniFiscalRegister.PrintShiftSummaryReport(CurrentTerminal.NetworkName, serviceShiftSummaryInfos);
			}
			else
			{
				throw new ApplicationException(Constants.MessageAccessDenied);
			}
		}

		public void PrintParkingTicket(DateTime startDate, string barCode, decimal price, decimal penalty)
		{
			shtrihMiniFiscalRegister.PrintParkingToken(startDate, barCode, price, penalty);
		}

	    public void PrintParkingExitTicket(string cardNumber, DateTime startDate, DateTime finishTime, bool externalPayment, decimal paidSum)
	    {
            shtrihMiniFiscalRegister.PrintParkingExitTicket(cardNumber, startDate, finishTime, externalPayment, paidSum);
        }

	    public void PrintAccessCode(string accessCode)
		{
			shtrihMiniFiscalRegister.PrintAccessCode(accessCode);
		}
	}
}