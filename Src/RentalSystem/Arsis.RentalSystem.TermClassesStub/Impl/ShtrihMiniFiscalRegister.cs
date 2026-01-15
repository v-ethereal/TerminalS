using System;
using System.Collections.Generic;
using System.Text;
using TermClasses;

namespace Arsis.RentalSystem.TermClassesStub.Impl
{
    public class ShtrihMiniFiscalRegister : ITerminalFiscalRegister
    {
        public void Initialize()
        {
            //throw new ApplicationException("Initialize error!");
        }

        public void PrintRentalReceipt(IList<DayRentalPaymentInfo> paymentsInfo)
        {
            Console.WriteLine("Вывод отчета.");
        }

        public void PrintAdditionalServiceReceipt(string serviceName, decimal servicePrice, decimal paidSum)
        {
            Console.WriteLine(string.Format("Услуга:{0}\nСтоимость услуги:{1}\nОплачено:{2}", serviceName, servicePrice, paidSum));
        }

        public void PrintUnpaidRentalPlacesReport(DateTime controlDate, IList<string> unpaidPlaces)
        {
            Console.WriteLine("Вывод отчета.");
        }

        public void PrintXReport()
        {
            Console.WriteLine("Вывод отчета.");
        }

        public void PrintZReport()
        {
            Console.WriteLine("Вывод отчета.");
        }

        public void PrintShiftSummaryReport(string terminalName, IList<ServiceShiftSummaryInfo> servicesShiftInfo)
        {
            Console.WriteLine("Вывод отчета.");
        }

        public void PrintParkingToken(DateTime startDate, string barCode, decimal price, decimal penalty)
        {
            Console.WriteLine(string.Format("Дата заезда: {0}\nШтрих-код: {1}\nСтоимость парковки за 1 час: {2}\nСтоимость парковки при утере парковочного талона: {3}", startDate, barCode, price, penalty));
        }

        public void PrintParkingExitTicket(string cardNumber, DateTime startDate, DateTime finishDate, bool externalPayment, decimal paidSum)
        {
            Console.WriteLine(string.Format("Номер карты: {0}\nВремя заезда: {1}\nВремя оплаты: {2}\nБадет оплачена на паркомате: {3}\nОплачено: {4}", cardNumber, startDate, finishDate, externalPayment, paidSum));
        }

        public void PrintParkingPerHourReceipt(string parkingTicketNumber, DateTime startDate, DateTime endDate, decimal servicePrice, decimal needPaySum, decimal realPaySum)
        {
            Console.WriteLine(string.Format("Номер парковочного талона: {0}\nДата заезда: {1}\n Дата выезда:{2}\nСтоимость парковки за 1 час: {3}\nСтоимость парковки при утере парковочного талона: {3}\nИтого:{4}\nОплачено: {5}", parkingTicketNumber, startDate, endDate, servicePrice, needPaySum, realPaySum));
        }

        public void PrintParkingWithoutTimeReceipt(decimal servicePrice, decimal realPaySum)
        {
            Console.WriteLine(string.Format("Оплата парковки без учёта времени. Дата:{0}\nТариф парковки без учёта времени:{1}\nОплачено: {2}", DateTime.Now, servicePrice, realPaySum));
        }

        public void PrintAdditionalServiceReceiptEx(string serviceName, decimal servicePrice, decimal paidSum, IList<string> infoItems)
        {
            ///infoItems[0] - "Парковочный талон №"
            ///infoItems[1] - значение
            ///infoItems[2] - "Дата заезда:"
            ///infoItems[3] - значение
            ///infoItems[4] - "Дата выезда:"
            ///infoItems[5] - значение
            ///infoItems[6] - "Продолжительность стоянки:"
            ///infoItems[7] - значение

            StringBuilder temp = new StringBuilder().AppendFormat("Услуга: {0}\nСтоимость парковки:{1}\nОплачено:{2}\n",serviceName, servicePrice, paidSum);

            if (infoItems != null)
            {
                for (int i = 0; i < infoItems.Count; i++)
                {
                    temp.AppendFormat("{0}", infoItems[i]);

                    if ((i + 1) % 2 == 0)
                    {
                        temp.AppendFormat("\n");
                    }
                }
            }

            Console.WriteLine(temp.ToString());
        }

        public void PrintAccessCode(string accessCode)
        {
            Console.WriteLine(accessCode);
        }
    }
}