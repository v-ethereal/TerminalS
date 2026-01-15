namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class ContractorSelectForm
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractorSelectForm));
            this.contractorsFilterExtender = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dgvContractors = new System.Windows.Forms.DataGridView();
            this.Client1SCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJuridicalPerson = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletOrgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportOutletDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.llClearContractorsFilter = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsFilterExtender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractors)).BeginInit();
            this.SuspendLayout();
            // 
            // contractorsFilterExtender
            // 
            this.contractorsFilterExtender.DataGridView = this.dgvContractors;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.contractorsFilterExtender.FilterFactory = defaultGridFilterFactory2;
            this.contractorsFilterExtender.FilterText = "";
            this.contractorsFilterExtender.FilterTextVisible = false;
            // 
            // dgvContractors
            // 
            this.dgvContractors.AllowUserToAddRows = false;
            this.dgvContractors.AllowUserToDeleteRows = false;
            this.dgvContractors.AllowUserToOrderColumns = true;
            this.dgvContractors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContractors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContractors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContractors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Client1SCode,
            this.ClientName,
            this.IsJuridicalPerson,
            this.ClientAddress,
            this.ClientPostAddress,
            this.ClientPhone,
            this.PassportSeries,
            this.PassportNumber,
            this.PassportOutletOrgan,
            this.PassportOutletDate});
            this.dgvContractors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContractors.Location = new System.Drawing.Point(25, 24);
            this.dgvContractors.MultiSelect = false;
            this.dgvContractors.Name = "dgvContractors";
            this.dgvContractors.ReadOnly = true;
            this.dgvContractors.RowHeadersVisible = false;
            this.dgvContractors.RowHeadersWidth = 22;
            this.dgvContractors.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvContractors.RowTemplate.ReadOnly = true;
            this.dgvContractors.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContractors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContractors.Size = new System.Drawing.Size(752, 338);
            this.dgvContractors.TabIndex = 1;
            this.dgvContractors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContractors_CellDoubleClick);
            this.dgvContractors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvContractors_KeyDown);
            // 
            // Client1SCode
            // 
            this.Client1SCode.DataPropertyName = "Client1SCode";
            this.Client1SCode.HeaderText = "Код контрагента";
            this.Client1SCode.Name = "Client1SCode";
            this.Client1SCode.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Название контрагента";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // IsJuridicalPerson
            // 
            this.IsJuridicalPerson.DataPropertyName = "IsJuridicalPerson";
            this.IsJuridicalPerson.HeaderText = "Юридическое лицо";
            this.IsJuridicalPerson.Name = "IsJuridicalPerson";
            this.IsJuridicalPerson.ReadOnly = true;
            this.IsJuridicalPerson.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsJuridicalPerson.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClientAddress
            // 
            this.ClientAddress.DataPropertyName = "ClientAddress";
            this.ClientAddress.HeaderText = "Адрес";
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
            // 
            // ClientPostAddress
            // 
            this.ClientPostAddress.DataPropertyName = "ClientPostAddress";
            this.ClientPostAddress.HeaderText = "Почтовый адрес";
            this.ClientPostAddress.Name = "ClientPostAddress";
            this.ClientPostAddress.ReadOnly = true;
            // 
            // ClientPhone
            // 
            this.ClientPhone.DataPropertyName = "ClientPhone";
            this.ClientPhone.HeaderText = "Телефон";
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.ReadOnly = true;
            // 
            // PassportSeries
            // 
            this.PassportSeries.DataPropertyName = "PassportSeries";
            this.PassportSeries.HeaderText = "Серия пасспорта";
            this.PassportSeries.Name = "PassportSeries";
            this.PassportSeries.ReadOnly = true;
            // 
            // PassportNumber
            // 
            this.PassportNumber.DataPropertyName = "PassportNumber";
            this.PassportNumber.HeaderText = "№ пасспорта";
            this.PassportNumber.Name = "PassportNumber";
            this.PassportNumber.ReadOnly = true;
            // 
            // PassportOutletOrgan
            // 
            this.PassportOutletOrgan.DataPropertyName = "PassportOutletOrgan";
            this.PassportOutletOrgan.HeaderText = "Пасспорт выдан";
            this.PassportOutletOrgan.Name = "PassportOutletOrgan";
            this.PassportOutletOrgan.ReadOnly = true;
            // 
            // PassportOutletDate
            // 
            this.PassportOutletDate.DataPropertyName = "PassportOutletDate";
            this.PassportOutletDate.HeaderText = "Дата выдачи";
            this.PassportOutletDate.Name = "PassportOutletDate";
            this.PassportOutletDate.ReadOnly = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.check2;
            this.btnSelect.Location = new System.Drawing.Point(677, 368);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 25);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // llClearContractorsFilter
            // 
            this.llClearContractorsFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llClearContractorsFilter.Image = ((System.Drawing.Image)(resources.GetObject("llClearContractorsFilter.Image")));
            this.llClearContractorsFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.llClearContractorsFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llClearContractorsFilter.Location = new System.Drawing.Point(2, 3);
            this.llClearContractorsFilter.Name = "llClearContractorsFilter";
            this.llClearContractorsFilter.Size = new System.Drawing.Size(22, 20);
            this.llClearContractorsFilter.TabIndex = 0;
            this.llClearContractorsFilter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.llClearContractorsFilter_MouseClick);
            this.llClearContractorsFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.llClearContractorsFilter_MouseDown);
            this.llClearContractorsFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.llClearContractorsFilter_MouseUp);
            // 
            // ContractorSelectForm
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSelect;
            this.ClientSize = new System.Drawing.Size(782, 396);
            this.Controls.Add(this.dgvContractors);
            this.Controls.Add(this.llClearContractorsFilter);
            this.Controls.Add(this.btnSelect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(798, 430);
            this.Name = "ContractorSelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите контрагента";
            ((System.ComponentModel.ISupportInitialize)(this.contractorsFilterExtender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridViewExtensions.DataGridFilterExtender contractorsFilterExtender;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.LinkLabel llClearContractorsFilter;
        private System.Windows.Forms.DataGridView dgvContractors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client1SCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsJuridicalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPostAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportOutletOrgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportOutletDate;


    }
}