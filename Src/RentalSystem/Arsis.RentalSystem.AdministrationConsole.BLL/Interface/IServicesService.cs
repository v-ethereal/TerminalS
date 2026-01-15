using System.Collections.Generic;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IServicesService
    {
        BindingListView<ServiceInformationExt> GetServices();
        int InsertServiceRecord(string name, string description, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime, bool isOtherService, bool usePlaceNumber, byte[] picture, string oneSCode);
        void UpdateServiceRecord(int id, string name, string description, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime, bool isOtherService, bool usePlaceNumber, byte[] picture, string oneSCode);
        void DeleteServiceRecord(int id);
        Service GetServiceRecord(int id);
        decimal GetServicePrice(int id);
        bool CheckServiceExistance(string name);
        BindingListView<Service> GetRentalServices();
        IEnumerable<ServiceInformation> GetAllServices();
    }
}