namespace Arsis.RentalSystem.Core.Domain
{
	public class ServiceTransactionInformation
	{
		public bool IsFeeRecordInserted { get; set; }

		public bool IsRecepiePrinted { get; set; }

		public string ServiceName { get; set; }

        public string PlaceNumber { get; set; }

		public decimal Price { get; set; }

		public decimal Fee { get; set; }

		public int ServiceId { get; set; }
	}
}