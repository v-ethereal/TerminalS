using System;
using System.Threading;
using System.Windows.Forms;
using Shtrih.ParkMaster.Common.Auxiliary;

namespace Shtrih.ParkMaster.CardsManagerUtil
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentUICulture = CommonConst.CultureRUS;
            Application.Run(new frmCardsManagerTest());
        }
    }
}
