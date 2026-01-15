using System.Collections.Generic;
using Arsis.RentalSystem.AdministrationConsole.BLL.AccessRightsUtility;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IUserService
    {
        int AddUser(string login, string password, string name, bool isActive, string accessCode);
        void EditUser(string oldLogin, string login, string password, string name, bool isActive);
        bool Logon(string login, string password);
        bool IsInRole(string roleName);
        User GetUser(string login);
        BindingListView<User> GetUsers();
        bool CanLogin(string login);
        IList<Role> GetUserRoles(string login);
        IList<Role> GetRolesList();
        void DeleteUser(string login);
        void AssignRole(string login, Roles role);
        void RemoveRole(string login, Roles roleName);
        User CurrentUser { get; }
        bool CheckUserExistance(string login);
        bool HasRight(UserActions action);
    	void GenerateNewAccessCode(string login);
    }
}