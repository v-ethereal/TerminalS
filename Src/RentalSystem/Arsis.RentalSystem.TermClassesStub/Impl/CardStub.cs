using System;
using System.Collections;
using System.Threading;
using System.Timers;
using Shtrih.ParkMaster.CardsManager;
using Timer=System.Timers.Timer;

namespace Arsis.RentalSystem.TermClassesStub.Impl
{
    /// <summary>
    /// класс - заглушка
    /// </summary>card
    public class CardStub : Card
    {
        private readonly Timer timerCheckCard = new Timer();

        private DateTime dateEntranceCurrent;
        private readonly int cardNumberCurrent;


        public CardStub()
        {
            cardNumberCurrent = new Random().Next();

            dateEntranceCurrent = DateTime.Now.AddHours(-3);

            timerCheckCard.Elapsed += timerCheckCard_Elapsed;
        }

        private void timerCheckCard_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (onCardPresent != null)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff"));
                onCardPresent(this, EventArgs.Empty);
            }
        }

        public new event EventHandler onCardPresent;

        public new void Connect()
        {
            Action action = () =>
                                {
                                    timerCheckCard.Interval = 10000;

                                    timerCheckCard.Start();
                                };

            Thread checkThread = new Thread(new ThreadStart(action));
            checkThread.Start();
        }

        public new void Disconnect()
        {
            timerCheckCard.Stop();
        }

        public new byte GetDateEntrance(out int cardNum, out DateTime dateEntrance)
        {
            Thread.Sleep(1000);

            cardNum = cardNumberCurrent;
            dateEntrance = dateEntranceCurrent;

            return 0;
        }

        public new ArrayList GetPortNames()
        {
            return new ArrayList(new[] {"COM1", "COM2"});
        }

        public new byte ImportAccount(AccountNumber accountNumber)
        {
            throw new NotImplementedException();
        }

        public new byte ImportMasterCard()
        {
            throw new NotImplementedException();
        }

        public new byte PayCancel()
        {
            return 0;
        }

        public new byte PayCard()
        {
            throw new NotImplementedException();
        }

        public new byte PayCard(bool isDateWrite, AccountNumber accountNumber)
        {
            if (isDateWrite)
            {
                dateEntranceCurrent = DateTime.Now;
            }

            return 0;
        }

        public new byte Reset()
        {
            throw new NotImplementedException();
        }

        public new string PortName
        {
            get { return "COM1"; }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }
    }
}