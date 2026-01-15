namespace Arsis.RentalSystem.Core.Domain
{
	public class Contractor
	{
		#region Fields

		private string client1SCode;
		private string clientName;
		private bool isJuridicalPerson;
		private string clientAddress;
		private string clientPostAddress;
		private string clientPhone;
		private string inn;
		private string passportSeries;
		private string passportNumber;
		private string passportOutletOrgan;
		private string passportOutletDate;

		#endregion

		#region Properties

		public string Client1SCode
		{
			get { return client1SCode; }
			set { client1SCode = value; }
		}

		public string ClientName
		{
			get { return clientName; }
			set { clientName = value; }
		}

		public bool IsJuridicalPerson
		{
			get { return isJuridicalPerson; }
			set { isJuridicalPerson = value; }
		}

		public string ClientAddress
		{
			get { return clientAddress; }
			set { clientAddress = value; }
		}

		public string ClientPostAddress
		{
			get { return clientPostAddress; }
			set { clientPostAddress = value; }
		}

		public string ClientPhone
		{
			get { return clientPhone; }
			set { clientPhone = value; }
		}

		public string INN
		{
			get { return inn; }
			set { inn = value; }
		}

		public string PassportSeries
		{
			get { return passportSeries; }
			set { passportSeries = value; }
		}

		public string PassportNumber
		{
			get { return passportNumber; }
			set { passportNumber = value; }
		}

		public string PassportOutletOrgan
		{
			get { return passportOutletOrgan; }
			set { passportOutletOrgan = value; }
		}

		public string PassportOutletDate
		{
			get { return passportOutletDate; }
			set { passportOutletDate = value; }
		}

		#endregion

		#region Constructors

		public Contractor(string client1SCode, string clientName, bool isJuridicalPerson, string clientAddress, string clientPostAddress, string clientPhone, string inn, string passportSeries, string passportNumber, string passportOutletOrgan, string passportOutletDate)
		{
			this.client1SCode = client1SCode;
			this.clientName = clientName;
			this.isJuridicalPerson = isJuridicalPerson;
			this.clientAddress = clientAddress;
			this.clientPostAddress = clientPostAddress;
			this.clientPhone = clientPhone;
			this.inn = inn;
			this.passportSeries = passportSeries;
			this.passportNumber = passportNumber;
			this.passportOutletOrgan = passportOutletOrgan;
			this.passportOutletDate = passportOutletDate;
		}

		#endregion

	}
}