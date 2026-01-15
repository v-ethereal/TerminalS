namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class UnpayablePeriodsManagementForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.gbManagePeriods = new System.Windows.Forms.GroupBox();
            this.lblPeriods = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lbxPeriods = new System.Windows.Forms.ListBox();
            this.dprDateTo = new System.Windows.Forms.DateTimePicker();
            this.dprDateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.tbxPlaceNumber = new System.Windows.Forms.TextBox();
            this.tbxContractNumber = new System.Windows.Forms.TextBox();
            this.lblPlaceNumber = new System.Windows.Forms.Label();
            this.lblContracNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbManagePeriods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(207, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // gbManagePeriods
            // 
            this.gbManagePeriods.Controls.Add(this.lblPeriods);
            this.gbManagePeriods.Controls.Add(this.lblReason);
            this.gbManagePeriods.Controls.Add(this.lblDateTo);
            this.gbManagePeriods.Controls.Add(this.lblDateFrom);
            this.gbManagePeriods.Controls.Add(this.lbxPeriods);
            this.gbManagePeriods.Controls.Add(this.dprDateTo);
            this.gbManagePeriods.Controls.Add(this.dprDateFrom);
            this.gbManagePeriods.Controls.Add(this.btnDelete);
            this.gbManagePeriods.Controls.Add(this.btnAdd);
            this.gbManagePeriods.Controls.Add(this.tbxReason);
            this.gbManagePeriods.Controls.Add(this.tbxPlaceNumber);
            this.gbManagePeriods.Controls.Add(this.tbxContractNumber);
            this.gbManagePeriods.Controls.Add(this.lblPlaceNumber);
            this.gbManagePeriods.Controls.Add(this.lblContracNumber);
            this.gbManagePeriods.Location = new System.Drawing.Point(12, 12);
            this.gbManagePeriods.Name = "gbManagePeriods";
            this.gbManagePeriods.Size = new System.Drawing.Size(295, 250);
            this.gbManagePeriods.TabIndex = 0;
            this.gbManagePeriods.TabStop = false;
            this.gbManagePeriods.Text = "Изменение неоплачиваемых периодов";
            // 
            // lblPeriods
            // 
            this.lblPeriods.AutoSize = true;
            this.lblPeriods.Location = new System.Drawing.Point(30, 149);
            this.lblPeriods.Name = "lblPeriods";
            this.lblPeriods.Size = new System.Drawing.Size(53, 13);
            this.lblPeriods.TabIndex = 0;
            this.lblPeriods.Text = "Периоды";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(20, 126);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(63, 13);
            this.lblReason.TabIndex = 0;
            this.lblReason.Text = "Основание";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(62, 101);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(21, 13);
            this.lblDateTo.TabIndex = 0;
            this.lblDateTo.Text = "По";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(69, 75);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(14, 13);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "С";
            // 
            // lbxPeriods
            // 
            this.lbxPeriods.DisplayMember = "DateRange";
            this.lbxPeriods.FormattingEnabled = true;
            this.lbxPeriods.Location = new System.Drawing.Point(89, 149);
            this.lbxPeriods.Name = "lbxPeriods";
            this.lbxPeriods.Size = new System.Drawing.Size(200, 95);
            this.lbxPeriods.TabIndex = 4;
            this.lbxPeriods.ValueMember = "Id";
            this.lbxPeriods.SelectedIndexChanged += new System.EventHandler(this.lbxPeriods_SelectedIndexChanged);
            // 
            // dprDateTo
            // 
            this.dprDateTo.Location = new System.Drawing.Point(89, 97);
            this.dprDateTo.Name = "dprDateTo";
            this.dprDateTo.Size = new System.Drawing.Size(200, 20);
            this.dprDateTo.TabIndex = 2;
            // 
            // dprDateFrom
            // 
            this.dprDateFrom.Location = new System.Drawing.Point(89, 71);
            this.dprDateFrom.Name = "dprDateFrom";
            this.dprDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dprDateFrom.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(58, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnDelete, "Удалить выбранный период");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(27, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnAdd, "Добавить новый период");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxReason
            // 
            this.tbxReason.Location = new System.Drawing.Point(89, 123);
            this.tbxReason.MaxLength = 250;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.Size = new System.Drawing.Size(200, 20);
            this.tbxReason.TabIndex = 3;
            // 
            // tbxPlaceNumber
            // 
            this.tbxPlaceNumber.Location = new System.Drawing.Point(89, 45);
            this.tbxPlaceNumber.Name = "tbxPlaceNumber";
            this.tbxPlaceNumber.ReadOnly = true;
            this.tbxPlaceNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxPlaceNumber.TabIndex = 0;
            // 
            // tbxContractNumber
            // 
            this.tbxContractNumber.Location = new System.Drawing.Point(89, 19);
            this.tbxContractNumber.Name = "tbxContractNumber";
            this.tbxContractNumber.ReadOnly = true;
            this.tbxContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxContractNumber.TabIndex = 0;
            // 
            // lblPlaceNumber
            // 
            this.lblPlaceNumber.AutoSize = true;
            this.lblPlaceNumber.Location = new System.Drawing.Point(12, 48);
            this.lblPlaceNumber.Name = "lblPlaceNumber";
            this.lblPlaceNumber.Size = new System.Drawing.Size(53, 13);
            this.lblPlaceNumber.TabIndex = 0;
            this.lblPlaceNumber.Text = "№ Места";
            // 
            // lblContracNumber
            // 
            this.lblContracNumber.AutoSize = true;
            this.lblContracNumber.Location = new System.Drawing.Point(12, 22);
            this.lblContracNumber.Name = "lblContracNumber";
            this.lblContracNumber.Size = new System.Drawing.Size(71, 13);
            this.lblContracNumber.TabIndex = 0;
            this.lblContracNumber.Text = "№ Договора";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // UnpayablePeriodsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(319, 300);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbManagePeriods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnpayablePeriodsManagementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Неоплачиваемые периоды";
            this.gbManagePeriods.ResumeLayout(false);
            this.gbManagePeriods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbManagePeriods;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxContractNumber;
        private System.Windows.Forms.Label lblContracNumber;
        private System.Windows.Forms.DateTimePicker dprDateTo;
        private System.Windows.Forms.DateTimePicker dprDateFrom;
        private System.Windows.Forms.ListBox lbxPeriods;
        private System.Windows.Forms.TextBox tbxPlaceNumber;
        private System.Windows.Forms.Label lblPlaceNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox tbxReason;
        private System.Windows.Forms.Label lblPeriods;
    }
}