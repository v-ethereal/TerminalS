using System;
using System.Collections.Generic;
using TermClasses;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface IFiscalRegister
    {
        void PrintXReport();
        void PrintZReport();
        void Initialize();
        void PrintAdditionalServiceReceipt(string serviceName, decimal price, decimal depositAmmount);
		void PrintAdditionalServiceReceiptEx(string serviceName, decimal price, decimal depositAmmount, IList<String> infoItems);
        void PrintRentalReceipt(List<DayRentalPaymentInfo> paymentsInfo);
        void PrintUnpaidRentalPlacesReport(DateTime controlDate);
        void PrintShiftSummaryReport();
        void PrintParkingTicket(DateTime startDate, string barCode, decimal price, decimal penalty);
        void PrintParkingExitTicket(string cardNumber, DateTime startDate, DateTime finishTime, bool externalPayment, decimal paidSum);
        void PrintAccessCode(string accessCode);
    }
}