using System;

namespace Arsis.RentalSystem.AdministrationConsole.Dialogs_GUI
{
    public class SimpleDateTimeItem
    {
        public SimpleDateTimeItem(DateTime dateValue)
        {
            DateValue = dateValue;
        }

        public DateTime DateValue { get; set; }
    }
}
