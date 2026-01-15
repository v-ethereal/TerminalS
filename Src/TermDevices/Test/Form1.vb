Imports System.Threading, System.Collections.ObjectModel
Imports TermClasses

Public Class Form1

    Private BV As CashCodeSMBillValidator
    Private FR As ShtrihMiniFiscalRegister
    Private BS As BarCodeScanner
    Private Delegate Sub OneStrParmDelegate(ByVal vText As String)
    Private ListBoxItemsClear As New OneStrParmDelegate(AddressOf ListBoxItemsClearMethod)
    Private ListBoxItemsAdd As New OneStrParmDelegate(AddressOf ListBoxItemsAddMethod)
    Private CmdStartMoneyEnable As New OneStrParmDelegate(AddressOf CmdStartMoneyEnableMethod)
    Private CmdStartBarCodeEnable As New OneStrParmDelegate(AddressOf CmdStartBarCodeEnableMethod)
    Private Break As Boolean

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BV = New CashCodeSMBillValidator
        ListBoxItemsAddMethod("Bill Validator PermissibleNominals :")
        For Each nom As Integer In BV.GetAcceptableBillDenominations()
            ListBoxItemsAddMethod("     " & nom.ToString)
        Next

        FR = New ShtrihMiniFiscalRegister
        BS = New BarCodeScanner

    End Sub

    Private Sub cmdInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInitialize.Click

        Try
            BV.Initialize()
            FR.Initialize()
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdAcceptMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcceptMoney.Click

        Break = False
        Dim ReaderThread As New Thread(AddressOf BillReader)
        ReaderThread.IsBackground = True
        ReaderThread.Start()
        cmdInitialize.Enabled = False
        cmdAcceptMoney.Enabled = False

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Break = True

    End Sub

    Private Sub BillReader()

        'Dim UserTimeOut As Integer = 5000000
        Dim UserMoney As Integer = 0
        'Me.Invoke(ListBoxItemsClear, New Object() {Nothing})
        Try
            UserMoney = BV.AcceptMoneyInterruptable(Break)
            If UserMoney <> 0 Then
                Me.Invoke(ListBoxItemsAdd, New Object() {"Принято " & UserMoney.ToString & " рублей"})
            End If
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try
        Me.Invoke(CmdStartMoneyEnable, New Object() {Nothing})

    End Sub

    Public Sub ListBoxItemsAddMethod(ByVal vText As String)
        ListBox1.Items.Add(vText)
        ListBox1.SetSelected(ListBox1.Items.Count - 1, True)
    End Sub

    Public Sub ListBoxItemsClearMethod(ByVal vText As String)
        ListBox1.Items.Clear()
    End Sub

    Public Sub CmdStartMoneyEnableMethod(ByVal vText As String)
        cmdInitialize.Enabled = True
        cmdAcceptMoney.Enabled = True
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ListBox1.Height = Me.ClientSize.Height - ListBox1.Top - 10
        ListBox1.Width = Me.ClientSize.Width - ListBox1.Left - 10
    End Sub

    Private Sub cmdPrintRentalCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintRentalCheck.Click

        Dim PaidParts As New List(Of DayRentalPaymentInfo)
        Dim NextDate As DateTime = #1/10/2008#
        Dim NextPrice As Decimal = 550
        Dim NextPlaceNum As Integer = 333
        For I As Integer = 0 To 11
            Dim p As New DayRentalPaymentInfo
            p.PlaceNumber = NextPlaceNum.ToString
            NextPlaceNum = NextPlaceNum + 10
            p.Date = NextDate
            NextDate = NextDate.AddDays(1)
            p.Price = NextPrice
            NextPrice = NextPrice + 10
            p.PaidSum = 600
            PaidParts.Add(p)
        Next I
        Try
            FR.PrintRentalReceipt(PaidParts)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdPrintAddCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAddCheck.Click

        Try
            FR.PrintAdditionalServiceReceipt("Аренда места №14 за 22.06.2008", 350, 344)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdPrintUReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintUReport.Click

        Dim UnpaidPlaces As New List(Of String) '(New String() {"10", "50", "100", "500", "1000", "5000"})
        UnpaidPlaces.AddRange((New String() {"      1", "       2  ", "     3 ", "      4  ", "     5  ", "     6"}))
        UnpaidPlaces.AddRange((New String() {"      11", "       12222222  ", "     13333333 ", "      144444444  ", "     1555555555  ", "     1666666666"}))
        UnpaidPlaces.AddRange((New String() {"     21", "       22  ", "     23 ", "      24  ", "     25  ", "     26"}))
        UnpaidPlaces.AddRange((New String() {"   31", "       32  ", "     33 ", "      34  ", "     35  ", "     36"}))
        UnpaidPlaces.AddRange((New String() {"   41   ", "       42  ", "     43 ", "      44  ", "     45  ", "     46"}))
        UnpaidPlaces.AddRange((New String() {"      51", "       52  ", "     53 ", "      54  ", "     55  ", "     56"}))
        UnpaidPlaces.AddRange((New String() {"  61", "       62  ", "     63 ", "      64  ", "     65  ", "     66"}))
        UnpaidPlaces.AddRange((New String() {"     71", "       72  ", "     73 ", "      74  ", "     75  ", "     76"}))
        UnpaidPlaces.AddRange((New String() {"    81", "       82  ", "     83 ", "      84  ", "     85  ", "     86"}))
        UnpaidPlaces.AddRange((New String() {"   91"}))

        Try
            FR.PrintUnpaidRentalPlacesReport(#2/25/2008#, UnpaidPlaces)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdXReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXReport.Click

        Try
            FR.PrintXReport()
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdZReport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZReport.Click

        Try
            FR.PrintZReport()
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdReportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReportDetails.Click

        Dim ServiceSums As New List(Of ServiceShiftSummaryInfo)

        Dim p1 As New ServiceShiftSummaryInfo
        p1.ServiceName = "Услуга 1"
        p1.ServicePaidTotal = 111.11
        ServiceSums.Add(p1)

        Dim p2 As New ServiceShiftSummaryInfo
        p2.ServiceName = "Услуга 2"
        p2.ServicePaidTotal = 2222222.22
        ServiceSums.Add(p2)

        Dim p3 As New ServiceShiftSummaryInfo
        p3.ServiceName = "Услуга 3"
        p3.ServicePaidTotal = 3333333.33
        ServiceSums.Add(p3)

        Dim p4 As New ServiceShiftSummaryInfo
        p4.ServiceName = "Услуга 4"
        p4.ServicePaidTotal = 4444444.44
        ServiceSums.Add(p4)

        Dim p5 As New ServiceShiftSummaryInfo
        p5.ServiceName = "Услуга 5"
        p5.ServicePaidTotal = 5555555.55
        ServiceSums.Add(p5)

        Try
            FR.PrintShiftSummaryReport("Терминал зала ожидания", ServiceSums)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdAcceptBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcceptBarCode.Click

        Break = False
        Dim ReaderThread As New Thread(AddressOf BarCodeReader)
        ReaderThread.IsBackground = True
        ReaderThread.Start()
        cmdAcceptBarCode.Enabled = False

    End Sub

    Private Sub BarCodeReader()

        'Me.Invoke(ListBoxItemsClear, New Object() {Nothing})
        Try
            Dim BarCode As String = BS.AcceptBarCode(Break)
            If BarCode <> "" Then
                'WriteLog("Считано: " & BarCode)
                Me.Invoke(ListBoxItemsAdd, New Object() {"Считано: " & BarCode})
            End If
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try
        Me.Invoke(CmdStartBarCodeEnable, New Object() {Nothing})

    End Sub

    Public Sub CmdStartBarCodeEnableMethod(ByVal vText As String)
        cmdAcceptBarCode.Enabled = True
    End Sub

    Private Sub cmdPrintParkingToken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintParkingToken.Click

        Try
            FR.PrintParkingToken(DateTime.Now, "Parking Token 99", 50, 500)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

    Private Sub cmdPrintAddCheckEx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAddCheckEx.Click


        Dim InfoItems As New List(Of String)
        InfoItems.Add("Время заезда: 15.07.09 16:08")
        InfoItems.Add("Время выезда: 15.07.09 17:44")

        Try
            FR.PrintAdditionalServiceReceiptEx("Парковка 5 часов", 350, 344, InfoItems)
        Catch ex As Exception
            Dim MsgText As String = ex.Message
            If ex.InnerException IsNot Nothing Then MsgText = MsgText & vbCr & ex.InnerException.Message
            MsgBox(MsgText)
        End Try

    End Sub

End Class
