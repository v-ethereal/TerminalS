using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
	public interface IParkingService
	{
		IEnumerable<ParkingTicketInfo> GetParkingPays(DateTime dateFrom, DateTime dateTo);
	}
}
