using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Arsis.RentalSystem.AdministrationConsole.BLL.Interface;
using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole
{
    public partial class UserManagementForm : Form
    {


        #region Fields

        private readonly IUserService userService = AppRuntime.Instance.Container.GetComponent<IUserService>();
        private readonly bool isCurrentUserChangedRights;

        #endregion

        #region Constructors

        public UserManagementForm()
        {
            InitializeComponent();

            refreshUsersList();
            refreshRolesList();

            UsersFilterExtender.AfterFiltersChanged += UsersFilterExtender_AfterFiltersChanged;
            isCurrentUserChangedRights = true;
        }

        #endregion

        #region Private Methods

        private void UsersFilterExtender_AfterFiltersChanged(object sender, EventArgs e)
        {
            refreshRolesList();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void refreshUsersList()
        {
            refreshUsersList(-1);
        }

        private void refreshUsersList(int id)
        {
            User user = null;
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvUsers.SelectedRows)
                {
                    user = row.DataBoundItem as User;
                    if (user != null)
                    {
                        break;
                    }

                }
            }
            UsersFilterExtender.DataGridView = null;
            dgvUsers.DataSource = userService.GetUsers();
            UsersFilterExtender.DataGridView = dgvUsers;
            UsersFilterExtender.RefreshFilters();
            if (id == -1)
            {
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    User actual = row.DataBoundItem as User;
                    if (user != null
                            && actual != null)
                    {
                        if (user.Id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    User actual = row.DataBoundItem as User;
                    if (actual != null)
                    {
                        if (id == actual.Id)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            dgvUsers.Focus();
        }

        private void refreshRolesList()
        {
            User user;
            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                user = row.DataBoundItem as User;
                if (user != null
                    && userService.CheckUserExistance(user.Login))
                {
                    IList<Role> systemRoles = userService.GetRolesList();
                    IList<Role> userRoles = userService.GetUserRoles(user.Login);
                    lbxCurentRoles.DataSource = userRoles;
                    foreach (Role role in userRoles)
                    {
                        systemRoles.Remove(role);
                    }
                    lbxAllRoles.DataSource = systemRoles;
                }
                return;
            }

            //If no user present: clean roles list
            lbxCurentRoles.DataSource = null;
            lbxAllRoles.DataSource = null;
        }



        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            User user;
            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                user = row.DataBoundItem as User;
                if (user != null
                    && userService.CheckUserExistance(user.Login))
                {
                    if (lbxCurentRoles.SelectedValue != null)
                    {
                        userService.RemoveRole(user.Login,
                                               (Roles)Enum.Parse(typeof(Roles), lbxCurentRoles.SelectedValue.ToString()));
                    }
                }
                break;
            }
            refreshRolesList();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            User user;
            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                user = row.DataBoundItem as User;
                if (user != null
                    && userService.CheckUserExistance(user.Login))
                {
                    if (lbxAllRoles.SelectedValue != null)
                    {
                        userService.AssignRole(user.Login,
                                               (Roles)
                                                       Enum.Parse(typeof(Roles),
                                                                  lbxAllRoles.SelectedValue.ToString()));
                    }
                }
                break;
            }
            refreshRolesList();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshRolesList();
        }

        private void dgvUsers_Enter(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.Empty;
                    row.DefaultCellStyle.SelectionForeColor = Color.Empty;
                }
            }
        }

        private void dgvUsers_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.Selected)
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.InactiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.InactiveCaptionText;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }

        private void dgvUsers_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 45:
                    {
                        AddUser();
                        break;
                    }
                case 46:
                    {
                        DeleteUser();
                        break;
                    }
                case 13:
                    {
                        EditUser();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            e.Handled = true;
        }

        private void EditUser()
        {
            User user;
            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                user = row.DataBoundItem as User;
                if (user != null)
                {
                    EditUserForm editUserForm = new EditUserForm(user.Login);
                    if (editUserForm.ShowDialog(this) == DialogResult.OK)
                    {
                        refreshUsersList();
                        refreshRolesList();
                    }
                }
                break;
            }
        }

        private void AddUser()
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog(this) == DialogResult.OK)
            {
                if (addUserForm.Tag != null)
                {
                    refreshUsersList((int)addUserForm.Tag);
                }
                else
                {
                    refreshUsersList();
                }
                refreshRolesList();
            }
        }

        private void DeleteUser()
        {
            User user;
            foreach (DataGridViewRow row in dgvUsers.SelectedRows)
            {
                user = row.DataBoundItem as User;
                if (user != null
                    && userService.CheckUserExistance(user.Login))
                {
                    if (MessageBox.Show(this, string.Format("Пользователь '{0}' будет удален, либо переведен в состояние \"Не активен\". Продолжить? ", user.Login), "Удаление пользователя", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        userService.DeleteUser(user.Login);
                    }
                }
                break;
            }
            refreshUsersList();
            refreshRolesList();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser();
        }

        private void btnRefreshUserList_Click(object sender, EventArgs e)
        {
            refreshUsersList();
            refreshRolesList();
        }

        public bool IsCurrentUserChangedRights
        {
            get { return isCurrentUserChangedRights; }
        }

		private void buttonGenerateNewAccessCode_Click(object sender, EventArgs e)
		{
			if (dgvUsers.SelectedRows.Count == 0)
			{
				return;
			}
				
			var user = dgvUsers.SelectedRows[0].DataBoundItem as User;

			if (user == null)
			{
				return;
			}

			userService.GenerateNewAccessCode(user.Login);

			MessageBox.Show(this, "Код доступа успешно изменён!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
        #endregion


    }
}
