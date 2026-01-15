using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class TerminalInformation
	{
		#region Fields

		private int id;
		private string networkName;
		private string status;
		private DateTime? dateTime;
		private int? shiftNumber;
	    private decimal totalPaidSum;
		private decimal servicePaidSum;
	    private decimal rentalPaidSum;

	    #endregion

		#region Properties

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string NetworkName
		{
			get { return networkName; }
			set { networkName = value; }
		}

		public string Status
		{
			get { return status; }
			set { status = value; }
		}

		public DateTime? DateTime
		{
			get { return dateTime; }
			set { dateTime = value; }
		}

		public int? ShiftNumber
		{
			get { return shiftNumber; }
			set { shiftNumber = value; }
		}

	    public decimal RentalPaidSum
	    {
	        get { return rentalPaidSum; }
            set { rentalPaidSum = value; }
	    }

        public decimal ServicePaidSum
        {
            get { return servicePaidSum; }
            set { servicePaidSum = value; }
        }
        
        public decimal TotalPaidSum
	    {
            get { return totalPaidSum; }
            set { totalPaidSum = value; }
	    }

		#endregion

		#region Constructors

		public TerminalInformation(int id, string networkName, string status, DateTime? dateTime, int? shiftNumber, decimal? rentalPaidSum, decimal? servicePaidSum)
		{
			this.id = id;
			this.networkName = networkName;
			this.status = status;
			this.dateTime = dateTime;
			this.shiftNumber = shiftNumber;
            this.rentalPaidSum = rentalPaidSum ?? 0;
            this.servicePaidSum = servicePaidSum ?? 0;
		    totalPaidSum = this.rentalPaidSum + this.servicePaidSum;
        }

		#endregion
	}
}