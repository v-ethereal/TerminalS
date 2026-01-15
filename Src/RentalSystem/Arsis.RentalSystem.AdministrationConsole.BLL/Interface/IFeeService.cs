using System;

using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IFeeService
    {
        BindingListView<RentalPayLogRecord> GetRentalFees(DateTime from, DateTime to);
        BindingListView<RentalPayLogRecord> GetPaidRentalFees(DateTime from, DateTime to);
        BindingListView<RentalPayLogRecord> GetNotTransferedPayment(DateTime from, DateTime to);
        BindingListView<RentalPayLogRecord> GetNotPaidRentalFees(DateTime from, DateTime to);
        BindingListView<ServicePayLogRecord> GetServiceFees(DateTime from, DateTime to);
        BindingListView<ContractStateInformation> GetContractState(DateTime from, DateTime to, string contractNumber, string contractor);
        BindingListView<CashlessPayLogRecord> GetRentalCashlessPayments();
        int InsertRentalFeeRecord(int contractId, DateTime dateFrom, DateTime dateTo, DateTime checkDate);
        void UpdateRentalFeeRecord(int recordId, int contractId, DateTime dateFrom, DateTime dateTo);
        void DeleteRentalFeeRecord(int recordId);
        RentalCashlessPayment GetRentalFeeRecord(int recordId);
        bool IsPaymentExistsInPeriod(int contractId, int? paymentId,DateTime tryPeriodFrom, DateTime tryPeriodTo);
        BindingListView<ServicePayLogRecord> GetServiceFeesExt(DateTime from, DateTime to, int[] serviceIdArr);
    }
}