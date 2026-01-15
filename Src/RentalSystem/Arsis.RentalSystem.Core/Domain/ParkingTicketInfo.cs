using System;
using System.Collections.Generic;

namespace Arsis.RentalSystem.Core.Domain
{
    /// <summary>
    /// информация о парковке
    /// </summary>
    public class ParkingTicketInfo
    {
        #region properties


        /// <summary>
        /// id парковочной записи = id в таблице parkings
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  начало парковки - дата заезда
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// окончание парковки  - дата выезда
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        ///  цена парковки за 1 час
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// цена парковки сверх лимитированного временни
        /// </summary>
        public decimal CostWithoutTime { get; set; }

        /// <summary>
        /// составной логический ключ 
        /// дата и время заеда + номер парк. карты (HEX) 
        /// формат DDMMYYHHmm_XXXXXXXX
        /// </summary>
        public string InternalId { get; set; }

        /// <summary>
        /// <summary>
        /// номер парковочной карты 
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// минимальное количество тарифицируемых часов
        /// Значение 4 - если продолжительность парковки < = 4, то стоимость парковки = продолжительность * CostPerHour,
        /// иначе иначе стоимость парковки = CostWithoutTime
        /// </summary>
        public int TariffParkingHours { get; set; }

        
        /// <summary>
        /// продолжительность парковки в часах
        /// </summary>
        public int ParkingDuration
        {
            get
            {
                double parkingHourDouble = (DateTo - DateFrom).TotalHours;
                int parkingDuration = (int) parkingHourDouble;

                if (parkingHourDouble > 1)
                {
                    return parkingDuration + 1;
                }

                return 1;
            }
        }

        /// <summary>
        /// итоговая стоимость парковки
        /// </summary>
        public decimal TotalSum
        {
            get
            {
                decimal totalSumma;
                if (ParkingDuration <= TariffParkingHours)
                {
                    totalSumma = ParkingDuration*CostPerHour;
                }
                else
                {
                    totalSumma = CostWithoutTime;
                }

                return totalSumma;
            }
        }

        /// <summary>
        /// сумма оплаченная ранее по этой парковочной карте
        /// вычисляется из вне
        /// </summary>
        public decimal EarlyPaidSum { get; set; }



        /// <summary>
        /// набор строк для печати на чек
        /// </summary>
        public List<String> ExtInfo4Check
        {
            get
            {
                return new List<string>
                           {
                               "Парковочная карта №" + Number.ToString("X8"),
                               "Время заезда:" + DateFrom,
                               "Время оплаты:" + DateTo,
                               "Длительность:" + ParkingDuration
                           };
            }
        }

        /// <summary>
        ///  признак карта закрыта
        /// </summary>
        public bool IsClose
        {
            get { return EarlyPaidSum >= TotalSum; }
        }

        #endregion

        #region constructor

        public ParkingTicketInfo(Parking parking, int tariffParkingHours)
        {
            Id = parking.Id;
            DateFrom = parking.DateFrom;
            DateTo = (parking.DateTo.HasValue) ? parking.DateTo.Value : DateTime.Now;
            CostPerHour = parking.CostPerHour;
            CostWithoutTime = parking.CostWithoutTime;
            InternalId = parking.InternalId;
            Number = parking.Number;

            TariffParkingHours = tariffParkingHours;
        }

        public ParkingTicketInfo(Parking parking, int tariffParkingHours, decimal paidSumm)
        {
            Id = parking.Id;
            DateFrom = parking.DateFrom;
            DateTo = (parking.DateTo.HasValue) ? parking.DateTo.Value : DateTime.Now;
            CostPerHour = parking.CostPerHour;
            CostWithoutTime = parking.CostWithoutTime;
            InternalId = parking.InternalId;
            Number = parking.Number;
            EarlyPaidSum = paidSumm;

            TariffParkingHours = tariffParkingHours;
        }

        public ParkingTicketInfo()
        {
        }
        #endregion
    }
}