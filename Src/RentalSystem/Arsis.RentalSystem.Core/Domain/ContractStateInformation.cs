using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class ContractStateInformation
	{
		#region Fields

		private string contractNumber;
		private DateTime contractDateFrom;
		private DateTime contractDateTo;
		private string placeNumber;
		private DateTime date;
		private bool isHoliday;
		private bool isPaid;
		private bool isPartialyPaid;

		#endregion

		#region Properties

		public string ContractNumber
		{
			get { return contractNumber; }
			set { contractNumber = value; }
		}

		public string PlaceNumber
		{
			get { return placeNumber; }
			set { placeNumber = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public bool IsHoliday
		{
			get { return isHoliday; }
			set { isHoliday = value; }
		}

		public bool IsPaid
		{
			get { return isPaid; }
			set { isPaid = value; }
		}

		public bool IsPartialyPaid
		{
			get { return isPartialyPaid; }
			set { isPartialyPaid = value; }
		}

		public DateTime ContractDateFrom
		{
			get { return contractDateFrom; }
			set { contractDateFrom = value; }
		}

		public DateTime ContractDateTo
		{
			get { return contractDateTo; }
			set { contractDateTo = value; }
		}

		#endregion

		#region Constructors

		public ContractStateInformation(string contractNumber, DateTime contractDateFrom, DateTime contractDateTo, string placeNumber, DateTime date, bool isHoliday, bool isPaid, bool isPartialyPaid)
		{
			this.contractNumber = contractNumber;
			this.contractDateFrom = contractDateFrom;
			this.contractDateTo = contractDateTo;
			this.placeNumber = placeNumber;
			this.date = date;
			this.isHoliday = isHoliday;
			this.isPaid = isPaid;
			this.isPartialyPaid = isPartialyPaid;
		}

		#endregion
	}
}