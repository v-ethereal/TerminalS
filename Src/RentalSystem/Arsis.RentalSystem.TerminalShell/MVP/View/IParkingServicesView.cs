using System;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
	/// <summary>
	/// интерфейс страницы функций парковки
	/// </summary>
	public interface IParkingServicesView : IView
	{
		/// <summary>
		/// Показать / спрятать сообщение о необходимости авторизации true - показать, false - спрятать
		/// </summary>
		void ShowAuthorizationRequestMessage(bool showLabel);

	
		/// <summary>
		/// перенаправить на страницу оплаты по талону parkingTicketInfo
		/// </summary>
		/// <param name="parkingTicketInfo">парковочный талон</param>
		void RedirectToPayPage(ParkingTicketInfo parkingTicketInfo);

		/// <summary>
		/// перенаправить на страницу получения чека
		/// </summary>
		void RedirectToTakeRecepieSuggestionPage();

		/// <summary>
		/// перенаправить на страницу ввода номера талона в ручную
		/// </summary>
		void RedirectToParkingTicketInputPage();

		/// <summary>
		///  перенаправить на страницу оплаты парковки без учёта времени
		/// </summary>
		/// <param name="userInfo"></param>
		void RedirectToParkingWithoutTimePayPage(User userInfo);

		/// <summary>
		/// перенаправить на главную страницу
		/// </summary>
		void RedirectToMainPage();

		/// <summary>
		/// событие генерируемое при запросе получения нового парковочного талона
		/// </summary>
		event EventHandler<EventArgs> CreateParkingTicketEvent;

		/// <summary>
		/// событие возврата на главную страницу приложения
		/// </summary>
		event EventHandler<EventArgs> BackEvent;

		/// <summary>
		/// событие запроса страницы оплаты парковки без учёта времени
		/// </summary>
		event EventHandler<EventArgs> PayUnderParkingWithoutTimeEvent;

		/// <summary>
		/// событие запроса страницы для ввода номера талона
		/// </summary>
		event EventHandler<EventArgs> InputParkingTicketNumberEvent;
	}
}
