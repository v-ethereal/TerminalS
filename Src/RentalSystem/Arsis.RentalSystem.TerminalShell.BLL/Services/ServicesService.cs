using System.Collections.Generic;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
    public class ServicesService : BaseService, IServicesService
    {
        #region Public Methods

        /// <summary>
        /// Gets the list of available services.
        /// </summary>
        /// <returns>List of services.</returns>
        public IList<Service> GetServices()
        {
            return Dal.GetServices();
        }

        /// <summary>
        /// Gets the service information.
        /// </summary>
        /// <param name="serviceId">The service id.</param>
        /// <returns>Information about selected service.</returns>
        public ServiceInformation GetServiceInformation(int serviceId)
        {
            ServiceInformation serviceInformation = Dal.GetServiceInformation(serviceId);
            if (serviceInformation.Price == 0)
            {
                throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
                                                              serviceInformation.Name));
            }
            return serviceInformation;
        }

        /// <summary>
        /// Получить информацию об услуге парковка без учёта времени
        /// </summary>
        /// <returns>Информация об услуге</returns>
        public ServiceInformation GetServiceInformationAboutParkingWithoutTime()
        {
            var serviceInfo = Dal.GetServiceInformationAboutParkingWithoutTime();
            if (serviceInfo == null)
            {
                throw new RentalSystemException("Отсутствует услуга парковка без учёта времени");
            }

            return GetServiceInformation(serviceInfo.Id);
        }

        /// <summary>
        /// Получить информацию об услуге парковка почасовая
        /// </summary>
        /// <returns>Информация об услуге</returns>
        public ServiceInformation GetServiceInformationAboutParkingPerHour()
        {
            var serviceInfo = Dal.GetServiceInformationAboutParkingPerHour();

            if (serviceInfo == null)
            {
                throw new RentalSystemException("Отсутствует услуга парковка без учёта времени");
            }

            ServiceInformation serviceInformation = Dal.GetServiceInformation(serviceInfo.Id);
            if (serviceInformation.Price == 0)
            {
                throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
                                                              serviceInformation.Name));
            }
            return serviceInformation;
        }

        #endregion
    }
}