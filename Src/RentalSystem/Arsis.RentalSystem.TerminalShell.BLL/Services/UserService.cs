using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;
using Arsis.RentalSystem.TerminalShell.BLL.Interface;

namespace Arsis.RentalSystem.TerminalShell.BLL.Services
{
	public class UserService : BaseService, IUserService
	{
		private User currentUser;

		/// <summary>
		/// Logons the user.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <param name="password">The password.</param>
		/// <returns>Is loged in.</returns>
		public bool Logon(string login, string password)
		{
			if (Dal.CheckActiveUserExistance(login))
			{
				User user = Dal.GetActivUserByLogin(login);
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
		/// Logoffs user.
		/// </summary>
		public void Logoff()
		{
			currentUser = null;
		}

		/// <summary>
		/// Determines whether current user is in role for the specified role name.
		/// </summary>
		/// <param name="roleName">Name of the role.</param>
		/// <returns>
		/// 	<c>true</c> if  current user is in specified role name; otherwise, <c>false</c>.
		/// </returns>
		public bool IsInRole(string roleName)
		{
			Role role = Dal.GetRoleByName(roleName);
			UserRole userSecurityObject = Dal.GetActiveUserRole(currentUser.Id, role.Id);
			if (currentUser.UserRoles.Contains(userSecurityObject))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Gets the user roles.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <returns>List of user roles.</returns>
		public IList<Role> GetUserRoles(string login)
		{
			return Dal.GetActiveUserRoles(login);
		}

		/// <summary>
		///  получить инфо о пользователе по логину
		/// </summary>
		/// <param name="login">логин</param>
		/// <returns>инфо о пользователе</returns>
		public User GetUser(string login)
		{
			return Dal.GetActivUserByLogin(login);
		}

		/// <summary>
		/// Получить инфо о пользователи по коду доступа
		/// </summary>
		/// <param name="accessCode">код доступа</param>
		/// <returns>инфо о пользователе</returns>
		public User GetUserByAccessCode(string accessCode)
		{
			return Dal.GetUserByAccessCode(accessCode);
		}
	}
}