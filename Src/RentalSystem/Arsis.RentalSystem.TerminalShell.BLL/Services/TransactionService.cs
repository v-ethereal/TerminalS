using System;
using System.Collections.Generic;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using TermClasses;
using System.IO;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        #region Constants

        public const string RentalTransactionFile = "RentalTransaction.xml";
        public const string ServiceTransactionFile = "ServiceTransaction.xml";
        public const string ParkingInfoFile = "ParkingInfo.xml";

        #endregion

        #region Fields

        private RentalTransactionInformation rentalTransactionInformation;
        private ServiceTransactionInformation serviceTransactionInformation;

        #endregion

        #region Properties

        public ServiceTransactionInformation ServiceTransactionInformation
        {
            get { return serviceTransactionInformation; }
        }

        public IServicesService ServicesService { get; set; }

        public IParkingService ParkingService { get; set; }

        public IFiscalRegister FiscalRegister { get; set; }

        public IRentalFeeService RentalFeeService { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Ends unprocessed pay transaction.
        /// </summary>
        public void Initialize()
        {
            if (File.Exists(RentalTransactionFile))
            {
                CloseRentalTransaction();
            }

            if (File.Exists(ServiceTransactionFile))
            {
                CloseServiceTransaction();
            }
        }

        private void CloseRentalTransaction()
        {
            try
            {
                rentalTransactionInformation =
                    XmlUtility.DeserializeObjectFromDisk<RentalTransactionInformation>(RentalTransactionFile);
            }
            catch (Exception err)
            {
                throw new RentalSystemException(
                    "Невозможно считать с диска информацию о прерванной транзакции оплаты аренды.", err);
            }


            if (rentalTransactionInformation == null)
            {
                return;
            }

            if (rentalTransactionInformation.RentalPaymentInfos.Count == 0)
            {
                InitializeRentalPayments();
                SaveRentalInformationToDisk();
            }
            if (!rentalTransactionInformation.IsFeeRecordInserted)
            {
                RentalFeeService.InsertRentalFeeRecord(rentalTransactionInformation.PlaceNumber,
                                                       rentalTransactionInformation.TotalMoneyAmmount);
                rentalTransactionInformation.IsFeeRecordInserted = true;
                SaveRentalInformationToDisk();
            }
            if (!rentalTransactionInformation.IsRecepiePrinted)
            {
                FiscalRegister.PrintRentalReceipt(rentalTransactionInformation.RentalPaymentInfos);
            }

            rentalTransactionInformation = null;
            ClearTransactionInfo(RentalTransactionFile);
        }

        private void CloseServiceTransaction()
        {
            try
            {
                serviceTransactionInformation =
                    XmlUtility.DeserializeObjectFromDisk<ServiceTransactionInformation>(ServiceTransactionFile);
            }
            catch (Exception err)
            {
                throw new RentalSystemException(
                    "Ошибка при обработке прерванной транзакции. Невозможно считать информацию о транзакции для прочих услуг или услуг парковки.",
                    err);
            }

            try
            {
                ParkingTicketInfo parkingInfo = null;
                ServiceInformation parkingServiceInfo = ServicesService.GetServiceInformationAboutParkingPerHour();

                /// проверка : транзакция по парковке
                if (parkingServiceInfo.Id == serviceTransactionInformation.ServiceId)
                {
                    // достаём информацию о парковке с диска
                    try
                    {
                        parkingInfo = XmlUtility.DeserializeObjectFromDisk<ParkingTicketInfo>(ParkingInfoFile);
                        if (parkingInfo == null) throw new RentalSystemException();
                    }
                    catch (Exception err)
                    {
                        throw new RentalSystemException("Ошибка при обработке прерванной транзакции.\nНевозможно считать информацию о парковке.\nИнформация о платеже по парковке не может быть сохранена в БД.", err);
                    }
                }

                if (!serviceTransactionInformation.IsFeeRecordInserted)
                {
                    var servicePayment = RentalFeeService.InsertServiceFeeRecord(
                        serviceTransactionInformation.ServiceId,
                        serviceTransactionInformation.Price,
                        serviceTransactionInformation.Fee,
                        serviceTransactionInformation.PlaceNumber);

                    if (parkingInfo != null)
                    {
                        ParkingService.BindParkingTicketWithPayments(parkingInfo, servicePayment);

                        if ((parkingInfo.EarlyPaidSum + servicePayment.PaidSum) >= parkingInfo.TotalSum)
                        {
                            parkingInfo.InternalId = CommonHelper.GetInternalPackedTicketId(parkingInfo.Number,
                                                                                            parkingInfo.DateTo);
                            ParkingService.CloseParkingTicket(parkingInfo);
                        }
                    }

                    serviceTransactionInformation.IsFeeRecordInserted = true;
                }

                if (!serviceTransactionInformation.IsRecepiePrinted)
                {
                    if (string.IsNullOrEmpty(serviceTransactionInformation.PlaceNumber))
                    {
                        if (parkingInfo == null) // просто услуга
                        {
                            FiscalRegister.PrintAdditionalServiceReceipt(serviceTransactionInformation.ServiceName,
                                                                         serviceTransactionInformation.Price,
                                                                         serviceTransactionInformation.Fee);
                        }
                        else // парковка
                        {
                            FiscalRegister.PrintAdditionalServiceReceiptEx(
                                parkingServiceInfo.Name,
                                parkingInfo.TotalSum,
                                serviceTransactionInformation.Fee,
                                parkingInfo.ExtInfo4Check);
                        }
                    }
                    else
                    {
                        FiscalRegister.PrintAdditionalServiceReceiptEx(
                            serviceTransactionInformation.ServiceName,
                            serviceTransactionInformation.Price,
                            serviceTransactionInformation.Fee,
                            new[]
                                {
                                    "Место №" +
                                    serviceTransactionInformation.
                                        PlaceNumber
                                });
                    }
                }

                serviceTransactionInformation = null;
                ClearTransactionInfo(ParkingInfoFile);
                ClearTransactionInfo(ServiceTransactionFile);
            }
            catch (Exception)
            {
                SaveServiceInformationToDisk();
                throw;
            }
        }

        /// <summary>
        /// Begins the rental transaction.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="placeNumber">The place number.</param>
        public void BeginRentalTransaction(string contractNumber, string placeNumber)
        {
            rentalTransactionInformation = new RentalTransactionInformation
                                               {
                                                   ContractNumber = contractNumber,
                                                   PlaceNumber = placeNumber
                                               };

            ClearTransactionInfo(RentalTransactionFile);
        }

        /// <summary>
        /// Ends the rental transaction.
        /// </summary>
        public void EndRentalTransaction()
        {
            if (rentalTransactionInformation == null)
            {
                return;
            }

            if (rentalTransactionInformation.TotalMoneyAmmount != 0)
            {
                InitializeRentalPayments();
                SaveRentalInformationToDisk();

                RentalFeeService.InsertRentalFeeRecord(rentalTransactionInformation.PlaceNumber,
                                                       rentalTransactionInformation.TotalMoneyAmmount);
                rentalTransactionInformation.IsFeeRecordInserted = true;
                SaveRentalInformationToDisk();

                FiscalRegister.PrintRentalReceipt(rentalTransactionInformation.RentalPaymentInfos);
            }

            rentalTransactionInformation = null;
            ClearTransactionInfo(RentalTransactionFile);
        }

        /// <summary>
        /// Proceeds the rental payment.
        /// </summary>
        /// <param name="depositAmmount">The deposit ammount.</param>
        public void ProceedRentalPayment(decimal depositAmmount)
        {
            rentalTransactionInformation.TotalMoneyAmmount += depositAmmount;
            SaveRentalInformationToDisk();
        }

        /// <summary>
        /// Begins the service transaction.
        /// </summary>
        public void BeginServiceTransaction(string placeNumber)
        {
            serviceTransactionInformation = new ServiceTransactionInformation
                                                {
                                                    PlaceNumber = placeNumber
                                                };

            ClearTransactionInfo(ServiceTransactionFile);
        }

        /// <summary>
        /// Ends the service transaction.
        /// </summary>
        public void EndServiceTransaction()
        {
            try
            {
                if (serviceTransactionInformation == null)
                {
                    return; /// магия
                }

                if (serviceTransactionInformation.Fee != 0)
                {
                    RentalFeeService.InsertServiceFeeRecord(serviceTransactionInformation.ServiceId,
                                                            serviceTransactionInformation.Price,
                                                            serviceTransactionInformation.Fee,
                                                            serviceTransactionInformation.PlaceNumber);

                    serviceTransactionInformation.IsFeeRecordInserted = true;

                    if (string.IsNullOrEmpty(serviceTransactionInformation.PlaceNumber))
                    {
                        FiscalRegister.PrintAdditionalServiceReceipt(serviceTransactionInformation.ServiceName,
                                                                     serviceTransactionInformation.Price,
                                                                     serviceTransactionInformation.Fee);
                    }
                    else
                    {
                        FiscalRegister.PrintAdditionalServiceReceiptEx(serviceTransactionInformation.ServiceName,
                                                                       serviceTransactionInformation.Price,
                                                                       serviceTransactionInformation.Fee,
                                                                       new[]
                                                                           {
                                                                               "Место №" +
                                                                               serviceTransactionInformation.
                                                                                   PlaceNumber
                                                                           });
                    }
                }

                ClearTransactionInfo(ServiceTransactionFile);
            }
            catch (Exception)
            {
                SaveServiceInformationToDisk();
                throw;
            }
        }

        private static void ClearTransactionInfo(string transactionInfoFileName)
        {
            if (File.Exists(transactionInfoFileName))
            {
                File.Delete(transactionInfoFileName);
            }
        }


        public void EndParkingServiceTransaction()
        {
            serviceTransactionInformation = null;
            ClearTransactionInfo(ServiceTransactionFile);
            ClearTransactionInfo(ParkingInfoFile);
        }


        /// <summary>
        /// Proceeds the service payment.
        /// </summary>
        /// <param name="serviceId">The service id.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="price">The price.</param>
        /// <param name="depositAmmount">The deposit ammount.</param>
        public void ProceedServicePayment(int serviceId, string serviceName, decimal price, decimal depositAmmount)
        {
            serviceTransactionInformation.ServiceName = serviceName;
            serviceTransactionInformation.Price = price;
            serviceTransactionInformation.ServiceId = serviceId;
            serviceTransactionInformation.Fee += depositAmmount;
            SaveServiceInformationToDisk();
        }

        #endregion

        #region Private Methods

        public void SaveServiceInformationToDisk()
        {
            XmlUtility.SerializeObjectToDisk(ServiceTransactionFile, serviceTransactionInformation);
        }

        private void SaveRentalInformationToDisk()
        {
            XmlUtility.SerializeObjectToDisk(RentalTransactionFile, rentalTransactionInformation);
        }

        private void InitializeRentalPayments()
        {
            List<PayDateInformation> payDatesInformation =
                RentalFeeService.GetPayDates(rentalTransactionInformation.ContractNumber,
                                             rentalTransactionInformation.PlaceNumber);
            int currentDay = 0;
            decimal totalSum = 0;
            if (payDatesInformation[currentDay].IsPartialyPaid)
            {
                totalSum = payDatesInformation[currentDay].PaidAmount;
            }
            totalSum += rentalTransactionInformation.TotalMoneyAmmount;
            while (totalSum > 0)
            {
                DayRentalPaymentInfo paymentInfo = new DayRentalPaymentInfo
                                                       {
                                                           PlaceNumber = rentalTransactionInformation.PlaceNumber,
                                                           Date = payDatesInformation[currentDay].Date,
                                                           Price = payDatesInformation[currentDay].Rate
                                                       };

                if (currentDay == payDatesInformation.Count - 1)
                {
                    paymentInfo.PaidSum = totalSum;
                    //removes partialy paid sum from pay bill
                    if (payDatesInformation[currentDay].IsPartialyPaid)
                    {
                        paymentInfo.PaidSum -= payDatesInformation[currentDay].PaidAmount;
                    }
                    rentalTransactionInformation.RentalPaymentInfos.Add(paymentInfo);
                    break;
                }

                paymentInfo.PaidSum = totalSum >= payDatesInformation[currentDay].Rate
                                          ? payDatesInformation[currentDay].Rate
                                          : totalSum;

                //removes partialy paid sum from pay bill
                if (payDatesInformation[currentDay].IsPartialyPaid)
                {
                    paymentInfo.PaidSum -= payDatesInformation[currentDay].PaidAmount;
                }

                rentalTransactionInformation.RentalPaymentInfos.Add(paymentInfo);

                totalSum -= payDatesInformation[currentDay].Rate;
                if (currentDay < payDatesInformation.Count - 1)
                {
                    currentDay++;
                }
            }
        }

        #endregion
    }
}