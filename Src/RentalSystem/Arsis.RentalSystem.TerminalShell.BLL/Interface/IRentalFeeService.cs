using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface IRentalFeeService
    {
        void InsertRentalFeeRecord(string number, decimal fee);
        List<PayLogRecord> GetNotPaidRentalFees(DateTime date);
        List<PayDateInformation> GetPayDates(string contractNumber, string placeNumber);
        ServicePayment InsertServiceFeeRecord(int serviceId, decimal price, decimal feeAmount, string placeNumber);
        decimal GetRate(string serviceName, DateTime date);
        bool IsFirstBelongDate(string contractNumber, string number, DateTime date);
        bool IsHoliday(string contractNumber, string number, DateTime date);
    }
}