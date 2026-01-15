using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Arsis.RentalSystem.Core.Bll;
using log4net.Config;

namespace Arsis.RentalSystem.AdministrationConsole
{
    internal static class Program
    {
        private const string ERROR_CAPTION = "Ошибка";
        private const string ERROR_TEXT = "Ошибка в работе приложения";

        static Mutex mutex;
        const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);

        private static IntPtr GetCurrentInstanceWindowHandle()
        {
            IntPtr hWnd = IntPtr.Zero;
            Process process = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(process.ProcessName);
            foreach (Process _process in processes)
            {
                // Get the first instance that is not this instance, has the
                // same process name and was started from the same file name
                // and location. Also check that the process has a valid
                // window handle in this session to filter out other user's
                // processes.
                if (_process.Id != process.Id &&
                    _process.MainModule.FileName == process.MainModule.FileName &&
                    _process.MainWindowHandle != IntPtr.Zero)
                {
                    hWnd = _process.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }

        private static void SwitchToCurrentInstance()
        {
            IntPtr hWnd = GetCurrentInstanceWindowHandle();
            if (hWnd != IntPtr.Zero)
            {
                if (IsIconic(hWnd) != 0)
                {
                    ShowWindow(hWnd, SW_RESTORE);
                }

                SetForegroundWindow(hWnd);
            }
        }

        private static bool IsAlreadyRunning()
        {
            string strLoc = Application.ExecutablePath;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppRuntime.Instance.Initialize();
            XmlConfigurator.Configure();
            Application.ThreadException += Application_OnThreadException;
            if (IsAlreadyRunning())
            {
                SwitchToCurrentInstance();
                return;
            }
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SplashScreen.ShowSplashScreen();
            Thread.Sleep(100);

            SplashScreen.SetStatus("Инициализация приложения...");
            Thread.Sleep(200);
            
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }

        private static void Application_OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(ERROR_TEXT + Environment.NewLine + e.Exception.Message, ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}