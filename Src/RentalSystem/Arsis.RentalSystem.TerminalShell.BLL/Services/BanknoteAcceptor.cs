using System;
using System.Collections.Generic;
using System.Threading;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using log4net;
using TermClasses;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
    public class BanknoteAcceptor : IBanknoteAcceptor
    {
        private readonly ILog logger = LogManager.GetLogger("GeneralAppender");
		private ITerminalBillValidator billValidator;
    	private bool internalBreakOperation;
        private bool inWaitMoneyMethod;
		private Thread waitMoneyThread;
    	private int feeAmount;

    	#region properties
		public ITerminalBillValidator BillValidator
    	{
    		get { return billValidator; }
    		set { billValidator = value; }
		}
		#endregion

		/// <summary>
        /// Accepts bill during interval.
        /// </summary>
        /// <param name="waitMillis">The wait interval millis.</param>
        /// <returns>Bill denomination.</returns>
        public int AcceptMoney(int waitMillis)
        {
            try
            {
                return billValidator.AcceptMoney(waitMillis);
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
                throw new RentalSystemException(e.Message, e);
            }
        }

        /// <summary>
        /// Accepts bill interruptable by flag.
        /// </summary>
        /// <param name="breakOperation">if set to <c>true</c> breaks bill acception operation.</param>
        /// <returns>Bill denomination.</returns>
        public int AcceptMoneyInterruptable(ref bool breakOperation)
        {
            try
            {
                return billValidator.AcceptMoneyInterruptable(ref breakOperation);
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
                throw new RentalSystemException(e.Message, e);
            }
        }

        /// <summary>
        /// Initializes bill acceptor.
        /// </summary>
        public void Initialize()
        {
            try
            {
                billValidator.Initialize();
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
                throw new RentalSystemException(e.Message, e);
            }
        }

        /// <summary>
        /// Gets the acceptable bill denominations.
        /// </summary>
        /// <returns>List of bill denominations.</returns>
        public IList<int> GetAcceptableBillDenominations()
        {
            try
            {
                return billValidator.GetAcceptableBillDenominations();
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);
                throw new RentalSystemException(e.Message, e);
            }
        }

    	public void StartWaitMoney()
		{
    		feeAmount = 0;
    		internalBreakOperation = false;
            logger.Debug("Начинаем ждать поступления денег");
			waitMoneyThread = new Thread(WaitMoneyMethod) { Name = "WaitMoneyThread" };
    		waitMoneyThread.Start();
    	}

    	public void StopWaitMoney()
    	{
            //TODO: Здесь что-то не чисто!!! Сначала надо дождаться окончания приема денег, а потом отрубать листенер
			internalBreakOperation = true;
            logger.Debug("Инициировано завершение ожидания денег, ждем 500мс...");
            Thread.Sleep(500);
            while (inWaitMoneyMethod)
            {
                logger.Debug("Ждем еще 100мс...");
                Thread.Sleep(100);
            }
            logger.Debug("Завершено ожидание поступления денег.");
            ReceiveMoneyEvent = null;
        }

    	public event EventHandler<BanknoteAcceptorEventArgs> ReceiveMoneyEvent;
    	public event EventHandler<TerminalDeviceErrorEventArgs> ErrorEvent;

    	public bool IsPendingMoney
    	{
			get { return !internalBreakOperation; }
    	}

    	private void WaitMoneyMethod()
		{
            inWaitMoneyMethod = true;
            try
            {
                do
                {
                    feeAmount = billValidator.AcceptMoneyInterruptable(ref internalBreakOperation);

                    logger.Debug("Деньги поступили в купюроприемник");

                    if (feeAmount > 0 && ReceiveMoneyEvent != null)
                    {
                        logger.Debug("Поступившие деньги опознаны");
                        ReceiveMoneyEvent(this, new BanknoteAcceptorEventArgs(feeAmount));
                    }
                }
                while (!internalBreakOperation);
            }
            catch (Exception e)
            {
                logger.Error(e.Message, e);

                if (ErrorEvent != null)
                {
                    ErrorEvent(this, new TerminalDeviceErrorEventArgs(e));
                }
            }
            finally
            {
                inWaitMoneyMethod = false;
            }
		}
    }
}