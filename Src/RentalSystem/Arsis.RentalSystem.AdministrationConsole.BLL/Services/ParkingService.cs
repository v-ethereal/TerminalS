using System;
using System.Collections.Generic;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
	public class ParkingService : BaseService, IParkingService
	{
		public IEnumerable<ParkingTicketInfo> GetParkingPays(DateTime dateFrom, DateTime dateTo)
		{
			return Dal.GetParkingTickets(dateFrom, dateTo);
		}
	}
}
