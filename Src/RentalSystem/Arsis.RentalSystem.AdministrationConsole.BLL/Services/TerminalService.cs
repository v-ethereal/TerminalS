using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class TerminalService : BaseService, ITerminalService
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

        #region Public Methods

        /// <summary>
        /// Gets the terminals.
        /// </summary>
        /// <returns>List of terminals.</returns>
        public BindingListView<TerminalInformation> GetTerminals()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<TerminalInformation>(Dal.GetTerminals());
            }
            return null;
        }

        #endregion
    }
}