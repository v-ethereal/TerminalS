using System;
using System.Windows.Threading;

namespace Arsis.RentalSystem.TerminalShell
{
    /// <summary>
    /// Interaction logic for TakeDialogWindow.xaml
    /// </summary>
    public partial class TakeDialogWindow
    {
        private readonly DispatcherTimer clockTimer = new DispatcherTimer();
        private int time;

        public TakeDialogWindow() 
        {
            InitializeComponent();
        }

        public TakeDialogWindow(string message, int timerTick)
        {
            InitializeComponent();
            
            PrimaryMessage.Text = message;
            time = timerTick;

            lblRedirectionTimer.Content = time + " сек.";
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            clockTimer.Interval = new TimeSpan(0, 0, 0, 1);
            clockTimer.Tick += delegate
            {
                time -= 1;

                lblRedirectionTimer.Content = time + " сек.";

                if (time > 0) return;

                clockTimer.Stop();

                Close();
            };

            clockTimer.Start();
        }
    }
}