using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface IUserService
    {
        bool Logon(string login, string password);
        void Logoff();
        bool IsInRole(string roleName);
        IList<Role> GetUserRoles(string login);
    	User GetUser(string login);
    	User GetUserByAccessCode(string accessCode);
    }
}