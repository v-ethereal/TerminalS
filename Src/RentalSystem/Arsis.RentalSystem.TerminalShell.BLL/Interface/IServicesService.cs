using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface IServicesService
    {
        IList<Service> GetServices();
        ServiceInformation GetServiceInformation(int serviceId);
    	ServiceInformation GetServiceInformationAboutParkingWithoutTime();
    	ServiceInformation GetServiceInformationAboutParkingPerHour();
    }
}