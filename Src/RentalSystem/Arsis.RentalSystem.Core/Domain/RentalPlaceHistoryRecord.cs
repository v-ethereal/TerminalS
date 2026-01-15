using System;

namespace Arsis.RentalSystem.Core.Domain
{
	public class RentalPlaceHistoryRecord
	{
		#region Fields

		private string contractNumber;
		private string placeNumber;
		private DateTime? modificationDate;

		#endregion

		#region Properties

		public string ContractNumber
		{
			get { return contractNumber; }
			set { contractNumber = value; }
		}

		public string PlaceNumber
		{
			get { return placeNumber; }
			set { placeNumber = value; }
		}

		public DateTime? ModificationDate
		{
			get { return modificationDate; }
			set { modificationDate = value; }
		}

		#endregion

		#region Constructors

		public RentalPlaceHistoryRecord(string contractNumber, string placeNumber, DateTime? modificationDate)
		{
			this.contractNumber = contractNumber;
			this.placeNumber = placeNumber;
			this.modificationDate = modificationDate;
		}

		#endregion

	}
}