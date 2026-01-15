namespace Arsis.RentalSystem.Core.Bll
{
	public interface IComponentContainer
	{
		T GetComponent<T>();
	}
}