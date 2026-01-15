namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class RentalPlacesManagementForm
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
            this.gbManageRentalProperties = new System.Windows.Forms.GroupBox();
            this.btnPeriods = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbRentalProperties = new System.Windows.Forms.ComboBox();
            this.lbRentalProperties = new System.Windows.Forms.ListBox();
            this.tbxContractNumber = new System.Windows.Forms.TextBox();
            this.lblRentalProperty2 = new System.Windows.Forms.Label();
            this.lblRentalPorpery1 = new System.Windows.Forms.Label();
            this.lblContracNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbManageRentalProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbManageRentalProperties
            // 
            this.gbManageRentalProperties.Controls.Add(this.btnPeriods);
            this.gbManageRentalProperties.Controls.Add(this.btnDelete);
            this.gbManageRentalProperties.Controls.Add(this.btnAdd);
            this.gbManageRentalProperties.Controls.Add(this.cbRentalProperties);
            this.gbManageRentalProperties.Controls.Add(this.lbRentalProperties);
            this.gbManageRentalProperties.Controls.Add(this.tbxContractNumber);
            this.gbManageRentalProperties.Controls.Add(this.lblRentalProperty2);
            this.gbManageRentalProperties.Controls.Add(this.lblRentalPorpery1);
            this.gbManageRentalProperties.Controls.Add(this.lblContracNumber);
            this.gbManageRentalProperties.Location = new System.Drawing.Point(12, 12);
            this.gbManageRentalProperties.Name = "gbManageRentalProperties";
            this.gbManageRentalProperties.Size = new System.Drawing.Size(295, 238);
            this.gbManageRentalProperties.TabIndex = 0;
            this.gbManageRentalProperties.TabStop = false;
            this.gbManageRentalProperties.Text = "Изменение списка торговых мест";
            // 
            // btnPeriods
            // 
            this.btnPeriods.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.calendar;
            this.btnPeriods.Location = new System.Drawing.Point(25, 84);
            this.btnPeriods.Name = "btnPeriods";
            this.btnPeriods.Size = new System.Drawing.Size(58, 58);
            this.btnPeriods.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnPeriods, "Редактировать список неоплачиваемых периодов");
            this.btnPeriods.UseVisualStyleBackColor = true;
            this.btnPeriods.Click += new System.EventHandler(this.btnPeriods_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(58, 207);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnDelete, "Удалить торговое место");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(25, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnAdd, "Добавить новое торговое место");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbRentalProperties
            // 
            this.cbRentalProperties.DisplayMember = "Number";
            this.cbRentalProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRentalProperties.FormattingEnabled = true;
            this.cbRentalProperties.Location = new System.Drawing.Point(89, 211);
            this.cbRentalProperties.Name = "cbRentalProperties";
            this.cbRentalProperties.Size = new System.Drawing.Size(200, 21);
            this.cbRentalProperties.TabIndex = 5;
            this.cbRentalProperties.ValueMember = "Id";
            // 
            // lbRentalProperties
            // 
            this.lbRentalProperties.DisplayMember = "Number";
            this.lbRentalProperties.FormattingEnabled = true;
            this.lbRentalProperties.Location = new System.Drawing.Point(89, 45);
            this.lbRentalProperties.Name = "lbRentalProperties";
            this.lbRentalProperties.Size = new System.Drawing.Size(200, 160);
            this.lbRentalProperties.TabIndex = 1;
            this.lbRentalProperties.ValueMember = "Id";
            // 
            // tbxContractNumber
            // 
            this.tbxContractNumber.Location = new System.Drawing.Point(89, 19);
            this.tbxContractNumber.Name = "tbxContractNumber";
            this.tbxContractNumber.ReadOnly = true;
            this.tbxContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbxContractNumber.TabIndex = 0;
            // 
            // lblRentalProperty2
            // 
            this.lblRentalProperty2.AutoSize = true;
            this.lblRentalProperty2.Location = new System.Drawing.Point(45, 58);
            this.lblRentalProperty2.Name = "lblRentalProperty2";
            this.lblRentalProperty2.Size = new System.Drawing.Size(38, 13);
            this.lblRentalProperty2.TabIndex = 0;
            this.lblRentalProperty2.Text = "места";
            // 
            // lblRentalPorpery1
            // 
            this.lblRentalPorpery1.AutoSize = true;
            this.lblRentalPorpery1.Location = new System.Drawing.Point(26, 45);
            this.lblRentalPorpery1.Name = "lblRentalPorpery1";
            this.lblRentalPorpery1.Size = new System.Drawing.Size(57, 13);
            this.lblRentalPorpery1.TabIndex = 0;
            this.lblRentalPorpery1.Text = "Торговые";
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
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(207, 256);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RentalPlacesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(318, 286);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbManageRentalProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RentalPlacesManagementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Привязка торговых мест";
            this.gbManageRentalProperties.ResumeLayout(false);
            this.gbManageRentalProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbManageRentalProperties;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbRentalProperties;
        private System.Windows.Forms.ListBox lbRentalProperties;
        private System.Windows.Forms.TextBox tbxContractNumber;
        private System.Windows.Forms.Label lblContracNumber;
        private System.Windows.Forms.Label lblRentalPorpery1;
        private System.Windows.Forms.Label lblRentalProperty2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPeriods;
        private System.Windows.Forms.ToolTip toolTip;
    }
}