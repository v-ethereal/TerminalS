using System;
using System.Threading;

using Arsis.RentalSystem.TerminalShell.BLL.Interface;

using log4net;

using TermClasses;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public enum BarCodeWaitMode
	{
		Number,
		AccessCode
	}

	public class BarCodeScannerService : IBarCodeScannerService
	{
		private readonly ILog logger = LogManager.GetLogger("GeneralAppender");
		private Thread waitThread;
		private bool internalBreakOperation;

		#region IBarCodeScannerService

		public BarCodeTypeEnum BarCodeType { get; set; }

		public void Start()
		{
			waitThread = new Thread(WaitMethod) { IsBackground = true, Name = "WaitBarCodeThread" };

			BarCodeType = BarCodeTypeEnum.TicketNumber;

			if (waitThread.IsAlive)
			{
				return;
			}
			waitThread.Start();
		}

		public void Stop()
		{
			BarCodeReceiveEvent = null;
			BarCodeScannerErrorEvent = null;

			internalBreakOperation = true;

			while (waitThread.IsAlive) {}
		}

		public void ClearEventHandlers()
		{
			BarCodeReceiveEvent = null;
			BarCodeScannerErrorEvent = null;
		}

		public event EventHandler<BarCodeScannerEventArgs> BarCodeReceiveEvent;
		public event EventHandler<TerminalDeviceErrorEventArgs> BarCodeScannerErrorEvent;

		#endregion

		public ITerminalBarCodeScanner BarCodeScanner { get; set; }

		private void WaitMethod()
		{
			try
			{
				do
				{
					string barCode = BarCodeScanner.AcceptBarCode(ref internalBreakOperation);
					if (!String.IsNullOrEmpty(barCode) && BarCodeReceiveEvent != null)
					{
						BarCodeReceiveEvent(this, new BarCodeScannerEventArgs(barCode));
					}
				}
				while (!internalBreakOperation);
			}
			catch (Exception e)
			{
				logger.Error(e.Message, e);

				if (BarCodeScannerErrorEvent != null)
				{
					BarCodeScannerErrorEvent(this, new TerminalDeviceErrorEventArgs(e));
				}
			}
		}
	}
}