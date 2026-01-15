namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class AddRentalPlaceConfirmForm
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
            this.gbRentalPropertyFields = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dprDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbRentalPropertyFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRentalPropertyFields
            // 
            this.gbRentalPropertyFields.Controls.Add(this.lblInfo);
            this.gbRentalPropertyFields.Controls.Add(this.dprDate);
            this.gbRentalPropertyFields.Location = new System.Drawing.Point(12, 12);
            this.gbRentalPropertyFields.Name = "gbRentalPropertyFields";
            this.gbRentalPropertyFields.Size = new System.Drawing.Size(288, 78);
            this.gbRentalPropertyFields.TabIndex = 0;
            this.gbRentalPropertyFields.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(244, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Торговое место будет добавлено к договору с";
            // 
            // dprDate
            // 
            this.dprDate.Location = new System.Drawing.Point(49, 52);
            this.dprDate.Name = "dprDate";
            this.dprDate.Size = new System.Drawing.Size(200, 20);
            this.dprDate.TabIndex = 1;
            this.dprDate.Validating += new System.ComponentModel.CancelEventHandler(this.dprDate_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(94, 96);
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
            this.btnCancel.Location = new System.Drawing.Point(200, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddRentalPlaceConfirmForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 128);
            this.Controls.Add(this.gbRentalPropertyFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRentalPlaceConfirmForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление торгового места к договору";
            this.gbRentalPropertyFields.ResumeLayout(false);
            this.gbRentalPropertyFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbRentalPropertyFields;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dprDate;
        private System.Windows.Forms.Label lblInfo;
    }
}