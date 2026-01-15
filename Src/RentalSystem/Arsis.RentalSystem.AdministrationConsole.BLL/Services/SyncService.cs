using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class SyncService : BaseService, ISyncService
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
        /// Launchs 1C data import process.
        /// </summary>
        public void ReplyScan()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                SQLHelper.ReplyScan();
            }
        }

        #endregion
    }
}
