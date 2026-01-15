namespace Arsis.RentalSystem.AdministrationConsole.Dialogs_GUI
{
    partial class HolidayAddDialogForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Dates = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lb_Date = new System.Windows.Forms.Label();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.dateValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Dates);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.lb_Date);
            this.groupBox1.Controls.Add(this.dtpNewDate);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поля для заполнения";
            // 
            // dgv_Dates
            // 
            this.dgv_Dates.AllowUserToAddRows = false;
            this.dgv_Dates.AllowUserToDeleteRows = false;
            this.dgv_Dates.AllowUserToResizeColumns = false;
            this.dgv_Dates.AllowUserToResizeRows = false;
            this.dgv_Dates.AutoGenerateColumns = false;
            this.dgv_Dates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Dates.ColumnHeadersVisible = false;
            this.dgv_Dates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateValueDataGridViewTextBoxColumn});
            this.dgv_Dates.DataSource = this.bindingSource;
            this.dgv_Dates.Location = new System.Drawing.Point(80, 44);
            this.dgv_Dates.MultiSelect = false;
            this.dgv_Dates.Name = "dgv_Dates";
            this.dgv_Dates.ReadOnly = true;
            this.dgv_Dates.RowHeadersVisible = false;
            this.dgv_Dates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Dates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Dates.Size = new System.Drawing.Size(169, 147);
            this.dgv_Dates.TabIndex = 3;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Arsis.RentalSystem.AdministrationConsole.Dialogs_GUI.SimpleDateTimeItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Список:";
            // 
            // btDelete
            // 
            this.btDelete.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.delete;
            this.btDelete.Location = new System.Drawing.Point(255, 166);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(25, 25);
            this.btDelete.TabIndex = 4;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.add;
            this.btAdd.Location = new System.Drawing.Point(255, 15);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(25, 25);
            this.btAdd.TabIndex = 2;
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lb_Date
            // 
            this.lb_Date.AutoSize = true;
            this.lb_Date.Location = new System.Drawing.Point(13, 21);
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Size = new System.Drawing.Size(61, 13);
            this.lb_Date.TabIndex = 1;
            this.lb_Date.Text = "Дата вых.:";
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.Location = new System.Drawing.Point(80, 18);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(169, 20);
            this.dtpNewDate.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.cancel;
            this.btCancel.Location = new System.Drawing.Point(196, 219);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 25);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Отменить";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSave.Image = global::Arsis.RentalSystem.AdministrationConsole.Properties.Resources.disk;
            this.btSave.Location = new System.Drawing.Point(90, 219);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 25);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Сохранить";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // dateValueDataGridViewTextBoxColumn
            // 
            this.dateValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateValueDataGridViewTextBoxColumn.DataPropertyName = "DateValue";
            dataGridViewCellStyle1.Format = "dd MMMM yyyy г.";
            this.dateValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateValueDataGridViewTextBoxColumn.HeaderText = "DateValue";
            this.dateValueDataGridViewTextBoxColumn.Name = "dateValueDataGridViewTextBoxColumn";
            this.dateValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // HolidayAddDialogForm
            // 
            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(302, 251);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HolidayAddDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление выходных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.Label lb_Date;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridView dgv_Dates;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateValueDataGridViewTextBoxColumn;
    }
}