namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class TransferRentalPlaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.gbContracts = new System.Windows.Forms.GroupBox();
            this.cpContractTo = new Arsis.RentalSystem.AdministrationConsole.UserControls.ContractPicker();
            this.cpContractFrom = new Arsis.RentalSystem.AdministrationConsole.UserControls.ContractPicker();
            this.dprDate = new System.Windows.Forms.DateTimePicker();
            this.lbxRentalPlaces = new System.Windows.Forms.ListBox();
            this.lblRentalPlaces = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblContractTo = new System.Windows.Forms.Label();
            this.lbContractFrom = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnTransfer.Location = new System.Drawing.Point(94, 210);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(100, 25);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Передать";
            this.btnTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // gbContracts
            // 
            this.gbContracts.Controls.Add(this.cpContractTo);
            this.gbContracts.Controls.Add(this.cpContractFrom);
            this.gbContracts.Controls.Add(this.dprDate);
            this.gbContracts.Controls.Add(this.lbxRentalPlaces);
            this.gbContracts.Controls.Add(this.lblRentalPlaces);
            this.gbContracts.Controls.Add(this.lblDate);
            this.gbContracts.Controls.Add(this.lblContractTo);
            this.gbContracts.Controls.Add(this.lbContractFrom);
            this.gbContracts.Location = new System.Drawing.Point(12, 12);
            this.gbContracts.Name = "gbContracts";
            this.gbContracts.Size = new System.Drawing.Size(288, 192);
            this.gbContracts.TabIndex = 0;
            this.gbContracts.TabStop = false;
            this.gbContracts.Text = "Ввод информации о передаче";
            // 
            // cpContractTo
            // 
            this.cpContractTo.ContractId = 0;
            this.cpContractTo.ContractService = null;
            this.cpContractTo.Location = new System.Drawing.Point(110, 138);
            this.cpContractTo.Name = "cpContractTo";
            this.cpContractTo.Size = new System.Drawing.Size(150, 20);
			this.cpContractTo.State = Arsis.RentalSystem.Core.Bll.ContractState.Active;
            this.cpContractTo.TabIndex = 7;
            this.cpContractTo.ValueChanged += new ValueChangedEventHandler(this.cpContractTo_ValueChanged);
            this.cpContractTo.Validating += new System.ComponentModel.CancelEventHandler(this.contractTo_Validating);
            // 
            // cpContractFrom
            // 
            this.cpContractFrom.ContractId = 0;
            this.cpContractFrom.ContractService = null;
            this.cpContractFrom.Location = new System.Drawing.Point(110, 21);
            this.cpContractFrom.Name = "cpContractFrom";
            this.cpContractFrom.Size = new System.Drawing.Size(150, 20);
			this.cpContractFrom.State = Arsis.RentalSystem.Core.Bll.ContractState.Active;
            this.cpContractFrom.TabIndex = 7;
            this.cpContractFrom.ValueChanged += new ValueChangedEventHandler(this.cpContractFrom_ValueChanged);
            this.cpContractFrom.Validating += new System.ComponentModel.CancelEventHandler(this.contractFrom_Validating);
            // 
            // dprDate
            // 
            this.dprDate.Location = new System.Drawing.Point(110, 163);
            this.dprDate.Name = "dprDate";
            this.dprDate.Size = new System.Drawing.Size(150, 20);
            this.dprDate.TabIndex = 6;
            this.dprDate.Validating += new System.ComponentModel.CancelEventHandler(this.dprDate_Validating);
            // 
            // lbxRentalPlaces
            // 
            this.lbxRentalPlaces.DisplayMember = "Number";
            this.lbxRentalPlaces.FormattingEnabled = true;
            this.lbxRentalPlaces.Location = new System.Drawing.Point(110, 47);
            this.lbxRentalPlaces.Name = "lbxRentalPlaces";
            this.lbxRentalPlaces.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxRentalPlaces.Size = new System.Drawing.Size(150, 82);
            this.lbxRentalPlaces.TabIndex = 3;
            this.lbxRentalPlaces.ValueMember = "Id";
            // 
            // lblRentalPlaces
            // 
            this.lblRentalPlaces.AutoSize = true;
            this.lblRentalPlaces.Location = new System.Drawing.Point(6, 81);
            this.lblRentalPlaces.Name = "lblRentalPlaces";
            this.lblRentalPlaces.Size = new System.Drawing.Size(39, 13);
            this.lblRentalPlaces.TabIndex = 2;
            this.lblRentalPlaces.Text = "Места";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 167);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(83, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Дата передачи";
            // 
            // lblContractTo
            // 
            this.lblContractTo.AutoSize = true;
            this.lblContractTo.Location = new System.Drawing.Point(6, 138);
            this.lblContractTo.Name = "lblContractTo";
            this.lblContractTo.Size = new System.Drawing.Size(79, 13);
            this.lblContractTo.TabIndex = 4;
            this.lblContractTo.Text = "На договор №";
            // 
            // lbContractFrom
            // 
            this.lbContractFrom.AutoSize = true;
            this.lbContractFrom.Location = new System.Drawing.Point(6, 23);
            this.lbContractFrom.Name = "lbContractFrom";
            this.lbContractFrom.Size = new System.Drawing.Size(78, 13);
            this.lbContractFrom.TabIndex = 0;
            this.lbContractFrom.Text = "С договора №";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // TransferRentalPlaceForm
            // 
            this.AcceptButton = this.btnTransfer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 242);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.gbContracts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferRentalPlaceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Передача торговых мест";
            this.gbContracts.ResumeLayout(false);
            this.gbContracts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.GroupBox gbContracts;
        private System.Windows.Forms.Label lblContractTo;
        private System.Windows.Forms.Label lbContractFrom;
        private System.Windows.Forms.ListBox lbxRentalPlaces;
        private System.Windows.Forms.Label lblRentalPlaces;
        private System.Windows.Forms.DateTimePicker dprDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private UserControls.ContractPicker cpContractTo;
        private UserControls.ContractPicker cpContractFrom;
    }
}