using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface IRentalPlaceService
    {
        IList<RentalPlace> GetRentalPlaces();
        bool CheckPayPossibility(string number);
        RentalPlaceInformation GetRentalPlaceInfo(string placeNumber);
    }
}