using System;
using System.Runtime.Serialization;
using System.Threading;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using log4net;
using Shtrih.ParkMaster.CardsManager;
#if CARDSTUB
using Arsis.RentalSystem.TermClassesStub.Impl;

#endif

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
    public class CardReaderService : ICardReaderService
    {
        private volatile bool isCardPresent;

        public bool IsCardPresent
        {
            get { return isCardPresent; }
        }

        private int cardNumber;
        private DateTime entranceDate;
        private bool isStarted;
        private bool readCardOnPresent;

#if CARDSTUB
        public CardStub CardReader { get; set; }
#else

        public Card CardReader { get; set; }
#endif

        #region Implementation of ICardReaderService

        private void CardReader_onErrorPresent(object sender, ErrorEventArgs e)
        {
            //Тут происходит ошибка контрольной суммы в фоне, потому что постоянно мурыжатся пакеты между ридером и компом 
            //и иногда пакеты приходят битые, но это не означает,что ридер неисправен, к тому же операция в этот момент 
            //скорее всегоне выполнялась, поэтому запишем ошибку в лог и поедем дальше.
            string error = string.Format("Ошибка карт-ридера: ({0}) {1}", e.ErrorCode, new ReaderMessages().ErrorMessage(e.ErrorCode));

            LogManager.GetLogger(GetType()).Error(error);
        }

        public bool ReadCardOnPresent
        {
            get
            {
                return readCardOnPresent;
            }
            set
            {
                readCardOnPresent = value;
            }
        }

        private void CardReader_onCardPresent(object sender, EventArgs e)
        {
            if (!readCardOnPresent)
            {
                return;
            }
            try
            {
                if (!isCardPresent)
                {
                    isCardPresent = true;

                    byte returnCode = CardReader.GetDateEntrance(out cardNumber, out entranceDate);

                    if (returnCode > 0)
                    {
                        throw new CardReaderServiceException(new ReaderMessages().ErrorMessage(returnCode));
                    }
                }

                if (CardPresentEvent != null)
                {
                    Console.WriteLine("CardReader_onCardPresent CardPresentEvent " + DateTime.Now.ToString("HH:mm:ss fff"));
                    CardPresentEvent(this, EventArgs.Empty);
                }
            }
            //если в процессе работы с кард ридером произошла ошибка, мы её ловим ...
            catch (Exception)
            {
                // выплёвываем карту 
                EjectCard();

                //и прокидываем ошибку дальше
                //её перехватит LoggingInterceptor
                throw;
            }
        }

        public int? CardNumber
        {
            get
            {
                if (isCardPresent) return cardNumber;

                return null;
            }
        }

        public DateTime? EntranceDate
        {
            get
            {
                if (isCardPresent) return entranceDate;

                return null;
            }
        }


        public void ImportTariff(int tariffNumber)
        {
            try
            {
                byte returnCode = CardReader.ImportAccount((Card.AccountNumber) tariffNumber);
                if (returnCode != 0)
                {
                    throw new CardReaderServiceException("Ошибка импорта мастер-карты (" + returnCode + ") - " +
                                                         new ReaderMessages().ErrorMessage(returnCode));
                }
            }
            catch (Exception)
            {
                EjectCard();
                throw;
            }
        }

        public void WriteTariff(bool rewriteEntranceDate, int tariffNumber)
        {
            try
            {
                if (!isCardPresent)
                {
                    throw new CardReaderServiceException("Отсутствует карта");
                }

                if (!Enum.IsDefined(typeof (Card.AccountNumber), tariffNumber))
                {
                    throw new ArgumentOutOfRangeException("tariffNumber", "Доступный интервал 0..3");
                }

                #region магия рекомендованная от разработчиков библиотеки для работы с кардридером :)

                byte returnCode = CardReader.GetDateEntrance(out cardNumber, out entranceDate);
                if (returnCode > 0)
                {
                    throw new CardReaderServiceException(new ReaderMessages().ErrorMessage(returnCode));
                }

                #endregion

                returnCode = CardReader.PayCard(rewriteEntranceDate, (Card.AccountNumber) tariffNumber);
                if (returnCode > 0)
                {
                    throw new CardReaderServiceException(new ReaderMessages().ErrorMessage(returnCode));
                }

                returnCode = CardReader.GetDateEntrance(out cardNumber, out entranceDate);
                if (returnCode > 0)
                {
                    throw new CardReaderServiceException(new ReaderMessages().ErrorMessage(returnCode));
                }
            }
            catch (Exception)
            {
                EjectCard();

                throw;
            }
        }

        public event EventHandler<EventArgs> CardPresentEvent;
        public event EventHandler<CardReaderExceptionEventArgs> CardReaderErrorEvent;

        public bool IsStarted
        {
            get { return isStarted; }
        }

        public void Start(string port)
        {
            if (isStarted) return;

            CardReader.PortName = port;

            CardReader.Connect();

            isStarted = true;

            readCardOnPresent = true;

            CardReader.onCardPresent += CardReader_onCardPresent;
            CardReader.onErrorPresent += CardReader_onErrorPresent;
        }


        public void Stop()
        {
            if (!isStarted) return;

            CardReader.onCardPresent -= CardReader_onCardPresent;
            CardReader.onErrorPresent -= CardReader_onErrorPresent;

            //EnableEvents(false, false);

            EjectCard();

            CardReader.Disconnect();

            isStarted = false;

            Thread.Sleep(2000); // магия

        }

        public void EjectCard()
        {
            bool tempIsCardPresent = isCardPresent;
            isCardPresent = false;

            var returnCode = CardReader.PayCancel();

            if (returnCode > 0)
            {
                isCardPresent = tempIsCardPresent;
                throw new CardReaderServiceException("Ошибка извлечения карты.\n\n" +
                                               new ReaderMessages().ErrorMessage(returnCode));
            }

            Thread.Sleep(1000); // магия
        }
        #endregion
    }

    public class CardReaderServiceException : Exception
    {
        public CardReaderServiceException()
        {
        }

        public CardReaderServiceException(string message) : base(message)
        {
        }

        public CardReaderServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CardReaderServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}