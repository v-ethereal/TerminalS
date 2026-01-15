using System;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface ICardReaderService
    {
        /// <summary>
        /// признак того, что ридер уже был запущен (подключен)
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// читать или нет карту при ее появлении в ридере
        /// нужно для отключения чтения карты при импорте тарифов (иначе будет ошибка - не системная карта)
        /// </summary>
        bool ReadCardOnPresent { get; set; }

        /// <summary>
        /// признак наличия карты в картридере
        /// </summary>
        bool IsCardPresent { get; }

        /// <summary>
        /// номер карточки
        /// </summary>
        int? CardNumber { get; }

        /// <summary>
        /// дата въезда
        /// </summary>
        DateTime? EntranceDate { get; }

        /// <summary>
        /// импортирует мастер-карту (тариф)
        /// </summary>
        /// <param name="tariffNumber">номер тарифа</param>
        void ImportTariff(int tariffNumber);

        /// <summary>
        /// записать новый тариф на карту
        /// </summary>
        /// <param name="rewriteEntranceDate">перезаписать дату въезда</param>
        /// <param name="tariffNumber">тариф Id</param>
        void WriteTariff(bool rewriteEntranceDate, int tariffNumber);


        /// <summary>
        ///  событие карта в кардридере
        /// </summary>
        event EventHandler<EventArgs> CardPresentEvent;


        /// <summary>
        /// exception в кардридере
        /// </summary>
        event EventHandler<CardReaderExceptionEventArgs> CardReaderErrorEvent;


        /// <summary>
        /// начать работу с картридером
        /// </summary>
        void Start(string port);

        /// <summary>
        /// прекратить работу с кардридером
        /// </summary>
        void Stop();


        /// <summary>
        /// выплюнуть карту
        /// </summary>
        void EjectCard();
    }

    public class CardReaderExceptionEventArgs : EventArgs
    {
        public Exception Error { get; set; }
    }
}