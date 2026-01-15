<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdInitialize = New System.Windows.Forms.Button
        Me.cmdAcceptMoney = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdPrintAddCheck = New System.Windows.Forms.Button
        Me.cmdPrintUReport = New System.Windows.Forms.Button
        Me.cmdPrintRentalCheck = New System.Windows.Forms.Button
        Me.cmdXReport = New System.Windows.Forms.Button
        Me.cmdZReport = New System.Windows.Forms.Button
        Me.cmdReportDetails = New System.Windows.Forms.Button
        Me.cmdAcceptBarCode = New System.Windows.Forms.Button
        Me.cmdPrintParkingToken = New System.Windows.Forms.Button
        Me.cmdPrintAddCheckEx = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdInitialize
        '
        Me.cmdInitialize.Location = New System.Drawing.Point(38, 49)
        Me.cmdInitialize.Name = "cmdInitialize"
        Me.cmdInitialize.Size = New System.Drawing.Size(106, 23)
        Me.cmdInitialize.TabIndex = 0
        Me.cmdInitialize.Text = "Инициализация"
        Me.cmdInitialize.UseVisualStyleBackColor = True
        '
        'cmdAcceptMoney
        '
        Me.cmdAcceptMoney.Location = New System.Drawing.Point(161, 49)
        Me.cmdAcceptMoney.Name = "cmdAcceptMoney"
        Me.cmdAcceptMoney.Size = New System.Drawing.Size(110, 23)
        Me.cmdAcceptMoney.TabIndex = 1
        Me.cmdAcceptMoney.Text = "Принять купюру"
        Me.cmdAcceptMoney.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(38, 93)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(346, 160)
        Me.ListBox1.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(289, 49)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(95, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Отменить"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdPrintAddCheck
        '
        Me.cmdPrintAddCheck.Location = New System.Drawing.Point(161, 14)
        Me.cmdPrintAddCheck.Name = "cmdPrintAddCheck"
        Me.cmdPrintAddCheck.Size = New System.Drawing.Size(110, 23)
        Me.cmdPrintAddCheck.TabIndex = 4
        Me.cmdPrintAddCheck.Text = "Доп. услуга"
        Me.cmdPrintAddCheck.UseVisualStyleBackColor = True
        '
        'cmdPrintUReport
        '
        Me.cmdPrintUReport.Location = New System.Drawing.Point(289, 14)
        Me.cmdPrintUReport.Name = "cmdPrintUReport"
        Me.cmdPrintUReport.Size = New System.Drawing.Size(95, 23)
        Me.cmdPrintUReport.TabIndex = 5
        Me.cmdPrintUReport.Text = "Неоплаченные"
        Me.cmdPrintUReport.UseVisualStyleBackColor = True
        '
        'cmdPrintRentalCheck
        '
        Me.cmdPrintRentalCheck.Location = New System.Drawing.Point(38, 14)
        Me.cmdPrintRentalCheck.Name = "cmdPrintRentalCheck"
        Me.cmdPrintRentalCheck.Size = New System.Drawing.Size(106, 23)
        Me.cmdPrintRentalCheck.TabIndex = 6
        Me.cmdPrintRentalCheck.Text = "Аренда"
        Me.cmdPrintRentalCheck.UseVisualStyleBackColor = True
        '
        'cmdXReport
        '
        Me.cmdXReport.Location = New System.Drawing.Point(401, 14)
        Me.cmdXReport.Name = "cmdXReport"
        Me.cmdXReport.Size = New System.Drawing.Size(113, 23)
        Me.cmdXReport.TabIndex = 7
        Me.cmdXReport.Text = "Суточный X-отчет"
        Me.cmdXReport.UseVisualStyleBackColor = True
        '
        'cmdZReport
        '
        Me.cmdZReport.Location = New System.Drawing.Point(530, 14)
        Me.cmdZReport.Name = "cmdZReport"
        Me.cmdZReport.Size = New System.Drawing.Size(108, 23)
        Me.cmdZReport.TabIndex = 8
        Me.cmdZReport.Text = "Суточный Z-отчет"
        Me.cmdZReport.UseVisualStyleBackColor = True
        '
        'cmdReportDetails
        '
        Me.cmdReportDetails.Location = New System.Drawing.Point(654, 14)
        Me.cmdReportDetails.Name = "cmdReportDetails"
        Me.cmdReportDetails.Size = New System.Drawing.Size(113, 23)
        Me.cmdReportDetails.TabIndex = 9
        Me.cmdReportDetails.Text = "Детализация"
        Me.cmdReportDetails.UseVisualStyleBackColor = True
        '
        'cmdAcceptBarCode
        '
        Me.cmdAcceptBarCode.Location = New System.Drawing.Point(404, 49)
        Me.cmdAcceptBarCode.Name = "cmdAcceptBarCode"
        Me.cmdAcceptBarCode.Size = New System.Drawing.Size(110, 23)
        Me.cmdAcceptBarCode.TabIndex = 10
        Me.cmdAcceptBarCode.Text = "Принять штрихкод"
        Me.cmdAcceptBarCode.UseVisualStyleBackColor = True
        '
        'cmdPrintParkingToken
        '
        Me.cmdPrintParkingToken.Location = New System.Drawing.Point(530, 49)
        Me.cmdPrintParkingToken.Name = "cmdPrintParkingToken"
        Me.cmdPrintParkingToken.Size = New System.Drawing.Size(110, 34)
        Me.cmdPrintParkingToken.TabIndex = 11
        Me.cmdPrintParkingToken.Text = "Парковочный талон"
        Me.cmdPrintParkingToken.UseVisualStyleBackColor = True
        '
        'cmdPrintAddCheckEx
        '
        Me.cmdPrintAddCheckEx.Location = New System.Drawing.Point(783, 14)
        Me.cmdPrintAddCheckEx.Name = "cmdPrintAddCheckEx"
        Me.cmdPrintAddCheckEx.Size = New System.Drawing.Size(110, 23)
        Me.cmdPrintAddCheckEx.TabIndex = 12
        Me.cmdPrintAddCheckEx.Text = "Доп. услуга расш."
        Me.cmdPrintAddCheckEx.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 288)
        Me.Controls.Add(Me.cmdPrintAddCheckEx)
        Me.Controls.Add(Me.cmdPrintParkingToken)
        Me.Controls.Add(Me.cmdAcceptBarCode)
        Me.Controls.Add(Me.cmdReportDetails)
        Me.Controls.Add(Me.cmdZReport)
        Me.Controls.Add(Me.cmdXReport)
        Me.Controls.Add(Me.cmdPrintRentalCheck)
        Me.Controls.Add(Me.cmdPrintUReport)
        Me.Controls.Add(Me.cmdPrintAddCheck)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.cmdAcceptMoney)
        Me.Controls.Add(Me.cmdInitialize)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdInitialize As System.Windows.Forms.Button
    Friend WithEvents cmdAcceptMoney As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdPrintAddCheck As System.Windows.Forms.Button
    Friend WithEvents cmdPrintUReport As System.Windows.Forms.Button
    Friend WithEvents cmdPrintRentalCheck As System.Windows.Forms.Button
    Friend WithEvents cmdXReport As System.Windows.Forms.Button
    Friend WithEvents cmdZReport As System.Windows.Forms.Button
    Friend WithEvents cmdReportDetails As System.Windows.Forms.Button
    Friend WithEvents cmdAcceptBarCode As System.Windows.Forms.Button
    Friend WithEvents cmdPrintParkingToken As System.Windows.Forms.Button
    Friend WithEvents cmdPrintAddCheckEx As System.Windows.Forms.Button

End Class
