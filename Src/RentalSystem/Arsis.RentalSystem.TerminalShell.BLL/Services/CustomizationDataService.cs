using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
    class CustomizationDataService : BaseService
    {

        /// <summary>
        /// Gets the customization data string from DB.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Customization data string.</returns>
        public string GetData(string key)
        {
			return Dal.GetData(key);
        }

        /// <summary>
        /// Checks the customization data string existance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Flag</returns>
        public bool CheckDataExistance(string key)
        {
			return Dal.CheckDataExistance(key);
        }
    }
}
