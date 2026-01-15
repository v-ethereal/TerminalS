using System.Configuration;

namespace Arsis.RentalSystem.TerminalShell.Configuration
{
    public class CardReaderConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("FullyPaidTariffId", IsRequired = true)]
        public int FullyPaidTariffId
        {
            get { return (int)this["FullyPaidTariffId"]; }
        }

        [ConfigurationProperty("ExternalPayTariffId", IsRequired = true)]
        public int ExternalPayTariffId
        {
            get { return (int)this["ExternalPayTariffId"]; }
        }

        [ConfigurationProperty("port", IsRequired = true)]
        public string Port
        {
            get
            {
                return (string) this["port"];
            }
        }
    }
}