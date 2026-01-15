using System.Configuration;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System;
using Arsis.RentalSystem.Core.Helpers;
using Arsis.RentalSystem.TerminalShell.Configuration;
using Arsis.RentalSystem.TerminalShell.Helpers;
using log4net;
using Microsoft.VisualBasic.ApplicationServices;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Dal;
using Arsis.RentalSystem.TerminalShell.BLL;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;
using log4net.Config;
using MessageBox=System.Windows.MessageBox;
using UnhandledExceptionEventArgs = System.UnhandledExceptionEventArgs;


namespace Arsis.RentalSystem.TerminalShell
{
    public class EntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                SQLHelper.IsDbEnable();
                CommonHelper.CreateTempDirectory();
                CardReaderHelper.GetTariffIdArray();

                new SingleInstanceManager().Run(args);
            }
            catch (Exception err)
            {
                LogManager.GetLogger(typeof(EntryPoint)).Error(err);
                MessageBox.Show(CommonHelper.GetErrorMessage(err),"Ошибка инициализации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class SingleInstanceManager : WindowsFormsApplicationBase
    {
        private App app;

        public SingleInstanceManager()
        {
            IsSingleInstance = true;
        }

        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {
            app = new App();
            app.InitializeComponent();
            app.Run();

            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            app.Activate();
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ITerminalService terminalService;
        private readonly ICardReaderService cardReaderService;

        public void Activate()
        {
            MainWindow.Activate();
        }

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_OnUnhandledException;
            AppRuntime.Instance.Initialize();
            XmlConfigurator.Configure();
            terminalService = AppRuntime.Instance.Container.GetComponent<ITerminalService>();
            IFiscalRegister fiscalRegister = AppRuntime.Instance.Container.GetComponent<IFiscalRegister>();
            IBanknoteAcceptor banknoteAcceptor = AppRuntime.Instance.Container.GetComponent<IBanknoteAcceptor>();
            ITransactionService transactionService = AppRuntime.Instance.Container.GetComponent<ITransactionService>();

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var currentTerminalConfig = configuration.GetSection("terminal.configuration") as TerminalConfiguration;
            if (currentTerminalConfig != null)
            {
                if (currentTerminalConfig.ParkingServiceEnable)
                {
                    cardReaderService = AppRuntime.Instance.Container.GetComponent<ICardReaderService>();
                }
            }

            MainWindow window = new MainWindow();
            window.Show();

            try
            {
                terminalService.Start();
                fiscalRegister.Initialize();
                banknoteAcceptor.Initialize();
                transactionService.Initialize();
                if (cardReaderService != null)
                {
                    cardReaderService.Start(CardReaderHelper.GetPort());
                }
            }
            catch (Exception err)
            {
                try
                {
                    if (cardReaderService != null)
                    {
                        cardReaderService.Stop();
                    }

                    terminalService.Stop();

                    terminalService.SetErrorStatus();
                }
                finally
                {
                    LogManager.GetLogger(GetType()).Error(err);
                    Current.Properties[Constants.ParameterLastError] = CommonHelper.GetErrorMessage(err);
                    window.Workspace.Navigate(Constants.UriErrorPage);
                }
            }
        }

        private static void CurrentDomain_OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogManager.GetLogger(AppDomain.CurrentDomain.GetType()).Error(e.ExceptionObject);
            MessageBox.Show(e.ExceptionObject.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            Thread thread = new Thread(() => Environment.Exit(-1));
            thread.Start();
            thread.Join();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                if (cardReaderService != null)
                {
                    cardReaderService.Stop();
                }

                terminalService.Stop();
            }
            catch
            {
                //cath's connection exception while disconnected from database. base exception logged in LoggingInterceptor
            }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Thread thread = new Thread(delegate()
                                           {
                                               try
                                               {
                                                   if (cardReaderService != null)
                                                   {
                                                       cardReaderService.Stop();
                                                   }

                                                   terminalService.Stop();

                                                   terminalService.SetErrorStatus();
                                               }
                                               catch
                                               {
                                                   //cath's connection exception while disconnected from database. base exception logged in LoggingInterceptor
                                               }
                                           });
            thread.Start();
            e.Handled = true;

            LogManager.GetLogger(AppDomain.CurrentDomain.GetType()).Error(e.Exception);

            Current.Properties[Constants.ParameterLastError] = CommonHelper.GetErrorMessage(e.Exception);
            ((MainWindow) MainWindow).Workspace.Navigate(Constants.UriErrorPage);
        }
    }
}