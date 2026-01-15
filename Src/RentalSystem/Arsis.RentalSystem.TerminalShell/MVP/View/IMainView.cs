using System;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
	public interface IMainView : IView
	{
        /// <summary>
        /// функция оплаты парковки доступна
        /// </summary>
        bool ParkingEnable { get; }
        
		/// <summary>
		/// событие нажатие кнопки "Разгрузка"
		/// </summary>
		event EventHandler<EventArgs> ParkingServiceButtonClickEvent;

		/// <summary>
		/// событие нажатия кнопки "Оплата аренды"
		/// </summary>
		event EventHandler<EventArgs> RentalServiceButtonClickEvent;

		/// <summary>
		/// событие нажатия кнопки "прочие услуги"
		/// </summary>
		event EventHandler<EventArgs> OtherServiceButtonClickEvent;


		/// <summary>
		/// событие нажатия кнопки "вход для админа"
		/// </summary>
		event EventHandler<EventArgs> AdminLoginButtonClickEvent;


		/// <summary>
		/// Переход на страницу оплаты по парковочному талону
		/// </summary>
		/// <param name="parkingTicketInfo">парковочный талон</param>
		void RedirectToParkingPerHourPayPage(ParkingTicketInfo parkingTicketInfo);

		/// <summary>
		/// переход на страницу парковки
		/// </summary>
		void RedirectToParkingServicePage();


		/// <summary>
		/// переход на оплаты аренды
		/// </summary>
		void RedirectToRentalServicePage();

		/// <summary>
		/// переход на страницу оплаты прочих услуг
		/// </summary>
		void RedirectToOtherServicePage();

		/// <summary>
		/// переход на страницу для админа
		/// </summary>
		void RedirectToAdminLoginPage();
	}

}
