using System.Collections.Generic;

using TermClasses;

namespace Arsis.RentalSystem.Core.Domain
{
	public class RentalTransactionInformation
	{
		private List<DayRentalPaymentInfo> rentalPaymentInfos = new List<DayRentalPaymentInfo>();

		public List<DayRentalPaymentInfo> RentalPaymentInfos
		{
			get { return rentalPaymentInfos; }
			set { rentalPaymentInfos = value; }
		}

		public bool IsFeeRecordInserted { get; set; }

		public bool IsRecepiePrinted { get; set; }

		public string PlaceNumber { get; set; }

		public string ContractNumber { get; set; }

		public decimal TotalMoneyAmmount { get; set; }
	}
}