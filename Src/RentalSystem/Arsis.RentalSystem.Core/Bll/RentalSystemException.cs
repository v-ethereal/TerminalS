using System;

namespace Arsis.RentalSystem.Core.Bll
{
	public class RentalSystemException : Exception
	{
		private readonly object extraInfo;

		#region Public Methods

		public RentalSystemException(string message, object extra)
				: base(message)
		{
			extraInfo = extra;
		}

		public RentalSystemException(string message)
				: base(message)
		{
		}

		public RentalSystemException()
		{
		}

		public override string ToString()
		{
			string exeptionMsg = string.Empty;
			exeptionMsg += "Exception: ";
			exeptionMsg += extraInfo == null ? string.Empty : extraInfo.ToString();
			exeptionMsg += "\n" + base.Message + "\n" + base.StackTrace;
			return exeptionMsg;
		}

		#endregion
	}


}