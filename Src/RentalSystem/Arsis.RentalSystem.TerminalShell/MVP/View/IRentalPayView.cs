using System;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
    public interface IRentalPayView : IView
    {
        /// <summary>
        /// информация об арендуемом торговом месте
        /// </summary>
        RentalPlaceInformation RentalPlaceInformation { get; }

        /// <summary>
        ///  получено денег за текущий сеанс оплаты
        /// </summary>
        int FeeAmount { get; set; }

        /// <summary>
        /// Текущая стоимость аренды торгового места (для каждого дня она типа может быть своя ?)
        /// </summary>
        int Rate { get; set; }

        /// <summary>
        /// Показать информацию об арендуемом торговом месте
        /// </summary>
        /// <param name="rentalPlaceInformation">инфо о торговом месте</param>
        void InitView(RentalPlaceInformation rentalPlaceInformation);

        /// <summary>
        /// показать диалог "заберите чек"
        /// </summary>
        void ShowAlertTakeCheck();

        /// <summary>
        /// Показываем сообщение "Внимание"
        /// </summary>
        /// <param name="messages">массив строк</param>
        void ShowAttentionMessage(string[] messages);

        /// <summary>
        /// событие нажатия кнопки "оплатить"
        /// </summary>
        event EventHandler<EventArgs> FinishPayEvent;

        /// <summary>
        /// событие нажатия кнопки "назад"
        /// </summary>
        event EventHandler<EventArgs> BackButtonEvent;

        /// <summary>
        /// Обновить прогресс бар на значение только что полученной денежки
        /// </summary>
        /// <param name="moneyAmount">полученная денежка</param>
        void UpdateProgressBar(int moneyAmount);

        /// <summary>
        /// возврат к главному окну программы
        /// </summary>
        void RedirectOnParentPage();

        /// <summary>
        /// Выключение кнопки оплатить, чтоб не нажали два раза
        /// </summary>
        void DisablePayButton();
    }
}
