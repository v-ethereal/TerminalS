using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class RentalPlaceService : BaseService, IRentalPlaceService
    {
        #region Fields

        private IUserService userService;

        #endregion

        #region Properties

        public IUserService UserService
        {
            get { return userService; }
            set { userService = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the rental places.
        /// </summary>
        /// <returns>List of rental places.</returns>
        public BindingListView<RentalPlaceInformationExt> GetRentalPlaces()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<RentalPlaceInformationExt>(Dal.GetRentalPlacesInformation());
            }
            return null;
        }

        /// <summary>
        /// Inserts the rental place record.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The rental place record id.</returns>
        public int InsertRentalPlaceRecord(string number)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                if (!Dal.CheckRentalPlaceExistance(number))
                {
                    RentalPlace rentalPlace = new RentalPlace {Number = number};
                	Dal.InsertRentalPlace(rentalPlace);

                    return rentalPlace.Id;
                }
                throw new RentalSystemException("Место с таким номером уже существует");
            }
            return 0;
        }

        /// <summary>
        /// Deletes the rental place record.
        /// </summary>
        /// <param name="id">The place id.</param>
        public void DeleteRentalPlaceRecord(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                RentalPlace rentalProperty = Dal.GetRentalPlaceById(id);
                if (rentalProperty.ContractRentalPlaces.Count > 0)
                {
                    throw new RentalSystemException();
                }

            	Dal.DeleteRentalPlace(rentalProperty);

            }
        }

        /// <summary>
        /// Gets the rental place.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The rental place.</returns>
        public RentalPlace GetRentalPlace(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                RentalPlace place = Dal.GetRentalPlaceById(id);
                return place;
            }
            return null;
        }

        /// <summary>
        /// Gets the rental place by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The rental place.</returns>
        public RentalPlace GetRentalPlaceByNumber(string number)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                RentalPlace place = Dal.GetRentalPlaceByNumber(number);
                return place;
            }
            return null;
        }

        /// <summary>
        /// Checks the rental place existance.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Place existance flag.</returns>
        public bool CheckRentalPlaceExistance(string number)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.CheckRentalPlaceExistance(number);
            }
            return false;
        }

        #endregion
    }
}