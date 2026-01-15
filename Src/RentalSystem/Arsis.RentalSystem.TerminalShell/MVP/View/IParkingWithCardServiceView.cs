using System;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
    public interface IParkingWithCardServiceView : IView
    {
        /// <summary>
        /// событие - нажатие кнопки "Назад"
        /// </summary>
        event EventHandler BackEvent;

        /// <summary>
        /// нажатие кнопки "Оплатить на терминале"
        /// </summary>
        event EventHandler PayLocal;

        /// <summary>
        ///  нажатие кнопки "Оплатить на внешнем терминале"
        /// </summary>
        event EventHandler PayExternal;

        /// <summary>
        /// редирект ту страница оплаты на локальном  терминале
        /// </summary>
        void RedirectToPayLocal(ParkingTicketInfo parkingTicketInfo);

        /// <summary>
        /// вернуться на страницу назад
        /// </summary>
        void RedirectBack();

        /// <summary>
        /// показать информацию по парковке
        /// </summary>
        /// <param name="parkingTicketInfo">парковка</param>
        void ShowParkingTicketInfo(ParkingTicketInfo parkingTicketInfo);

        /// <summary>
        ///  переход на окно напоминание про карту
        /// </summary>
        void RedirectToTakeParkingCardSuggestionPage(bool redirectTakeRecepieSuggestionPage);


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
