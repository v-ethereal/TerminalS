using System;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class ContractService : BaseService, IContractService
    {
        #region Constants

        private const string ALL_ITEMS = "(Все)";

        #endregion

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

        public int InsertContractRecord(Contract filledContract, int serviceId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                if (filledContract != null)
                {
                    return InsertContract(filledContract, serviceId);
                }
            }

            return 0;
        }

        /// <summary>
        /// Inserts the contract record.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="durationFrom">The duration from.</param>
        /// <param name="durationTo">The duration to.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="cashlessPaymentControlDate">The cashless payment control date.</param>
        /// <param name="contractorCode">The contractor code.</param>
        /// <param name="isExporting">if set to <c>true</c> is exporting to 1C.</param>
        /// <returns>The contract id.</returns>
        public int InsertContractRecord(string contractNumber, DateTime durationFrom, DateTime durationTo, int serviceId, DateTime cashlessPaymentControlDate, string contractorCode, bool isExporting)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contractor contractor = OdbcHelper.GetContractor(contractorCode);
                Contract contract = new Contract
                                        {
                                                ContractNumber = contractNumber,
                                                DateFrom = durationFrom.Date,
                                                DateTo = durationTo.Date,
                                                Client1SCode = contractor.Client1SCode,
                                                ClientName = contractor.ClientName,
                                                IsJuridicalPerson = contractor.IsJuridicalPerson,
                                                ClientAddress = contractor.ClientAddress,
                                                ClientPostAddress = contractor.ClientPostAddress,
                                                ClientPhone = contractor.ClientPhone,
                                                INN = contractor.INN,
                                                PassportSeries = contractor.PassportSeries,
                                                PassportNumber = contractor.PassportNumber,
                                                PassportOutletOrgan = contractor.PassportOutletOrgan,
                                                PassportOutletDate = (string.IsNullOrEmpty(contractor.PassportOutletDate)
                                                        ? (DateTime?)null
                                                        : DateTime.Parse(contractor.PassportOutletDate).
                                                        Date),
                                                IsCashless = true,
                                                CashlessPaymentControlDate = cashlessPaymentControlDate,
                                                CrDateTime = DateTime.Now,
                                                CrUserId = userService.CurrentUser.Id,
                                                Status = Convert.ToByte(isExporting ? 1 : 0),
                                                PlacePrice = Dal.GetServicePrice(serviceId)
                                        };

                return InsertContract(contract, serviceId);
            }
            return 0;
        }

        private int InsertContract(Contract contract, int serviceId)
        {
            contract.Service = Dal.GetServiceById(serviceId);

        	Dal.InsertContract(contract);

            ContractHistory contractHistory = new ContractHistory
                                                  {
                                                      Contract = contract,
                                                      UserId = userService.CurrentUser.Id,
                                                      Date = DateTime.Now,
                                                      ChangeLog = "договор создан"
                                                  };

        	Dal.InsertContractHistory(contractHistory);


            return contract.Id;
        }

        /// <summary>
        /// Inserts the contract record.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="durationFrom">The duration from.</param>
        /// <param name="durationTo">The duration to.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="contractorCode">The contractor code.</param>
        /// <param name="isExporting">if set to <c>true</c> is exporting to 1C.</param>
        /// <returns>The contract id.</returns>
        public int InsertContractRecord(string contractNumber, DateTime durationFrom, DateTime durationTo, int serviceId, string contractorCode, bool isExporting)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contractor contractor = OdbcHelper.GetContractor(contractorCode);
                Contract contract = new Contract
                                        {
                                                ContractNumber = contractNumber,
                                                DateFrom = durationFrom.Date,
                                                DateTo = durationTo.Date,
                                                Client1SCode = contractor.Client1SCode,
                                                ClientName = contractor.ClientName,
                                                IsJuridicalPerson = contractor.IsJuridicalPerson,
                                                ClientAddress = contractor.ClientAddress,
                                                ClientPostAddress = contractor.ClientPostAddress,
                                                ClientPhone = contractor.ClientPhone,
                                                INN = contractor.INN,
                                                PassportSeries = contractor.PassportSeries,
                                                PassportNumber = contractor.PassportNumber,
                                                PassportOutletOrgan = contractor.PassportOutletOrgan,
                                                PassportOutletDate =
                                                        string.IsNullOrEmpty(contractor.PassportOutletDate)
                                                                ? (DateTime?)null
                                                                : DateTime.Parse(contractor.PassportOutletDate).Date,
                                                IsCashless = false,
                                                CrDateTime = DateTime.Now,
                                                CrUserId = userService.CurrentUser.Id,
                                                Service = Dal.GetServiceById(serviceId),
                                                Status = Convert.ToByte(isExporting ? 1 : 0),
                                                PlacePrice = Dal.GetServicePrice(serviceId)
                                        };

                return InsertContract(contract, serviceId);
            }
            return 0;
        }

        /// <summary>
        /// Updates the contract record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="durationFrom">The duration from.</param>
        /// <param name="durationTo">The duration to.</param>
        /// <param name="cashlessPaymentControlDate">The cashless payment control date.</param>
        /// <param name="isExporting">if set to <c>true</c> is exporting to 1C.</param>
        public void UpdateContractRecord(int id, DateTime durationFrom, DateTime durationTo, DateTime cashlessPaymentControlDate, bool isExporting)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contract = Dal.GetContractById(id);
                contract.DateFrom = durationFrom.Date;
                contract.DateTo = durationTo.Date;
                contract.IsCashless = true;
                contract.CashlessPaymentControlDate = cashlessPaymentControlDate;
                contract.ChDateTime = DateTime.Now;
                contract.ChUserId = userService.CurrentUser.Id;
                contract.Status = Convert.ToByte(isExporting ? 1 : 0);

                ContractHistory contractHistory = new ContractHistory
                                                      {
                                                              Contract = contract,
                                                              UserId = userService.CurrentUser.Id,
                                                              Date = DateTime.Now,
                                                              ChangeLog = "договор изменен"
                                                      };
                Dal.InsertContractHistory(contractHistory);
            }
        }

        /// <summary>
        /// Updates the contract record.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="durationFrom">The duration from.</param>
        /// <param name="durationTo">The duration to.</param>
        /// <param name="isExporting">if set to <c>true</c> is exporting to 1C.</param>
        public void UpdateContractRecord(int id, DateTime durationFrom, DateTime durationTo, bool isExporting)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contract = Dal.GetContractById(id);
                List<RentalPlace> rentalPlaces = Dal.GetRentalPlacesByContractId(contract.Id);
                foreach (RentalPlace place in rentalPlaces)
                {
                    ContractRentalPlace contractRentalPlaceRecord = Dal.GetContractRentalPlaceRecord(contract.Id, place.Id);

                    if (contractRentalPlaceRecord.DateFrom.GetValueOrDefault().Date == contract.DateFrom.GetValueOrDefault().Date)
                    {
                        contractRentalPlaceRecord.DateFrom = durationFrom.Date;
                    }
                    if (contractRentalPlaceRecord.DateTo.GetValueOrDefault().Date == contract.DateTo.GetValueOrDefault().Date)
                    {
                        contractRentalPlaceRecord.DateTo = durationTo.Date;
                    }
                }
                contract.DateFrom = durationFrom.Date;
                contract.DateTo = durationTo.Date;
                contract.ChDateTime = DateTime.Now;
                contract.ChUserId = userService.CurrentUser.Id;
                contract.Status = Convert.ToByte(isExporting ? 1 : 0);

                ContractHistory contractHistory = new ContractHistory
                                                      {
                                                              Contract = contract,
                                                              UserId = userService.CurrentUser.Id,
                                                              Date = DateTime.Now,
                                                              ChangeLog = "договор изменен"
                                                      };
                Dal.InsertContractHistory(contractHistory);
            }
        }

        /// <summary>
        /// Gets the contracts.
        /// </summary>
        /// <param name="state">The contract state.</param>
        /// <param name="fromDate">Date from.</param>
        /// <param name="toDate">Date to.</param>
        /// <returns>List of contracts.</returns>
        public BindingListView<Contract> GetContracts(ContractState state, DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                List<Contract> contracts;
                switch (state)
                {
                    case ContractState.All:
                        {
                            contracts = Dal.GetContracts(fromDate, toDate);
                            break;
                        }
                    case ContractState.Active:
                        {
                            contracts = Dal.GetActiveContracts(fromDate, toDate);
                            break;
                        }
                    case ContractState.Closed:
                        {
                            contracts = Dal.GetClosedContracts(fromDate, toDate);
                            break;
                        }
                    case ContractState.Cashless:
                        {
                            contracts = Dal.GetCashlessContracts(fromDate, toDate);
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("state");
                }
                return new BindingListView<Contract>(contracts);
            }
            return null;
        }

        /// <summary>
        /// Closes the contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="date">The date.</param>
        public void CloseContract(int contractId, DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contract = Dal.GetContractById(contractId);
                contract.DateTo = date.Date;
                contract.DissolutionDate = date;
                contract.ChUserId = userService.CurrentUser.Id;

                List<RentalPlace> rentalPlaces = Dal.GetRentalPlacesByContractId(contractId);
                foreach (RentalPlace place in rentalPlaces)
                {
                    ContractRentalPlace contractRentalPlaceRecord = Dal.GetContractRentalPlaceRecord(
                            contractId, place.Id);
                    contractRentalPlaceRecord.DateTo = date.Date;
                }

                ContractHistory contractHistory = new ContractHistory
                                                      {
                                                              Contract = contract,
                                                              UserId = userService.CurrentUser.Id,
                                                              Date = DateTime.Now,
                                                              ChangeLog = "договор закрыт"
                                                      };
                Dal.InsertContractHistory(contractHistory);
            }
        }

        /// <summary>
        /// Gets the contractors.
        /// </summary>
        /// <returns>List of contractors.</returns>
        public BindingListView<Contractor> GetContractors(string parentCode)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                try
                {
                    return new BindingListView<Contractor>(OdbcHelper.GetContractors(parentCode));
                }
                catch (OdbcException e)
                {
                    throw new RentalSystemException(e.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the contractor.
        /// </summary>
        /// <param name="contractorCode">The contractor code.</param>
        /// <returns>The contractor.</returns>
        public Contractor GetContractor(string contractorCode)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                try
                {
                    return OdbcHelper.GetContractor(contractorCode ?? string.Empty);
                }
                catch (OdbcException e)
                {
                    throw new RentalSystemException(e.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the contractors list for filter.
        /// </summary>
        /// <returns>List of contractors.</returns>
        public List<string> GetContractorsFilter()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                List<string> result = new List<string> { ALL_ITEMS };
                result.AddRange(Dal.GetContractorsFilter());
                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets the contracts list for filter.
        /// </summary>
        /// <returns>List of contracts.</returns>
        public List<string> GetContractsFilter()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                List<string> result = new List<string> { ALL_ITEMS };
                result.AddRange(Dal.GetContractsFilter());
                return result;
            }
            return null;
        }

        /// <summary>
        /// Calculates the contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="date">The date.</param>
        /// <param name="renderedAmmount">The rendered ammount.</param>
        /// <param name="recievedAmmount">The recieved ammount.</param>
        /// <param name="balance">The balance.</param>
        public void CalculateContract(int contractId, DateTime date, out decimal renderedAmmount, out decimal recievedAmmount, out decimal balance)
        {
            renderedAmmount = 0;
            recievedAmmount = 0;
            balance = 0;
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                SQLHelper.GetFinancialInfo(contractId, date, out renderedAmmount, out recievedAmmount);
                balance = recievedAmmount - renderedAmmount;
            }
        }

        /// <summary>
        /// Gets the contract.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The contract.</returns>
        public Contract GetContract(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contract = Dal.GetContractById(id);
                return contract;
            }
            return null;
        }

        /// <summary>
        /// Transfers the specified contract id from.
        /// </summary>
        /// <param name="contractIdFrom">The contract id from.</param>
        /// <param name="contractIdTo">The contract id to.</param>
        /// <param name="rentalPlacesIds">The rental places ids.</param>
        /// <param name="date">The date.</param>
        public void Transfer(int contractIdFrom, int contractIdTo, List<int> rentalPlacesIds, DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contractFrom = Dal.GetContractById(contractIdFrom);
                Contract contractTo = Dal.GetContractById(contractIdTo);
                if (contractTo.DissolutionDate != null
                        && contractTo.DissolutionDate.GetValueOrDefault().Date <= DateTime.Now.Date)
                {
                    throw new RentalSystemException("Договор закрыт");
                }
                foreach (int rentalPlaceId in rentalPlacesIds)
                {
                    ContractRentalPlace actualPlace =
                            Dal.GetContractRentalPlaceRecord(contractFrom.Id, rentalPlaceId);
                    
                    ContractRentalPlace newPlace = new ContractRentalPlace
                                                       {
                                                               Contract = contractTo,
                                                               RentalPlace = actualPlace.RentalPlace,
                                                               DateTo = contractTo.DateTo.GetValueOrDefault().Date,
                                                               DateFrom = date.Date
                                                       };
                    actualPlace.DateTo = date.AddDays(-1).Date;

                    Dal.InsertContractRentalPlace(newPlace);

                    ContractHistory contractFromHistory = new ContractHistory
                                                              {
                                                                      Contract = contractFrom,
                                                                      UserId = userService.CurrentUser.Id,
                                                                      Date = DateTime.Now,
                                                                      ChangeLog =
                                                                              string.Format(
                                                                              "место №:{0} передано с договора №:{1} на договор №:{2}",
                                                                              actualPlace.RentalPlace.Number,
                                                                              contractFrom.ContractNumber,
                                                                              contractTo.ContractNumber)
                                                              };
                    Dal.InsertContractHistory(contractFromHistory);

                    ContractHistory contractToHistory = new ContractHistory
                                                            {
                                                                    Contract = contractTo,
                                                                    UserId = userService.CurrentUser.Id,
                                                                    Date = DateTime.Now,
                                                                    ChangeLog =
                                                                            string.Format(
                                                                            "место №:{0} передано с договора №:{1} на договор №:{2}",
                                                                            actualPlace.RentalPlace.Number,
                                                                            contractFrom.ContractNumber,
                                                                            contractTo.ContractNumber)
                                                            };
                    Dal.InsertContractHistory(contractToHistory);
                }
            }
        }

        /// <summary>
        /// Adds the rental place to contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <param name="date">The date.</param>
        public void AddRentalPlaceToContract(int contractId, int rentalPlaceId, DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                RentalPlace rentalPlace = Dal.GetRentalPlaceById(rentalPlaceId);
                Contract contract = Dal.GetContractById(contractId);
                if (contract.DissolutionDate != null
                        && contract.DissolutionDate.GetValueOrDefault().Date <= DateTime.Now.Date)
                {
                    throw new RentalSystemException("Договор закрыт");
                }

                ContractRentalPlace contractRentalPlace = new ContractRentalPlace
                                                              {
                                                                      Contract = contract,
                                                                      RentalPlace = rentalPlace,
                                                                      DateFrom = date.Date,
                                                                      DateTo = contract.DateTo.GetValueOrDefault().Date

                                                              };
                Dal.InsertContractRentalPlace(contractRentalPlace);

                ContractHistory contractHistory = new ContractHistory
                                                      {
                                                              Contract = contract,
                                                              UserId = userService.CurrentUser.Id,
                                                              Date = DateTime.Now,
                                                              ChangeLog =
                                                                      string.Format("место №:{0} добавлено c {1}", rentalPlace.Number, date.Date)
                                                      };
                Dal.InsertContractHistory(contractHistory);
            }
        }

        /// <summary>
        /// Removes the rental place from contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="rentalPlaceId">The rental place id.</param>
        /// <param name="date">The date.</param>
        public void RemoveRentalPlaceFromContract(int contractId, int rentalPlaceId, DateTime date)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                Contract contract = Dal.GetContractById(contractId);
                if (contract.DissolutionDate != null
                        && contract.DissolutionDate.GetValueOrDefault().Date <= DateTime.Now.Date)
                {
                    throw new RentalSystemException("Договор закрыт");
                }

                ContractRentalPlace contractRentalPlace = Dal.GetContractRentalPlaceRecord(contractId, rentalPlaceId);

                //Deletes this rental place from the contract
                //Dal.Refresh(RefreshMode.OverwriteCurrentValues, contractRentalPlace);
                contractRentalPlace.DateTo = date.Date.AddDays(-1);

                ContractHistory contractHistory = new ContractHistory
                                                      {
                                                              Contract = contractRentalPlace.Contract,
                                                              UserId = userService.CurrentUser.Id,
                                                              Date = DateTime.Now,
                                                              ChangeLog =
                                                                      string.Format("место №:{0} удалено c {1}", contractRentalPlace.RentalPlace.Number, date.Date)
                                                      };
                Dal.InsertContractHistory(contractHistory);
            }
        }

        /// <summary>
        /// Gets the rental places.
        /// </summary>
        /// <param name="id">The contract id.</param>
        /// <returns>List of rental places.</returns>
        public List<RentalPlace> GetRentalPlaces(int id)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.GetRentalPlacesByContractId(id);
            }
            return null;
        }

        /// <summary>
        /// Gets the rental places.
        /// </summary>
        /// <returns>List of rental places.</returns>
        public List<RentalPlace> GetRentalPlaces()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.GetRentalPlaces();
            }
            return null;
        }

        /// <summary>
        /// Checks the contract existance.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Contract existance flag.</returns>
        public bool CheckContractExistance(string number)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                return Dal.CheckContractExistance(number);
            }
            return false;
        }

        /// <summary>
        /// Gets the contract by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The contract.</returns>
        public Contract GetContractByNumber(string number)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Contract contract = Dal.GetContractByNumber(number);
                return contract;
            }
            return null;
        }

        /// <summary>
        /// Gets the contract history.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns>List of actions.</returns>
        public List<string> GetHistory(int contractId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString()))
            {
                List<string> result = new List<string>();
				List<ContractHistory> contractHistories = Dal.GetContractHistoryByContractId(contractId);

                foreach (ContractHistory history in contractHistories)
                {
                    string record = string.Format("{0}, {1}; изменение произведено пользователем {2} ", history.Date,
                                                  history.ChangeLog, history.User.Login);
                    if (!string.IsNullOrEmpty(history.User.Name))
                    {
                        record += string.Format("({0})", history.User.Name);
                    }
                    result.Add(record);
                }

                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets the contract rental place from date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="placeId">The place id.</param>
        /// <returns>The date.</returns>
        public DateTime GetContractRentalPlaceFromDate(int contractId, int placeId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.GetContractRentalPlaceFromDate(contractId, placeId) ?? DateTime.MinValue;
            }
            return DateTime.MinValue;
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
            if (userService.IsInRole(Roles.Accountant.ToString())
                    || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.CheckAddingPlaceDateIntersection(contractId, placeId, dateFrom.Date, dateTo.Date);
            }
            return false;
        }

        /// <summary>
        /// Gets the cashless payment control date.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns>The date.</returns>
        public DateTime GetCashlessPaymentControlDate(int contractId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                DateTime date = Dal.GetCashlessPaymentFromDate(contractId);
                if(date == DateTime.MinValue)
                {
                    throw new RentalSystemException("Ошибка данных, для безналичного договора отсутствует дата контроля платежа");
                }
                return date;
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Gets the minimal duration of the contract.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        public void GetMinimalContractDuration(int contractId, out DateTime dateFrom, out DateTime dateTo)
        {
            dateFrom = new DateTime();
            dateTo = new DateTime();
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                dateFrom = Dal.GetFirstCashlessPaymentDate(contractId);
                dateTo = Dal.GetLastCashlessPaymentDate(contractId);
            }
        }

        public DateTime[] GetLastRentalCashlessPaymentForContract(int contractId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.GetLastCashlessPaymentDateIfExists(contractId);
            }

            return null;
        }

        #endregion;
    }
}