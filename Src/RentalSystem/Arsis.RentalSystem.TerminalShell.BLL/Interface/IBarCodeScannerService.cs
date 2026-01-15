using System;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
	public interface IBarCodeScannerService
	{
		/// <summary>
		/// тип получаемого значения 
		/// </summary>
		BarCodeTypeEnum BarCodeType { get; set; }

		/// <summary>
		/// включить ожидание значение от считывателя штрих кодов
		/// </summary>
		void Start();

		/// <summary>
		/// остановить считывающий поток 
		/// </summary>
		void Stop();

		/// <summary>
		/// событие - получение значения
		/// </summary>
		event EventHandler<BarCodeScannerEventArgs> BarCodeReceiveEvent;

		/// <summary>
		///  событие - получение ошибки
		/// </summary>
		event EventHandler<TerminalDeviceErrorEventArgs> BarCodeScannerErrorEvent;

		/// <summary>
		/// Об null ение обработчиков для всех событий
		/// </summary>
		void ClearEventHandlers();
	}

	public enum BarCodeTypeEnum
	{
		TicketNumber,
		AccessCode
	}

	public class TerminalDeviceErrorEventArgs : EventArgs {
		public TerminalDeviceErrorEventArgs(Exception e)
		{
			TerminalDeviceException = e;
		}

		public Exception TerminalDeviceException
		{
			get; set;
		}
	}

	public class BarCodeScannerEventArgs : EventArgs
	{
		public string BarCode { get; set; }
		public BarCodeScannerEventArgs(string barCode)
		{
			BarCode = barCode;
		}
	}
}