using System;

namespace Arsis.RentalSystem.TerminalShell.BLL
{
	public class BanknoteAcceptorEventArgs : EventArgs
	{
		public int ReceiveMoney { get; set; }

		public string ErrorMessage { get; set;}
		
		public BanknoteAcceptorEventArgs(int receiveMoney)
		{
			ReceiveMoney = receiveMoney;
		}
	}
}