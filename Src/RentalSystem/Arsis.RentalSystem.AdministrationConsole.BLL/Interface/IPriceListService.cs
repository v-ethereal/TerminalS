using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

using System;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IPriceListService
    {
        BindingListView<PriceListRecord> GetPriceLists();
        PriceList GetPriceListRecord(int id);
        int AddPriceListRecord(int serviceId, decimal price, DateTime validFrom);
        void UpdatePriceListRecord(int priceListRecordId, int serviceId, decimal price, DateTime validFrom);
        void DeletePriceListRecord(int priceListRecordId);
    }
}