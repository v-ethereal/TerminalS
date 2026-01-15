using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Arsis.RentalSystem.AdministrationConsole.BLL.AccessRightsUtility;
using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;

using System.Security.Cryptography;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Fields

        private User currentUser;
        private readonly AccessRightsUtility.AccessRightsUtility accessRightsUtility = new AccessRightsUtility.AccessRightsUtility();

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        public User CurrentUser
        {
            get { return currentUser; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The name.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="accessCode">уникальный код для доступа к определённым функциям терминала - выдача парков талона</param>
        /// <returns>User id.</returns>
        public int AddUser(string login, string password, string name, bool isActive, string accessCode)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                if (Dal.CheckUserExistance(login))
                {
                    throw new RentalSystemException("Пользователь с таким логином уже существует");
                }
                User user = new User
                            	{
                            			Login = login,
                            			Password = MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(password)),
                            			Name = name,
                            			IsActive = isActive,
										AccessCode = accessCode
                            	};

            	Dal.InsertUser(user);
                return user.Id;
            }
            return 0;
        }

        /// <summary>
        /// Checks the user existance.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>User existance flag.</returns>
        public bool CheckUserExistance(string login)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.CheckUserExistance(login);
            }
            return false;
        }

        public bool HasRight(UserActions action)
        {
            foreach (var userRole in GetUserRoles(CurrentUser.Login))
            {
                if(accessRightsUtility.CheckRoleRight(userRole, action))
                {
                    return true;
                }
            }

            MessageBox.Show(UserServiceSR.CommonRightsError, UserServiceSR.CommonRoghtsErrorHeader, MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);

            return false;
        }

    	public void GenerateNewAccessCode(string login)
    	{
			User user = Dal.GetUserByLogin(login);

    		user.AccessCode = UserServiceHelper.GetNewAccessCode();

			Dal.InsertUser(user);
    	}

    	/// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="oldLogin">The old login.</param>
        /// <param name="login">The new login.</param>
        /// <param name="password">The password.</param>
        /// <param name="name">The name.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void EditUser(string oldLogin, string login, string password, string name, bool isActive)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                User user = Dal.GetUserByLogin(oldLogin);
                user.Login = login;
                if (!string.IsNullOrEmpty(password))
                {
                    MD5 md5 = MD5.Create();
                    user.Password = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
                }
                user.Name = name;
                user.IsActive = isActive;

				Dal.InsertUser(user);
            }
        }

        /// <summary>
        /// Logons the specified user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <returns>Is logon sucessfull</returns>
        public bool Logon(string login, string password)
        {
            if (Dal.CheckUserExistance(login))
            {
                User user = Dal.GetUserByLogin(login);
                MD5 md5 = MD5.Create();
                byte[] data = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                string actualPassword = sBuilder.ToString();

                sBuilder = new StringBuilder();
                data = user.Password.ToArray();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                string expectedPassword = sBuilder.ToString();
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(actualPassword, expectedPassword))
                {
                    currentUser = user;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the curent user is in specified role name.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        /// 	<c>true</c> if the curent user is in specified role name; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInRole(string roleName)
        {
            Role role = Dal.GetRoleByName(roleName);
            UserRole userSecurityObject = Dal.GetUserRole(currentUser.Id, role.Id);

	       	return (userSecurityObject == null) ? false : true;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>The user.</returns>
        public User GetUser(string login)
        {
            return Dal.GetUserByLogin(login);
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of users.</returns>
        public BindingListView<User> GetUsers()
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                return new BindingListView<User>(Dal.GetUsers());
            }
            return null;
        }

        /// <summary>
        /// Determines whether specified user can login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// 	<c>true</c> if specified user can login; otherwise, <c>false</c>.
        /// </returns>
        public bool CanLogin(string login)
        {
            User user = Dal.GetUserByLogin(login);
            if (user.IsActive)
            {
                List<Role> roles = Dal.GetUserRoles(login);
                foreach (Role role in roles)
                {
                    if (role.Name == Roles.Accountant.ToString()
                            || role.Name == Roles.SystemAdmin.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>List of roles.</returns>
        public IList<Role> GetUserRoles(string login)
        {
                return Dal.GetUserRoles(login);
        }

        /// <summary>
        /// Gets the roles list.
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetRolesList()
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                return Dal.GetRoles();
            }
            return null;
        }

        /// <summary>
        /// Deletes the user or sets IsActive to false
        /// </summary>
        /// <param name="login">The login.</param>
        public void DeleteUser(string login)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                if (currentUser.Login != login)
                {
                    User user = Dal.GetUserByLogin(login);
                    
                    //If user has no any relations, just role dependency, than clean delete
                    if(Dal.IsUserAvailableForDelete(user.Id))
                    {
                        Dal.GetUserRoles(login).ForEach( role => Dal.DeleteUserRole(Dal.GetUserRole(user.Id, role.Id)));
                    	Dal.DeleteUser(user);
                    }
                    else
                    {
                        user.IsActive = false;
                    	Dal.InsertUser(user);
                    }
                }
            }
        }

        /// <summary>
        /// Assigns the role to user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="role">The role.</param>
        public void AssignRole(string login, Roles role)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                UserRole userRole = new UserRole
                                    	{
                                    			User = Dal.GetUserByLogin(login),
                                    			Role = Dal.GetRoleByName(role.ToString())
                                    	};

            	Dal.InsertUserRole(userRole);
            }
        }

        /// <summary>
        /// Removes the specified role from user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="roleName">Name of the role.</param>
        public void RemoveRole(string login, Roles roleName)
        {
            if (IsInRole(Roles.SystemAdmin.ToString()))
            {
                if ((roleName != Roles.SystemAdmin || !CurrentRoles.Contains(Roles.SystemAdmin)) ||
                        currentUser.Login != login)
                {
                    User user = Dal.GetUserByLogin(login);
                    Role role = Dal.GetRoleByName(roleName.ToString());
                    UserRole userRole = Dal.GetUserRole(user.Id, role.Id);

                	Dal.DeleteUserRole(userRole);
                }
            }
        }

        #endregion

        #region Private Methods

        private IList<Roles> CurrentRoles
        {
            get
            {
                List<Role> userRoles = Dal.GetUserRoles(currentUser.Login);
                List<Roles> roles = new List<Roles>();
                foreach (Role role in userRoles)
                {
                    roles.Add((Roles)Enum.Parse(typeof(Roles), role.Name));
                }
                return roles;
            }
        }

        #endregion
    }
}