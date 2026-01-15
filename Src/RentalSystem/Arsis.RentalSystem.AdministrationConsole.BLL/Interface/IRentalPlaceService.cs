using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IRentalPlaceService
    {
        BindingListView<RentalPlaceInformationExt> GetRentalPlaces();
        int InsertRentalPlaceRecord(string number);
        void DeleteRentalPlaceRecord(int id);
        RentalPlace GetRentalPlace(int id);
        RentalPlace GetRentalPlaceByNumber(string number);
        bool CheckRentalPlaceExistance(string number);
    }
}