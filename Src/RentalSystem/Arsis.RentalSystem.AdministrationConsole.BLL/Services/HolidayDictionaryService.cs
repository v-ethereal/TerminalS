using System;
using System.Collections.Generic;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class HolidayDictionaryService : BaseService, IHolidayDictionaryService
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
        /// Adds the holiday record.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The holiday record id.</returns>
        public int AddHolidayRecord(DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                if (!Dal.CheckHolidayExistance(date))
                {
                    HolidayDictionary holidayRecord = new HolidayDictionary
                                                          {
                                                              Date = date.Date,
                                                              Description = string.Empty

                                                          };
					Dal.InsertHoliday(holidayRecord);

                    return holidayRecord.Id;
                }
            }
            return 0;
        }

        /// <summary>
        /// Deletes the holiday.
        /// </summary>
        /// <param name="date">The date.</param>
        public void DeleteHoliday(DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                HolidayDictionary entry = Dal.GetHoliday(date);
                if (entry != null)
                {
					Dal.InsertHoliday(entry);
                }
            }
        }

        /// <summary>
        /// Gets the holidays.
        /// </summary>
        /// <returns>List of holiday dates.</returns>
        public List<DateTime> GetHolidays()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                 || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                List<DateTime> holidays = Dal.GetHolidays();
                return holidays;
            }
            return null;
        }

        /// <summary>
        /// Gets the holiday dictionaries.
        /// </summary>
        /// <returns>List of HolidayDictionary.</returns>
        public BindingListView<HolidayDictionary> GetHolidayDictionaries()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<HolidayDictionary>(Dal.GetHolidayDictionaries());
            }
            return null;
        }

        /// <summary>
        /// Determines whether the specified date is holiday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is holiday; otherwise, <c>false</c>.
        /// </returns>
        public bool IsHoliday(DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.CheckHolidayExistance(date);
            }
            return false;
        }

        #endregion
    }
}