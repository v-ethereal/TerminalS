using System;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class UnpayablePeriodsService : BaseService, IUnpayablePeriodsService
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

        #region IUnpayablePeriodsService Implementation

        /// <summary>
        /// Adds the unpayable period.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="placeId">The place id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="reason">The reason.</param>
        public void AddPeriod(int contractId, int placeId, DateTime fromDate, DateTime toDate, string reason)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                ContractUnpayablePeriod contractUnpayablePeriod = new ContractUnpayablePeriod
                                                                  	{
                                                                  			ContractRentalPlace =
                                                                  					Dal.GetContractRentalPlaceRecord(
                                                                  					contractId,
                                                                  					placeId),
                                                                  			BeginDate = fromDate.Date,
                                                                  			EndDate = toDate.Date,
                                                                  			Reason = reason
                                                                  	};
            	Dal.InsertContractUnpayablePeriod(contractUnpayablePeriod);

            	
            }
        }

        /// <summary>
        /// Deletes the period.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeletePeriod(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                ContractUnpayablePeriod contractUnpayablePeriod = Dal.GetContractUnpayablePeriod(id);
            	Dal.DeleteContractUnpayablePeriod(contractUnpayablePeriod);

            }
        }

        /// <summary>
        /// Gets the contract unpayable periods.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <returns>List of unpayable periods.</returns>
        public BindingListView<ContractUnpayablePeriod> GetContractUnpayablePeriods(int contractId, int rentalPlaceId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return
                    new BindingListView<ContractUnpayablePeriod>(Dal.GetContractUnpayablePeriods(contractId,
                                                                                                         rentalPlaceId));
            }
            return null;
        }

        /// <summary>
        /// Checks the intersection of periods.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Intersection flag.</returns>
        public bool CheckIntersection(int contractId, int rentalPlaceId, DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                fromDate = fromDate.Date;
                toDate = toDate.Date;
                
                return Dal.CheckIntersection(contractId, rentalPlaceId, fromDate, toDate);
            }
            return false;
        }

        #endregion
    }
}
