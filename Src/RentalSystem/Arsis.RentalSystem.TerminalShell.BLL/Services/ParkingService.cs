using System;
using System.Linq;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class ParkingService : BaseService, IParkingService
	{
		public ParkingTicketInfo CreateParkingTicket(bool isLoss, User user)
		{
			DateTime now = DateTime.Now;

			int parkingTicketNumber = Dal.GetParkingTicketNumber();

			var pricePerHour = Dal.GetParkingPerHourPrice();
			if (pricePerHour == 0)
			{
				throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'", "почасовая парковка"));
			}

			var priceWithoutTime = Dal.GetParkingWithoutTimePrice();
			if (priceWithoutTime == 0)
			{
				throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
				                                              "почасовая без учёта времени"));
			}

            string internalId = CommonHelper.GetInternalPackedTicketId(parkingTicketNumber + 1, now);
            

			Parking parking = Dal.CreateParking(parkingTicketNumber + 1,
			                                    now,
			                                    isLoss,
			                                    pricePerHour,
			                                    priceWithoutTime,
			                                    internalId,
			                                    user != null ? user.Id : (int?)null);

			var tariffHours = Dal.GetTariffParkingHours();

			return new ParkingTicketInfo(parking, tariffHours);
		}

	    public ParkingTicketInfo CreateParkingTicket(int parkingCardNumber, DateTime entranceDate)
	    {
            var pricePerHour = Dal.GetParkingPerHourPrice();
            if (pricePerHour == 0)
            {
                throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'", "почасовая парковка"));
            }

            var priceWithoutTime = Dal.GetParkingWithoutTimePrice();
            if (priceWithoutTime == 0)
            {
                throw new RentalSystemException(string.Format("Отсутствует прайс лист для услуги '{0}'",
                                                              "почасовая без учёта времени"));
            }

	        string internalId = CommonHelper.GetInternalPackedTicketId(parkingCardNumber, entranceDate);

            Parking parking = Dal.CreateParking(parkingCardNumber,
                                                entranceDate,
                                                false,
                                                pricePerHour,
                                                priceWithoutTime,
                                                internalId,
                                                null);

            var tariffHours = Dal.GetTariffParkingHours();

            return new ParkingTicketInfo(parking, tariffHours);
	    }

	    public void BindParkingTicketWithPayments(ParkingTicketInfo parkingInfo, ServicePayment servicePayment)
		{
			Dal.BindParkingServicePayment(parkingInfo, servicePayment);

			if ((parkingInfo.EarlyPaidSum + servicePayment.PaidSum) >= parkingInfo.TotalSum)
			{
				Dal.SetParkingDateTo(parkingInfo);
			}
		}

		public ParkingTicketInfo GetParkingTicket(string internalParkingTicketNumber)
		{
			var parking = Dal.GetParking(internalParkingTicketNumber);

			if (parking == null)
			{
				return null;
			}

			var tariffHours = Dal.GetTariffParkingHours();

			var earlyPaidSum = parking.ParkingServicePayments.Sum(item => item.ServicePayment.PaidSum);

			ParkingTicketInfo parkingInfo = new ParkingTicketInfo(parking, tariffHours)
			                                	{
			                                			EarlyPaidSum = earlyPaidSum
			                                	};

			return parkingInfo;
		}

	    public void SetDateTo(ParkingTicketInfo parkingTicketInfo)
	    {
	        Dal.SetParkingDateTo(parkingTicketInfo);
	    }

	    public void CloseParkingTicket(ParkingTicketInfo parkingTicketInfo)
	    {
	        Dal.CloseParkingTicket(parkingTicketInfo);
	    }
	}
}