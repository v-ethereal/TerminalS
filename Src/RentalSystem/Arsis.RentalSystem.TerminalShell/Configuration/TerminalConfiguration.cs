using System.Configuration;

namespace Arsis.RentalSystem.TerminalShell.Configuration
{
    public class TerminalConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("rental", IsRequired = true)]
        public bool RentalServiceEnable
        {
            get { return (bool) this["rental"]; }
            set { this["rental"] = value; }
        }

        [ConfigurationProperty("other", IsRequired = true)]
        public bool OtherServiceEnable
        {
            get { return (bool) this["other"]; }
            set { this["other"] = value; }
        }

        [ConfigurationProperty("parking", IsRequired = true)]
        public bool ParkingServiceEnable
        {
            get { return (bool) this["parking"]; }
            set { this["parking"] = value; }
        }

        /// <summary>
        /// true - показывать ошибку сразу, false - показывать ошибку на admin странице
        /// </summary>
        [ConfigurationProperty("show.error", DefaultValue = true)]
        public bool ShowError
        {
            get { return (bool)this["show.error"]; }
            set { this["show.error"] = value; }
        }

    }
}