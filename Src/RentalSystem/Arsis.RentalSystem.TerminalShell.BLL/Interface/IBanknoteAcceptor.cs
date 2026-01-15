using System;
using System.Collections.Generic;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
	public interface IBanknoteAcceptor
	{
		int AcceptMoney(int waitMillis);
		int AcceptMoneyInterruptable(ref bool breakOperation);
		void Initialize();
		IList<int> GetAcceptableBillDenominations();
		void StartWaitMoney();
		void StopWaitMoney();
		event EventHandler<BanknoteAcceptorEventArgs> ReceiveMoneyEvent;
		event EventHandler<TerminalDeviceErrorEventArgs> ErrorEvent;
		bool IsPendingMoney { get; }
	}
}