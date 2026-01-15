using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class PriceListRecord
	{
		#region Constructors

		public PriceListRecord() {}

		public PriceListRecord(int id, string serviceName, decimal price, DateTime validThrough)
		{
			this.id = id;
			this.serviceName = serviceName;
			this.price = price;
			this.validThrough = validThrough;
		}

		#endregion

		#region Fields

		private int id;
		private string serviceName;
		private decimal price;
		private DateTime validThrough;

		#endregion

		#region Properties

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string ServiceName
		{
			get { return serviceName; }
			set { serviceName = value; }
		}

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		public DateTime ValidThrough
		{
			get { return validThrough; }
			set { validThrough = value; }
		}

		#endregion
	}
}