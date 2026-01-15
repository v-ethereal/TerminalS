using System;
using System.Collections.Generic;
using System.Threading;
using TermClasses;

namespace Arsis.RentalSystem.TermClassesStub.Impl
{
    public class CashCodeSMBillValidator : ITerminalBillValidator
    {
        public void Initialize()
        {
        }

        public int AcceptMoney(int waitMillis)
        {
            throw new NotImplementedException();
        }

        public int AcceptMoneyInterruptable(ref bool interrupt)
        {
            Thread.Sleep(1000);
            if (interrupt) return 0;
            return 100;
        }

        public IList<int> GetAcceptableBillDenominations()
        {
            //Достоинства банкнот
            return new List<int> { 10, 50, 100, 500, 1000};
        }
    }
}