using System;
using System.IO;
using Arsis.RentalSystem.Core.Bll;

namespace Arsis.RentalSystem.Core.Helpers
{
    public abstract class CommonHelper
    {
        public static string GetInternalPackedTicketId(int parkingCardNumber, DateTime entranceDate)
        {
            return string.Format("{0}_{1:X8}", entranceDate.ToString("ddMMyyHHmm"), parkingCardNumber);
        }

        public static void CreateTempDirectory()
        {
            try
            {
                Directory.CreateDirectory(@"C:\TEMP\Domodedovo");
                Directory.CreateDirectory(@"C:\TEMP\Domodedovo\IN");
                Directory.CreateDirectory(@"C:\TEMP\Domodedovo\OUT");
            }
            catch (Exception err)
            {
                throw new RentalSystemException(err.Message);
            }
        }

        public static string GetErrorMessage(Exception exception)
        {
            return exception.InnerException != null
                       ? string.Format("{0} {1}", exception.Message, exception.InnerException.Message)
                       : exception.Message;
        }

        public static string GetErrorMessage(string title, Exception exception)
        {
            return exception.InnerException != null
                       ? string.Format("{0}\n\n{1}\n\n{2}", title, exception.Message, exception.InnerException.Message)
                       : string.Format("{0}\n\n{1}", title, exception.Message);
        }
    }
}