namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class UserManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvUsers = new System.Windows.Forms.DataGridView();
			this.UserLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AccessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnRemoveRole = new System.Windows.Forms.Button();
			this.btnAddRole = new System.Windows.Forms.Button();
			this.lbxAllRoles = new System.Windows.Forms.ListBox();
			this.lbxCurentRoles = new System.Windows.Forms.ListBox();
			this.lblCurentRoles = new System.Windows.Forms.Label();
			this.lblRoles = new System.Windows.Forms.Label();
			this.gbUsersActions = new System.Windows.Forms.GroupBox();
			this.buttonGenerateNewAccessCode = new System.Windows.Forms.Button();
			this.btnRefreshUserList = new System.Windows.Forms.Button();
			this.btnDeleteUser = new System.Windows.Forms.Button();
			this.btnEditUser = new System.Windows.Forms.Button();
			this.btnAddUser = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.UsersFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
			this.gbUsersActions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UsersFilterExtender)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgvUsers);
			this.groupBox2.Controls.Add(this.btnRemoveRole);
			this.groupBox2.Controls.Add(this.btnAddRole);
			this.groupBox2.Controls.Add(this.lbxAllRoles);
			this.groupBox2.Controls.Add(this.lbxCurentRoles);
			this.groupBox2.Controls.Add(this.lblCurentRoles);
			this.groupBox2.Controls.Add(this.lblRoles);
			this.groupBox2.Location = new System.Drawing.Point(143, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(462, 319);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Пользователи";
			// 
			// dgvUsers
			// 
			this.dgvUsers.AllowUserToAddRows = false;
			this.dgvUsers.AllowUserToDeleteRows = false;
			this.dgvUsers.AllowUserToOrderColumns = true;
			this.dgvUsers.AllowUserToResizeRows = false;
			this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserLogin,
            this.UserName,
            this.UserPassword,
            this.UserIsActive,
            this.Id,
            this.AccessCode});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvUsers.Location = new System.Drawing.Point(9, 35);
			this.dgvUsers.MultiSelect = false;
			this.dgvUsers.Name = "dgvUsers";
			this.dgvUsers.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvUsers.RowHeadersVisible = false;
			this.dgvUsers.RowHeadersWidth = 22;
			this.dgvUsers.RowTemplate.DefaultCellStyle.NullValue = null;
			this.dgvUsers.RowTemplate.ReadOnly = true;
			this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUsers.Size = new System.Drawing.Size(240, 274);
			this.dgvUsers.TabIndex = 6;
			this.dgvUsers.Enter += new System.EventHandler(this.dgvUsers_Enter);
			this.dgvUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
			this.dgvUsers.Leave += new System.EventHandler(this.dgvUsers_Leave);
			this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
			this.dgvUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsers_KeyDown);
			// 
			// UserLogin
			// 
			this.UserLogin.DataPropertyName = "Login";
			this.UserLogin.HeaderText = "Логин";
			this.UserLogin.Name = "UserLogin";
			this.UserLogin.ReadOnly = true;
			// 
			// UserName
			// 
			this.UserName.DataPropertyName = "Name";
			this.UserName.HeaderText = "Ф.И.О.";
			this.UserName.Name = "UserName";
			this.UserName.ReadOnly = true;
			// 
			// UserPassword
			// 
			this.UserPassword.DataPropertyName = "Password";
			this.UserPassword.HeaderText = "Password";
			this.UserPassword.Name = "UserPassword";
			this.UserPassword.ReadOnly = true;
			this.UserPassword.Visible = false;
			// 
			// UserIsActive
			// 
			this.UserIsActive.DataPropertyName = "IsActive";
			this.UserIsActive.HeaderText = "Активен";
			this.UserIsActive.Name = "UserIsActive";
			this.UserIsActive.ReadOnly = true;
			this.UserIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.UserIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// Id
			// 
			this.Id.DataPropertyName = "Id";
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Visible = false;
			// 
			// AccessCode
			// 
			this.AccessCode.DataPropertyName = "AccessCode";
			this.AccessCode.HeaderText = "AccessCode";
			this.AccessCode.Name = "AccessCode";
			this.AccessCode.ReadOnly = true;
			this.AccessCode.Visible = false;
			// 
			// btnRemoveRole
			// 
			this.btnRemoveRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveRole.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.arrow_down;
			this.btnRemoveRole.Location = new System.Drawing.Point(391, 136);
			this.btnRemoveRole.Name = "btnRemoveRole";
			this.btnRemoveRole.Size = new System.Drawing.Size(32, 32);
			this.btnRemoveRole.TabIndex = 5;
			this.btnRemoveRole.UseVisualStyleBackColor = true;
			this.btnRemoveRole.Click += new System.EventHandler(this.btnRemoveRole_Click);
			// 
			// btnAddRole
			// 
			this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddRole.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.arrow_up;
			this.btnAddRole.Location = new System.Drawing.Point(353, 136);
			this.btnAddRole.Name = "btnAddRole";
			this.btnAddRole.Size = new System.Drawing.Size(32, 32);
			this.btnAddRole.TabIndex = 4;
			this.btnAddRole.UseVisualStyleBackColor = true;
			this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
			// 
			// lbxAllRoles
			// 
			this.lbxAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbxAllRoles.DisplayMember = "Description";
			this.lbxAllRoles.FormattingEnabled = true;
			this.lbxAllRoles.Location = new System.Drawing.Point(256, 174);
			this.lbxAllRoles.Name = "lbxAllRoles";
			this.lbxAllRoles.Size = new System.Drawing.Size(200, 134);
			this.lbxAllRoles.TabIndex = 3;
			this.lbxAllRoles.ValueMember = "Name";
			// 
			// lbxCurentRoles
			// 
			this.lbxCurentRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxCurentRoles.DisplayMember = "Description";
			this.lbxCurentRoles.FormattingEnabled = true;
			this.lbxCurentRoles.Location = new System.Drawing.Point(256, 35);
			this.lbxCurentRoles.Name = "lbxCurentRoles";
			this.lbxCurentRoles.Size = new System.Drawing.Size(200, 95);
			this.lbxCurentRoles.TabIndex = 2;
			this.lbxCurentRoles.ValueMember = "Name";
			// 
			// lblCurentRoles
			// 
			this.lblCurentRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurentRoles.AutoSize = true;
			this.lblCurentRoles.Location = new System.Drawing.Point(253, 19);
			this.lblCurentRoles.Name = "lblCurentRoles";
			this.lblCurentRoles.Size = new System.Drawing.Size(106, 13);
			this.lblCurentRoles.TabIndex = 0;
			this.lblCurentRoles.Text = "Роли пользователя";
			// 
			// lblRoles
			// 
			this.lblRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRoles.AutoSize = true;
			this.lblRoles.Location = new System.Drawing.Point(255, 155);
			this.lblRoles.Name = "lblRoles";
			this.lblRoles.Size = new System.Drawing.Size(80, 13);
			this.lblRoles.TabIndex = 0;
			this.lblRoles.Text = "Роли системы";
			// 
			// gbUsersActions
			// 
			this.gbUsersActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gbUsersActions.Controls.Add(this.buttonGenerateNewAccessCode);
			this.gbUsersActions.Controls.Add(this.btnRefreshUserList);
			this.gbUsersActions.Controls.Add(this.btnDeleteUser);
			this.gbUsersActions.Controls.Add(this.btnEditUser);
			this.gbUsersActions.Controls.Add(this.btnAddUser);
			this.gbUsersActions.Location = new System.Drawing.Point(12, 12);
			this.gbUsersActions.Name = "gbUsersActions";
			this.gbUsersActions.Size = new System.Drawing.Size(125, 319);
			this.gbUsersActions.TabIndex = 0;
			this.gbUsersActions.TabStop = false;
			this.gbUsersActions.Text = "Действия";
			// 
			// buttonGenerateNewAccessCode
			// 
			this.buttonGenerateNewAccessCode.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.Администратор_рабочих_групп;
			this.buttonGenerateNewAccessCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonGenerateNewAccessCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonGenerateNewAccessCode.Location = new System.Drawing.Point(6, 77);
			this.buttonGenerateNewAccessCode.Name = "buttonGenerateNewAccessCode";
			this.buttonGenerateNewAccessCode.Size = new System.Drawing.Size(113, 23);
			this.buttonGenerateNewAccessCode.TabIndex = 4;
			this.buttonGenerateNewAccessCode.Text = "Код доступа";
			this.buttonGenerateNewAccessCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.buttonGenerateNewAccessCode, "Сгенерировать новый код доступа для пользователя");
			this.buttonGenerateNewAccessCode.UseVisualStyleBackColor = true;
			this.buttonGenerateNewAccessCode.Click += new System.EventHandler(this.buttonGenerateNewAccessCode_Click);
			// 
			// btnRefreshUserList
			// 
			this.btnRefreshUserList.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.refresh;
			this.btnRefreshUserList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefreshUserList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnRefreshUserList.Location = new System.Drawing.Point(6, 137);
			this.btnRefreshUserList.Name = "btnRefreshUserList";
			this.btnRefreshUserList.Size = new System.Drawing.Size(113, 23);
			this.btnRefreshUserList.TabIndex = 3;
			this.btnRefreshUserList.Text = "Обновить";
			this.btnRefreshUserList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnRefreshUserList, "Обновить список");
			this.btnRefreshUserList.UseVisualStyleBackColor = true;
			this.btnRefreshUserList.Click += new System.EventHandler(this.btnRefreshUserList_Click);
			// 
			// btnDeleteUser
			// 
			this.btnDeleteUser.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
			this.btnDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDeleteUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDeleteUser.Location = new System.Drawing.Point(6, 107);
			this.btnDeleteUser.Name = "btnDeleteUser";
			this.btnDeleteUser.Size = new System.Drawing.Size(113, 23);
			this.btnDeleteUser.TabIndex = 2;
			this.btnDeleteUser.Text = "Удалить";
			this.btnDeleteUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnDeleteUser, "Удалить текущего пользователя");
			this.btnDeleteUser.UseVisualStyleBackColor = true;
			this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
			// 
			// btnEditUser
			// 
			this.btnEditUser.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.edit;
			this.btnEditUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEditUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnEditUser.Location = new System.Drawing.Point(6, 48);
			this.btnEditUser.Name = "btnEditUser";
			this.btnEditUser.Size = new System.Drawing.Size(113, 23);
			this.btnEditUser.TabIndex = 1;
			this.btnEditUser.Text = "Редактировать";
			this.btnEditUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnEditUser, "Редактировать текущего пользователя");
			this.btnEditUser.UseVisualStyleBackColor = true;
			this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
			// 
			// btnAddUser
			// 
			this.btnAddUser.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
			this.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnAddUser.Location = new System.Drawing.Point(6, 19);
			this.btnAddUser.Name = "btnAddUser";
			this.btnAddUser.Size = new System.Drawing.Size(113, 23);
			this.btnAddUser.TabIndex = 0;
			this.btnAddUser.Text = "Добавить";
			this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnAddUser, "Добавить нового пользователя");
			this.btnAddUser.UseVisualStyleBackColor = true;
			this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(505, 337);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(100, 25);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Закрыть";
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.btnClose, "Закрыть диалог");
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// UsersFilterExtender
			// 
			this.UsersFilterExtender.DataGridView = this.dgvUsers;
			defaultGridFilterFactory1.CreateDistinctGridFilters = false;
			defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
			defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
			defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
			defaultGridFilterFactory1.HandleEnumerationTypes = true;
			defaultGridFilterFactory1.MaximumDistinctValues = 20;
			this.UsersFilterExtender.FilterFactory = defaultGridFilterFactory1;
			this.UsersFilterExtender.FilterText = "";
			this.UsersFilterExtender.FilterTextVisible = false;
			// 
			// UserManagementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(623, 372);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.gbUsersActions);
			this.Controls.Add(this.groupBox2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(631, 399);
			this.Name = "UserManagementForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Управление пользователями";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
			this.gbUsersActions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.UsersFilterExtender)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbUsersActions;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.ListBox lbxAllRoles;
        private System.Windows.Forms.ListBox lbxCurentRoles;
        private System.Windows.Forms.Button btnRemoveRole;
        private System.Windows.Forms.Label lblCurentRoles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvUsers;
        private GridViewExtensions.DataGridFilterExtender UsersFilterExtender;
		private System.Windows.Forms.Button btnRefreshUserList;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserLogin;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserPassword;
		private System.Windows.Forms.DataGridViewCheckBoxColumn UserIsActive;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn AccessCode;
		private System.Windows.Forms.Button buttonGenerateNewAccessCode;
		private System.Windows.Forms.ToolTip toolTip1;
    }
}