using System;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.Core.Domain;
using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class FeeService : BaseService, IFeeService
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

        /// <summary>
        /// Gets the rental fees.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of rental fees.</returns>
        public BindingListView<RentalPayLogRecord> GetRentalFees(DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                fromDate = new DateTime(fromDate.Year,
                                        fromDate.Month,
                                        fromDate.Day,
                                        0,
                                        0,
                                        0);
                toDate = new DateTime(toDate.Year,
                                      toDate.Month,
                                      toDate.Day,
                                      23,
                                      59,
                                      59);
                return new BindingListView<RentalPayLogRecord>(SQLHelper.GetRentalFees(fromDate, toDate));
            }
            return null;
        }

        /// <summary>
        /// Gets the paid rental fees.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of rental fees.</returns>
        public BindingListView<RentalPayLogRecord> GetPaidRentalFees(DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<RentalPayLogRecord>(SQLHelper.GetPaidRentalFees(fromDate, toDate));
            }
            return null;
        }

        /// <summary>
        /// Gets the rental cashless payments.
        /// </summary>
        /// <returns>List of cashless rental payments.</returns>
        public BindingListView<CashlessPayLogRecord> GetRentalCashlessPayments()
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<CashlessPayLogRecord>(Dal.GetRentalCashlessPayments());
            }
            return null;
        }

        /// <summary>
        /// Gets the not transfered payment.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of not transfered payments.</returns>
        public BindingListView<RentalPayLogRecord> GetNotTransferedPayment(DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                fromDate = new DateTime(fromDate.Year,
                                        fromDate.Month,
                                        fromDate.Day,
                                        0,
                                        0,
                                        0);
                toDate = new DateTime(toDate.Year,
                                      toDate.Month,
                                      toDate.Day,
                                      23,
                                      59,
                                      59);
                return new BindingListView<RentalPayLogRecord>(SQLHelper.GetNotTransferedPayment(fromDate, toDate));
            }
            return null;
        }

        /// <summary>
        /// Gets the not paid rental fees.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of not paid rental fees.</returns>
        public BindingListView<RentalPayLogRecord> GetNotPaidRentalFees(DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                fromDate = new DateTime(fromDate.Year,
                                        fromDate.Month,
                                        fromDate.Day,
                                        0,
                                        0,
                                        0);
                toDate = new DateTime(toDate.Year,
                                      toDate.Month,
                                      toDate.Day,
                                      23,
                                      59,
                                      59);
                return new BindingListView<RentalPayLogRecord>(SQLHelper.GetNotPaidRentalFees(fromDate, toDate));
            }
            return null;
        }

        /// <summary>
        /// Gets the service fees.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List of service fees.</returns>
        public BindingListView<ServicePayLogRecord> GetServiceFees(DateTime fromDate, DateTime toDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<ServicePayLogRecord>(Dal.GetOtherServiceFees(fromDate, toDate));
            }
            return null;
        }


        public BindingListView<ServicePayLogRecord> GetServiceFeesExt(DateTime from, DateTime to, int[] serviceIdArr)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<ServicePayLogRecord>(Dal.GetNonRentalServiceFees(from, to, serviceIdArr));
            }
            return null;

            //SQLHelper.GetServiceFeesExt(from, to, serviceId)
        }

        /// <summary>
        /// Gets the state of the contract.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="contractor">The contractor.</param>
        /// <returns>List of contract state info.</returns>
        public BindingListView<ContractStateInformation> GetContractState(DateTime fromDate, DateTime toDate,
                                                                          string contractNumber, string contractor)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                if (contractNumber == ALL_ITEMS)
                {
                    contractNumber = null;
                }
                if (contractor == ALL_ITEMS)
                {
                    contractor = null;
                }
                fromDate = new DateTime(fromDate.Year,
                                        fromDate.Month,
                                        fromDate.Day,
                                        0,
                                        0,
                                        0);
                toDate = new DateTime(toDate.Year,
                                      toDate.Month,
                                      toDate.Day,
                                      23,
                                      59,
                                      59);
                return
                    new BindingListView<ContractStateInformation>(SQLHelper.GetContractState(fromDate, toDate,
                                                                                             contractNumber, contractor));
            }
            return null;
        }

        /// <summary>
        /// Inserts the rental fee record.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="checkDate">Check date</param>
        /// <returns>The rental fee record id.</returns>
        public int InsertRentalFeeRecord(int contractId, DateTime dateFrom, DateTime dateTo, DateTime checkDate)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Contract contract = Dal.GetContractById(contractId);
                contract.CashlessPaymentControlDate = checkDate.Date;
                RentalCashlessPayment rentalFee = new RentalCashlessPayment
                                                      {
                                                          Contract = contract,
                                                          PaidDateFrom = dateFrom.Date,
                                                          PaidDateTo = dateTo.Date
                                                      };
                Dal.InsertRentalCashlessPayment(rentalFee);

                return rentalFee.Id;
            }
            return 0;
        }

        /// <summary>
        /// Updates the rental fee record.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <param name="contractId">The contract id.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        public void UpdateRentalFeeRecord(int recordId, int contractId, DateTime dateFrom, DateTime dateTo)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                RentalCashlessPayment rentalFee = Dal.GetRentalCashlessPaymentRecord(recordId);
                rentalFee.Contract = Dal.GetContractById(contractId);
                rentalFee.PaidDateFrom = dateFrom.Date;
                rentalFee.PaidDateTo = dateTo.Date;

                Dal.InsertRentalCashlessPayment(rentalFee);
            }
        }

        /// <summary>
        /// Deletes the rental fee record
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <returns>Deleted rental fee record id.</returns>
        public void DeleteRentalFeeRecord(int recordId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                Dal.DeleteRentalCashlessPaymentRecord(recordId);
            }
        }

        /// <summary>
        /// Gets the rental fee record.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <returns>The rental fee record.</returns>
        public RentalCashlessPayment GetRentalFeeRecord(int recordId)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                RentalCashlessPayment record = Dal.GetRentalCashlessPaymentRecord(recordId);
                return record;
            }
            return null;
        }

        public bool IsPaymentExistsInPeriod(int contractId, int? paymentId, DateTime tryPeriodFrom, DateTime tryPeriodTo)
        {
            if (userService.IsInRole(Roles.Accountant.ToString())
                || userService.IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.IsPaymentExistsInPeriod(contractId, paymentId, tryPeriodFrom, tryPeriodTo);
            }

            return false;
        }
        #endregion
    }
}