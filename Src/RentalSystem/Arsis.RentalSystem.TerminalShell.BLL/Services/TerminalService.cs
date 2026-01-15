using System;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class TerminalService : BaseService, ITerminalService
	{
		#region Public Methods

		/// <summary>
		/// Insert information about terminal start into DB.
		/// </summary>
		public void Start()
		{
			Terminal terminal;
			if (Dal.CheckTerminalExistance(Environment.MachineName))
			{
				terminal = Dal.GetTerminal(Environment.MachineName);
				terminal.Status = "Started";
				terminal.DateTime = DateTime.Now;
			}
			else
			{
				terminal = new Terminal
				           	{
				           			NetworkName = Environment.MachineName,
				           			Status = "Started",
				           			DateTime = DateTime.Now,
				           			ShiftNumber = 1
				           	};
			}

			Dal.UpdateTerminal(terminal);
		}

		/// <summary>
		/// Insert information about terminal stop into DB.
		/// </summary>
		public void Stop()
		{
			Terminal terminal;
			if (Dal.CheckTerminalExistance(Environment.MachineName))
			{
				terminal = Dal.GetTerminal(Environment.MachineName);
				terminal.DateTime = DateTime.Now;
				terminal.Status = "Stopped";
			}
			else
			{
				terminal = new Terminal
				           	{
				           			NetworkName = Environment.MachineName,
				           			DateTime = DateTime.Now,
				           			Status = "Stopped",
				           			ShiftNumber = 1
				           	};
			}

			Dal.UpdateTerminal(terminal);
		}

		/// <summary>
		/// Sets the error status of current terminal.
		/// </summary>
		public void SetErrorStatus()
		{
			Terminal terminal;
			if (Dal.CheckTerminalExistance(Environment.MachineName))
			{
				terminal = Dal.GetTerminal(Environment.MachineName);
				terminal.DateTime = DateTime.Now;
				terminal.Status = "Error";
			}
			else
			{
				terminal = new Terminal
				           	{
				           			NetworkName = Environment.MachineName,
				           			DateTime = DateTime.Now,
				           			Status = "Error",
				           			ShiftNumber = 1
				           	};
			}

			Dal.UpdateTerminal(terminal);
		}

		#endregion
	}
}