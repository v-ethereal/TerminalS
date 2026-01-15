using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class ServicePayLogRecord
	{
		#region Fields

		private string name;
		private string description;
		private DateTime date;
		private decimal rate;
		private decimal paidSum;
		private string terminal;
		private string statusMessage;
	    private string placeNumber;

		#endregion

		#region Properties

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public decimal Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public decimal PaidSum
		{
			get { return paidSum; }
			set { paidSum = value; }
		}

		public string Terminal
		{
			get { return terminal; }
			set { terminal = value; }
		}

		public string StatusMessage
		{
			get { return statusMessage; }
			set { statusMessage = value; }
		}

        public string PlaceNumber
        {
            get { return placeNumber; }
            set { placeNumber = value; }
        }
        
        #endregion

		#region Constructors

		public ServicePayLogRecord(string name, string description, decimal rate, decimal paidSum, DateTime date, string terminal, string statusMessage, string placeNumber)
		{
			this.name = name;
			this.description = description;
			this.date = date;
			this.rate = rate;
			this.paidSum = paidSum;
			this.terminal = terminal;
			this.statusMessage = statusMessage;
		    this.placeNumber = placeNumber;
		}
		#endregion

	}
}