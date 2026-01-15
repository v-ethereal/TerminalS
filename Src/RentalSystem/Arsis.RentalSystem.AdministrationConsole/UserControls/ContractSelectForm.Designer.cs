namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    partial class ContractSelectForm
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractSelectForm));
            this.contractFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.ContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentalServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractCrUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DissolutionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client1SCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contract1SCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletOrgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCashless = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CashlessPaymebtControlDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJuridicalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractChDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractChUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractUser1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatusDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractStatusMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.llClearContractsFilter = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.contractFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // contractFilterExtender
            // 
            this.contractFilterExtender.DataGridView = this.dgvContracts;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.contractFilterExtender.FilterFactory = defaultGridFilterFactory1;
            this.contractFilterExtender.FilterText = "";
            this.contractFilterExtender.FilterTextVisible = false;
            // 
            // dgvContracts
            // 
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            this.dgvContracts.AllowUserToOrderColumns = true;
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractId,
            this.RentalServiceId,
            this.columnContractNumber,
            this.CreationDate,
            this.ContractCrUserId,
            this.DateFrom,
            this.DateTo,
            this.DissolutionDate,
            this.ClientName,
            this.Client1SCode,
            this.Contract1SCode,
            this.PassportOutletOrgan,
            this.ClientAddress,
            this.ClientPostAddress,
            this.ClientPhone,
            this.PassportSeries,
            this.PassportOutletDate,
            this.INN,
            this.IsCashless,
            this.CashlessPaymebtControlDate,
            this.PassportNumber,
            this.IsJuridicalPerson,
            this.PlacePrice,
            this.Service,
            this.ContractChDateTime,
            this.ContractChUserId,
            this.ContractUser,
            this.ContractUser1,
            this.ContractStatus,
            this.ContractStatusDateTime,
            this.ContractStatusMessage});
            this.dgvContracts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContracts.Location = new System.Drawing.Point(29, 26);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(625, 278);
            this.dgvContracts.TabIndex = 3;
            this.dgvContracts.Enter += new System.EventHandler(this.dgvContracts_Enter);
            this.dgvContracts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContracts_CellDoubleClick);
            this.dgvContracts.Leave += new System.EventHandler(this.dgvContracts_Leave);
            this.dgvContracts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvContracts_KeyDown);
            // 
            // ContractId
            // 
            this.ContractId.DataPropertyName = "Id";
            this.ContractId.HeaderText = "Id";
            this.ContractId.Name = "ContractId";
            this.ContractId.ReadOnly = true;
            this.ContractId.Visible = false;
            // 
            // RentalServiceId
            // 
            this.RentalServiceId.DataPropertyName = "RentalServiceId";
            this.RentalServiceId.HeaderText = "RentalServiceId";
            this.RentalServiceId.Name = "RentalServiceId";
            this.RentalServiceId.ReadOnly = true;
            this.RentalServiceId.Visible = false;
            // 
            // columnContractNumber
            // 
            this.columnContractNumber.DataPropertyName = "ContractNumber";
            this.columnContractNumber.HeaderText = "Номер договора";
            this.columnContractNumber.Name = "columnContractNumber";
            this.columnContractNumber.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CrDateTime";
            this.CreationDate.HeaderText = "Дата создания";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Visible = false;
            // 
            // ContractCrUserId
            // 
            this.ContractCrUserId.DataPropertyName = "CrUserId";
            this.ContractCrUserId.HeaderText = "ContractCrUserId";
            this.ContractCrUserId.Name = "ContractCrUserId";
            this.ContractCrUserId.ReadOnly = true;
            this.ContractCrUserId.Visible = false;
            // 
            // DateFrom
            // 
            this.DateFrom.DataPropertyName = "DateFrom";
            this.DateFrom.HeaderText = "Срок действия с";
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ReadOnly = true;
            // 
            // DateTo
            // 
            this.DateTo.DataPropertyName = "DateTo";
            this.DateTo.HeaderText = "Срок действия по";
            this.DateTo.Name = "DateTo";
            this.DateTo.ReadOnly = true;
            // 
            // DissolutionDate
            // 
            this.DissolutionDate.DataPropertyName = "DissolutionDate";
            this.DissolutionDate.HeaderText = "Дата закрытия";
            this.DissolutionDate.Name = "DissolutionDate";
            this.DissolutionDate.ReadOnly = true;
            this.DissolutionDate.Visible = false;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Контрагент";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // Client1SCode
            // 
            this.Client1SCode.DataPropertyName = "Client1SCode";
            this.Client1SCode.HeaderText = "Код контрагента";
            this.Client1SCode.Name = "Client1SCode";
            this.Client1SCode.ReadOnly = true;
            // 
            // Contract1SCode
            // 
            this.Contract1SCode.DataPropertyName = "Contract1SCode";
            this.Contract1SCode.HeaderText = "Contract1SCode";
            this.Contract1SCode.Name = "Contract1SCode";
            this.Contract1SCode.ReadOnly = true;
            this.Contract1SCode.Visible = false;
            // 
            // PassportOutletOrgan
            // 
            this.PassportOutletOrgan.DataPropertyName = "PassportOutletOrgan";
            this.PassportOutletOrgan.HeaderText = "PassportOutletOrgan";
            this.PassportOutletOrgan.Name = "PassportOutletOrgan";
            this.PassportOutletOrgan.ReadOnly = true;
            this.PassportOutletOrgan.Visible = false;
            // 
            // ClientAddress
            // 
            this.ClientAddress.DataPropertyName = "ClientAddress";
            this.ClientAddress.HeaderText = "ClientAddress";
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
            this.ClientAddress.Visible = false;
            // 
            // ClientPostAddress
            // 
            this.ClientPostAddress.DataPropertyName = "ClientPostAddress";
            this.ClientPostAddress.HeaderText = "ClientPostAddress";
            this.ClientPostAddress.Name = "ClientPostAddress";
            this.ClientPostAddress.ReadOnly = true;
            this.ClientPostAddress.Visible = false;
            // 
            // ClientPhone
            // 
            this.ClientPhone.DataPropertyName = "ClientPhone";
            this.ClientPhone.HeaderText = "ClientPhone";
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.ReadOnly = true;
            this.ClientPhone.Visible = false;
            // 
            // PassportSeries
            // 
            this.PassportSeries.DataPropertyName = "PassportSeries";
            this.PassportSeries.HeaderText = "PassportSeries";
            this.PassportSeries.Name = "PassportSeries";
            this.PassportSeries.ReadOnly = true;
            this.PassportSeries.Visible = false;
            // 
            // PassportOutletDate
            // 
            this.PassportOutletDate.DataPropertyName = "PassportOutletDate";
            this.PassportOutletDate.HeaderText = "PassportOutletDate";
            this.PassportOutletDate.Name = "PassportOutletDate";
            this.PassportOutletDate.ReadOnly = true;
            this.PassportOutletDate.Visible = false;
            // 
            // INN
            // 
            this.INN.DataPropertyName = "INN";
            this.INN.HeaderText = "ИНН";
            this.INN.Name = "INN";
            this.INN.ReadOnly = true;
            this.INN.Visible = false;
            // 
            // IsCashless
            // 
            this.IsCashless.DataPropertyName = "IsCashless";
            this.IsCashless.HeaderText = "Возможен безналичный расчет";
            this.IsCashless.Name = "IsCashless";
            this.IsCashless.ReadOnly = true;
            this.IsCashless.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCashless.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCashless.Visible = false;
            // 
            // CashlessPaymebtControlDate
            // 
            this.CashlessPaymebtControlDate.DataPropertyName = "CashlessPaymentControlDate";
            this.CashlessPaymebtControlDate.HeaderText = "Дата контроля платежа";
            this.CashlessPaymebtControlDate.Name = "CashlessPaymebtControlDate";
            this.CashlessPaymebtControlDate.ReadOnly = true;
            // 
            // PassportNumber
            // 
            this.PassportNumber.DataPropertyName = "PassportNumber";
            this.PassportNumber.HeaderText = "Номер паспорта";
            this.PassportNumber.Name = "PassportNumber";
            this.PassportNumber.ReadOnly = true;
            this.PassportNumber.Visible = false;
            // 
            // IsJuridicalPerson
            // 
            this.IsJuridicalPerson.DataPropertyName = "IsJuridicalPerson";
            this.IsJuridicalPerson.HeaderText = "Тип договора";
            this.IsJuridicalPerson.Name = "IsJuridicalPerson";
            this.IsJuridicalPerson.ReadOnly = true;
            this.IsJuridicalPerson.Visible = false;
            // 
            // PlacePrice
            // 
            this.PlacePrice.DataPropertyName = "PlacePrice";
            this.PlacePrice.HeaderText = "PlacePrice";
            this.PlacePrice.Name = "PlacePrice";
            this.PlacePrice.ReadOnly = true;
            this.PlacePrice.Visible = false;
            // 
            // Service
            // 
            this.Service.DataPropertyName = "Service";
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.ReadOnly = true;
            this.Service.Visible = false;
            // 
            // ContractChDateTime
            // 
            this.ContractChDateTime.DataPropertyName = "ChDateTime";
            this.ContractChDateTime.HeaderText = "ContractChDateTime";
            this.ContractChDateTime.Name = "ContractChDateTime";
            this.ContractChDateTime.ReadOnly = true;
            this.ContractChDateTime.Visible = false;
            // 
            // ContractChUserId
            // 
            this.ContractChUserId.DataPropertyName = "ChUserId";
            this.ContractChUserId.HeaderText = "ContractChUserId";
            this.ContractChUserId.Name = "ContractChUserId";
            this.ContractChUserId.ReadOnly = true;
            this.ContractChUserId.Visible = false;
            // 
            // ContractUser
            // 
            this.ContractUser.DataPropertyName = "User";
            this.ContractUser.HeaderText = "ContractUser";
            this.ContractUser.Name = "ContractUser";
            this.ContractUser.ReadOnly = true;
            this.ContractUser.Visible = false;
            // 
            // ContractUser1
            // 
            this.ContractUser1.DataPropertyName = "User1";
            this.ContractUser1.HeaderText = "ContractUser1";
            this.ContractUser1.Name = "ContractUser1";
            this.ContractUser1.ReadOnly = true;
            this.ContractUser1.Visible = false;
            // 
            // ContractStatus
            // 
            this.ContractStatus.DataPropertyName = "Status";
            this.ContractStatus.HeaderText = "ContractStatus";
            this.ContractStatus.Name = "ContractStatus";
            this.ContractStatus.ReadOnly = true;
            this.ContractStatus.Visible = false;
            // 
            // ContractStatusDateTime
            // 
            this.ContractStatusDateTime.DataPropertyName = "StatusDateTime";
            this.ContractStatusDateTime.HeaderText = "ContractStatusDateTime";
            this.ContractStatusDateTime.Name = "ContractStatusDateTime";
            this.ContractStatusDateTime.ReadOnly = true;
            this.ContractStatusDateTime.Visible = false;
            // 
            // ContractStatusMessage
            // 
            this.ContractStatusMessage.DataPropertyName = "StatusMessage";
            this.ContractStatusMessage.HeaderText = "Результат выгрузки в 1С";
            this.ContractStatusMessage.Name = "ContractStatusMessage";
            this.ContractStatusMessage.ReadOnly = true;
            this.ContractStatusMessage.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.check2;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.Location = new System.Drawing.Point(554, 310);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 25);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // llClearContractsFilter
            // 
            this.llClearContractsFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearContractsFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearContractsFilter.Image")));
            this.llClearContractsFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearContractsFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearContractsFilter.Location = new System.Drawing.Point(3, 4);
            this.llClearContractsFilter.Name = "llClearContractsFilter";
            this.llClearContractsFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearContractsFilter.TabIndex = 0;
            this.llClearContractsFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearContractsFilter_MouseClick);
            this.llClearContractsFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearContractsFilter_MouseDown);
            this.llClearContractsFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearContractsFilter_MouseUp);
            // 
            // ContractSelectForm
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 341);
            this.Controls.Add(this.dgvContracts);
            this.Controls.Add(this.llClearContractsFilter);
            this.Controls.Add(this.btnSelect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(677, 375);
            this.Name = "ContractSelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор договора";
            ((System.ComponentModel.ISupportInitialize)(this.contractFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridViewExtensions.DataGridFilterExtender contractFilterExtender;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.LinkLabel llClearContractsFilter;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentalServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnContractNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractCrUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DissolutionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client1SCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contract1SCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportOutletOrgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPostAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportOutletDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn INN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCashless;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashlessPaymebtControlDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsJuridicalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractChDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractChUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractUser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractStatusDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractStatusMessage;


    }
}