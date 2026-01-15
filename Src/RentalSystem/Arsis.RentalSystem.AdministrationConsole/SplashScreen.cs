using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Arsis.RentalSystem.AdministrationConsole
{
    /// Summary description for SplashScreen.
    public class SplashScreen : Form
    {
        // Threading
        static SplashScreen ms_frmSplash = null;
        static Thread ms_oThread = null;

        // Fade in and out.
        private double m_dblOpacityIncrement = .05;
        private double m_dblOpacityDecrement = .04;
        private const int TIMER_INTERVAL = 50;

        // Status and progress bar
        private string m_sStatus;
        private double m_dblCompletionFraction = 0;
        private Rectangle m_rProgress = new Rectangle(296, 7, 212, 14);

        // Progress smoothing
        private double m_dblLastCompletionFraction = 0.0;
        private double m_dblPBIncrementPerTimerInterval = .015;

        // Self-calibration support
        private bool m_bFirstLaunch = false;
        private DateTime m_dtStart;
        private bool m_bDTSet = false;
        private int m_iIndex = 1;
        private int m_iActualTicks = 0;
        private ArrayList m_alPreviousCompletionFraction;
        private ArrayList m_alActualTimes = new ArrayList();
        private const string REG_KEY_INITIALIZATION = "Initialization";
        private const string REGVALUE_PB_MILISECOND_INCREMENT = "Increment";
        private const string REGVALUE_PB_PERCENTS = "Percents";

        private Label lblStatus;
        private Label lblTimeRemaining;
        private System.Windows.Forms.Timer timer1;
        private Panel pnlStatus;
        private Label lblFirstLaunch;
        private System.ComponentModel.IContainer components;

        /// Constructor
        public SplashScreen()
        {
            InitializeComponent();
            Opacity = .00;
            TransparencyKey = BackColor;
            timer1.Interval = TIMER_INTERVAL;
            timer1.Start();
            ClientSize = BackgroundImage.Size;
            m_sStatus = lblStatus.Text;
            TopMost = true;
        }

        /// Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblFirstLaunch = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblStatus.Location = new System.Drawing.Point(12, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(496, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Идет загрузка...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatus.Controls.Add(this.lblFirstLaunch);
            this.pnlStatus.Location = new System.Drawing.Point(274, 3);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(212, 21);
            this.pnlStatus.TabIndex = 1;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatus_Paint);
            // 
            // lblFirstLaunch
            // 
            this.lblFirstLaunch.AutoSize = true;
            this.lblFirstLaunch.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFirstLaunch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFirstLaunch.Location = new System.Drawing.Point(0, 0);
            this.lblFirstLaunch.Name = "lblFirstLaunch";
            this.lblFirstLaunch.Size = new System.Drawing.Size(216, 17);
            this.lblFirstLaunch.TabIndex = 3;
            this.lblFirstLaunch.Text = "Первый запуск приложения";
            this.lblFirstLaunch.Visible = false;
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.White;
            this.lblTimeRemaining.Location = new System.Drawing.Point(283, 112);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(209, 12);
            this.lblTimeRemaining.TabIndex = 2;
            this.lblTimeRemaining.Text = "Осталось:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.domodedovskiy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(520, 199);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TransparencyKey = System.Drawing.Color.White;
            this.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // ************* Static Methods *************** //

        // A static method to create the thread and 
        // launch the SplashScreen.
        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.
            if (ms_frmSplash != null)
                return;
            ms_oThread = new Thread(ShowForm);
            ms_oThread.IsBackground = true;
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
        }

        // A property returning the splash screen instance
        static public SplashScreen SplashForm
        {
            get
            {
                return ms_frmSplash;
            }
        }

        // A private entry point for the thread.
        static private void ShowForm()
        {
            ms_frmSplash = new SplashScreen();
            System.Windows.Forms.Application.Run(ms_frmSplash);
        }

        // A static method to close the SplashScreen
        static public void CloseForm()
        {
            if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
            {
                // Make it start going away.
                ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
            }
            ms_oThread = null;  // we do not need these any more.
            ms_frmSplash = null;
        }

        // A static method to set the status and update the reference.
        static public void SetStatus(string newStatus)
        {
            SetStatus(newStatus, true);
        }

        // A static method to set the status and optionally update the reference.
        // This is useful if you are in a section of code that has a variable
        // set of status string updates.  In that case, don't set the reference.
        static public void SetStatus(string newStatus, bool setReference)
        {
            if (ms_frmSplash == null)
                return;
            ms_frmSplash.m_sStatus = newStatus;
            if (setReference)
                ms_frmSplash.SetReferenceInternal();
        }

        // Static method called from the initializing application to 
        // give the splash screen reference points.  Not needed if
        // you are using a lot of status strings.
        static public void SetReferencePoint()
        {
            if (ms_frmSplash == null)
                return;
            ms_frmSplash.SetReferenceInternal();

        }

        // ************ Private methods ************

        // Internal method for setting reference points.
        private void SetReferenceInternal()
        {
            if (m_bDTSet == false)
            {
                m_bDTSet = true;
                m_dtStart = DateTime.Now;
                ReadIncrements();
            }
            double dblMilliseconds = ElapsedMilliSeconds();
            m_alActualTimes.Add(dblMilliseconds);
            m_dblLastCompletionFraction = m_dblCompletionFraction;
            if (m_alPreviousCompletionFraction != null
                && m_iIndex < m_alPreviousCompletionFraction.Count)
                m_dblCompletionFraction =
                    (double)m_alPreviousCompletionFraction[m_iIndex++];
            else
                m_dblCompletionFraction = (m_iIndex > 0) ? 1 : 0;
        }

        // Utility function to return elapsed Milliseconds since the 
        // SplashScreen was launched.
        private double ElapsedMilliSeconds()
        {
            TimeSpan ts = DateTime.Now - m_dtStart;
            return ts.TotalMilliseconds;
        }

        // Function to read the checkpoint intervals 
        // from the previous invocation of the
        // splashscreen from the registry.
        private void ReadIncrements()
        {
            string sPBIncrementPerTimerInterval =
                RegistryAccess.GetStringRegistryValue(
                    REGVALUE_PB_MILISECOND_INCREMENT, "0.0015");
            double dblResult;

            if (Double.TryParse(sPBIncrementPerTimerInterval,
                                System.Globalization.NumberStyles.Float,
                                System.Globalization.NumberFormatInfo.InvariantInfo,
                                out dblResult))
                m_dblPBIncrementPerTimerInterval = dblResult;
            else
                m_dblPBIncrementPerTimerInterval = .0015;

            string sPBPreviousPctComplete = RegistryAccess.GetStringRegistryValue(
                REGVALUE_PB_PERCENTS, "");

            if (sPBPreviousPctComplete != "")
            {
                string[] aTimes = sPBPreviousPctComplete.Split(null);
                m_alPreviousCompletionFraction = new ArrayList();

                for (int i = 0; i < aTimes.Length; i++)
                {
                    double dblVal;
                    if (Double.TryParse(aTimes[i],
                                        System.Globalization.NumberStyles.Float,
                                        System.Globalization.NumberFormatInfo.InvariantInfo,
                                        out dblVal))
                        m_alPreviousCompletionFraction.Add(dblVal);
                    else
                        m_alPreviousCompletionFraction.Add(1.0);
                }
            }
            else
            {
                m_bFirstLaunch = true;
            }
        }

        // Method to store the intervals (in percent complete)
        // from the current invocation of
        // the splash screen to the registry.
        private void StoreIncrements()
        {
            string sPercent = "";
            double dblElapsedMilliseconds = ElapsedMilliSeconds();
            for (int i = 0; i < m_alActualTimes.Count; i++)
                sPercent += ((double)m_alActualTimes[i] /
                             dblElapsedMilliseconds).ToString("0.####",
                                                              System.Globalization.NumberFormatInfo.InvariantInfo) + " ";

            RegistryAccess.SetStringRegistryValue(
                REGVALUE_PB_PERCENTS, sPercent);

            m_dblPBIncrementPerTimerInterval = 1.0 / m_iActualTicks;
            RegistryAccess.SetStringRegistryValue(
                REGVALUE_PB_MILISECOND_INCREMENT,
                m_dblPBIncrementPerTimerInterval.ToString("#.000000",
                                                          System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        //********* Event Handlers ************

        // Tick Event handler for the Timer control.  
        // Handle fade in and fade out.  Also
        // handle the smoothed progress bar.
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = m_sStatus;

            if (m_dblOpacityIncrement > 0)
            {
                m_iActualTicks++;
                if (Opacity < 1)
                    Opacity += m_dblOpacityIncrement;
            }
            else
            {
                if (Opacity > 0)
                    Opacity += m_dblOpacityIncrement;
                else
                {
                    StoreIncrements();
                    Close();
                }
            }
            if (!m_bFirstLaunch && m_dblLastCompletionFraction < m_dblCompletionFraction)
            {
                m_dblLastCompletionFraction += m_dblPBIncrementPerTimerInterval;
                int width = (int)Math.Floor(
                                     pnlStatus.ClientRectangle.Width * m_dblLastCompletionFraction);
                int height = pnlStatus.ClientRectangle.Height;
                int x = pnlStatus.ClientRectangle.X;
                int y = pnlStatus.ClientRectangle.Y;
                if (width > 0 && height > 0)
                {
                    m_rProgress = new Rectangle(x, y, width, height);
                    pnlStatus.Invalidate(m_rProgress);
                    int iSecondsLeft = 1 + (int)(TIMER_INTERVAL *
                                                 ((1.0 - m_dblLastCompletionFraction) /
                                                  m_dblPBIncrementPerTimerInterval)) / 1000;
                    string suffix = "";
                    if (iSecondsLeft >= 5 && iSecondsLeft <= 20)
                    {}
                    else if (iSecondsLeft % 10 == 1)
                    {
                        suffix = "а";
                    }
                    else if (iSecondsLeft % 10 >= 2 && iSecondsLeft % 10 <= 4)
                    {
                        suffix = "ы";
                    }
                    lblTimeRemaining.Text = string.Format("Осталось: {0} секунд{1}", 
                        iSecondsLeft, suffix);
                }
            }
            if (m_bFirstLaunch)
            {
                lblTimeRemaining.Text = "Осталось: неизвестно";
                if (!lblFirstLaunch.Visible)
                {
                    lblFirstLaunch.Visible = true;
                }
            }
        }

        // Paint the portion of the panel invalidated during the tick event.
        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {
            if (m_bFirstLaunch == false && e.ClipRectangle.Width > 0
                && m_iActualTicks > 1)
            {
                LinearGradientBrush brBackground =
                    new LinearGradientBrush(m_rProgress,
                                            Color.FromArgb(100, 100, 100),
                                            Color.FromArgb(150, 150, 255),
                                            LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brBackground, m_rProgress);
            }
        }

        // Close the form if they double click on it.
        private void SplashScreen_DoubleClick(object sender, EventArgs e)
        {
            CloseForm();
        }

    }

    /// A class for managing registry access.
    public class RegistryAccess
    {
        private const string SOFTWARE_KEY = "Software";
        private const string COMPANY_NAME = "Dekart";
        private const string APPLICATION_NAME = "CRM";

        // Method for retrieving a Registry Value.
        static public string GetStringRegistryValue(string key,
                                                    string defaultValue)
        {
            RegistryKey rkCompany;
            RegistryKey rkApplication;

            rkCompany = Registry.CurrentUser.OpenSubKey(SOFTWARE_KEY,
                                                        false).OpenSubKey(COMPANY_NAME, false);
            if (rkCompany != null)
            {
                rkApplication = rkCompany.OpenSubKey(APPLICATION_NAME, true);
                if (rkApplication != null)
                {
                    foreach (string sKey in rkApplication.GetValueNames())
                    {
                        if (sKey == key)
                        {
                            return (string)rkApplication.GetValue(sKey);
                        }
                    }
                }
            }
            return defaultValue;
        }

        // Method for storing a Registry Value.
        static public void SetStringRegistryValue(string key,
                                                  string stringValue)
        {
            RegistryKey rkSoftware;
            RegistryKey rkCompany;
            RegistryKey rkApplication;

            rkSoftware = Registry.CurrentUser.OpenSubKey(SOFTWARE_KEY, true);
            rkCompany = rkSoftware.CreateSubKey(COMPANY_NAME);
            if (rkCompany != null)
            {
                rkApplication = rkCompany.CreateSubKey(APPLICATION_NAME);
                if (rkApplication != null)
                {
                    rkApplication.SetValue(key, stringValue);
                }
            }
        }
    }
}