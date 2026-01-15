using System;
using System.Threading;

using TermClasses;

namespace Arsis.RentalSystem.TermClassesStub.Impl
{
    public class BarCodeScanner : ITerminalBarCodeScanner
    {
        public string AcceptBarCode(ref bool interrupt)
        {
            Thread.Sleep(7000);

            if (interrupt)
            {
                return String.Empty;
            }
			
            return "1";
        }
    }
}