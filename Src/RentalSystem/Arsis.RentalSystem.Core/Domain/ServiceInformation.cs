namespace Arsis.RentalSystem.Core.Domain
{
	public class ServiceInformation
	{
		#region Constructors

		public ServiceInformation(string name, string description, decimal? price)
		{
			Name = name;
			Description = description;
			Price = price ?? 0;
		}

        public ServiceInformation(int id, string name, string description, decimal? price) : this(name, description, price)
        {
            Id = id;
        }

        public ServiceInformation(int id, string name, string description, decimal? price, bool usePlaceNumber) : this(id, name, description, price)
        {
            UsePlaceNumber = usePlaceNumber;
        }

		#endregion

		#region Properties

		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

        public bool UsePlaceNumber { get; set; }

		#endregion

        public override string ToString()
        {
            return Name; 
        }
	}
}