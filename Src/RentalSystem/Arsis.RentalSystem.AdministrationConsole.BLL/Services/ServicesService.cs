using System.Collections.Generic;
using System.Linq;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class ServicesService : BaseService, IServicesService
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

        #region IServicesService Implementation

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>List of services.</returns>
        public BindingListView<ServiceInformationExt> GetServices()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<ServiceInformationExt>(Dal.GetServiceInformations());
            }
            return null;
        }

        /// <summary>
        /// Insers the service record.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="isRental">if set to <c>true</c> [is rental].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isParkingWithoutTime">признак услуги парковка без учёта времени</param>
		/// <param name="isOtherServices">признак прочих услуг</param>
		/// <param name="usePlaceNumber">использовать номер места при оплате услуги или нет</param>
        /// <param name="picture">The picture.</param>
        /// <param name="oneSCode">Code for 1S export</param>
        /// <param name="isParkingPerHour">признак услуги почасовая порковка</param>
        /// <returns>The service record id.</returns>
        public int InsertServiceRecord(string name, string description, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime, bool isOtherServices, bool usePlaceNumber, byte[] picture, string oneSCode)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Service serviceRecord = new Service
                                            {
                                                Name = name,
                                                IsActive = isActive,
                                                IsRental = isRental,
												IsParkingPerHour = isParkingPerHour,
												IsParkingWithoutTime = isParkingWithoutTime,
												IsOther =  isOtherServices,
                                                UsePlaceNumber = usePlaceNumber,
                                                Description = description,
                                                Picture = picture,
                                                Service1SCode = PrepareOneSCode(oneSCode)
                                            };

            	Dal.InsertService(serviceRecord);

                return serviceRecord.Id;
            }
            return 0;
        }

        private static string PrepareOneSCode(string oneSCode)
        {
            if (oneSCode != null)
            {
                oneSCode = oneSCode.Trim();
                oneSCode = (oneSCode == string.Empty) ? null : oneSCode;
            }

            return oneSCode;
        }

        /// <summary>
        /// Updates the service record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="isRental">if set to <c>true</c> [is rental].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isParkingWithoutTime">признак услуги  - парковка без учёта времени</param>
		/// <param name="isParkingPerHour">признак услуги - почасовая парковка</param>
        /// <param name="isOtherServices">признак прочих услуг</param>
        /// <param name="usePlaceNumber">использовать номер места при оплате услуги или нет</param>
        /// <param name="picture">The picture.</param>
        /// <param name="oneSCode"></param>
        public void UpdateServiceRecord(int id, string name, string description, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime,  bool isOtherServices, bool usePlaceNumber, byte[] picture, string oneSCode)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Service serviceRecord = Dal.GetServiceById(id);
                serviceRecord.Name = name;
                serviceRecord.IsActive = isActive;
                serviceRecord.IsRental = isRental;
                serviceRecord.Description = description;
                serviceRecord.Service1SCode = PrepareOneSCode(oneSCode);
            	serviceRecord.IsParkingPerHour = isParkingPerHour;
            	serviceRecord.IsParkingWithoutTime = isParkingWithoutTime;
            	serviceRecord.IsOther = isOtherServices;
                serviceRecord.UsePlaceNumber = usePlaceNumber;
                if (picture != null)
                {
                    serviceRecord.Picture = picture;
                }

                Dal.InsertService(serviceRecord);
            }
        }

        /// <summary>
        /// Deletes the service record.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteServiceRecord(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Service serviceRecord = Dal.GetServiceById(id);
                if (serviceRecord.PriceLists.Count > 0 || serviceRecord.ServicePayments.Count > 0)
                {
                    throw new RentalSystemException();
                }

            	Dal.DeleteService(serviceRecord);
            }
        }

        /// <summary>
        /// Gets the service record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The service.</returns>
        public Service GetServiceRecord(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Service serviceRecord = Dal.GetServiceById(id);
                return serviceRecord;
            }
            return null;
        }

        public decimal GetServicePrice(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                decimal servicePrice = Dal.GetServicePrice(id);
                return servicePrice;
            }

            return 0;
        }

        /// <summary>
        /// Checks the service existance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Service existance flag.</returns>
        public bool CheckServiceExistance(string name)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.CheckServiceExistance(name);
            }
            return false;
        }

        /// <summary>
        /// Gets the rental services.
        /// </summary>
        /// <returns>List of rental services.</returns>
        public BindingListView<Service> GetRentalServices()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<Service>(Dal.GetRentalServices());
            }
            return null;
        }

        public IEnumerable<ServiceInformation> GetAllServices()
        {
            return Dal.GetAllServices().Select(item => new ServiceInformation(item.Id, item.Name, item.Description, 0));
        }

        #endregion
    }
}