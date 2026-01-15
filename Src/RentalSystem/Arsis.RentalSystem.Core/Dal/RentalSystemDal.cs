using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.Core.Dal
{
    public class RentalSystemDal : IDisposable
    {
        private RentalSystemDataContext db;

        public RentalSystemDal()
        {
            db = new RentalSystemDataContext(SQLHelper.SqlConnectionString);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        #region Contract

        /// <summary>
        /// Gets the contract by place number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The contract.</returns>
        public Contract GetContractByPlaceNumber(string number)
        {
            return (
                       from contract in db.Contracts
                       join contractRentalPlaces in db.ContractRentalPlaces on contract.Id equals
                           contractRentalPlaces.ContractId
                       join rentalPlace in db.RentalPlaces on contractRentalPlaces.RentalPlaceId equals
                           rentalPlace.Id
                       where rentalPlace.Number == number
                             && contractRentalPlaces.DateFrom <= DateTime.Now.Date
                             && contractRentalPlaces.DateTo >= DateTime.Now.Date
                       select contract).FirstOrDefault();
        }

        /// <summary>
        /// Gets the contract rental place by place number.
        /// </summary>
        /// <param name="number">The place number.</param>
        /// <returns>The ContractRentalPlace.</returns>
        public ContractRentalPlace GetContractRentalPlaceByPlaceNumber(string number)
        {
            return (
                       from contract in db.Contracts
                       join contractRentalPlaces in db.ContractRentalPlaces on contract.Id equals
                           contractRentalPlaces.ContractId
                       join rentalPlace in db.RentalPlaces on contractRentalPlaces.RentalPlaceId equals
                           rentalPlace.Id
                       where rentalPlace.Number == number
                             && contractRentalPlaces.DateFrom <= DateTime.Now.Date
                             && contractRentalPlaces.DateTo >= DateTime.Now.Date
                       select contractRentalPlaces).FirstOrDefault();
        }

        #endregion

        #region customizationData

        /// <summary>
        /// Gets the customization data string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Customization data string.</returns>
        public string GetData(string key)
        {
            return (from customizationData in db.CustomizationDatas
                    where customizationData.Key == key
                    select customizationData.Value).FirstOrDefault();
        }

        /// <summary>
        /// Checks the customization data string existance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Customization data existance flag.</returns>
        public bool CheckDataExistance(string key)
        {
            return (from customizationData in db.CustomizationDatas
                    where customizationData.Key == key
                    select customizationData.Value).Count() > 0;
        }

        #endregion

        #region user

        /// <summary>
        /// Checks the user existance.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>User existance flag.</returns>
        public bool CheckActiveUserExistance(string login)
        {
            return (from user in db.Users
                    where user.Login == login
                          && user.IsActive
                    select user).Count() > 0;
        }

        /// <summary>
        /// Gets the user by login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>The user.</returns>
        public User GetActivUserByLogin(string login)
        {
            return (from user in db.Users
                    where user.Login == login
                          && user.IsActive
                    select user).FirstOrDefault();
        }

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>List of user roles.</returns>
        public List<Role> GetActiveUserRoles(string login)
        {
            return (from role in db.Roles
                    join userRole in db.UserRoles on role.Id equals userRole.RoleId
                    where userRole.User.Login == login
                          && userRole.User.IsActive
                    select role).ToList();
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="roleId">The role id.</param>
        /// <returns>The UserRole.</returns>
        public UserRole GetActiveUserRole(int userId, int roleId)
        {
            return (from userRole in db.UserRoles
                    where userRole.UserId == userId
                          && userRole.RoleId == roleId
                          && userRole.User.IsActive
                    select userRole).FirstOrDefault();
        }

        public User GetUserByAccessCode(string code)
        {
            return (from user in db.Users
                    where user.AccessCode == code && user.IsActive
                    select user).FirstOrDefault();
        }

        /// <summary>
        /// Checks the user existance.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>Existance flag.</returns>
        public bool CheckUserExistance(string login)
        {
            return (from user in db.Users
                    where user.Login == login
                    select user).Count() > 0;
        }

        /// <summary>
        /// Gets the user by login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>The user.</returns>
        public User GetUserByLogin(string login)
        {
            return (from user in db.Users
                    where user.Login == login
                    select user).FirstOrDefault();
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="roleId">The role id.</param>
        /// <returns>The UserRole.</returns>
        public UserRole GetUserRole(int userId, int roleId)
        {
            return (from userRole in db.UserRoles
                    where userRole.UserId == userId
                          && userRole.RoleId == roleId
                    select userRole).FirstOrDefault();
        }

        /// <summary>
        /// Check's availibility for user delete
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsUserAvailableForDelete(int userId)
        {
            return ((from ch in db.ContractHistories
                     where ch.UserId == userId
                     select ch).Count()
                    +
                    (from c in db.Contracts
                     where c.ChUserId == userId
                           || c.CrUserId == userId
                     select c).Count()) == 0;
        }

        #endregion

        #region parking

        /// <summary>
        /// ¬ыдать внешний номер паркововочного талона
        /// </summary>
        /// <returns>номер талона</returns>
        public int GetParkingTicketNumber()
        {
            DateTime now = DateTime.Now;

            DateTime begin = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime end = begin.AddDays(1);

            return db.Parkings.Count(parkingItem => begin <= parkingItem.DateFrom && parkingItem.DateFrom < end);
        }

        /// <summary>
        /// ѕолучить цену парковки за 1 час
        /// </summary>
        /// <returns>цена за 1 час</returns>
        public int GetParkingPerHourPrice()
        {
            DateTime now = DateTime.Now;
            DateTime onlyDateNow = new DateTime(now.Year, now.Month, now.Day);

            var priceItem =
                db.PriceLists.Where(
                    priceListItem =>
                    priceListItem.ValidFrom.Value <= onlyDateNow && priceListItem.Service.IsParkingPerHour).
                    OrderByDescending(priceListItem => priceListItem.ValidFrom).FirstOrDefault();
            return priceItem != null ? (int) priceItem.Price : 0;
        }

        /// <summary>
        /// ѕолучить ценц парковки при утере талона
        /// </summary>
        /// <returns>цена парковки при утере</returns>
        public int GetParkingWithoutTimePrice()
        {
            DateTime now = DateTime.Now;
            DateTime onlyDateNow = new DateTime(now.Year, now.Month, now.Day);

            var priceItem =
                db.PriceLists.Where(
                    priceListItem =>
                    priceListItem.ValidFrom.Value <= onlyDateNow && priceListItem.Service.IsParkingWithoutTime).
                    OrderByDescending(priceListItem => priceListItem.ValidFrom).FirstOrDefault();
            return priceItem != null ? (int) priceItem.Price : 0;
        }

        /// <summary>
        /// —оздать парковочный талон
        /// </summary>
        /// <param name="number">номер внешний</param>
        /// <param name="dateFrom">дата заезда</param>
        /// <param name="isLoss">признак утери true - парковоный талон по утери, false - нормальный вариант</param>
        /// <param name="pricePerHour">цена парковки за 1 час</param>
        /// <param name="priceWithoutTime">цена парковки при утери талона</param>
        /// <param name="internalId">внутренний номер талона</param>
        /// <param name="userId">креатор</param>
        /// <returns></returns>
        public Parking CreateParking(int number,
                                     DateTime dateFrom,
                                     bool isLoss,
                                     int pricePerHour,
                                     int priceWithoutTime,
                                     string internalId,
                                     int? userId)
        {
            Parking parking = new Parking
                                  {
                                      Number = number,
                                      DateFrom = dateFrom,
                                      IsLoss = isLoss,
                                      CostPerHour = pricePerHour,
                                      CostWithoutTime = priceWithoutTime,
                                      InternalId = internalId,
                                      UserId = userId
                                  };
            db.Parkings.InsertOnSubmit(parking);
            db.SubmitChanges();

            return parking;
        }

        /// <summary>
        /// —в€зать платЄж и парковку
        /// </summary>
        /// <param name="parkingInfo"></param>
        /// <param name="servicePayment"></param>
        public void BindParkingServicePayment(ParkingTicketInfo parkingInfo, ServicePayment servicePayment)
        {
            var parking = GetParking(parkingInfo.Id);

            parking.InternalId = parkingInfo.InternalId;
            parking.ParkingServicePayments.Add(new ParkingServicePayment
                                                   {
                                                       ParkingId = parkingInfo.Id,
                                                       ServicePaymentsId = servicePayment.Id
                                                   });
            db.SubmitChanges();
        }

        /// <summary>
        /// ѕолучить макс кол-во часов парковки тарифицируемых по часовому тарифу
        /// </summary>
        /// <returns>часы</returns>
        public int GetTariffParkingHours()
        {
            const string parkingHoursKeyName = "ParkingHours";

            var glbSettingItem = db.GblSettings.SingleOrDefault(item => item.KeyName == parkingHoursKeyName);
            if (glbSettingItem.KeyName == null)
            {
                return 0;
            }

            int minParkingHours;
            if (!int.TryParse(glbSettingItem.KeyValue, out minParkingHours))
            {
                return 0;
            }

            return minParkingHours;
        }

        /// <summary>
        /// ѕолучить парковоный талон по внутреннему номеру
        /// </summary>
        /// <param name="internalId">внутренний номер </param>
        /// <returns>парковочный талон</returns>
        public Parking GetParking(string internalId)
        {
            return db.Parkings.SingleOrDefault(item => item.InternalId == internalId);
        }

        /// <summary>
        /// ѕолучить парковоный талон по id
        /// </summary>
        /// <param name="id">внутренний номер </param>
        /// <returns>парковочный талон</returns>
        public Parking GetParking(int id)
        {
            return db.Parkings.SingleOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// ѕроверка существовани€ парковочного талона 
        /// </summary>
        /// <param name="internalId">внутренний номер</param>
        /// <returns>true/false</returns>
        public bool ParkingExists(string internalId)
        {
            return db.Parkings.Any(item => item.InternalId == internalId);
        }

        /// <summary>
        /// ‘иксирование в Ѕƒ даты dыезда с разгрузочной парковки.
        /// ≈сли эта дата установлена, то парковочноа€ карта оплачена полностью
        /// </summary>
        /// <param name="info">инфо о парковке</param>
        public void SetParkingDateTo(ParkingTicketInfo info)
        {
            var parking = GetParking(info.Id);

            parking.DateTo = info.DateTo;

            db.SubmitChanges();
        }

        public void CloseParkingTicket(ParkingTicketInfo parkingInfo)
        {
            var parking = GetParking(parkingInfo.Id);

            parking.DateTo = parkingInfo.DateTo;
            parking.InternalId = parkingInfo.InternalId;

            db.SubmitChanges();
        }

        public Service GetServiceInformationAboutParkingWithoutTime()
        {
            /// добавлена  сортировка и возврат первого элемента
            /// на случай если добавим более одной парковочной услуги
            return db.Services.Where(item => item.IsParkingWithoutTime).OrderBy(item => item.Id).FirstOrDefault();
        }

        public Service GetServiceInformationAboutParkingPerHour()
        {
            /// добавлена  сортировка и возврат первого элемента
            /// на случай если добавим более одной парковочной услуги
            return db.Services.Where(item => item.IsParkingPerHour).OrderBy(item => item.Id).FirstOrDefault();
        }

        public IEnumerable<ParkingTicketInfo> GetParkingTickets(DateTime dateFrom, DateTime dateTo)
        {
            const string parkingHoursKeyName = "ParkingHours";

            var glbSettingItem = db.GblSettings.SingleOrDefault(item => item.KeyName == parkingHoursKeyName);
            int minParkingHours;
            if (glbSettingItem == null || !int.TryParse(glbSettingItem.KeyValue, out minParkingHours))
            {
                minParkingHours = 4;
            }

//				select 
//					P.*,
//					sum(SP.PaidSum) PaidSum
//				from 
//					Parking P
//						left join ParkingServicePayments PSP on P.ID = PSP.ParkingID
//						left join ServicePayments SP on PSP.ServicePaymentsID = SP.ID
//				where 
//					P.DateTo is not NULL and DateTo between CONVERT(datetime, '12/01/09', 1) and CONVERT(datetime, '01/01/10', 1)
//				group by 
//					P.Id, P.Number, P.DateFrom, P.DateTo, P.CostPerHour, P.CostWithoutTime, P.IsLoss, P.InternalId, P.UserId


            var temp = from p in db.Parkings
                       join psp in db.ParkingServicePayments on new {p.Id} equals new {Id = psp.ParkingId} into
                           psp_join
                       from psp in psp_join.DefaultIfEmpty()
                       join sp in db.ServicePayments on new {psp.ServicePaymentsId} equals
                           new {ServicePaymentsId = sp.Id} into sp_join
                       from sp in sp_join.DefaultIfEmpty()
                       where
                           p.DateTo != null &&
                           p.DateTo >= dateFrom &&
                           p.DateTo <= dateTo
                       group new {p, sp} by new
                                                {
                                                    p
                                                }
                       into g
                           select new {g.Key, PaidSum = (Decimal?) g.Sum(p => p.sp.PaidSum)}
                       into res
                           select
                           new ParkingTicketInfo(res.Key.p, minParkingHours,
                                                 res.PaidSum.HasValue ? res.PaidSum.Value : 0);

            return temp;
        }

        #endregion

        #region rental fee

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="date">The date.</param>
        /// <returns>The rate.</returns>
        public decimal GetRate(string serviceName, DateTime date)
        {
            return (from priceList in db.PriceLists
                    join service in db.Services on priceList.ServiceId equals service.Id
                    where
                        service.Name == serviceName
                        && priceList.ValidFrom <= DateTime.Now
                    orderby priceList.ValidFrom descending
                    select priceList.Price).FirstOrDefault();
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
            return (from holidayDictionary in db.HolidayDictionaries
                    where holidayDictionary.Date.Date == date.Date
                    select holidayDictionary).Count() > 0;
        }

        /// <summary>
        /// Determines whether the specified date for place of contract is unpayable period.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="number">The place number.</param>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if the specified date for place of contract is unpayable period; otherwise, <c>false</c>.
        /// </returns>
        public bool IsUnpayablePeriod(string contractNumber, string number, DateTime date)
        {
            return (from contractUnpayablePeriod in db.ContractUnpayablePeriods
                    join contractRentalPlace in db.ContractRentalPlaces on
                        contractUnpayablePeriod.ContractRentalPlacesId equals
                        contractRentalPlace.Id
                    where contractRentalPlace.RentalPlace.Number == number
                          && contractRentalPlace.Contract.ContractNumber == contractNumber
                          && contractUnpayablePeriod.BeginDate <= date.Date
                          && contractUnpayablePeriod.EndDate >= date.Date
                    select contractUnpayablePeriod).Count() > 0;
        }

        /// <summary>
        /// Determines whether the specified date for place of contract is places first belong date.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="number">The number.</param>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if the specified date for place of contract is places first belong date; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPlacesFirstBelongDate(string contractNumber, string number, DateTime date)
        {
            return (from contractRentalPlace in db.ContractRentalPlaces
                    where contractRentalPlace.RentalPlace.Number == number
                          && contractRentalPlace.Contract.ContractNumber == contractNumber
                          && contractRentalPlace.DateFrom.GetValueOrDefault().Date == date.Date
                    select contractRentalPlace).Count() > 0;
        }

        /// <summary>
        /// Gets the service summary.
        /// </summary>
        /// <param name="shiftNumber">The shift number.</param>
        /// <param name="terminalId">The terminal id.</param>
        /// <returns>Service payment summary.</returns>
        public List<ServiceSummary> GetServiceSummary(int? shiftNumber, int terminalId)
        {
            var result = new List<ServiceSummary>();
            result.AddRange((from servicePayment in db.ServicePayments
                             where servicePayment.ShiftNumber == shiftNumber && servicePayment.TerminalId == terminalId
                             select new ServiceSummary(servicePayment.Service.Name,
                                                       (from servicePayment1 in db.ServicePayments
                                                        where servicePayment1.ShiftNumber == shiftNumber
                                                              && servicePayment1.TerminalId == terminalId
                                                              && servicePayment1.ServiceId == servicePayment.ServiceId
                                                        select servicePayment1.PaidSum).Count(),
                                                       (from servicePayment1 in db.ServicePayments
                                                        where servicePayment1.ShiftNumber == shiftNumber
                                                              && servicePayment1.TerminalId == terminalId
                                                              && servicePayment1.ServiceId == servicePayment.ServiceId
                                                        select servicePayment1.PaidSum).Sum())).Distinct());
            result.AddRange((from rentalPayment in db.RentalPayments
                             where rentalPayment.ShiftNumber == shiftNumber && rentalPayment.TerminalId == terminalId
                             select new ServiceSummary(rentalPayment.Contract.Service.Name,
                                                       (from rentalPayment1 in db.RentalPayments
                                                        where rentalPayment1.ShiftNumber == shiftNumber
                                                              && rentalPayment1.TerminalId == terminalId
                                                              && rentalPayment1.Contract.Service.Id == rentalPayment.Contract.Service.Id
                                                        select rentalPayment1.PaidSum).Count(),
                                                       (from rentalPayment1 in db.RentalPayments
                                                        where rentalPayment1.ShiftNumber == shiftNumber
                                                              && rentalPayment1.TerminalId == terminalId
                                                              && rentalPayment1.Contract.Service.Id == rentalPayment.Contract.Service.Id
                                                        select rentalPayment1.PaidSum).Sum())).Distinct());
            return result;
        }

        public void AddRentalPayment(RentalPayment payment)
        {
            db.RentalPayments.InsertOnSubmit(payment);
            db.SubmitChanges();
        }

        #endregion

        #region rentalPlace

        /// <summary>
        /// Gets the rental place by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The rental place.</returns>
        public RentalPlace GetRentalPlaceById(int id)
        {
            return (from rentalPlace in db.RentalPlaces
                    where rentalPlace.Id == id
                    select rentalPlace).FirstOrDefault();
        }

        /// <summary>
        /// Checks the pay possibility.
        /// </summary>
        /// <param name="number">The place number.</param>
        /// <returns>Pay possibility flag</returns>
        public bool CheckPayPossibility(string number)
        {
            return (from rentalPlace in db.RentalPlaces
                    join contractRentalPlace in db.ContractRentalPlaces on rentalPlace.Id equals
                        contractRentalPlace.RentalPlaceId
                    join contract in db.Contracts on contractRentalPlace.ContractId equals contract.Id
                    where rentalPlace.Number == number
                          && contract.DissolutionDate == null
                          && contractRentalPlace.DateTo >= DateTime.Now.Date
                          && !contract.IsCashless
                    select rentalPlace).Count() > 0;
        }

        /// <summary>
        /// Gets the rental place by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public RentalPlace GetRentalPlaceByNumber(string number)
        {
            return (from rentalPlace in db.RentalPlaces
                    where rentalPlace.Number == number
                    select rentalPlace).FirstOrDefault();
        }

        /// <summary>
        /// Gets the rental place info.
        /// </summary>
        /// <param name="placeNumber">The place number.</param>
        /// <returns>Rental place information.</returns>
        public RentalPlaceInformation GetRentalPlaceInfo(string placeNumber)
        {
            return (from rentalPlace in db.RentalPlaces
                    join contractRentalPlace in db.ContractRentalPlaces on rentalPlace.Id equals
                        contractRentalPlace.RentalPlaceId
                    join contract in db.Contracts on contractRentalPlace.ContractId equals contract.Id
                    join service in db.Services on contract.RentalServiceId equals service.Id
                    where rentalPlace.Number == placeNumber
                          && contractRentalPlace.DateFrom <= DateTime.Now.Date
                          && contractRentalPlace.DateTo >= DateTime.Now.Date
                    select
                        new RentalPlaceInformation(rentalPlace.Number,
                                                   contract.ContractNumber,
                                                   service.Name,
                                                   (from priceList in db.PriceLists
                                                    where
                                                        priceList.ServiceId == service.Id
                                                        && priceList.ValidFrom <= DateTime.Now
                                                    orderby priceList.ValidFrom descending
                                                    select priceList.Price).FirstOrDefault())).
                FirstOrDefault();
        }

        public List<RentalPlace> GetRentalPlaces()
        {
            return db.RentalPlaces.ToList();
        }

        public List<RentalPlace> GetRentalPlacesByContractId(int id)
        {
            return (from rentalPlace in db.RentalPlaces
                    join contractRentalPlace in db.ContractRentalPlaces on rentalPlace.Id equals
                        contractRentalPlace.RentalPlaceId
                    where contractRentalPlace.ContractId == id
                          && contractRentalPlace.DateTo >= DateTime.Now
                    select rentalPlace).ToList();
        }

        public void InsertRentalPlace(RentalPlace place)
        {
            db.RentalPlaces.InsertOnSubmit(place);
            db.SubmitChanges();
        }

        #endregion

        #region role

        /// <summary>
        /// Gets the Role by the role name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The Role.</returns>
        public Role GetRoleByName(string name)
        {
            return (from role in db.Roles
                    where role.Name == name
                    select role).FirstOrDefault();
        }

        #endregion

        #region service

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>List of services</returns>
        public IEnumerable<Service> GetAllServices()
        {
            return (
                       from service in db.Services
                       where service.IsActive && !service.IsRental
                       select service).OrderBy(item => item.Name);
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>List of services</returns>
        public List<Service> GetServices()
        {
            return (from service in db.Services
                    where service.IsActive
                          && service.IsOther
                          && (from priceList in db.PriceLists
                              where
                                  priceList.ServiceId == service.Id
                                  && priceList.ValidFrom <= DateTime.Now
                              orderby priceList.ValidFrom descending
                              select priceList).Count() > 0
                    select service).ToList();
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>List of service information records.</returns>
        public List<ServiceInformationExt> GetServiceInformations()
        {
            return (from service in db.Services
                    select
                        new ServiceInformationExt(
                        service.Id,
                        service.Name,
                        service.IsRental,
                        service.IsActive,
                        service.IsParkingPerHour,
                        service.IsParkingWithoutTime,
                        service.IsOther,
                        service.Description,
                        service.Picture,
                        service.Service1SCode,
                        service.UsePlaceNumber,
                        (from priceList in db.PriceLists
                         where
                             priceList.ServiceId == service.Id
                             && priceList.ValidFrom <= DateTime.Now
                         orderby priceList.ValidFrom descending
                         select priceList.Price).FirstOrDefault())).ToList();
        }

        /// <summary>
        /// Gets the service information.
        /// </summary>
        /// <param name="serviceId">The service id.</param>
        /// <returns>The service information.</returns>
        public ServiceInformation GetServiceInformation(int serviceId)
        {
            return (from service in db.Services
                    where service.Id == serviceId
                    select
                        new ServiceInformation(service.Id,
                                               service.Name,
                                               service.Description,
                                               (from priceList in db.PriceLists
                                                where
                                                    priceList.ServiceId == serviceId
                                                    && priceList.ValidFrom <= DateTime.Now
                                                orderby priceList.ValidFrom descending
                                                select priceList.Price).FirstOrDefault(),
                                               service.UsePlaceNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the service by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The service.</returns>
        public Service GetServiceById(int id)
        {
            return (from service in db.Services
                    where service.Id == id
                    select service).FirstOrDefault();
        }

        public void InsertServicePayment(ServicePayment payment)
        {
            db.ServicePayments.InsertOnSubmit(payment);
            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        /// <summary>
        /// Checks the service existance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Existance flag.</returns>
        public bool CheckServiceExistance(string name)
        {
            return (from service in db.Services
                    where service.Name == name
                    select service).Count() > 0;
        }

        /// <summary>
        /// Gets the rental services.
        /// </summary>
        /// <returns>List of services.</returns>
        public List<Service> GetRentalServices()
        {
            return (from service in db.Services
                    where service.IsActive
                          && service.IsRental
                    select service).ToList();
        }

        /// <summary>
        /// Gets the service price.
        /// </summary>
        /// <param name="serviceId">The service id.</param>
        /// <returns>The price.</returns>
        public decimal GetServicePrice(int serviceId)
        {
            return (from priceList in db.PriceLists
                    where
                        priceList.ServiceId == serviceId
                        && priceList.ValidFrom <= DateTime.Now
                    orderby priceList.ValidFrom descending
                    select priceList.Price).FirstOrDefault();
        }

        #endregion

        #region terminal

        /// <summary>
        /// Gets the terminals.
        /// </summary>
        /// <returns>List of terminals.</returns>
        public List<TerminalInformation> GetTerminals()
        {
            return (from terminal in db.Terminals
                    select
                        new TerminalInformation(terminal.Id,
                                                terminal.NetworkName,
                                                terminal.Status,
                                                terminal.DateTime,
                                                terminal.ShiftNumber,
                                                (from rentalPayment in db.RentalPayments
                                                 where rentalPayment.TerminalId == terminal.Id
                                                       && rentalPayment.ShiftNumber == terminal.ShiftNumber
                                                 select rentalPayment.PaidSum).Sum(),
                                                (from servicePayment in db.ServicePayments
                                                 where servicePayment.TerminalId == terminal.Id
                                                       && servicePayment.ShiftNumber == terminal.ShiftNumber
                                                 select servicePayment.PaidSum).Sum())).ToList();
        }

        /// <summary>
        /// Gets the terminal.
        /// </summary>
        /// <param name="machineName">Name of the machine.</param>
        /// <returns>The terminal</returns>
        public Terminal GetTerminal(string machineName)
        {
            var res = (from terminal in db.Terminals
                       where terminal.NetworkName.Equals(machineName)
                       select terminal).FirstOrDefault();

            //Terminals.Context.Refresh(RefreshMode.OverwriteCurrentValues, res); //TODO: ¬лепил рефреш, чтобы гарантированно получать актуальную инфу, возможно это и не очень правильно, зато надежно. ASN.

            return res;
        }

        /// <summary>
        /// Checks the terminal existance.
        /// </summary>
        /// <param name="machineName">Name of the machine.</param>
        /// <returns>Terminal existance flag.</returns>
        public bool CheckTerminalExistance(string machineName)
        {
            return (from terminal in db.Terminals
                    where terminal.NetworkName.Equals(machineName)
                    select terminal).Count() > 0;
        }

        public void UpdateTerminal(Terminal terminal)
        {
            if (terminal.Id == 0)
            {
                db.Terminals.InsertOnSubmit(terminal);
            }

            db.SubmitChanges();
        }

        #endregion

        #region contracts

        /// <summary>
        /// Gets the contract by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The contract.</returns>
        public Contract GetContractById(int id)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.Id == id
                    select contract).FirstOrDefault();
        }

        /// <summary>
        /// Checks the contract existance.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Contract existance flag.</returns>
        public bool CheckContractExistance(string number)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.ContractNumber == number
                    select contract).Count() > 0;
        }

        /// <summary>
        /// Gets the contract by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The contract.</returns>
        public Contract GetContractByNumber(string number)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.ContractNumber == number
                    select contract).FirstOrDefault();
        }

        /// <summary>
        /// Gets the active contracts.
        /// </summary>
        /// <returns>List of contracts.</returns>
        public List<Contract> GetActiveContracts(DateTime fromDate, DateTime toDate)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.DissolutionDate == null
                    select contract).ToList();
        }

        /// <summary>
        /// Gets the contractors for filter.
        /// </summary>
        /// <returns>List of contractors.</returns>
        public List<string> GetContractorsFilter()
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    select contract.ClientName ?? string.Empty).Distinct().ToList();
        }

        /// <summary>
        /// Gets the contracts for filter.
        /// </summary>
        /// <returns>List of contracts.</returns>
        public List<string> GetContractsFilter()
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    select contract.ContractNumber).ToList();
        }

        /// <summary>
        /// Gets the closed contracts.
        /// </summary>
        /// <returns>List of closed contracts.</returns>
        public List<Contract> GetClosedContracts(DateTime fromDate, DateTime toDate)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.DissolutionDate != null
                    select contract).ToList();
        }

        /// <summary>
        /// Gets the contracts.
        /// </summary>
        /// <returns>List of contracts.</returns>
        public List<Contract> GetContracts(DateTime fromDate, DateTime toDate)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);

            return (from contract in db.Contracts
                    where (((contract.DateFrom >= fromDate) && (contract.DateFrom <= toDate))
                           || ((contract.DateFrom >= fromDate) && (contract.DateFrom <= toDate))
                           || ((fromDate >= contract.DateFrom) && (fromDate <= contract.DateTo))
                           || ((toDate >= contract.DateFrom) && (toDate <= contract.DateTo)))
                    select contract).ToList();
        }

        /// <summary>
        /// Gets the cashless contracts.
        /// </summary>
        /// <returns>List of cashless contracts.</returns>
        public List<Contract> GetCashlessContracts(DateTime fromDate, DateTime toDate)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.IsCashless
                    select contract).ToList();
        }

        /// <summary>
        /// Gets the cashless payment from date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns>The date.</returns>
        public DateTime GetCashlessPaymentFromDate(int contractId)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.IsCashless
                          && contract.Id == contractId
                    select contract.CashlessPaymentControlDate).FirstOrDefault().GetValueOrDefault();
        }

        /// <summary>
        /// Gets the first cashless payment date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns>The date.</returns>
        public DateTime GetFirstCashlessPaymentDate(int contractId)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where
                        contract.IsCashless && contract.Id == contractId
                    select contract.RentalCashlessPayments.Count > 0
                               ?
                                   (from rentalCashlessPayment in db.RentalCashlessPayments
                                    where rentalCashlessPayment.ContractId == contract.Id
                                    orderby rentalCashlessPayment.PaidDateFrom ascending
                                    select rentalCashlessPayment.PaidDateFrom).FirstOrDefault()
                               : contract.DateFrom).FirstOrDefault().GetValueOrDefault();
        }

        /// <summary>
        /// Gets the last cashless payment date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns>The date.</returns>
        public DateTime GetLastCashlessPaymentDate(int contractId)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            return (from contract in db.Contracts
                    where contract.IsCashless
                          && contract.Id == contractId
                    select contract.RentalCashlessPayments.Count > 0
                               ?
                                   (from rentalCashlessPayment in db.RentalCashlessPayments
                                    where rentalCashlessPayment.ContractId == contract.Id
                                    orderby rentalCashlessPayment.PaidDateTo descending
                                    select rentalCashlessPayment.PaidDateTo).FirstOrDefault()
                               : contract.DateTo).FirstOrDefault().GetValueOrDefault();
        }

        public DateTime[] GetLastCashlessPaymentDateIfExists(int contractId)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.Contracts);
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.RentalCashlessPayments);

            if (((from contract in db.Contracts
                  where contract.IsCashless && contract.Id == contractId
                  select contract.RentalCashlessPayments.Count).First()) > 0)
            {
                return (from rentalCashlessPayment in db.RentalCashlessPayments
                        where rentalCashlessPayment.ContractId == contractId
                        orderby rentalCashlessPayment.PaidDateTo descending
                        select new[] {rentalCashlessPayment.PaidDateFrom, rentalCashlessPayment.PaidDateTo}).
                    FirstOrDefault();
            }

            return null;
        }

        public void InsertContract(Contract contract)
        {
            db.Contracts.InsertOnSubmit(contract);
            db.SubmitChanges();
        }

        public void InsertContractHistory(ContractHistory history)
        {
            db.ContractHistories.InsertOnSubmit(history);
            db.SubmitChanges();
        }

        /// <summary>
        /// Gets the contract rental place from date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <returns>The date.</returns>
        public DateTime? GetContractRentalPlaceFromDate(int contractId, int rentalPlaceId)
        {
            return (from rentalPlace in db.RentalPlaces
                    join contractRentalPlace in db.ContractRentalPlaces on rentalPlace.Id equals
                        contractRentalPlace.RentalPlaceId
                    where contractRentalPlace.ContractId == contractId
                          && contractRentalPlace.DateTo >= DateTime.Now
                          && rentalPlace.Id == rentalPlaceId
                    select contractRentalPlace.DateFrom).FirstOrDefault();
        }

        /// <summary>
        /// Checks the adding place date intersection.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="placeId">The place id.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <returns>Intersection flag.</returns>
        public bool CheckAddingPlaceDateIntersection(int contractId, int placeId, DateTime dateFrom, DateTime dateTo)
        {
            return (from rentalPlace in db.RentalPlaces
                    join contractRentalPlace in db.ContractRentalPlaces on rentalPlace.Id equals
                        contractRentalPlace.RentalPlaceId
                    where contractRentalPlace.ContractId == contractId
                          && rentalPlace.Id == placeId
                          && ((contractRentalPlace.DateTo >= dateFrom
                               && contractRentalPlace.DateTo <= dateTo)
                              || (contractRentalPlace.DateFrom >= dateFrom
                                  && contractRentalPlace.DateFrom <= dateTo))
                    select contractRentalPlace.DateFrom).Count() > 0;
        }

        public void InsertContractRentalPlace(ContractRentalPlace place)
        {
            db.ContractRentalPlaces.InsertOnSubmit(place);
            db.SubmitChanges();
        }

        public List<ContractHistory> GetContractHistoryByContractId(int contractId)
        {
            return
                (
                    from contractHistory in db.ContractHistories
                    where contractHistory.ContractId == contractId
                    orderby contractHistory.Date
                    select contractHistory
                ).ToList();
        }

        #endregion

        #region RentalPlaces

        /// <summary>
        /// Gets the contract rental place record.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="placeId">The place id.</param>
        /// <returns>The ContractRentalPlace.</returns>
        public ContractRentalPlace GetContractRentalPlaceRecord(int contractId, int placeId)
        {
            return (from contractRentalProperty in db.ContractRentalPlaces
                    where contractRentalProperty.ContractId == contractId
                          && contractRentalProperty.RentalPlaceId == placeId
                          && contractRentalProperty.DateTo.GetValueOrDefault().Date >= DateTime.Now.Date
                    select contractRentalProperty).FirstOrDefault();
        }

        #endregion

        #region ContractUnpayablePeriod

        /// <summary>
        /// Gets the contract unpayable period.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The ContractUnpayablePeriod</returns>
        public ContractUnpayablePeriod GetContractUnpayablePeriod(int id)
        {
            return (from contractUnpayablePeriod in db.ContractUnpayablePeriods
                    where contractUnpayablePeriod.Id == id
                    select contractUnpayablePeriod).FirstOrDefault();
        }

        /// <summary>
        /// Checks the intersection.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Intersection flag.</returns>
        public bool CheckIntersection(int contractId, int rentalPlaceId, DateTime fromDate, DateTime toDate)
        {
            return (from contractUnpayablePeriod in db.ContractUnpayablePeriods
                    where contractUnpayablePeriod.ContractRentalPlace.ContractId == contractId
                          && contractUnpayablePeriod.ContractRentalPlace.RentalPlaceId == rentalPlaceId
                          && ((contractUnpayablePeriod.BeginDate >= fromDate
                               && contractUnpayablePeriod.BeginDate <= toDate)
                              || (contractUnpayablePeriod.EndDate >= fromDate
                                  && contractUnpayablePeriod.EndDate <= toDate)
                              || (contractUnpayablePeriod.BeginDate >= fromDate
                                  && contractUnpayablePeriod.EndDate <= toDate))
                    select contractUnpayablePeriod).Count() > 0;
        }

        /// <summary>
        /// Gets the contract unpayable periods.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <returns>List of contract unpayable periods.</returns>
        public List<ContractUnpayablePeriod> GetContractUnpayablePeriods(int contractId, int rentalPlaceId)
        {
            return (from contractUnpayablePeriod in db.ContractUnpayablePeriods
                    where contractUnpayablePeriod.ContractRentalPlace.ContractId == contractId
                          && contractUnpayablePeriod.ContractRentalPlace.RentalPlaceId == rentalPlaceId
                    select contractUnpayablePeriod).ToList();
        }

        #endregion

        #region HolidayDictionary

        /// <summary>
        /// Gets the holidays.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of holiday dates.</returns>
        public List<DateTime> GetHolidays(DateTime fromDate, DateTime toDate)
        {
            return (from holidayDictionary in db.HolidayDictionaries
                    where holidayDictionary.Date >= fromDate.Date &&
                          holidayDictionary.Date <= toDate.Date
                    select holidayDictionary.Date).ToList();
        }

        public List<HolidayDictionary> GetHolidayDictionaries()
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.HolidayDictionaries);
            return db.HolidayDictionaries.ToList();
        }

        /// <summary>
        /// Gets the holidays.
        /// </summary>
        /// <returns>List of holiday dates.</returns>
        public List<DateTime> GetHolidays()
        {
            db = new RentalSystemDataContext();

            return (from holidayDictionary in db.HolidayDictionaries
                    select holidayDictionary.Date).ToList();
        }

        /// <summary>
        /// Gets the holiday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The HolidayDictionary.</returns>
        public HolidayDictionary GetHoliday(DateTime date)
        {
            return (from holidayDictionary in db.HolidayDictionaries
                    where holidayDictionary.Date == date.Date
                    select holidayDictionary).FirstOrDefault();
        }

        /// <summary>
        /// Checks the holiday existance.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Existance flag.</returns>
        public bool CheckHolidayExistance(DateTime date)
        {
            return (from holidayDictionary in db.HolidayDictionaries
                    where holidayDictionary.Date == date.Date
                    select holidayDictionary).Count() > 0;
        }

        public void InsertHoliday(HolidayDictionary dictionary)
        {
            db.HolidayDictionaries.InsertOnSubmit(dictionary);
            db.SubmitChanges();
        }

        #endregion

        #region pricelist

        /// <summary>
        /// Gets the price list by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The PriceList.</returns>
        public PriceList GetPriceListById(int id)
        {
            return (from priceList in db.PriceLists
                    where priceList.Id == id
                    select priceList).FirstOrDefault();
        }

        /// <summary>
        /// Gets the price list records.
        /// </summary>
        /// <returns>List of price lists.</returns>
        public List<PriceListRecord> GetPriceListRecords()
        {
            return (from priceList in db.PriceLists
                    select
                        new PriceListRecord(priceList.Id, priceList.Service.Name, priceList.Price,
                                            priceList.ValidFrom ?? DateTime.Now)).
                ToList();
        }

        public void InsertPriceListRecord(PriceList priceList)
        {
            if (priceList.Id == 0)
            {
                db.PriceLists.InsertOnSubmit(priceList);
            }

            db.SubmitChanges();
        }

        public void DeletePriceList(PriceList list)
        {
            db.PriceLists.DeleteOnSubmit(list);
            db.SubmitChanges();
        }

        #endregion

        #region RentalCashlessPayment

        /// <summary>
        /// Gets the rental cashless payments.
        /// </summary>
        /// <returns>List of RentalCashlessPayments.</returns>
        public List<CashlessPayLogRecord> GetRentalCashlessPayments()
        {
            return (from rentalCashlessPayment in db.RentalCashlessPayments
                    join contract in db.Contracts on rentalCashlessPayment.ContractId equals contract.Id
                    where contract.IsCashless
                    select
                        new CashlessPayLogRecord(rentalCashlessPayment.Id,
                                                 contract.ContractNumber,
                                                 rentalCashlessPayment.PaidDateFrom,
                                                 rentalCashlessPayment.PaidDateTo,
                                                 contract.CashlessPaymentControlDate.GetValueOrDefault())).ToList();
        }

        public void InsertRentalCashlessPayment(RentalCashlessPayment payment)
        {
            if (payment.Id == 0)
            {
                db.RentalCashlessPayments.InsertOnSubmit(payment);
            }

            db.SubmitChanges();
        }

        /// <summary>
        /// Gets the rental cashless payment record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The RentalCashlessPayment.</returns>
        public RentalCashlessPayment GetRentalCashlessPaymentRecord(int id)
        {
            return (from rentalCashlessPayment in db.RentalCashlessPayments
                    where rentalCashlessPayment.Id == id
                    select rentalCashlessPayment).FirstOrDefault();
        }

        public void DeleteRentalCashlessPaymentRecord(int id)
        {
            db.RentalCashlessPayments.DeleteOnSubmit(
                (from rentalCashlessPayment in db.RentalCashlessPayments
                 where rentalCashlessPayment.Id == id
                 select rentalCashlessPayment).FirstOrDefault());

            db.SubmitChanges();
        }

        public bool IsPaymentExistsInPeriod(int contractId, int? paymentId, DateTime tryPeriodFrom, DateTime tryPeriodTo)
        {
            return (from rentalCashlessPayment in db.RentalCashlessPayments
                    where rentalCashlessPayment.ContractId == contractId
                          && tryPeriodFrom <= rentalCashlessPayment.PaidDateTo
                          && tryPeriodTo >= rentalCashlessPayment.PaidDateFrom
                          && (paymentId == null
                              || (paymentId != null && rentalCashlessPayment.Id != paymentId)
                             )
                    select rentalCashlessPayment).Count() > 0;
        }

        #endregion

        /// <summary>
        /// Gets the rental places information.
        /// </summary>
        /// <returns>List of rental place information.</returns>
        public List<RentalPlaceInformationExt> GetRentalPlacesInformation()
        {
            return (
                       from rentalPlace in db.RentalPlaces
                       select
                           new RentalPlaceInformationExt(
                           rentalPlace.Id,
                           rentalPlace.Number,
                           (from contractRentalPlace in db.ContractRentalPlaces
                            join contract in db.Contracts on contractRentalPlace.ContractId equals contract.Id
                            where contractRentalPlace.RentalPlaceId == rentalPlace.Id
                                  && contractRentalPlace.DateFrom <= DateTime.Now
                                  && contractRentalPlace.DateTo >= DateTime.Now
                            select contract.ContractNumber).FirstOrDefault(),
                           (from contractRentalPlace in db.ContractRentalPlaces
                            join contract in db.Contracts on contractRentalPlace.ContractId equals contract.Id
                            join service in db.Services on contract.RentalServiceId equals service.Id
                            where contractRentalPlace.RentalPlaceId == rentalPlace.Id
                                  && contractRentalPlace.DateFrom <= DateTime.Now
                                  && contractRentalPlace.DateTo >= DateTime.Now
                            select service.Name).FirstOrDefault(),
                           (from contractRentalPlace in db.ContractRentalPlaces
                            join contract in db.Contracts on contractRentalPlace.ContractId equals contract.Id
                            join service in db.Services on contract.RentalServiceId equals service.Id
                            join priceList in db.PriceLists on service.Id equals priceList.ServiceId
                            where contractRentalPlace.RentalPlaceId == rentalPlace.Id
                                  && contractRentalPlace.DateFrom <= DateTime.Now
                                  && contractRentalPlace.DateTo >= DateTime.Now
                                  && priceList.ValidFrom <= DateTime.Now
                            orderby priceList.ValidFrom descending
                            select priceList.Price).FirstOrDefault(),
                           (from contractRentalPlace in db.ContractRentalPlaces
                            where contractRentalPlace.RentalPlaceId == rentalPlace.Id
                                  && contractRentalPlace.DateFrom <= DateTime.Now
                                  && contractRentalPlace.DateTo >= DateTime.Now
                            select contractRentalPlace.DateTo.GetValueOrDefault()).FirstOrDefault()
                           )).ToList();
        }

        /// <summary>
        /// Checks the rental place existance.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Existance flag.</returns>
        public bool CheckRentalPlaceExistance(string number)
        {
            return (from rentalPlace in db.RentalPlaces
                    where rentalPlace.Number == number
                    select rentalPlace).Count() > 0;
        }

        public void DeleteRentalPlace(RentalPlace rentalPlace)
        {
            db.RentalPlaces.DeleteOnSubmit(rentalPlace);
            db.SubmitChanges();
        }

        public void InsertService(Service service)
        {
            if (service.Id == 0)
            {
                db.Services.InsertOnSubmit(service);
            }

            db.SubmitChanges();
        }

        public void DeleteService(Service service)
        {
            db.Services.DeleteOnSubmit(service);
            db.SubmitChanges();
        }

        public void InsertContractUnpayablePeriod(ContractUnpayablePeriod period)
        {
            if (period.Id == 0)
            {
                db.ContractUnpayablePeriods.InsertOnSubmit(period);
            }

            db.SubmitChanges();
        }

        public void DeleteContractUnpayablePeriod(ContractUnpayablePeriod period)
        {
            db.ContractUnpayablePeriods.DeleteOnSubmit(period);
            db.SubmitChanges();
        }

        public void InsertUser(User user)
        {
            if (user.Id == 0)
            {
                db.Users.InsertOnSubmit(user);
            }

            db.SubmitChanges();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>List of roles.</returns>
        public List<Role> GetUserRoles(string login)
        {
            return (from role in db.Roles
                    join userRole in db.UserRoles on role.Id equals userRole.RoleId
                    where userRole.User.Login == login
                    select role).ToList();
        }

        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }

        public void DeleteUser(User user)
        {
            db.Users.DeleteOnSubmit(user);
            db.SubmitChanges();
        }

        public void InsertUserRole(UserRole role)
        {
            db.UserRoles.InsertOnSubmit(role);
            db.SubmitChanges();
        }

        public void DeleteUserRole(UserRole role)
        {
            db.UserRoles.DeleteOnSubmit(role);
            db.SubmitChanges();
        }

        public List<ServicePayLogRecord> GetNonRentalServiceFees(DateTime dateFrom, DateTime dateTo, int[] serviceIdArr)
        {
            var result =
                from spm in db.ServicePayments
                join spds in db.ServicePaymentDailySummaries on
                    new {DailySummaryId = Convert.ToInt32(spm.DailySummaryId)}
                    equals new {DailySummaryId = spds.Id}
                join tm in db.Terminals on new {spm.TerminalId} equals new {TerminalId = tm.Id}
                join sv in db.Services
                    on new {ServiceId = Convert.ToInt32(spm.ServiceId)}
                    equals new {ServiceId = sv.Id}
                where
                    spm.DateTime >= dateFrom && spm.DateTime <= dateTo && serviceIdArr.Contains(sv.Id) && !sv.IsRental
                group new {sv, spm, tm, spds} by new
                                                     {
                                                         sv.Name,
                                                         sv.Description,
                                                         spm.DateTime,
                                                         sv.Id,
                                                         tm.NetworkName,
                                                         spm.PaidSum,
                                                         spds.StatusMessage,
                                                         spm.PlaceNumber
                                                     }
                into g
                    select
                    new ServicePayLogRecord
                    (
                    g.Key.Name,
                    g.Key.Description,
                    (from pl in db.PriceLists
                     where
                         pl.ServiceId == g.Key.Id &&
                         pl.ValidFrom <= g.Key.DateTime
                     orderby
                         pl.ValidFrom descending
                     select new {pl.Price}).Take(1).First().Price,
                    g.Key.PaidSum,
                    g.Key.DateTime,
                    g.Key.NetworkName,
                    g.Key.StatusMessage,
                    g.Key.PlaceNumber
                    );

            return result.ToList();
        }

        public List<ServicePayLogRecord> GetOtherServiceFees(DateTime dateFrom, DateTime dateTo)
        {
            var result =
                from spm in db.ServicePayments
                join spds in db.ServicePaymentDailySummaries on
                    new {DailySummaryId = Convert.ToInt32(spm.DailySummaryId)}
                    equals new {DailySummaryId = spds.Id}
                join tm in db.Terminals on new {spm.TerminalId} equals new {TerminalId = tm.Id}
                join sv in db.Services
                    on new {ServiceId = Convert.ToInt32(spm.ServiceId), IsRental = false}
                    equals new {ServiceId = sv.Id, sv.IsRental}
                where
                    spm.DateTime >= dateFrom && spm.DateTime <= dateTo && !sv.IsRental
                group new {sv, spm, tm, spds} by new
                                                     {
                                                         sv.Name,
                                                         sv.Description,
                                                         spm.DateTime,
                                                         sv.Id,
                                                         tm.NetworkName,
                                                         spm.PaidSum,
                                                         spds.StatusMessage,
                                                         spm.PlaceNumber
                                                     }
                into g
                    select
                    new ServicePayLogRecord
                    (
                    g.Key.Name,
                    g.Key.Description,
                    (from pl in db.PriceLists
                     where
                         pl.ServiceId == g.Key.Id &&
                         pl.ValidFrom <= g.Key.DateTime
                     orderby
                         pl.ValidFrom descending
                     select new {pl.Price}).Take(1).First().Price,
                    g.Key.PaidSum,
                    g.Key.DateTime,
                    g.Key.NetworkName,
                    g.Key.StatusMessage,
                    g.Key.PlaceNumber
                    );

            return result.ToList();
        }
    }
}