using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class CashlessPayLogRecord
	{
		#region Fields

		private int id;
		private string contractNumber;
		private DateTime paidDateFrom;
		private DateTime paidDateTo;
		private DateTime controlDate;

		#endregion

		#region Properties

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string ContractNumber
		{
			get { return contractNumber; }
			set { contractNumber = value; }
		}

		public DateTime PaidDateFrom
		{
			get { return paidDateFrom; }
			set { paidDateFrom = value; }
		}

		public DateTime PaidDateTo
		{
			get { return paidDateTo; }
			set { paidDateTo = value; }
		}

		public DateTime ControlDate
		{
			get { return controlDate; }
			set { controlDate = value; }
		}

		#endregion

		#region Constructors

		public CashlessPayLogRecord(int id, string contractNumber, DateTime paidDateFrom, DateTime paidDateTo, DateTime controlDate)
		{
			this.id = id;
			this.contractNumber = contractNumber;
			this.paidDateFrom = paidDateFrom;
			this.paidDateTo = paidDateTo;
			this.controlDate = controlDate;
		}

		#endregion
	}
}