namespace Arsis.RentalSystem.Core.Domain
{
	public class RentalPlaceInformation
	{
		#region Constructors

		public RentalPlaceInformation() { }

		public RentalPlaceInformation(string number, string contractNumber, string serviceName, decimal? price)
		{
			Number = number;
			ContractNumber = contractNumber;
			Price = price ?? 0;
			ServiceName = serviceName;
		}

		#endregion

		#region Fields

		#endregion

		#region Properties

		public string Number { get; set; }

		public string ContractNumber { get; set; }

		public decimal Price { get; set; }

		public string ServiceName { get; set; }

		#endregion
	}
}