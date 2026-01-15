using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class RentalFeeService : BaseService, IRentalFeeService
	{
		#region Public Methods

		/// <summary>
		/// Inserts the rental fee record.
		/// </summary>
		/// <param name="number">The place number.</param>
		/// <param name="fee">The fee ammount.</param>
		public void InsertRentalFeeRecord(string number, decimal fee)
		{
			var terminal = CurrentTerminal;
			//кэшируем инфу о терминале, иначе получаем два запроса на получение одного и того же
			RentalPayment rentalFee = new RentalPayment
			                          	{
			                          			Contract = Dal.GetContractByPlaceNumber(number),
			                          			ContractRentalPlace = Dal.GetContractRentalPlaceByPlaceNumber(number),
			                          			PaidSum = fee,
			                          			DateTime = DateTime.Now,
			                          			TerminalId = terminal.Id,
			                          			ShiftNumber = terminal.ShiftNumber,
			                          			Status = 1
			                          	};
			Dal.AddRentalPayment(rentalFee);
		}

		/// <summary>
		/// Gets the list of not paid rental places.
		/// </summary>
		/// <param name="date">The report date.</param>
		/// <returns>List of not paid rental places</returns>
		public List<PayLogRecord> GetNotPaidRentalFees(DateTime date)
		{
			DateTime fromDate = new DateTime(date.Year,
			                                 date.Month,
			                                 date.Day,
			                                 0,
			                                 0,
			                                 0);
			DateTime toDate = new DateTime(date.Year,
			                               date.Month,
			                               date.Day,
			                               23,
			                               59,
			                               59);
			return SQLHelper.GetNotPaidRentalFees(fromDate, toDate);
		}

		/// <summary>
		/// Gets the pay dates information.
		/// </summary>
		/// <param name="contractNumber">The contract number.</param>
		/// <param name="placeNumber">The place number.</param>
		/// <returns>List of dates to pay.</returns>
		public List<PayDateInformation> GetPayDates(string contractNumber, string placeNumber)
		{
			return SQLHelper.GetPayDate(contractNumber, placeNumber);
		}

		/// <summary>
		/// Inserts the service fee record.
		/// </summary>
		/// <param name="serviceId">The service id.</param>
		/// <param name="price">The price.</param>
		/// <param name="feeAmount">The fee ammount.</param>
		/// <param name="placeNumber">The place number.</param>
		public ServicePayment InsertServiceFeeRecord(int serviceId, decimal price, decimal feeAmount, string placeNumber)
		{
			var terminal = CurrentTerminal;

			var servicePayment = new ServicePayment
			                     	{
			                     			PaidSum = feeAmount,
			                     			Terminal = terminal,
			                     			Service = Dal.GetServiceById(serviceId),
			                     			Price = price,
			                     			DateTime = DateTime.Now,
			                     			ShiftNumber = terminal.ShiftNumber,
			                     			DailySummaryId = null,
                                            PlaceNumber = placeNumber
			                     	};

			Dal.InsertServicePayment(servicePayment);

		    return servicePayment;
		}

		/// <summary>
		/// Gets the place rate.
		/// </summary>
		/// <param name="serviceName">Name of the service.</param>
		/// <param name="date">The date.</param>
		/// <returns>Place rate.</returns>
		public decimal GetRate(string serviceName, DateTime date)
		{
			return Dal.GetRate(serviceName, date);
		}

		/// <summary>
		/// Determines whether passed date is first belong date for the specified place of contract.
		/// </summary>
		/// <param name="contractNumber">The contract number.</param>
		/// <param name="number">The place number.</param>
		/// <param name="date">The date.</param>
		/// <returns>
		/// 	<c>true</c> if it is first belong date for the specified place of contract; otherwise, <c>false</c>.
		/// </returns>
		public bool IsFirstBelongDate(string contractNumber, string number, DateTime date)
		{
			return Dal.IsPlacesFirstBelongDate(contractNumber, number, date);
		}

		/// <summary>
		/// Determines whether the specified date for the specified place of contract is holiday.
		/// </summary>
		/// <param name="contractNumber">The contract number.</param>
		/// <param name="number">The place number.</param>
		/// <param name="date">The date.</param>
		/// <returns>
		/// 	<c>true</c> if the specified date for place of contractis is holiday; otherwise, <c>false</c>.
		/// </returns>
		public bool IsHoliday(string contractNumber, string number, DateTime date)
		{
			return Dal.IsHoliday(date) || Dal.IsUnpayablePeriod(contractNumber, number, date);
		}

		public event EventHandler<RentalFeeServiceEventArgs> CreateFeeRecordEvent;

		#endregion
	}
}