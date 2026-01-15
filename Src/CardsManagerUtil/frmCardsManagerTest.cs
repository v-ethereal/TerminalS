using System;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using Shtrih.ParkMaster.CardsManager;

namespace Shtrih.ParkMaster.CardsManagerUtil
{
    public partial class frmCardsManagerTest : Form
    {
        readonly Card Card = new Card();

        /// <summary>
        /// Форма тестирования работы с картой и ридером
        /// </summary>
        public frmCardsManagerTest()
        {
            InitializeComponent();
            //Logger.ReadSettingsSafe();

            Card.onCardPresent += card_onCardPresent;
            Card.onErrorPresent += _card_onErrorPresent;
        }

        void _card_onErrorPresent(object sender, ErrorEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new logDelegate(writeLog), e.ErrorCode, string.Empty);
            }
            else
            {
                writeLog(e.ErrorCode, string.Empty);
            }
        }

        delegate void logDelegate(byte errorCode, string message);
        delegate void workDelegate();

        void card_onCardPresent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new workDelegate(work));
            }
            else
            {
                work();
            }
        }

        private void work()
        {
            switch (CardTypeConfig.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    writeLog(Card.ImportMasterCard(), "Мастер-карта импортирована");
                    CardTypeConfig.SelectedIndex = 0;
                    break;
                case 2:
                    // код ошибки
                    DateTime dt;
                    int cardNum;
                    byte er = Card.GetDateEntrance(out cardNum, out dt);
                    writeLog(er, string.Format("Card num={0}, Date entrance={1}", cardNum.ToString("X2"), dt));
                    break;
                default:
                    break;
            }
        }

        private void frmCardsManagerTest_Load(object sender, EventArgs e)
        {
            ArrayList alPorts = Card.GetPortNames();
            if (alPorts.Count > 0)
            {
                tslbComPortValue.Text = alPorts[0].ToString();
            }

            CardTypeConfig.SelectedIndex = 0;

            tscbAccountNumber.SelectedIndex = 0;


            ////Data bind settings properties with straightforward associations.
            //Binding bndPortName = new Binding("SelectedItem", Properties.Settings.Default,
            //    "PortName", true, DataSourceUpdateMode.OnPropertyChanged);
            //PortConfig.ComboBox.DataBindings.Add(bndPortName);
            string portName = ConfigurationManager.AppSettings["PortName"];
            Card.PortName = portName ?? "COM1";
            Card.Connect();
        }

        #region Работа с логом

        private enum LogMessageState
        {
            Info = 0,
            //Alarm = 1,
            CriticalAlarm = 2
        }
        private void writeLog(string message, LogMessageState imgIndex)
        {
            var lv = new ListViewItem(new[] { message }, (int)imgIndex);
            lvLOG.BeginUpdate();
            lvLOG.Items.Add(lv);
            if (lvLOG.Items.Count > 0)
            {
                lvLOG.EnsureVisible(lvLOG.Items.Count - 1);
            }
            lvLOG.EndUpdate();
        }

        private void writeLog(byte er)
        {
            writeLog(er, new ReaderMessages().ErrorMessage(er));
        }

        private void writeLog(byte er, string infoMessage)
        {
            if (er != 0)
                writeLog(new ReaderMessages().ErrorMessage(er) + " (" + infoMessage + ")", LogMessageState.CriticalAlarm);
            else
                writeLog(infoMessage, LogMessageState.Info);
        }

        #endregion

        private void frmCardsManagerTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Card.Disconnect();
        }


        private void tsbtEjectCard_Click(object sender, EventArgs e)
        {
            writeLog(Card.PayCancel());
        }

        private void tsbtImportAccount_Click(object sender, EventArgs e)
        {
            writeLog(Card.ImportAccount((Card.AccountNumber)tscbAccountNumber.SelectedIndex));
        }

        private void tsbtWriteAccount_Click(object sender, EventArgs e)
        {
            writeLog(Card.PayCard(tsbtWriteDate.Checked, (Card.AccountNumber)tscbAccountNumber.SelectedIndex));
        }

        private void tsbtReadAccount_Click(object sender, EventArgs e)
        {
            DateTime dt;
            int cardNumber;
            byte err = Card.GetDateEntrance(out cardNumber, out dt);
            writeLog(err, string.Format("Card num={0}, Date entrance={1}", cardNumber.ToString("X2"), dt));
        }

        private void tsbtWriteDate_Click(object sender, EventArgs e)
        {

        }

        private void tsbtReset_Click(object sender, EventArgs e)
        {
            writeLog(Card.Reset());
        }


    }
}
