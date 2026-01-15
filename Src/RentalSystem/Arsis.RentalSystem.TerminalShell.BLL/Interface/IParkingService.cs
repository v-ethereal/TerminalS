using System;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
	public interface IParkingService
	{
		/// <summary>
		/// Создание нового парковочного талона
		/// </summary>
		/// <param name="isLoss">true - признак утери старого парковочного талона, false - нормальное создание</param>
		/// <param name="user">администратор зала создавший новый талон</param>
		ParkingTicketInfo CreateParkingTicket(bool isLoss, User user);

        /// <summary>
        /// Создание нового парковочного талона, для версии с кардридером
        /// </summary>
        /// <param name="parkingCardNumber">номер парковочной карты - получаем из карты</param>
        /// <param name="entranceDate">дата заезда - получаем из карты</param>
        /// <returns></returns>
	    ParkingTicketInfo CreateParkingTicket(int parkingCardNumber, DateTime entranceDate);


		/// <summary>
        /// Вяжем парковочную карту и платежи по этой карте
		/// </summary>
		/// <param name="parking">инфо о парковке</param>
		/// <param name="servicePayment">инфо о платеже по этой парковке</param>
		/// если стоимость парковки меньше или равно платежу по этой парковке, то парковочный талон "закрывается"
		void BindParkingTicketWithPayments(ParkingTicketInfo parking, ServicePayment servicePayment);



		/// <summary>
		/// Получение парковочного талона по расширенному номеру
		/// </summary>
		/// <param name="internalParkingTicketNumber">расширенный номер парковочного талона, считанный сканером или введенный вручную</param>
		/// вгутренний номер талона - это дата заезда + номер в пределах часа 2807091254 + 1
		/// <returns>информация о парковочном талоне</returns>
		ParkingTicketInfo GetParkingTicket(string internalParkingTicketNumber);

        /// <summary>
        /// Фиксирование в БД даты реального выезда с разгрузочной парковки, \
        /// - устанавливается для неоплаченных (оплата на парктайме), 
        /// - частично оплаченных, 
        /// - полностью оплаченных
        /// </summary>
        /// <param name="parkingTicketInfo">инфо о парковке</param>
	    void SetDateTo(ParkingTicketInfo parkingTicketInfo);


        /// <summary>
        /// "Закрыть" парковочную карту => прописать новый InternalId и установить дату выезда
        /// </summary>
        /// <param name="parkingTicketInfo">инфо о карте</param>
	    void CloseParkingTicket(ParkingTicketInfo parkingTicketInfo);
    }

}
