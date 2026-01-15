namespace Arsis.RentalSystem.Core.Bll
{
	public enum Roles
	{
		SystemAdmin, 
		Accountant, 
		CommercialAdmin, 
		Casher
	}

	public enum ContractState
	{
		All = 0,
		Active,
		Closed,
		Cashless,
	}

}