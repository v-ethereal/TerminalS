using System;

using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IUnpayablePeriodsService
    {
        void AddPeriod(int contractId, int placeId, DateTime fromDate, DateTime toDate, string reason);
        void DeletePeriod(int id);
        BindingListView<ContractUnpayablePeriod> GetContractUnpayablePeriods(int contractId, int rentalPlaceId);
        bool CheckIntersection(int contractId, int rentalPlaceId, DateTime fromDate, DateTime toDate);
    }
}