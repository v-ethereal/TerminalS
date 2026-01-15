using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class RentalPlaceInformationExt
	{
		#region Constructors

		public RentalPlaceInformationExt(int id, string number, string contractNumber, string serviceName, decimal? rate, DateTime? dateTo)
		{
			this.id = id;
			this.number = number;
			this.contractNumber = contractNumber;
			this.rate = rate ?? 0;
			this.serviceName = serviceName;
			this.dateTo = dateTo;
		}

		#endregion

		#region Fields

		private int id;
		private string number;
		private string contractNumber;
		private decimal rate;
		private string serviceName;
		private DateTime? dateTo;

		#endregion

		#region Properties

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Number
		{
			get { return number; }
			set { number = value; }
		}

		public string ContractNumber
		{
			get { return contractNumber; }
			set { contractNumber = value; }
		}

		public decimal Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public string ServiceName
		{
			get { return serviceName; }
			set { serviceName = value; }
		}

		public DateTime? DateTo
		{
			get { return dateTo; }
			set { dateTo = value; }
		}

		#endregion
	}
}