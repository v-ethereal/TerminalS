using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class PayLogRecord
	{
		#region Fields

		#endregion

		#region Constructors

		public PayLogRecord() {}

		public PayLogRecord(string contractNumber,
		                    string rentalPlaceNumber,
		                    decimal rate,
		                    decimal paidSum,
		                    DateTime date,
		                    bool isPaid)
		{
			RentalPlaceNumber = rentalPlaceNumber;
			ContractNumber = contractNumber;
			Date = date;
			Rate = rate;
			PaidSum = paidSum;
			IsPaid = isPaid;
		}

		#endregion

		#region Properties

		public decimal PaidSum { get; set; }

		public string RentalPlaceNumber { get; set; }

		public string ContractNumber { get; set; }

		public DateTime Date { get; set; }

		public bool IsPaid { get; set; }

		public decimal Rate { get; set; }

		#endregion
	}
}