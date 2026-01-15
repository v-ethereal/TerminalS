using System;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
	public interface IParkingPerHourView : IServicePayView, IView
	{
		/// <summary>
		/// Парковочный талон
		/// </summary>
		ParkingTicketInfo ParkingTicketInfo { get; }

		/// <summary>
		/// Показать информацию о парковочном талоне
		/// </summary>
		/// <param name="parkingTicketInfo"></param>
		void ShowParkingTicketInfo(ParkingTicketInfo parkingTicketInfo);

        /// <summary>
        /// показать диалог "заберите карту"
        /// </summary>
        void ShowAlertTakeParkingCard();

        /// <summary>
        /// показать диалог "заберите чек"
        /// </summary>
        void ShowAlertTakeCheck();

        /// <summary>
        /// событие возникающее после закрытия диалога про карту
        /// </summary>
        event EventHandler ShowAlertTakeParkingCardEvent;

	    /// <summary>
	    /// событие возникающее после закрытие диалога про чек
	    /// </summary>
	    event EventHandler ShowAlertTakeCheckEvent;
	}
}