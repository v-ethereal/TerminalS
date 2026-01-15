using System;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
	public interface IView
	{
        /// <summary>
        /// показать сообщение 
        /// </summary>
        /// <param name="message">сообщение</param>
		void ShowMessage(string message);

        /// <summary>
        /// показать сообщение об ошибке
        /// </summary>
        /// <param name="err">ошибка</param>
		void ShowErrorMessage(Exception err);

        /// <summary>
        /// событие открытие формы
        /// </summary>
        event EventHandler LoadedViewEvent;

        /// <summary>
        ///  событие закрытие формы
        /// </summary>
        event EventHandler ClosedViewEvent;
	}
}