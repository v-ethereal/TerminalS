using System;

using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.Core.Dal;

namespace Arsis.RentalSystem.Core.Bll
{
	public class BaseService
	{
		private static RentalSystemDal dal;
		/// <summary>
		/// Gets the data context.
		/// </summary>
		/// <value>The data context.</value>
		public static RentalSystemDal Dal
		{
			get
			{
				if (dal == null)
				{
					dal = new RentalSystemDal();
				}

				return dal;
			}
			set
			{
				dal = value;
			}
		}
		/// <summary>
		/// Gets the current terminal.
		/// </summary>
		/// <value>The current terminal.</value>
		private Terminal currentTerminal;
		public Terminal CurrentTerminal
		{
			get
			{
				if (currentTerminal == null)
				{
					currentTerminal = Dal.GetTerminal(Environment.MachineName);
				}

				return currentTerminal;
			}
		}
	}
}