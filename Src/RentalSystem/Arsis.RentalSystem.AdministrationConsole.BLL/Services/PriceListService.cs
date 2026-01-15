using System;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class PriceListService : BaseService, IPriceListService
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

        #region IPriceListService Implementation

        /// <summary>
        /// Gets the price lists.
        /// </summary>
        /// <returns>List of price list records.</returns>
        public BindingListView<PriceListRecord> GetPriceLists()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<PriceListRecord>(Dal.GetPriceListRecords());
            }
            return null;
        }

        /// <summary>
        /// Adds the price list record.
        /// </summary>
        /// <param name="serviceId">The service id.</param>
        /// <param name="price">The price.</param>
        /// <param name="validFrom">The valid from.</param>
        /// <returns>The price list record id.</returns>
        public int AddPriceListRecord(int serviceId, decimal price, DateTime validFrom)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                PriceList priceList = new PriceList
                                          {
                                              Service = Dal.GetServiceById(serviceId),
                                              Price = price,
                                              ValidFrom = validFrom.Date
                                          };

            	Dal.InsertPriceListRecord(priceList);

                return priceList.Id;
            }
            return 0;
        }

        /// <summary>
        /// Updates the price list record.
        /// </summary>
        /// <param name="priceListRecordId">The price list record id.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="price">The price of service.</param>
        /// <param name="validFrom">The valid from.</param>
        public void UpdatePriceListRecord(int priceListRecordId, int serviceId, decimal price, DateTime validFrom)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                PriceList priceList = Dal.GetPriceListById(priceListRecordId);
                priceList.Service = Dal.GetServiceById(serviceId);
                priceList.Price = price;
                priceList.ValidFrom = validFrom.Date;
                
				Dal.InsertPriceListRecord(priceList);
            }
        }

        /// <summary>
        /// Deletes the price list record.
        /// </summary>
        /// <param name="priceListRecordId">The price list record id.</param>
        public void DeletePriceListRecord(int priceListRecordId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                PriceList priceList = Dal.GetPriceListById(priceListRecordId);

//                if (priceList.ValidFrom.GetValueOrDefault().Date < DateTime.Now.Date)
//                {
//                	throw new RentalSystemException();
//                }

				Dal.DeletePriceList(priceList);
            }
        }

        /// <summary>
        /// Gets the price list record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The price list record.</returns>
        public PriceList GetPriceListRecord(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                PriceList priceList = Dal.GetPriceListById(id);
                return priceList;
            }
            return null;
        }

        #endregion
    }
}
