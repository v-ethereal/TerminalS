Imports System.Xml, System.Threading, System.Collections.ObjectModel

Public Class ShtrihMiniFiscalRegister
    Implements ITerminalFiscalRegister


    Private Enum Alignment As Byte
        Center = 0
        Left = 1
        Right = 2
    End Enum

    Private Enum BarcodeType As Byte
        Code128A = 0
        Code128B = 1
        Code128C = 2
    End Enum

    Private Enum FontType As Byte
        Standard = 1
        Huge = 2
        Low = 3
        Wide = 4
        Shrink = 5
        Italic = 6
        Elegant = 7
    End Enum



    'ECRMode Режим ККМ	Описание режима ККМ
    '0	Принтер в рабочем режиме
    '1	Выдача данных
    '2	Открытая смена, 24 часа не кончились 
    '3	Открытая смена, 24 часа кончились
    '4	Закрытая смена
    '5	Блокировка по неправильному паролю налогового инспектора
    '6	Ожидание подтверждения ввода даты
    '7	Разрешение изменения положения десятичной точки
    '8	Открытый документ
    '9	Режим разрешения технологического обнуления
    '10	Тестовый прогон
    '11	Печать полного фискального отчета
    '12	Печать длинного отчета ЭКЛЗ
    '13	Работа с фискальным подкладным документом
    '14	Печать подкладного документа
    '15	Фискальный подкладной документ сформирован

    'ECRMode8Status Статус8Режима
    'Находясь в режиме 8, ККМ может быть в одном из состояний:
    'Статус режима 8	Описание статуса режима ККМ
    '0	Открыт чек продажи
    '1	Открыт чек покупки
    '2	Открыт чек возврата продажи
    '3	Открыт чек возврата покупки
    'Модифицируется методами GetECRStatus и GetShortECRStatus.

    'ECRAdvancedMode ПодрежимККМ
    'Подрежим ККМ   Описание
    '0	Бумага есть – ФР не в фазе печати операции – 
    '   принимает команды, связанные с печатью.
    '1	Пассивное отсутствие бумаги – ККМ не в фазе печати операции – 
    '   не принимает команды, связанные с печатью.
    '2	Активное отсутствие бумаги – ККМ в фазе печати операции – 
    '   не принимает команды, связанные с печатью.
    '   Переход из этого подрежима только в подрежим 3.
    '3	После активного отсутствия бумаги – ККМ ждет команду продолжения печати.
    '   не принимает команды, связанные с печатью.
    '4	Фаза печати операции – 
    '   не принимает команды, связанные с печатью.
    '5	Фаза печати операции длинного отчета (полные фискальные отчеты, полные отчеты ЭКЛЗ, печать контрольных лент из ЭКЛЗ) – 
    '   не принимает команды, связанные с печатью, кроме команды прерывания печати.
    'Модифицируется методами GetECRStatus и GetShortECRStatus.

    Friend Shared cfgDebugLevel As Integer = 1
    Friend Shared cfgComPort As String = "COM3"
    Friend Shared cfgBaudRate As Integer = 19200
    Friend Shared cfgReadTimeOut As Integer = 100
    Private FR As DrvFRLib.DrvFR

    Private Shared Sub WriteLog(ByVal msg As String)
        If cfgDebugLevel > 0 Then Trace.WriteLine(DateTime.Now.ToString & " " & msg)
    End Sub

    Public Sub New()
        'Constructor of the class ShtrihMiniFiscalRegister
        MyBase.New()

        Dim ComPortNum As Integer = 0
        Dim BaudRateCode As Integer = 3
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

            Dim BVNode As XmlNode = rootNode.SelectSingleNode("descendant::FiscalRegistrator")
            If BVNode Is Nothing Then
                WriteLog("FiscalRegistrator section of configuration file not found, default values will be used")
                Exit Do
            End If

            Dim xmlNode As XmlNode = BVNode.SelectSingleNode("descendant::Parameters")
            If xmlNode Is Nothing Then
                WriteLog("Parameters node of FiscalRegistrator configuration section not found, default values will be used")
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
                Dim strNum As String = cfgComPort.Replace("COM", "")
                If IsNumeric(strNum) Then
                    ComPortNum = CInt(strNum) - 1
                Else
                    WriteLog("Invalid value " & cfgComPort & " for ComPortName parameter, default value will be used")
                    cfgComPort = "COM3"
                    ComPortNum = 2
                End If
            End If

            watr = CType(xmlNode.Attributes.GetNamedItem("ComPortBaudRate"), XmlAttribute)
            If watr Is Nothing Then
                WriteLog("ComPortBaudRate value not found in configuration file, default value will be used")
            Else
                If IsNumeric(watr.Value) Then
                    cfgBaudRate = CInt(watr.Value)
                    Select Case cfgBaudRate
                        Case 2400
                            BaudRateCode = 0
                        Case 4800
                            BaudRateCode = 1
                        Case 9600
                            BaudRateCode = 2
                        Case 19200
                            BaudRateCode = 3
                        Case 38400
                            BaudRateCode = 4
                        Case 57600
                            BaudRateCode = 5
                        Case 115200
                            BaudRateCode = 6
                        Case Else
                            WriteLog("Invalid value " & cfgBaudRate & " for ComPortBaudRate parameter, default value will be used")
                            cfgBaudRate = 19200
                            BaudRateCode = 3
                    End Select
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

        WriteLog("Fiscal Registrator device parameters in use :")
        WriteLog("     DebugLevel = " & cfgDebugLevel.ToString)
        WriteLog("     ComPortName = " & cfgComPort)
        WriteLog("     ComPortBaudRate = " & cfgBaudRate.ToString)
        WriteLog("     ComPortReadTimeout = " & cfgReadTimeOut.ToString)

        FR = New DrvFRLib.DrvFR

        If cfgDebugLevel >= 2 Then WriteLog("Method SetExchangeParam is starting")
        FR.Password = 30
        FR.PortNumber = 0 'ComPortNum
        FR.BaudRate = BaudRateCode
        FR.Timeout = cfgReadTimeOut
        FR.SetExchangeParam()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method SetExchangeParam done")
        Else
            WriteLog("Method SetExchangeParam failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            'Exit Sub
        End If

        'FR.AboutBox()
        If cfgDebugLevel >= 2 Then WriteLog("Method GetECRStatus is starting")
        FR.Password = 30
        FR.GetECRStatus()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method GetECRStatus done")
        Else
            WriteLog("Method GetECRStatus failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода GetECRStatus")
        End If
        WriteLog("     Версия внутреннего программного обеспечения ККМ = " & FR.ECRSoftVersion)
        WriteLog("     Режим работы устройства = " & FR.ECRModeDescription & " (" & FR.ECRMode.ToString & ")")
        WriteLog("     Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")
        WriteLog("     Actual COM port number = " & FR.ComNumber.ToString)

        If cfgDebugLevel >= 2 Then WriteLog("Method GetExchangeParam is starting")
        FR.Password = 30
        FR.GetExchangeParam()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method GetExchangeParam done")
        Else
            WriteLog("Method GetExchangeParam failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
        End If
        WriteLog("     Actual BaudRate = " & FR.BaudRate.ToString)
        WriteLog("     Actual Timeout = " & FR.Timeout.ToString)

        If cfgDebugLevel >= 2 Then WriteLog("Method Beep is starting")
        FR.Password = 30
        FR.Beep()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method Beep done")
        Else
            WriteLog("Method Beep failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
        End If

    End Sub

    Public Sub Initialize() Implements ITerminalFiscalRegister.Initialize

        Try
            If cfgDebugLevel >= 2 Then WriteLog("Method GetECRStatus is starting")
            FR.Password = 30
            FR.GetECRStatus()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method GetECRStatus done")
            Else
                WriteLog("Method GetECRStatus failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода GetECRStatus")
            End If

            WriteLog("Режим работы устройства = " & FR.ECRModeDescription & " (" & FR.ECRMode.ToString & ")")
            WriteLog("Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")

            Select Case FR.ECRAdvancedMode
                Case 0   'Бумага есть – ФР не в фазе печати операции.
                Case 1   'Пассивное отсутствие бумаги – ККМ не в фазе печати операции.
                    Throw New ApplicationException("Устройство печати требует вмешательства")
                Case 2   'Активное отсутствие бумаги – ККМ в фазе печати операции.
                    Throw New ApplicationException("Устройство печати требует вмешательства")
                Case 3   'После активного отсутствия бумаги – ККМ ждет команду продолжения печати.
                    If cfgDebugLevel >= 2 Then WriteLog("Method ContinuePrint is starting")
                    FR.Password = 30
                    'Работает в любом режиме, но только в подрежиме 3
                    'Не меняет режима ККМ, но выводит из подрежима 3
                    FR.ContinuePrint()
                    If FR.ResultCode = 0 Then
                        If cfgDebugLevel >= 2 Then WriteLog("Method ContinuePrint done")
                    Else
                        WriteLog("Method ContinuePrint failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                        Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода ContinuePrint")
                    End If
                Case 4   'Фаза печати операции.
                Case 5   'Фаза печати операции длинного отчета
            End Select

            If Not WaitForIdle(5000) Then
                WriteLog("Method ContinuePrint can't change submode")
                Throw New ApplicationException("Устройство печати требует вмешательства")
            End If

            Select Case FR.ECRMode   'новое состояние после WaitForIdle
                Case 8   'Открытый документ
                    If cfgDebugLevel >= 2 Then WriteLog("Method CancelCheck is starting")
                    FR.Password = 30
                    'Работает в режиме 8
                    'Переводит ККМ в режим, в котором ККМ была до открытия чека, или в режим 3
                    FR.CancelCheck()   'SysAdminCancelCheck()
                    If FR.ResultCode = 0 Then
                        If cfgDebugLevel >= 2 Then WriteLog("Method CancelCheck done")
                    Else
                        WriteLog("Method CancelCheck failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                        Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода CancelCheck")
                    End If
                Case 11   '	Идет печать полного фискального отчета
                    If cfgDebugLevel >= 2 Then WriteLog("Method InterruptFullReport is starting")
                    FR.Password = 30
                    'Работает в режиме 11
                    'Восстанавливает режим работы ККМ, из которого был запущен полный отчет.
                    FR.InterruptFullReport()
                    If FR.ResultCode = 0 Then
                        If cfgDebugLevel >= 2 Then WriteLog("Method InterruptFullReport done")
                    Else
                        WriteLog("Method InterruptFullReport failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                        Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода InterruptFullReport")
                    End If
                Case 12   'Идет печать длинного отчета ЭКЛЗ
                    If cfgDebugLevel >= 2 Then WriteLog("Method StopEKLZDocumentPrinting is starting")
                    FR.Password = 30
                    'Работает в режиме 12
                    'Восстанавливает режим работы ККМ, из которого была запущена печать документа.
                    FR.StopEKLZDocumentPrinting()
                    If FR.ResultCode = 0 Then
                        If cfgDebugLevel >= 2 Then WriteLog("Method StopEKLZDocumentPrinting done")
                    Else
                        WriteLog("Method StopEKLZDocumentPrinting failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                        Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода StopEKLZDocumentPrinting")
                    End If
                Case 14   'Идет	печать подкладного документа

                Case Else

            End Select

            If FR.ECRMode = 3 Then
                WriteLog("Mode 3 detected during initialization")
                Throw New ApplicationException("24 часа кончились, для продолжения работы необходимо запустить печать Z-отчета")
            End If

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение инициализации фискального регистратора", ex)
            'Finally

        End Try

    End Sub

    ''' <summary>
    ''' Делает пропуск строк на принтере ФР
    ''' </summary>
    ''' <param name="lines">количество пустых строк</param>
    Private Sub PrintWhiteSpace(ByVal lines As Integer)
        'разделитель - пустая строка 
        If cfgDebugLevel >= 2 Then WriteLog("Method FeedDocument is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        FR.StringQuantity = lines
        FR.UseSlipDocument = False
        FR.UseReceiptRibbon = True
        FR.UseJournalRibbon = False
        'Метод может вызываться в любом режиме, кроме режимов 8, 10, 11, 12, 14 и подрежимов 4 и 5 (см. свойства ECRMode и ECRAdvancedMode).
        'Не меняет режима ККМ.
        FR.FeedDocument()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method FeedDocument done")
        Else
            WriteLog("Method FeedDocument failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода FeedDocument")
        End If
    End Sub

    Private Sub PrintStringWithFont(ByVal text As String, ByVal fontType As FontType, Optional ByVal alignment As Alignment = Alignment.Left)

        If cfgDebugLevel >= 2 Then WriteLog("Method PrintStringWithFont is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        'Строка не более 249 символов
        text = text.TrimEnd()
        FR.StringForPrinting = text
        FR.UseReceiptRibbon = True
        FR.UseJournalRibbon = False
        FR.FontType = fontType

        FR.GetFontMetrics()
        Dim printWidth As Integer = FR.PrintWidth
        Dim charWidth As Integer = FR.CharWidth
        Dim charHeight As Integer = FR.CharHeight
        Dim charCount As Integer = printWidth / charWidth

        If text.Length < charCount Then
            Dim spaceCount As Integer = 0
            If alignment = alignment.Center Then
                spaceCount = (charCount - text.Length) / 2
            ElseIf alignment = alignment.Right Then
                spaceCount = charCount - text.Length
            End If
            text = New String(" ", spaceCount) & text
        End If

        FR.StringForPrinting = text

        'Метод может вызываться в любом режиме, кроме режимов 11, 12 и 14 (см. свойство ECRMode).
        'Не меняет режима ККМ.
        FR.PrintStringWithFont()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method PrintStringWithFont done")
        Else
            WriteLog("Method PrintStringWithFont failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintStringWithFont")
        End If

    End Sub


    ''' <summary>
    ''' Печатает строку текста на принтере ФР
    ''' </summary>
    ''' <param name="text">текст для печати</param>
    ''' <param name="huge">печатать самым большим (широким и высоким) шрифтом, иначе стандартным</param>
    Private Sub PrintString(ByVal text As String, Optional ByVal alignment As Alignment = Alignment.Left, Optional ByVal huge As Boolean = False)

        Dim methodName As String = IIf(huge, "PrintWideString", "PrintString")

        If cfgDebugLevel >= 2 Then WriteLog("Method " & methodName & " is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        'Строка не более 249 символов
        text = text.TrimEnd()
        FR.StringForPrinting = text
        FR.UseReceiptRibbon = True
        FR.UseJournalRibbon = False

        Dim charCount As Integer = IIf(huge, 25, 50)

        If text.Length < charCount Then
            Dim spaceCount As Integer = 0
            If alignment = alignment.Center Then
                spaceCount = (charCount - text.Length) / 2
            ElseIf alignment = alignment.Right Then
                spaceCount = charCount - text.Length
            End If
            text = New String(" ", spaceCount) & text
        End If

        FR.StringForPrinting = text

        'Метод может вызываться в любом режиме, кроме режимов 11, 12 и 14 (см. свойство ECRMode).
        'Не меняет режима ККМ.
        If huge Then
            FR.PrintWideString()
        Else
            FR.PrintString()
        End If
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method " & methodName & " done")
        Else
            WriteLog("Method " & methodName & " failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода " & methodName)
        End If

    End Sub

    ''' <summary>
    ''' Печатает штрихкод на принтере ФР
    ''' </summary>
    ''' <param name="value">значение штрихкода</param>
    ''' <param name="type">тип штрихкода</param>
    ''' <param name="alignment">выравнивание штрихкода</param>
    ''' <param name="barHeight">высота штриха</param>
    ''' <param name="barWidth">ширина штриха</param>
    Private Sub PrintBarcode(ByVal value As String, ByVal type As BarcodeType, Optional ByVal alignment As Alignment = Alignment.Center, Optional ByVal barHeight As Integer = 100, Optional ByVal barWidth As Integer = 2)

        'штрих-код
        'PrintBarcodeLine печатает штрих-код при помощи команды печати линии.
        'BarCode          - Строка	40 	    штрих-код EAN-13, печатаемый на чеке
        'LineNumber       - Целое	0..1199	задает высоту штрих кода в точках
        'BarcodeType      - Целое	0-2	    задает тип штрих-кода
        'BarWidth         - Целое	0..1199	задает ширину штриха в точках
        'BarcodeAlignment - Целое	0-2	    задает выравнивание штрих-кода

        'BarcodeAlignment  выравнивание штрих-кода. 
        'Тип: Integer
        'Допустимые значения:
        '0	baCenter	по центру
        '1	baLeft	влево
        '2	baRight	вправо

        'BarcodeType   тип штрих-кода
        'Тип: Integer
        'Допустимые значения:
        '0	Code128A
        '1	Code128B
        '2	Code128C

        'BarWidth   ширина штриха в точках
        'Тип: Integer
        'Рекомендуемое значение - 2

        If cfgDebugLevel >= 2 Then WriteLog("Method PrintBarcodeLine is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        FR.BarCode = value
        FR.LineNumber = barHeight
        FR.BarcodeType = type
        FR.BarWidth = barWidth
        FR.BarcodeAlignment = alignment 'DrvFRLib.TBarcodeAlignment.baCenter
        'Метод может вызываться в любом режиме, кроме режимов 8, 10, 11, 12, 14 и подрежимов 4 и 5 (см. свойства ECRMode и ECRAdvancedMode).
        'Не меняет режима ККМ.
        FR.PrintBarcodeLine()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method PrintBarcodeLine done")
        Else
            WriteLog("Method PrintBarcodeLine failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintBarcodeLine")
        End If

    End Sub

    Sub PrintCliche()

        If cfgDebugLevel >= 2 Then WriteLog("Method PrintCliche is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        'Не меняет режима ККМ.
        FR.PrintCliche()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method PrintCliche done")
        Else
            WriteLog("Method PrintCliche failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintCliche")
        End If

    End Sub

    Sub CutReceipt()

        If cfgDebugLevel >= 2 Then WriteLog("Method CutCheck is starting")
        If Not WaitForIdle(5000) Then
            Throw New ApplicationException("Устройство печати требует вмешательства")
        End If
        FR.Password = 30
        'TRUE – неполная отрезка, FALSE – полная отрезка
        FR.CutType = True
        'Метод может вызываться в любом режиме, кроме 8, 10, 11, 12, 14 и подрежимов 4 и 5 (см. свойства ECRMode и ECRAdvancedMode).
        'Не меняет режима ККМ.
        FR.CutCheck()
        If FR.ResultCode = 0 Then
            If cfgDebugLevel >= 2 Then WriteLog("Method CutCheck done")
        Else
            WriteLog("Method CutCheck failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
            Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода CutCheck")
        End If

    End Sub

    Public Sub PrintAdditionalServiceReceipt(ByVal serviceName As String, ByVal servicePrice As Decimal, ByVal paidSum As Decimal) Implements ITerminalFiscalRegister.PrintAdditionalServiceReceipt

        Try
            PrintWhiteSpace(2)
            'операция продажи открывает чек 
            If cfgDebugLevel >= 2 Then WriteLog("Method Sale is starting")
            FR.Password = 30
            FR.Quantity = 1
            FR.Price = paidSum
            FR.Department = 1
            FR.Tax1 = 2
            FR.Tax2 = 0
            FR.Tax3 = 0
            FR.Tax4 = 0
            If paidSum < servicePrice Then
                'serviceName = serviceName.Substring(0, 30) & "/частично"
                serviceName = serviceName & "/ч" 'было /частично
            End If
            If paidSum > servicePrice Then
                serviceName = serviceName & "/п" 'было /переплата"
            End If
            FR.StringForPrinting = serviceName
            FR.Sale()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method Sale done")
            Else
                WriteLog("Method Sale failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода Sale")
            End If

            'операция закрытия чека
            If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck is starting")
            FR.Password = 30
            FR.Summ1 = paidSum 'сумма наличных
            FR.Summ2 = 0  'сумма типом оплаты 2
            FR.Summ3 = 0  'суммы типом оплаты 3
            FR.Summ4 = 0  'сумма типом оплаты 4
            FR.DiscountOnCheck = 0 'скидка на чек
            FR.Tax1 = 2 '1-ая налоговая группа
            FR.Tax2 = 0 '2-ая налоговая группа
            FR.Tax3 = 0 'нет налоговой группы
            FR.Tax4 = 0 'нет налоговой группы
            'в чеке будет двойная пунктирная линия
            FR.StringForPrinting = "===================================="
            FR.CloseCheck()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck done")
            Else
                WriteLog("Method CloseCheck failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода CloseCheck")
            End If

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати чека об оплате дополнительной услуги", ex)
            'Finally

        End Try

        'свойство Change содержит сумму сдачи.
        'WriteLog("Operation completed successfully with change = " & FR.Change)

    End Sub

    Public Sub PrintRentalReceipt(ByVal paymentsInfo As System.Collections.Generic.IList(Of DayRentalPaymentInfo)) Implements ITerminalFiscalRegister.PrintRentalReceipt

        Try
            PrintWhiteSpace(2)

            Dim ServiceName As String = ""
            Dim TotalPaidSum As Decimal = 0

            For Each pi As DayRentalPaymentInfo In paymentsInfo

                'регистрация продажи с вычислением налогов без закрытия чека.
                If cfgDebugLevel >= 2 Then WriteLog("Method Sale is starting")
                FR.Password = 30
                FR.Quantity = 1
                FR.Price = pi.PaidSum
                FR.Department = 1
                FR.Tax1 = 2
                FR.Tax2 = 0
                FR.Tax3 = 0
                FR.Tax4 = 0
                ServiceName = "Аренда места №" & pi.PlaceNumber & " за " & pi.Date.ToString("d")
                If pi.PaidSum < pi.Price Then
                    'ServiceName = ServiceName.Substring(0, 30) & "/частично"
                    ServiceName = ServiceName & "/ч" 'было /частично
                End If
                If pi.PaidSum > pi.Price Then
                    ServiceName = ServiceName & "/п" 'было /переплата"
                End If
                '"/доплата" ???
                FR.StringForPrinting = ServiceName
                FR.Sale()
                If FR.ResultCode = 0 Then
                    If cfgDebugLevel >= 2 Then WriteLog("Method Sale done")
                Else
                    WriteLog("Method Sale failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                    Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода Sale")
                End If
                TotalPaidSum = TotalPaidSum + pi.PaidSum
            Next pi

            'операция закрытия чека
            If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck is starting")
            FR.Password = 30
            FR.Summ1 = TotalPaidSum 'сумма наличных
            FR.Summ2 = 0  'сумма типом оплаты 2
            FR.Summ3 = 0  'суммы типом оплаты 3
            FR.Summ4 = 0  'сумма типом оплаты 4
            FR.DiscountOnCheck = 0 'скидка на чек
            FR.Tax1 = 2 '1-ая налоговая группа
            FR.Tax2 = 0 '2-ая налоговая группа
            FR.Tax3 = 0 'нет налоговой группы
            FR.Tax4 = 0 'нет налоговой группы
            'в чеке будет двойная пунктирная линия
            FR.StringForPrinting = "===================================="
            FR.CloseCheck()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck done")
            Else
                WriteLog("Method CloseCheck failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода CloseCheck")
            End If

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати чека об оплате аренды", ex)
            'Finally

        End Try

    End Sub

    Public Sub PrintUnpaidRentalPlacesReport(ByVal controlDate As Date, ByVal unpaidPlaces As System.Collections.Generic.IList(Of String)) Implements ITerminalFiscalRegister.PrintUnpaidRentalPlacesReport

        Try

            PrintWhiteSpace(4)

            PrintString("СПИСОК НЕОПЛАЧЕННЫХ МЕСТ ЗА " & controlDate.Day.ToString("00") & "." & controlDate.Month.ToString("00") & "." & controlDate.Year.ToString("0000"), Alignment.Center)

            PrintWhiteSpace(1)

            Dim dt As DateTime = DateTime.Now
            PrintString("Отчет сформирован " & dt.Day.ToString("00") & "." & dt.Month.ToString("00") & "." & dt.Year.ToString("0000") & " " & dt.Hour.ToString("00") & ":" & dt.Minute.ToString("00"), Alignment.Center)

            'разделитель - пустая строка 
            PrintWhiteSpace(1)

            'строки с номерами неоплаченных мест в формате  
            ' "  sssssss sssssss sssssss sssssss sssssss sssssss" 
            ' (табулированный список, выравнивание номеров по левому краю в маске) 
            Dim wPrintLines As New Collection(Of String)
            wPrintLines.Clear()
            Dim PrintLine As String = ""
            Dim LinePos As Integer = 0
            For I As Integer = 0 To unpaidPlaces.Count - 1
                LinePos = I Mod 6
                Select Case LinePos
                    Case 0 'начало строки
                        If PrintLine <> "" Then
                            wPrintLines.Add(PrintLine)
                        End If
                        PrintLine = Trim(unpaidPlaces(I))
                    Case 1, 2, 3, 4, 5
                        PrintLine = PrintLine & "        "
                        PrintLine = PrintLine.Substring(0, LinePos * 8 - 1) & " " & Trim(unpaidPlaces(I))
                End Select
            Next I
            If PrintLine <> "" Then
                wPrintLines.Add(PrintLine)
            End If
            For Each pl As String In wPrintLines
                PrintString("  " & pl)
            Next pl

            PrintWhiteSpace(1)

            PrintString("================== Конец отчета ==================")

            PrintWhiteSpace(6)

            PrintCliche()

            CutReceipt()

        Catch ex As Exception
            Throw New ApplicationException("Аварийное завершение печати отчета по неоплаченным местам", ex)
        End Try

    End Sub

    Public Sub PrintXReport() Implements ITerminalFiscalRegister.PrintXReport

        Try

            If cfgDebugLevel >= 2 Then WriteLog("Method PrintReportWithoutCleaning is starting")
            FR.Password = 30
            'Работает в режимах 2, 3 и 4:
            '2	Открытая смена, 24 часа не кончились 
            '3	Открытая смена, 24 часа кончились
            '4	Закрытая смена
            'Не меняет режима ККМ
            FR.PrintReportWithoutCleaning()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method PrintReportWithoutCleaning done")
            Else
                WriteLog("Method PrintReportWithoutCleaning failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintReportWithoutCleaning")
            End If

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати суточного X-отчета", ex)
            'Finally

        End Try

    End Sub

    Public Sub PrintZReport() Implements ITerminalFiscalRegister.PrintZReport

        Try

            If cfgDebugLevel >= 2 Then WriteLog("Method PrintReportWithCleaning is starting")
            FR.Password = 30
            'Работает в режимах 2(Открытая смена, 24 часа не кончились) и 3(Открытая смена, 24 часа кончились)
            'Переводит ККМ в режим 4(Закрытая смена) 
            FR.PrintReportWithCleaning()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method PrintReportWithCleaning done")
            Else
                WriteLog("Method PrintReportWithCleaning failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintReportWithCleaning")
            End If

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати суточного Z-отчета", ex)
            'Finally

        End Try

    End Sub

    Public Sub PrintShiftSummaryReport(ByVal terminalName As String, ByVal servicesShiftInfo As System.Collections.Generic.IList(Of ServiceShiftSummaryInfo)) Implements ITerminalFiscalRegister.PrintShiftSummaryReport

        Try

            PrintWhiteSpace(4)

            PrintString("ДЕТАЛИЗАЦИЯ СУТОЧНОГО ОТЧЕТА ПО УСЛУГАМ", Alignment.Center)

            PrintString("ТЕРМИНАЛ: " & terminalName, Alignment.Center)

            PrintWhiteSpace(1)

            Dim dt As DateTime = DateTime.Now
            PrintString("Отчет сформирован " & dt.Day.ToString("00") & "." & dt.Month.ToString("00") & "." & dt.Year.ToString("0000") & " " & dt.Hour.ToString("00") & ":" & dt.Minute.ToString("00"), Alignment.Center)

            'разделитель - пустая строка 
            PrintWhiteSpace(1)

            'список услуг  
            ' "ssssssssssssssssssssssssssssssssssssssssssssssssss"
            ' "              кол-во: #####   сумма: #########0.00"
            Dim Total As Decimal = 0
            For Each si As ServiceShiftSummaryInfo In servicesShiftInfo
                Dim strSrvName As String = Left(Trim(si.ServiceName), 50)
                PrintString(strSrvName)

                Dim strSrvQuantity As String = si.ServiceQuantity.ToString("####0")
                Dim strSrvPaid As String = si.ServicePaidTotal.ToString("#########0.00")
                PrintString(Space(14) & "кол-во: " & strSrvQuantity & Space(5 - Len(strSrvQuantity)) & "   сумма: " & Space(13 - Len(strSrvPaid)) & strSrvPaid)

                'разделитель - пустая строка 
                PrintWhiteSpace(1)

                Total = Total + si.ServicePaidTotal
            Next si

            PrintString("==================================================")

            Dim strTotalName As String = "ИТОГО:"
            Dim strTotalPaid As String = Total.ToString("#########0.00")
            PrintString(strTotalName & Space(50 - strTotalName.Length - strTotalPaid.Length) & strTotalPaid)

            PrintWhiteSpace(1)

            PrintString("================== Конец отчета ==================")

            PrintWhiteSpace(6)

            PrintCliche()

            CutReceipt()

        Catch ex As Exception
            Throw New ApplicationException("Аварийное завершение печати детального суточного отчета по услугам", ex)
        End Try

    End Sub


    Private Function WaitForIdle(ByVal vWaitTime As Integer) As Boolean
        '0	Бумага есть – ФР не в фазе печати операции – может принимать от хоста команды, связанные с печатью на том ленте, датчик которой сообщает о наличии бумаги.
        '1	Пассивное отсутствие бумаги – ККМ не в фазе печати операции – не принимает от хоста команды, связанные с печатью на том ленте, датчик которой сообщает об отсутствии бумаги.
        '2	Активное отсутствие бумаги – ККМ в фазе печати операции – принимает только команды, не связанные с печатью. Переход из этого подрежима только в подрежим 3.
        '3	После активного отсутствия бумаги – ККМ ждет команду продолжения печати. Кроме этого принимает команды, не связанные с печатью.
        '4	Фаза печати операции – ККМ не принимает от хоста команды, связанные с печатью.
        '5	Фаза печати операции длинного отчета (полные фискальные отчеты, полные отчеты ЭКЛЗ, печать контрольных лент из ЭКЛЗ) – ККМ не принимает от хоста команды, связанные с печатью, кроме команды прерывания печати.

        'Дождаться состояния готовности, периодически проверяя, не истекло ли время
        Dim ElapsedTime As TimeSpan
        Dim UserTime As TimeSpan = TimeSpan.FromMilliseconds(vWaitTime)
        Dim StartTime As DateTime = DateTime.Now
        Do
            FR.Password = 30
            FR.GetShortECRStatus()
            If FR.ResultCode = 0 Then
                Select Case FR.ECRAdvancedMode
                    Case 0
                        If cfgDebugLevel >= 2 Then WriteLog("Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")
                        Return True
                    Case 1, 2, 3
                        WriteLog("Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")
                        Return True
                    Case 4, 5
                        WriteLog("Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")
                        'устройство занято печатью, будем ждать 
                    Case Else 'unknown print status
                        WriteLog("Состояние печати = " & FR.ECRAdvancedModeDescription & " (" & FR.ECRAdvancedMode.ToString & ")")
                        'устройство занято, будем ждать 
                End Select
            Else
                WriteLog("Method GetShortECRStatus failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода GetShortECRStatus")
            End If
            ElapsedTime = DateTime.Now.Subtract(StartTime)
            If ElapsedTime > UserTime Then 'время истекло
                Return False
            End If
            Thread.Sleep(100)
        Loop

    End Function

    Public Sub PrintParkingToken(ByVal StartDate As Date, ByVal BarCode As String, ByVal Price As Decimal, ByVal Penalty As Decimal) Implements ITerminalFiscalRegister.PrintParkingToken

        Try

            PrintWhiteSpace(1)

            PrintStringWithFont("ПАРКОВОЧНЫЙ ТАЛОН", FontType.Huge, Alignment.Center)
            PrintString("Выдан " & StartDate.ToString("dd.MM.yy HH:mm"), Alignment.Center)

            PrintWhiteSpace(1)

            PrintString("    Сохраняйте талон до оплаты!")
            PrintString("    При утере или порче талона взимается плата")
            PrintString("    " & Penalty.ToString() & " рублей без учета времени стоянки!")
            PrintString("    Стоимость 1 часа стоянки составляет " & Price.ToString() & " руб.")
            PrintString("    Время стоянки округляется с точностью до")
            PrintString("    часа в большую сторону.")

            PrintWhiteSpace(1)

            PrintBarcode(BarCode, BarcodeType.Code128B)

            PrintWhiteSpace(1)

            'текст штрих-кода
            PrintString("          " & BarCode)

            PrintWhiteSpace(6)

            PrintCliche()

            CutReceipt()

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати парковочного талона", ex)
            'Finally

        End Try

    End Sub

    ''' <summary>
    ''' Печать выездного талона
    ''' </summary>
    ''' <param name="CardNumber">номер парковочной карты</param>
    ''' <param name="StartDate">дата, время заезда</param>
    ''' <param name="FinishDate">дата, время оплаты</param>
    ''' <param name="ExternalPayment">парковка будет оплачена в системе ParkTime</param>
    ''' <param name="PaidSum">оплаченная сумма</param>
    Public Sub PrintParkingExitTicket(ByVal cardNumber As String, ByVal startDate As Date, ByVal finishDate As Date, ByVal externalPayment As Boolean, ByVal paidSum As Decimal) Implements ITerminalFiscalRegister.PrintParkingExitTicket

        Try

            PrintWhiteSpace(1)

            PrintStringWithFont("ВЫЕЗДНОЙ ТАЛОН", FontType.Huge, Alignment.Center)
            PrintStringWithFont("Номер карты: " & cardNumber, FontType.Standard, Alignment.Center)
            'PrintWhiteSpace(1)
            PrintStringWithFont("Время заезда: ", FontType.Standard, Alignment.Left)
            PrintStringWithFont(startDate.ToString("dd.MM.yy HH:mm"), FontType.Wide, Alignment.Center)
            PrintStringWithFont(IIf(externalPayment, "Время печати: ", "Время оплаты: "), FontType.Standard, Alignment.Left)
            PrintStringWithFont(finishDate.ToString("dd.MM.yy HH:mm"), FontType.Wide, Alignment.Center)

            PrintWhiteSpace(1)

            If externalPayment Then
                PrintStringWithFont("Оплата будет производить-", FontType.Wide, Alignment.Left)
                PrintStringWithFont("ся на паркомате ParkTime.", FontType.Wide, Alignment.Left)
            Else
                PrintStringWithFont("Парковка полностью опла-", FontType.Wide, Alignment.Left)
                PrintStringWithFont("чена на сумму " & paidSum.ToString("F0") & " руб.", FontType.Wide, Alignment.Left)
            End If

            PrintWhiteSpace(1)

            If externalPayment Then
                PrintString("Предъявите этот талон для выезда из зоны разгрузки")
            Else
                PrintString("Предъявите этот талон и чек для выезда с парковки")
            End If

            PrintCliche()

            CutReceipt()

        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение печати выездного талона", ex)
            'Finally

        End Try

    End Sub


    Public Sub PrintParkingPerHourReceipt(ByVal parkingTicketNumber As String, ByVal startDate As Date, ByVal endDate As Date, ByVal servicePrice As Decimal, ByVal needPaySum As Decimal, ByVal realPaySum As Decimal) Implements ITerminalFiscalRegister.PrintParkingPerHourReceipt
        Throw New NotImplementedException()
    End Sub

    Public Sub PrintParkingWithoutTimeReceipt(ByVal servicePrice As Decimal, ByVal realPaySum As Decimal) Implements ITerminalFiscalRegister.PrintParkingWithoutTimeReceipt
        Throw New NotImplementedException()
    End Sub


    Public Sub PrintAdditionalServiceReceiptEx(ByVal serviceName As String, ByVal servicePrice As Decimal, ByVal paidSum As Decimal, ByVal InfoItems As IList(Of String)) Implements ITerminalFiscalRegister.PrintAdditionalServiceReceiptEx

        Try
            PrintWhiteSpace(2)
            'операция продажи открывает чек 
            If cfgDebugLevel >= 2 Then WriteLog("Method Sale is starting")
            FR.Password = 30
            FR.Quantity = 1
            FR.Price = paidSum
            FR.Department = 1
            FR.Tax1 = 2
            FR.Tax2 = 0
            FR.Tax3 = 0
            FR.Tax4 = 0
            If paidSum < servicePrice Then
                'serviceName = serviceName.Substring(0, 30) & "/частично"
                serviceName = serviceName & "/ч" 'было /частично
            End If
            If paidSum > servicePrice Then
                serviceName = serviceName & "/п" 'было /переплата"
            End If
            FR.StringForPrinting = serviceName
            FR.Sale()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method Sale done")
            Else
                WriteLog("Method Sale failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода Sale")
            End If

            For Each s As String In InfoItems
                If cfgDebugLevel >= 2 Then WriteLog("Method PrintString (Info line) is starting")
                If Not WaitForIdle(5000) Then
                    Throw New ApplicationException("Устройство печати требует вмешательства")
                End If
                FR.Password = 30
                'Строка не более 249 символов
                FR.StringForPrinting = s
                FR.UseReceiptRibbon = True
                FR.UseJournalRibbon = False
                'Метод может вызываться в любом режиме, кроме режимов 11, 12 и 14 (см. свойство ECRMode).
                'Не меняет режима ККМ.
                FR.PrintString()   'PrintWideString()
                If FR.ResultCode = 0 Then
                    If cfgDebugLevel >= 2 Then WriteLog("Method PrintString (Info line) done")
                Else
                    WriteLog("Method PrintString (Info line) failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                    Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода PrintString")
                End If
            Next

            'операция закрытия чека
            If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck is starting")
            FR.Password = 30
            FR.Summ1 = paidSum 'сумма наличных
            FR.Summ2 = 0  'сумма типом оплаты 2
            FR.Summ3 = 0  'суммы типом оплаты 3
            FR.Summ4 = 0  'сумма типом оплаты 4
            FR.DiscountOnCheck = 0 'скидка на чек
            FR.Tax1 = 2 '1-ая налоговая группа
            FR.Tax2 = 0 '2-ая налоговая группа
            FR.Tax3 = 0 'нет налоговой группы
            FR.Tax4 = 0 'нет налоговой группы
            'в чеке будет двойная пунктирная линия
            FR.StringForPrinting = "===================================="
            FR.CloseCheck()
            If FR.ResultCode = 0 Then
                If cfgDebugLevel >= 2 Then WriteLog("Method CloseCheck done")
            Else
                WriteLog("Method CloseCheck failed for operator " & FR.OperatorNumber & " with RC = " & FR.ResultCode & vbCrLf & FR.ResultCodeDescription)
                Throw New ApplicationException("Ошибка '" & FR.ResultCodeDescription & "' при выполнении метода CloseCheck")
            End If

        Catch ex As Exception
            Throw New ApplicationException("Аварийное завершение печати чека об оплате дополнительной услуги", ex)
        End Try

    End Sub

    Public Sub PrintAccessCode(ByVal accessCode As String) Implements ITerminalFiscalRegister.PrintAccessCode
        Throw New NotImplementedException()
    End Sub
End Class
