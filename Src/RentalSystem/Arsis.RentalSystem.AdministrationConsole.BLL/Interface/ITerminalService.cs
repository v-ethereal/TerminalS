using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface ITerminalService
    {
        BindingListView<TerminalInformation> GetTerminals();
    }
}