namespace Arsis.RentalSystem.AdministrationConsole
{
    partial class DateCriteriaSelectionForm
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dprToDate = new System.Windows.Forms.DateTimePicker();
            this.dprFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.lblToDate);
            this.gbFilter.Controls.Add(this.lblFromDate);
            this.gbFilter.Controls.Add(this.dprToDate);
            this.gbFilter.Controls.Add(this.dprFromDate);
            this.gbFilter.Location = new System.Drawing.Point(12, 12);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(338, 71);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Фильтр";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblToDate.Location = new System.Drawing.Point(107, 49);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(19, 13);
            this.lblToDate.TabIndex = 0;
            this.lblToDate.Text = "по";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFromDate.Location = new System.Drawing.Point(6, 23);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(120, 13);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Отображать записи с ";
            // 
            // dprToDate
            // 
            this.dprToDate.Location = new System.Drawing.Point(132, 45);
            this.dprToDate.Name = "dprToDate";
            this.dprToDate.Size = new System.Drawing.Size(200, 20);
            this.dprToDate.TabIndex = 2;
            this.dprToDate.ValueChanged += new System.EventHandler(this.dprToDate_ValueChanged);
            // 
            // dprFromDate
            // 
            this.dprFromDate.Location = new System.Drawing.Point(132, 19);
            this.dprFromDate.Name = "dprFromDate";
            this.dprFromDate.Size = new System.Drawing.Size(200, 20);
            this.dprFromDate.TabIndex = 1;
            this.dprFromDate.ValueChanged += new System.EventHandler(this.dprFromDate_ValueChanged);
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(12, 89);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 25);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "&Отмена";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(250, 89);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 25);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // DateCriteriaSelectionForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(362, 124);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateCriteriaSelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры отчета";
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dprToDate;
        private System.Windows.Forms.DateTimePicker dprFromDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;

    }
}