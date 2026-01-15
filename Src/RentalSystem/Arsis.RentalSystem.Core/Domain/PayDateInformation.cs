using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class PayDateInformation
	{
		public DateTime Date { get; set; }

		public int Rate { get; set; }

		public bool IsPartialyPaid { get; set; }

		public int PaidAmount { get; set; }

		public PayDateInformation(DateTime date, int rate, bool isPartialyPaid, int paidAmmount)
		{
			PaidAmount = paidAmmount;
			Date = date;
			Rate = rate;
			IsPartialyPaid = isPartialyPaid;
		}
	}
}