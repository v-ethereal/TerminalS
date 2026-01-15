namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class InsertRentalPlaceRecordForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbRentalPropertyFields = new System.Windows.Forms.GroupBox();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbRentalPropertyFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(94, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbRentalPropertyFields
            // 
            this.gbRentalPropertyFields.Controls.Add(this.tbxNumber);
            this.gbRentalPropertyFields.Controls.Add(this.lblNumber);
            this.gbRentalPropertyFields.Location = new System.Drawing.Point(12, 12);
            this.gbRentalPropertyFields.Name = "gbRentalPropertyFields";
            this.gbRentalPropertyFields.Size = new System.Drawing.Size(288, 46);
            this.gbRentalPropertyFields.TabIndex = 0;
            this.gbRentalPropertyFields.TabStop = false;
            this.gbRentalPropertyFields.Text = "Поля для заполнения";
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(71, 20);
            this.tbxNumber.MaxLength = 10;
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Size = new System.Drawing.Size(189, 20);
            this.tbxNumber.TabIndex = 1;
            this.tbxNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbxNumber_Validating);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(7, 20);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(52, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "№ места";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // InsertRentalPlaceRecordForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 95);
            this.Controls.Add(this.gbRentalPropertyFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertRentalPlaceRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление торгового места";
            this.gbRentalPropertyFields.ResumeLayout(false);
            this.gbRentalPropertyFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbRentalPropertyFields;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}