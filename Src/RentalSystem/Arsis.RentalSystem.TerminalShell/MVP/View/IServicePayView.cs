using System;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
	public interface IServicePayView
	{
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
		/// Задать содержимое поля "уже оплачено", "необходимо доплатить"
		/// </summary>
		/// <param name="feeAmount">сумма денег полученных</param>
		/// <param name="needAmount">сумма денег которые необходимо доплатить чтоб закрыть полностью платёж</param>
		/// рассчитывается как тариф - feeAmount
		void SetMoneyAmount(int feeAmount, int needAmount);

		/// <summary>
		///  Обновление UI после получения денежки
		/// </summary>
		void UpdateGui();

		/// <summary>
		///  Переход на страницу про  чек
		/// </summary>
        void RedirectOnTakePage(bool redirectToTakeRecepieSuggestionPage);


		/// <summary>
		///  Переход на страницу уровнем выше
		/// </summary>
		void RedirectOnParentPage();

		/// <summary>
		/// Показываем информацию о услуге
		/// </summary>
		/// <param name="serviceInformation">информация о услуге</param>
		void ShowServiceInfo(ServiceInformation serviceInformation);

        /// <summary>
        /// Выключение кнопки оплатить, чтоб не нажали два раза
        /// </summary>
        void DisablePayButton();
	}
}
