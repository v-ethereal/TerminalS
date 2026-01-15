using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class RentalPayLogRecord
	{
		#region Fields

		private string rentalPlaceNumber;
		private string contractNumber;
		private DateTime date;
		private bool isPaid;
		private decimal rate;
		private decimal paidSum;
		private string terminal;
		private string statusMessage;

		#endregion

		#region Constructors

		public RentalPayLogRecord() { }

		public RentalPayLogRecord(string contractNumber, string rentalPlaceNumber, decimal rate, decimal paidSum, DateTime date, bool isPaid, string terminal, string statusMessage)
		{
			this.rentalPlaceNumber = rentalPlaceNumber;
			this.contractNumber = contractNumber;
			this.date = date;
			this.rate = rate;
			this.paidSum = paidSum;
			this.isPaid = isPaid;
			this.terminal = terminal;
			this.statusMessage = statusMessage;
		}

		public RentalPayLogRecord(string contractNumber, string rentalPlaceNumber, decimal rate, decimal paidSum, DateTime date, bool isPaid, string terminal)
		{
			this.rentalPlaceNumber = rentalPlaceNumber;
			this.contractNumber = contractNumber;
			this.date = date;
			this.rate = rate;
			this.paidSum = paidSum;
			this.isPaid = isPaid;
			this.terminal = terminal;
		}

		#endregion

		#region Properties

		public decimal PaidSum
		{
			get { return paidSum; }
			set { paidSum = value; }
		}

		public string RentalPlaceNumber
		{
			get { return rentalPlaceNumber; }
			set { rentalPlaceNumber = value; }
		}

		public string ContractNumber
		{
			get { return contractNumber; }
			set { contractNumber = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public bool IsPaid
		{
			get { return isPaid; }
			set { isPaid = value; }
		}

		public decimal Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public string Terminal
		{
			get { return terminal; }
			set { terminal = value; }
		}

		public string StatusMessage
		{
			get { return statusMessage; }
			set { statusMessage = value; }
		}

		#endregion
	}
}