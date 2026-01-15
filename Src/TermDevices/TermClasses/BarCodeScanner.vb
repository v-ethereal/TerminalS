Imports System.IO, System.Threading, System.Xml

Public Class BarCodeScanner
    Implements ITerminalBarCodeScanner

    Private BCS As Ports.SerialPort
    Friend Shared cfgDebugLevel As Integer = 1
    Friend Shared cfgComPort As String = "COM1"
    Friend Shared cfgBaudRate As Integer = 9600
    Friend Shared cfgReadTimeOut As Integer = 1500
    Private Buffer As String = ""
    Private synBuffer As New ReaderWriterLock()

    Private Shared Sub WriteLog(ByVal msg As String)
        If cfgDebugLevel > 0 Then Trace.WriteLine(DateTime.Now.ToString & " " & msg)
    End Sub

    Public Sub New()
        'Constructor of the class BarCodeScanner

        MyBase.New()

        Do
            Dim CfgName As String = Reflection.[Assembly].GetExecutingAssembly.Location
            CfgName = IO.Path.GetDirectoryName(CfgName)
            CfgName = IO.Path.Combine(CfgName, "TermClasses.cfg")
            CfgName = IO.Path.GetFullPath(CfgName)
            If Not IO.File.Exists(CfgName) Then
                WriteLog("Configuration file not found, default values will be used")
                Exit Do
            End If
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(CfgName)
            Dim rootNode As XmlNode = xmlDoc.DocumentElement
            If rootNode.Name <> "TermDevices" Then
                WriteLog("TermDevices node not found in root of the configuration XML tree, default values will be used")
                Exit Do
            End If

            Dim BVNode As XmlNode = rootNode.SelectSingleNode("descendant::BarCodeScanner")
            If BVNode Is Nothing Then
                WriteLog("BarCodeScanner section of configuration file not found, default values will be used")
                Exit Do
            End If

            Dim xmlNode As XmlNode = BVNode.SelectSingleNode("descendant::Parameters")
            If xmlNode Is Nothing Then
                WriteLog("Parameters node of BarCodeScanner configuration section not found, default values will be used")
                Exit Do
            End If

            Dim watr As XmlAttribute
            watr = CType(xmlNode.Attributes.GetNamedItem("DebugLevel"), XmlAttribute)
            If watr Is Nothing Then
                WriteLog("DebugLevel value not found in configuration file, default value will be used")
            Else
                If IsNumeric(watr.Value) Then
                    cfgDebugLevel = CInt(watr.Value)
                Else
                    WriteLog("Invalid numeric value " & Trim(watr.Value) & " for DebugLevel parameter, default value will be used")
                End If
            End If

            watr = CType(xmlNode.Attributes.GetNamedItem("ComPortName"), XmlAttribute)
            If watr Is Nothing Then
                WriteLog("ComPortName value not found in configuration file, default value will be used")
                'Exit Sub
            Else
                cfgComPort = Trim(watr.Value)
            End If

            watr = CType(xmlNode.Attributes.GetNamedItem("ComPortBaudRate"), XmlAttribute)
            If watr Is Nothing Then
                WriteLog("ComPortBaudRate value not found in configuration file, default value will be used")
            Else
                If IsNumeric(watr.Value) Then
                    cfgBaudRate = CInt(watr.Value)
                Else
                    WriteLog("Invalid numeric value " & Trim(watr.Value) & " for ComPortBaudRate parameter, default value will be used")
                End If
            End If

            watr = CType(xmlNode.Attributes.GetNamedItem("ComPortReadTimeout"), XmlAttribute)
            If watr Is Nothing Then
                WriteLog("ComPortReadTimeout value not found in configuration file, default value will be used")
            Else
                If IsNumeric(watr.Value) Then
                    cfgReadTimeOut = CInt(watr.Value)
                Else
                    WriteLog("Invalid numeric value " & Trim(watr.Value) & " for ComPortReadTimeout parameter, default value will be used")
                End If
            End If

            Exit Do
        Loop

        WriteLog("BarCodeScanner device parameters in use :")
        WriteLog("     DebugLevel = " & cfgDebugLevel.ToString)
        WriteLog("     ComPortName = " & cfgComPort)
        WriteLog("     ComPortBaudRate = " & cfgBaudRate.ToString)
        WriteLog("     ComPortReadTimeout = " & cfgReadTimeOut.ToString)

        BCS = New Ports.SerialPort

        'Message terminator = CR/LF

        'Auto-Scan mode:
        ' light is always on,
        ' the scan is still active after the data is transmitted,
        ' successive transmission of the same barcode is not allowed when the barcode had been removed

        BCS.ReadBufferSize = 65534
        BCS.WriteBufferSize = &HFFFF - 1 '=65534
        BCS.PortName = cfgComPort
        BCS.BaudRate = cfgBaudRate
        BCS.DataBits = 8
        BCS.Parity = Ports.Parity.None
        BCS.StopBits = 1
        BCS.DtrEnable = False
        BCS.RtsEnable = False
        BCS.Handshake = Ports.Handshake.None
        BCS.ReadTimeout = cfgReadTimeOut + 66
        BCS.WriteTimeout = 266

    End Sub

    Private Sub OnDataReceived(ByVal source As Object, ByVal e As Ports.SerialDataReceivedEventArgs)
        'WriteLog("DataReceived: " & e.EventType.ToString)

        Try
            synBuffer.AcquireWriterLock(10000)
        Catch ex As ApplicationException
            WriteLog("The writer lock request timed out")
            Exit Sub
        End Try
        Try
            Buffer = BCS.ReadTo(vbCrLf)
            If cfgDebugLevel >= 2 Then WriteLog("< " & Buffer)
        Catch ex As Exception
            WriteLog("Receive aborted :" & vbCrLf & ex.ToString)
        Finally
            synBuffer.ReleaseWriterLock()
        End Try

    End Sub

    Private Sub OnErrorReceived(ByVal source As Object, ByVal e As Ports.SerialErrorReceivedEventArgs)
        WriteLog("ErrorReceived: " & e.EventType.ToString)
    End Sub

    Private Sub OnPinChanged(ByVal source As Object, ByVal e As Ports.SerialPinChangedEventArgs)
        WriteLog("PinChanged: " & e.EventType.ToString)
    End Sub

    Public Function AcceptBarCode(ByRef Break As Boolean) As String Implements ITerminalBarCodeScanner.AcceptBarCode

        Dim BarCode As String = ""

        Try
            BCS.Open()
            If Not BCS.IsOpen Then
                WriteLog("Open failed")
                Throw New ApplicationException("Ќе удалось открыть " & BCS.PortName)
                Exit Function
            Else
                WriteLog("Opened successfully")

                BCS.DiscardInBuffer()
                BCS.DiscardOutBuffer()

                Buffer = ""
                AddHandler BCS.DataReceived, AddressOf OnDataReceived
                AddHandler BCS.ErrorReceived, AddressOf OnErrorReceived
                AddHandler BCS.PinChanged, AddressOf OnPinChanged

                'ƒождатьс€ окончани€ приЄма штрих-кода, периодически провер€€, не прервана ли операци€ пользователем
                Do
                    Try
                        synBuffer.AcquireReaderLock(10000)
                    Catch ex As ApplicationException
                        WriteLog("The reader lock request timed out")
                        Throw New ApplicationException("Ќе удалось получить требуемый ресурс")
                        Exit Function
                    End Try
                    Try
                        BarCode = Buffer   'копирование ссылки или данных ?
                    Finally
                        synBuffer.ReleaseReaderLock()
                    End Try

                    If BarCode <> "" Then 'что-то прин€то
                        WriteLog("< " & BarCode)
                        Exit Do
                    End If

                    If Break Then ' пора заканчивать
                        Exit Do
                    End If
                    Thread.Sleep(200)
                Loop

            End If   'BCS.IsOpen
        Catch ex As Exception
            'WriteLog(ex.ToString)
            Throw New ApplicationException("јварийное завершение чтени€ штрих-кода", ex)
        Finally
            If BCS.IsOpen Then
                BCS.DiscardInBuffer()
                BCS.DiscardOutBuffer()
                BCS.Close()
            End If
            RemoveHandler BCS.DataReceived, AddressOf OnDataReceived
            RemoveHandler BCS.ErrorReceived, AddressOf OnErrorReceived
            RemoveHandler BCS.PinChanged, AddressOf OnPinChanged
        End Try

        Return BarCode

    End Function
End Class
