using System.Collections.Generic;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class RentalPlaceService : BaseService, IRentalPlaceService
	{
		#region Public Methods

		/// <summary>
		/// Gets the list of rental places.
		/// </summary>
		/// <returns>List of rental places.</returns>
		public IList<RentalPlace> GetRentalPlaces()
		{
			return Dal.GetRentalPlaces();
		}

		/// <summary>
		/// Checks the pay possibility.
		/// </summary>
		/// <param name="number">The place number.</param>
		/// <returns>Pay possibility.</returns>
		public bool CheckPayPossibility(string number)
		{
			bool payPossibility = Dal.CheckPayPossibility(number);
			if (!payPossibility)
			{
				return false;
			}

			RentalPlaceInformation placeInformation = Dal.GetRentalPlaceInfo(number);
			if (placeInformation == null)
			{
				//throw new RentalSystemException("Проверка возможности оплаты привела к ошибке");
				return false;
			}

			if (placeInformation.Price == 0)
			{
				throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
				                                              placeInformation.ServiceName));
			}
			List<PayDateInformation> payDateInformations = SQLHelper.GetPayDate(placeInformation.ContractNumber,
			                                                                    placeInformation.Number);
			return payDateInformations.Count > 0;
		}

		/// <summary>
		/// Gets the rental place info.
		/// </summary>
		/// <param name="placeNumber">The place number.</param>
		/// <returns>Information about selected rental place</returns>
		public RentalPlaceInformation GetRentalPlaceInfo(string placeNumber)
		{
			RentalPlaceInformation placeInformation = Dal.GetRentalPlaceInfo(placeNumber);
            if (placeInformation == null)
            {
                throw new RentalSystemException(string.Format("Не найдена информация для места '{0}'.", placeNumber));

            }

			if (placeInformation.Price == 0)
			{
				throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
				                                              placeInformation.ServiceName));
			}
			return placeInformation;
		}

		/// <summary>
		/// Gets the rental place.
		/// </summary>
		/// <param name="id">The place id.</param>
		/// <returns>Rental place.</returns>
		public RentalPlace GetRentalPlace(int id)
		{
			return Dal.GetRentalPlaceById(id);
		}

		#endregion
	}
}