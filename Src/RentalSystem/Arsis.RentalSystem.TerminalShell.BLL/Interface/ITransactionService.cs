using System;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface ITransactionService
    {
        void Initialize();
        void BeginRentalTransaction(string contractNumber, string placeNumber);
        void EndRentalTransaction();
        void ProceedRentalPayment(decimal depositAmmount);

        void BeginServiceTransaction(string placeNumber);
        void EndServiceTransaction();

        void EndParkingServiceTransaction();
       
        void ProceedServicePayment(int serviceId, string serviceName, decimal price, decimal depositAmmount);

        /// <summary>
        /// Сохранение информации о транзакции в файл если произошёл Exc
        /// </summary>
        void SaveServiceInformationToDisk();

        /// <summary>
        /// инфо о транзакции (прочие услуги, парковка )
        /// </summary>
        ServiceTransactionInformation ServiceTransactionInformation { get; }
    }

    public class RentalFeeServiceEventArgs : EventArgs
    {
        public RentalFeeServiceEventArgs(ServicePayment servicePaymentItem)
        {
            ServicePaymentItem = servicePaymentItem;
        }

        public ServicePayment ServicePaymentItem { get; set; }
    }
}