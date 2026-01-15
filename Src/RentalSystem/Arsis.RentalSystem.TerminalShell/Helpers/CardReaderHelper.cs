using System.Configuration;
using Arsis.RentalSystem.TerminalShell.Configuration;

namespace Arsis.RentalSystem.TerminalShell.Helpers
{
    public abstract class CardReaderHelper
    {
        private const string cardReaderConfiguration = "cardreader.configuration";

        public static int[] GetTariffIdArray()
        {

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CardReaderConfiguration config = configuration.GetSection(cardReaderConfiguration) as CardReaderConfiguration;

            if (config != null)
            {
                return new[]{config.FullyPaidTariffId, config.ExternalPayTariffId};
            }

            return null;
        }

        public static string GetPort()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CardReaderConfiguration config = configuration.GetSection(cardReaderConfiguration) as CardReaderConfiguration;

            if (config != null)
            {
                return config.Port;
            }

            return "COM1";
        }
    }
}