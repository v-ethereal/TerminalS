using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IHolidayDictionaryService
    {
        int AddHolidayRecord(DateTime date);
        void DeleteHoliday(DateTime date);
        List<DateTime> GetHolidays();
        BindingListView<HolidayDictionary> GetHolidayDictionaries();
        bool IsHoliday(DateTime date);
    }
}