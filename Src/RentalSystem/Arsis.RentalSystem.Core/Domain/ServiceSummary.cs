namespace Arsis.RentalSystem.Core.Domain
{
	public class ServiceSummary
	{
		#region Fields

		#endregion

		#region Constructors

		public ServiceSummary(string serviceName, decimal ammount) : this(serviceName, 1, ammount)
		{}

		public ServiceSummary(string serviceName, int quantity, decimal ammount)
		{
			ServiceName = serviceName;
			Quantity = quantity;
			Amount = ammount;
		}

		#endregion

		#region Properties

		public string ServiceName { get; set; }

		public int Quantity { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}