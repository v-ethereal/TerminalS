Imports System.IO, System.Threading, System.Xml
'Imports System.Collections.ObjectModel

Public Class CashCodeSMBillValidator
    Implements ITerminalBillValidator

    Private Const SYNC As Byte = &H2 'synchronization byte
    Private Const ACK As Byte = &H0  'ACK code
    Private Const NAK As Byte = &HFF 'NAK code
    Private Const ST_INV_CMD As Byte = &H30   'INVALID COMMAND response

    ' Device Addresses
    Private Const ADDR_BB As Byte = &H1      'Address for Bill-To-Bill units
    Private Const ADDR_CHANGER As Byte = &H2 'Address for Coin Changer
    Private Const ADDR_FL As Byte = &H3      'Address for Bill Validators
    Private Const ADDR_CR As Byte = &H4      'Address for Smart Card Reader

    Private Enum Cmds As Byte
        RESET = &H30            'RESET command code
        GET_STATUS = &H31       'STATUS REQUEST command code
        SET_SECURITY = &H32     'SET SECURITY command code
        POLL = &H33             'POLL command code
        BILL_TYPE = &H34        'BILL TYPE command code
        PACK = &H35             'PACK command code
        [RETURN] = &H36         'RETURN command code
        IDENTIFICATION = &H37   'IDENTIFICATION command code
        HOLD = &H38             'HOLD command code
        SET_BAR_PARAMS = &H39   'SET BARCODE PARAMETERS command code
        EXTRACT_BAR_DATA = &H3A 'EXTRACT BARCODE DATA command code
        GET_BILL_TABLE = &H41   'BILL TABLE REQUEST command code
        DOWNLOAD = &H50         'DOWNLOAD command code
        CRC32 = &H51            'CRC32 REQUEST command code
    End Enum

    Private Enum States As Byte
        ST_POWER_UP = &H10           'POWER UP state
        ST_POWER_BILL_ESCROW = &H11  'POWER UP WITH BILL IN ESCROW state
        ST_POWER_BILL_STACKER = &H12 'POWER UP WITH BILL IN STACKER state
        ST_INITIALIZE = &H13         'INITIALIZING state
        ST_IDLING = &H14             'IDLING state
        ST_ACCEPTING = &H15          'ACCEPTING state
        ST_PACKING = &H17            'STACKING/PACKING state
        ST_RETURNING = &H18          'RETURNING state
        ST_DISABLED = &H19           'UNIT DISABLED state
        ST_HOLDING = &H1A            'HOLDING state
        ST_BUSY = &H1B               'Device is busy
        ST_REJECTING = &H1C          'REJECTING state. Followed by a rejection code

        'ST_DISPENSING = &H1D         'DISPENSING state
        'ST_UNLOADING = &H1E          'UNLOADING state
        'ST_SETTING_CS_TYPE = &H21    'SETTING RECYCLING CASSETTE TYPE state
        'ST_DISPENSED = &H25          'DISPENSED event
        'ST_UNLOADED = &H26           'UNLOADED event
        'ST_BILL_NUMBER_ERR = &H28    'INVALID BILL NUMBER event
        'ST_CS_TYPE_SET = &H29        'RECYCLING CASSETTE TYPE SET event
        ST_ST_FULL = &H41            'DROP CASSETTE IS FULL state
        ST_BOX = &H42                'DROP CASSETTE REMOVED state
        ST_BV_JAMMED = &H43          'JAM IN VALIDATOR state
        ST_ST_JAMMED = &H44          'JAM IN STACKER state
        ST_CHEATED = &H45            'CHEATED event
        ST_PAUSED = &H46             'PAUSED state
        ST_FAILURE = &H47            'FAILURE state. Followed by failure description byte 

        ESCROW = &H80                'A bill is held in the escrow position
        ST_PACKED = &H81             'A bill has been packed. 2nd byte - 0xXY:                                */
        RETURNED = &H82              'A bill was returned
    End Enum

    Private Enum RejCodes As Byte
        RJ_INSERTION = &H60    'Rejection because of insertion problem
        RJ_MAGNETIC = &H61     'Rejection because of invalid magnetic pattern
        RJ_REMAINING = &H62    'Rejection because of other bill remaining in the device
        RJ_MULTIPLYING = &H63  'Rejection because of multiple check failures
        RJ_CONVEYING = &H64    'Rejection because of conveying 
        RJ_IDENT = &H65        'Rejection because of identification failure
        RJ_VRFY = &H66         'Rejection because of verification failure
        RJ_OPT = &H67          'Rejection because of optical pattern mismatch
        RJ_INHIBIT = &H68      'Rejection because the denomination is inhibited
        RJ_CAP = &H69          'Rejection because of capacity sensor pattern mismatch
        RJ_OPERATION = &H6A    'Rejection because of operation error
        RJ_LNG = &H6C          'Rejection because of invalid bill length
        'RJ_UV = &H6D          'Rejection because of invalid UV pattern
        'RJ_BAR = &H92         'Rejection because of unrecognized barcode
        'RJ_BAR_LNG = &H93     'Rejection because of invalid barcode length
        'RJ_BAR_START = &H94   'Rejection because of invalid barcode start sequence
        'RJ_BAR_STOP = &H95    'Rejection because of invalid barcode stop sequence
    End Enum

    Private Enum FailCodes As Byte
        FLR_STACKER = &H50     'Stacking mechanism failure
        FLR_TR_SPEED = &H51    'Invalid speed of transport mechanism
        FLR_TRANSPORT = &H52   'Transport mechanism failure
        FLR_ALIGNING = &H53    'Aligning mechanism failure
        FLR_INIT_CAS = &H54    'Initial cassette status failure
        FLR_OPT = &H55         'Optical channel failure     было &H65
        FLR_MAG = &H56         'Inductive channel failure   было &H66
        FLR_CAP = &H5F         'Capacity sensor failure     было &H67
    End Enum

    Private Enum BillTypeCodes As Byte
        'NOM_5_Rbl = 2
        NOM_10_Rbl = 2
        NOM_50_Rbl = 3
        NOM_100_Rbl = 4
        NOM_500_Rbl = 5
        NOM_1000_Rbl = 6
        NOM_5000_Rbl = 7
    End Enum

    'Communication error codes (related to phisical data transmission and frame integrity)
    Private Const RE_NONE As Integer = 0     'No error happened
    Private Const RE_TIMEOUT As Integer = -1 'Communication timeout
    Private Const RE_SYNC As Integer = -2    'Synchronization error (invalid synchro byte)
    Private Const RE_DATA As Integer = -3    'Data reception error
    Private Const RE_CRC As Integer = -4     'CRC error

    'Logical error codes (related to the interface logic)
    Private Const ER_NAK As Integer = -5            'NAK received
    Private Const ER_INVALID_CMD As Integer = -6    'Invalid command response received
    Private Const ER_EXECUTION As Integer = -7      'Execution error response received
    Private Const ERR_INVALID_STATE As Integer = -8 'Invalid state received

    Private Structure STRUC_PolResults
        Public Z1 As Byte
        Public Z2 As Byte
    End Structure

    Private Structure STRUC_BillStatus
        Public Enabled As UInt32   'A bitmap describing which bill types are enabled
        Public Security As UInt32  'A bitmap describing which bill types are processed in High Security mode
        'Public Routing As UInt32   'A bitmap describing which denominations are routed to a recycling cassette (only for BB units)
    End Structure

    Friend Shared cfgDebugLevel As Integer = 1
    Friend Shared cfgComPort As String = "COM1"
    Friend Shared cfgBaudRate As Integer = 9600
    Friend Shared cfgReadTimeOut As Integer = 1500 '300
    Private BV As Ports.SerialPort
    'Private OutData(4096) As Byte
    Private iCmdDelay As Integer = 20
    Private iLastError As Integer
    Private PollResults As STRUC_PolResults
    'Variable containing the most recent response to the STATUS REQUEST
    Private BillStatus As STRUC_BillStatus
    Private cfgNominals As New List(Of Integer)(New Integer() {10, 50, 100, 500, 1000, 5000})
    'Разрешить прием всех русских денег (10,50,100,500,1000,5000) кроме 5
    Private EnabledTypes As UInt32 = &H1FC

    Private Shared Sub WriteLog(ByVal msg As String)
        If cfgDebugLevel > 0 Then Trace.WriteLine(DateTime.Now.ToString & " " & msg)
    End Sub

    Private Function crc16_ccitt(ByVal data As Byte, ByVal crc As UInt16) As UInt16
        'CCITT calculations on single byte
        'The function processes one byte and is used in iteration to calculate CRC16 value
        '  data - a parameter containing data byte to process
        '  crc  - a parameter (UINT16) containing previous CRC16 value
        'Returns UINT16 - newly calculated CRC16 value

        Dim a As UInt16 = &H8408
        Dim d As UInt16 = crc
        d = (d Xor data)
        For i As Short = 0 To 7
            If (d And &H1) Then
                d = d >> 1
                d = d Xor a
            Else
                d = d >> 1
            End If
        Next i
        Return d

    End Function

    Private Function CalculateCRC(ByVal pBuffer As Byte()) As UInt16
        'Calculate CRC16 of the buffer
        'The function is taking the data length from the buffer
        ' (assuming that buffer contains valid CCNET frame)
        '   pBuffer a parameter - pointer to the frame of data
        'Returns UINT16 - CRC16 value

        Dim wCRC As UInt16 = 0
        Dim Len As UInt16 = 0
        If pBuffer(2) = 0 Then
            Len = (CType(pBuffer(4), UInt16) << 8) + pBuffer(5)
        Else
            Len = pBuffer(2)
        End If

        For i As Integer = 0 To Len - 3
            wCRC = crc16_ccitt(pBuffer(i), wCRC)
        Next i

        Return wCRC

    End Function

    'Private Shared Sub OnDataReceived(ByVal source As Object, ByVal e As Ports.SerialDataReceivedEventArgs)
    '    WriteLog("DataReceived: " & e.EventType.ToString)
    'End Sub

    Private Shared Sub OnErrorReceived(ByVal source As Object, ByVal e As Ports.SerialErrorReceivedEventArgs)
        WriteLog("ErrorReceived: " & e.EventType.ToString)
    End Sub

    Private Shared Sub OnPinChanged(ByVal source As Object, ByVal e As Ports.SerialPinChangedEventArgs)
        WriteLog("PinChanged: " & e.EventType.ToString)
    End Sub

    'PurgeComm WinAPI-function
    ' PURGE_TXABORT       0x0001  // Kill the pending/current writes to the comm port.
    ' PURGE_RXABORT       0x0002  // Kill the pending/current reads to the comm port.
    ' PURGE_TXCLEAR       0x0004  // Kill the transmit queue if there.
    ' PURGE_RXCLEAR       0x0008  // Kill the typeahead buffer if there.
    ' DiscardInBuffer: 10 = A = 8 + 2 = PURGE_RXCLEAR + PURGE_RXABORT
    ' DiscardOutBuffer: 5 = 4 + 1     = PURGE_TXCLEAR + PURGE_TXABORT

    Private Function Send(ByRef Data As Byte(), ByVal Number As Integer) As Boolean
        'Transmit specifiying number of bytes via COM port
        '   Data - a BYTE array with the data, which needs to be transmitted
        '   Number (Integer) - number of bytes to transmit
        'Returns TRUE if specified number of bytes successfully transmitted, otherwise FALSE

        Try
            BV.Write(Data, 0, Number)
            'WriteLog("Sended " & Number.ToString & " bytes")
            If cfgDebugLevel >= 2 Then WriteLog("> " & BitConverter.ToString(Data, 0, Number))
            Return True
        Catch ex As Exception
            WriteLog("Send aborted :" & vbCrLf & ex.ToString)
            Return False
        End Try

    End Function

    Private Function Receive(ByRef Buffer As Byte(), ByVal Length As Int32, Optional ByVal Offset As Int32 = 0) As Boolean
        'Receive specified number of bytes from the COM port
        '   Buffer - a BYTE array receiving data
        '   Length (Integer) - number of bytes to receive
        'Returns TRUE if specified number of bytes successfully received, otherwise FALSE

        Try
            Dim dwBytes As Int32 = BV.Read(Buffer, Offset, Length)
            'WriteLog("Received " & dwBytes.ToString & " bytes")
            If cfgDebugLevel >= 2 Then WriteLog("< " & BitConverter.ToString(Buffer, Offset, Length))
            If dwBytes = Length Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            WriteLog("Receive aborted :" & vbCrLf & ex.ToString)
            Return False
        End Try

    End Function


    Private Function SendCommand(ByRef BufOut As Byte(), ByRef BufIn As Byte()) As Integer
        'Transmission of the supplied buffer and the response reception
        '  The function transmits the CCNET frame (including STX, correct device address, length, 
        '  command and 2 CRC bytes)located in buffer BufOut and reads the device response into the BufIn. 
        '  If ACK or NAK message is transmitted the function returns immediately after transmission is completed.
        '	BufOut	- the output buffer containing CCNET frame.
        '	BufIn	- input buffer to copy unit's response to.
        'Returns Integer - a communication error code.
        ' Can be any value from CErrs (Communication error codes) 

        'number of bytes to receive from the device at once
        Dim iBytesToReceive As Integer
        'communication error code produced by last serial communication
        Dim iReceivingError As Integer = RE_TIMEOUT

        '	for(int iErrCount=0;iErrCount<1;iErrCount++)
        'ответ должен быть длиной хотя бы 6 байтов
        iBytesToReceive = 6

        BV.DiscardInBuffer()
        BV.DiscardOutBuffer()

        If BufOut(2) = 0 Then
            Send(BufOut, (CType(BufOut(4), UInt16) << 8) + BufOut(5))
        Else
            Send(BufOut, BufOut(2))
        End If

        If BufOut(3) = ACK Or BufOut(3) = NAK Then
            iReceivingError = RE_NONE
            Return iReceivingError
        End If

        If iCmdDelay Then Thread.Sleep(iCmdDelay)

        If Receive(BufIn, iBytesToReceive) Then 'приняли затребованное количество байт
            If BufIn(0) = SYNC Then
                Dim iLen As Integer
                If BufIn(2) = 0 Then
                    iLen = (CType(BufIn(4), UInt16) << 8) + BufIn(5)
                Else
                    iLen = BufIn(2)
                End If
                iLen = iLen - iBytesToReceive
                If iLen > 0 Then
                    If Receive(BufIn, iLen, iBytesToReceive) Then
                        iReceivingError = RE_NONE
                    Else
                        iReceivingError = RE_DATA
                        BV.DiscardInBuffer()
                    End If
                Else 'iLen <= 0
                    iReceivingError = RE_NONE
                End If 'iLen > 0
            Else 'BufIn(0) <> SYNC
                iReceivingError = RE_SYNC
            End If 'BufIn(0) = SYNC
        End If 'Receive returns TRUE

        Return iReceivingError

    End Function

    Private Function TransmitCMD(ByRef Cmd As Byte(), ByRef Rsp As Byte()) As Integer
        'Simple protocol exchange
        '	1) Set device address and CRC16
        '	2) Sending the frame and receiving a response via SendCommand
        '	3) Checking received frame integrity (by CRC16 value)
        ' Cmd - Output frame (should contain all required information except of device address and CRC)
        ' Rsp - response data
        'Returns communication error code

        Dim tmpBuffer(256) As Byte
        Rsp = Nothing
        Dim i As Integer = 0
        If Cmd(2) = 0 Then
            i = (CType(Cmd(4), UInt16) << 8) + Cmd(5)
        Else
            i = Cmd(2)
        End If
        Cmd(1) = 3 '= Bill Validator Addr
        Dim wCRC As UInt16 = CalculateCRC(Cmd)
        Cmd(i - 2) = wCRC And &HFF
        Cmd(i - 1) = (wCRC >> 8) And &HFF

        Dim iErrCode As Integer = SendCommand(Cmd, tmpBuffer)
        If iErrCode = 0 And Cmd(3) <> 0 And Cmd(3) <> &HFF Then ' не ACK и не NAK
            Dim BufLen As Integer = 0
            If tmpBuffer(2) = 0 Then
                BufLen = (CType(tmpBuffer(4), UInt16) << 8) + tmpBuffer(5)
            Else
                BufLen = tmpBuffer(2)
            End If
            wCRC = tmpBuffer(BufLen - 2) + (CType(tmpBuffer(BufLen - 1), UInt16) << 8)
            If CalculateCRC(tmpBuffer) <> wCRC Then iErrCode = RE_CRC
        End If
        Rsp = tmpBuffer
        Return iErrCode

    End Function

    Private Function Transmit(ByRef Cmd As Byte(), ByRef Rsp As Byte()) As Integer
        'Complete protocol exchange
        '	1) Sending the frame and receiving a response using TransmitCMD
        '	2) Checking the device response and determining whether ACK or NAK should be sent 
        '	3) Sending ACK or NAK message to the device or retransmitting the command up to 3 times 
        '      untill communication is successfully completed
        ' Cmd - output frame (should contain all required information except of device address and CRC)
        ' Rsp - response data
        'Returns communication error code

        'Dim cmdResp As Byte() = Nothing
        Dim cmdACK(5) As Byte
        Dim iErr As Integer
        For i As Integer = 0 To 2
            cmdACK(0) = SYNC
            cmdACK(2) = 6
            cmdACK(3) = ACK
            iErr = TransmitCMD(Cmd, Rsp)
            If iErr = RE_NONE Then
                If Rsp(2) = 6 And Rsp(3) = ACK Then 'ACK response received
                    Return iErr
                End If
                If Rsp(2) = 6 And Rsp(3) = NAK Then 'NAK response received
                    'повторить после задержки
                    If iCmdDelay Then Thread.Sleep(iCmdDelay)
                Else 'не NAK и не ACK (например, STATUS в ответ на POLL)
                    'послать положительное подтверждение
                    cmdACK(3) = ACK
                    TransmitCMD(cmdACK, Nothing)
                    'и немного подождать
                    If iCmdDelay Then Thread.Sleep(iCmdDelay)
                    Exit For
                End If
            Else 'ошибка передачи
                'если TIMEOUT, то просто повторить,
                'иначе послать NAK и повторить после задержки
                If iErr <> RE_TIMEOUT Then
                    cmdACK(3) = NAK
                    TransmitCMD(cmdACK, Nothing) 'cmdResp)
                    If iCmdDelay Then Thread.Sleep(iCmdDelay)
                End If
            End If
        Next i

        Return iErr

    End Function

    'For all CmdXXX functions possible error codes is stored in the iLastError global variable

    Private Function CmdReset() As Boolean
        'Send a RESET command to the device
        'Returns true if command was acknowledged

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.RESET, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(3) <> ACK Then
                If Response(3) <> ST_INV_CMD Then
                    iLastError = ER_NAK
                Else
                    iLastError = ER_INVALID_CMD
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function

    Private Function CmdPoll() As Boolean
        'Send POLL command to the device
        ' and fill bytes Z1 and Z2 of the response into the PollResultsZ1/Z2 variables.
        'Returns true if exchange was successfully completed

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.POLL, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            PollResults.Z1 = Response(3)
            PollResults.Z2 = Response(4)
            Return True
        Else
            PollResults.Z1 = 0
            PollResults.Z2 = 0
            Return False
        End If

    End Function

    Private Function CmdStatus() As Boolean
        'Send STATUS REQUEST to the device
        '  The response status data is stored in the BillStatus structure variable.
        'Returns true if exchange was successfully completed

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.GET_STATUS, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(2) = 6 And Response(3) = ST_INV_CMD Then
                iLastError = ER_INVALID_CMD
                BillStatus.Enabled = 0
                BillStatus.Security = 0
                'BillStatus.Routing = 0
                Return False
            End If
            BillStatus.Enabled = (CType(Response(3), UInt32) << 16) + (CType(Response(4), UInt32) << 8) + Response(5)
            BillStatus.Security = (CType(Response(6), UInt32) << 16) + (CType(Response(7), UInt32) << 8) + Response(8)
            'BillStatus.Routing = (CType(Response(9), UInt32) << 16) + (CType(Response(10), UInt32) << 8) + Response(11)
            Return True
        Else
            Return False
        End If

    End Function

    '/**	\brief	The CCCRSProtocol::CmdIdentification function sends IDENTIFICATION request

    '  The function sends IDENTIFICATION request and stores device identification in the member CCCRSProtocol::Ident structure.
    '  The function supports both new and old identification formats of Bill-To-Bill units.

    '	\param	Addr	a parameter of type BYTE containing device address. Refer to \link Addr Device address list \endlink for the valid values

    '	\return	bool - true if the exchange was successfully completed and data received


    '*/
    'bool CCCRSProtocol::CmdIdentification(BYTE Addr)
    '{
    '	BYTE Data[256]={SYNC,0,6,IDENTIFICATION,0,0};
    '	CCommand cmd(Data,0);
    '	CCommand Response=Transmit(cmd,Addr);
    '	if(!(iLastError=Response.GetCode()))
    '	{
    '		if((Response.GetData()[3]==ST_INV_CMD)&&(Response.GetData()[2]==6))
    '		{
    '			iLastError=ER_INVALID_CMD;
    '			return false;
    '		}
    '		strcpy(Ident.BCCPUBoot,"N/A");
    '		strcpy(Ident.BCCPUVersion,"N/A");
    '		strcpy(Ident.BCCS1Boot,"N/A");
    '		strcpy(Ident.BCCS2Boot,"N/A");
    '		strcpy(Ident.BCCS3Boot,"N/A");
    '		strcpy(Ident.BCCSVersion,"N/A");
    '		strcpy(Ident.BCDispenserBoot,"N/A");
    '		strcpy(Ident.BCDispenserVersion,"N/A");
    '		strcpy(Ident.BVBootVersion,"N/A");
    '		strcpy(Ident.BVVersion,"N/A");
    '		strcpy(Ident.PartNumber,"N/A");
    '		char sTemp[64];
    '		int iPos=3,iLen=15;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.PartNumber,sTemp);
    '		iLen=12;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.SN,sTemp);
    '		char *strTemp=(char*)Response.GetData()+iPos;


    '		Ident.DS1=0;iPos+=8;
    '		for(int i=0;i<7;i++)
    '		{
    '			Ident.DS1<<=8;
    '			Ident.DS1+=strTemp[i];
    '		}
    '		if(Response.GetData()[2]<109) return true;

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BVBootVersion,sTemp);

    '		iLen=20;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BVVersion,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCPUBoot,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCPUVersion,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCDispenserBoot,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCDispenserVersion,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCS1Boot,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCS2Boot,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCS3Boot,sTemp);

    '		iLen=6;
    '		strncpy(sTemp,(char*)Response.GetData()+iPos,iLen);
    '		sTemp[iLen]=0;iPos+=iLen;
    '		strcpy(Ident.BCCSVersion,sTemp);
    '		return true;
    '	}
    '	else 
    '	{
    '		return false;
    '	}
    '}

    Private Function CmdHold() As Boolean
        'Send HOLD command to the device
        'Returns true if exchange successfully completed

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.HOLD, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(3) <> ACK Then
                If Response(3) <> ST_INV_CMD Then
                    iLastError = ER_NAK
                Else
                    iLastError = ER_INVALID_CMD
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function


    '/**	\brief	The CCCRSProtocol::CmdSetSecurity function sends SET SECURITY LEVELS command

    '	\param	wS	a parameter of type DWORD - a bitmap containing security levels to set
    '	\param	Addr	a parameter of type BYTE containing device address. Refer to \link Addr Device address list \endlink for the valid values

    '	\return	bool - true if exchange successfully completed


    '*/
    'bool CCCRSProtocol::CmdSetSecurity(DWORD wS,BYTE Addr)
    '{
    '	BYTE Data[256]={SYNC,0,9,SET_SECURITY,(BYTE)(wS>>16),(BYTE)(wS>>8),(BYTE)wS,0,0};
    '	CCommand cmd(Data,0);
    '	CCommand Response=Transmit(cmd,Addr);
    '	BYTE ack;
    '	if(!(iLastError=Response.GetCode()))
    '	{
    '		if((ack=Response.GetData()[3])!=ACK)
    '		{
    '			iLastError=(ack!=ST_INV_CMD)?ER_NAK:ER_INVALID_CMD;
    '			return false;
    '		}
    '		else return true;

    '	}
    '	else 
    '	{
    '		return false;
    '	}
    '}

    Private Function CmdBillType(ByVal enBill As UInt32, ByVal escBill As UInt32) As Boolean
        'Send ENABLE BILL TYPE command
        '  enBill  - a bitmap containing 1 in the positions corresponding to the enabled bill types
        '  escBill - a bitmap containing 1 in the positions corresponding to bill type processed with escrow
        'Returns true if the command was acknowledged

        Dim Cmd() As Byte = {SYNC, 0, 12, Cmds.BILL_TYPE, _
                             CByte(enBill >> 16 And &HFF), CByte(enBill >> 8 And &HFF), CByte(enBill And &HFF), _
                             CByte(escBill >> 16 And &HFF), CByte(escBill >> 8 And &HFF), CByte(escBill And &HFF), _
                             0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(3) <> ACK Then
                If Response(3) <> ST_INV_CMD Then
                    iLastError = ER_NAK
                Else
                    iLastError = ER_INVALID_CMD
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function

    Private Function CmdPack() As Boolean
        'Send PACK command
        'Returns true if the command was acknowledged

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.PACK, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(3) <> ACK Then
                If Response(3) <> ST_INV_CMD Then
                    iLastError = ER_NAK
                Else
                    iLastError = ER_INVALID_CMD
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function

    Private Function CmdReturn() As Boolean
        'Send RETURN command
        'Returns true if the command was acknowledged

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.RETURN, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(3) <> ACK Then
                If Response(3) <> ST_INV_CMD Then
                    iLastError = ER_NAK
                Else
                    iLastError = ER_INVALID_CMD
                End If
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function

    '/**	\brief	The CCCRSProtocol::CmdGetBillTable function sends BILL TABLE request

    '	\param	BillTable	a parameter of type _BillRecord * containing pointer to the _BillRecord array receiving the bill table.
    '			Position in the array corresponds to the bill type and the structure at the position describes that bill type.
    '	\param	Addr	a parameter of type BYTE containing device address. Refer to \link Addr Device address list \endlink for the valid values

    '	\return	bool - true if the response was successfully received


    '*/
    'bool CCCRSProtocol::CmdGetBillTable(_BillRecord * BillTable,BYTE Addr)
    '{
    '	BYTE Data[256]={SYNC,0,6,GET_BILL_TABLE,0,0};
    '	CCommand cmd(Data,0);
    '	CCommand Response=Transmit(cmd,Addr);
    '	if(!(iLastError=Response.GetCode()))
    '	{
    '		if((Response.GetData()[3]==ST_INV_CMD)&&(Response.GetData()[2]==6))
    '		{
    '			iLastError=ER_INVALID_CMD;
    '			for(int i=0;i<24;i++)
    '			{
    '			BillTable[i].Denomination=0;
    '			strcpy(BillTable[i].sCountryCode,"");
    '			}
    '			return false;
    '		}
    '		for(int i=0;i<(Response.GetData()[2])-5;i+=5)
    '		{
    '			BillTable[i/5].Denomination=Response.GetData()[i+3];
    '			char sTmp[5];
    '			strncpy(sTmp,(const char *)(Response.GetData()+i+4),3);
    '			sTmp[3]='\0';
    '			strcpy(BillTable[i/5].sCountryCode,sTmp);
    '			if(((Response.GetData())[i+7])&0x80)
    '			{
    '				for(int j=0; j<((Response.GetData()[i+7])&0x7F);j++)
    '					BillTable[i/5].Denomination/=10;
    '			}
    '			else
    '			{
    '				for(int j=0; j<((Response.GetData()[i+7])&0x7F);j++)
    '					BillTable[i/5].Denomination*=10;
    '			};
    '		}
    '		for(i;i<24*5;i+=5)
    '		{
    '			BillTable[i/5].Denomination=0;
    '			strcpy(BillTable[i/5].sCountryCode,"");
    '		} 
    '		return true;

    '	}
    '	else 
    '	{
    '		return false;
    '	}
    '}


    '/**	\brief	The CCCRSProtocol::CmdSetBarParams function sends SET BARCODE PARAMETERS command

    '	\param	Format	a parameter of type BYTE specifiying barcode format
    '	\param	Length	a parameter of type BYTE specifiying barcode length
    '	\param	Addr	a parameter of type BYTE containing device address. Refer to \link Addr Device address list \endlink for the valid values

    '	\return	bool - true if the command was acknowledged


    '*/
    'bool CCCRSProtocol::CmdSetBarParams(BYTE Format, BYTE Length, BYTE Addr=ADDR_BB)
    '{
    '	BYTE Data[256]={SYNC,0,8,SET_BAR_PARAMS,
    '					Format, Length,
    '					0,0};
    '	CCommand cmd(Data,0);
    '	CCommand Response=Transmit(cmd, Addr);
    '	BYTE ack;
    '	if(!(iLastError=Response.GetCode()))
    '	{
    '		if((ack=Response.GetData()[3])!=ACK)
    '		{
    '			iLastError=(ack!=ST_INV_CMD)?ER_NAK:ER_INVALID_CMD;
    '			return false;
    '		}
    '		else return true;

    '	}
    '	else 
    '	{
    '		return false;
    '	}
    '}

    '/**	\brief	The CCCRSProtocol::CmdExtractBarData function sends EXTRACT BARCODE DATA command

    '	\param	sBar	a parameter of type LPSTR containing pointer to a zero-terminated string receiving the barcode value.
    '	\param	Addr	a parameter of type BYTE containing device address. Refer to \link Addr Device address list \endlink for the valid values

    '	\return	bool - true if the response was successfully received


    '*/
    'bool CCCRSProtocol::CmdExtractBarData(LPSTR sBar, BYTE Addr=ADDR_BB)
    '{
    '	BYTE Data[256]={SYNC,0,6,EXTRACT_BAR_DATA,0,0};
    '	CCommand cmd(Data,0);
    '	CCommand Response=Transmit(cmd,Addr);
    '	if(!(iLastError=Response.GetCode()))
    '	{
    '		if((Response.GetData()[3]==ST_INV_CMD)&&(Response.GetData()[2]==6))
    '		{
    '			iLastError=ER_INVALID_CMD;
    '			return false;
    '		}
    '		strcpy(sBar,"");
    '		for (int i=3; i<Response.GetData()[2]-2;i++)
    '			sBar[i-3]= Response.GetData()[i];
    '		return true;
    '	}
    '	else 
    '	{
    '		return false;
    '	}
    '}

    Private Function CmdGetCRC32(ByRef dwCRC As UInt32) As Boolean
        'Send CRC32 request
        '  dwCRC - a reference to the variable receiving CRC32 of the firmware.
        'Returns true if the request was answered

        Dim Cmd() As Byte = {SYNC, 0, 6, Cmds.CRC32, 0, 0}
        Dim Response As Byte() = Nothing
        iLastError = Transmit(Cmd, Response)
        If iLastError = 0 Then
            If Response(2) = 6 And Response(3) = ST_INV_CMD Then
                iLastError = ER_INVALID_CMD
                dwCRC = 0
                Return False
            End If
            dwCRC = (CType(Response(3), UInt32) << 24) + (CType(Response(4), UInt32) << 16) + (CType(Response(5), UInt32) << 8) + Response(6)
            Return True
        Else
            dwCRC = 0
            Return False
        End If

    End Function

    Public Sub New()
        'Constructor of the class CashCodeSMBillValidator

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

            Dim BVNode As XmlNode = rootNode.SelectSingleNode("descendant::BillValidator")
            If BVNode Is Nothing Then
                WriteLog("BillValidator section of configuration file not found, default values will be used")
                Exit Do
            End If

            Dim xmlNode As XmlNode = BVNode.SelectSingleNode("descendant::Parameters")
            If xmlNode Is Nothing Then
                WriteLog("Parameters node of BillValidator configuration section not found, default values will be used")
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

            xmlNode = BVNode.SelectSingleNode("descendant::PermissibleNominals")
            If xmlNode Is Nothing Then
                WriteLog("PermissibleNominals node of BillValidator configuration section not found, default values will be used")
                Exit Do
            End If

            Dim xmlNominals As XmlNodeList = xmlNode.SelectNodes("Nominal")

            cfgNominals.Clear()
            EnabledTypes = 0
            For Each NomNode As XmlNode In xmlNominals
                Dim atr As XmlAttribute
                Dim Value, Code As Integer
                atr = CType(NomNode.Attributes.GetNamedItem("Value"), XmlAttribute)
                If atr Is Nothing Then
                    WriteLog("Value not found in nominal definition, will be ignored")
                    Continue For
                Else
                    If IsNumeric(atr.Value) Then
                        Value = CInt(atr.Value)
                    Else
                        WriteLog("Invalid numeric value " & Trim(atr.Value) & " for nominal definition, will be ignored")
                        Continue For
                    End If
                End If
                atr = CType(NomNode.Attributes.GetNamedItem("Code"), XmlAttribute)
                If atr Is Nothing Then
                    WriteLog("Code not found in nominal definition, will be ignored")
                    Continue For
                Else
                    If IsNumeric(atr.Value) Then
                        Code = CInt(atr.Value)
                    Else
                        WriteLog("Invalid numeric code " & Trim(atr.Value) & " for nominal definition, will be ignored")
                        Continue For
                    End If
                End If
                cfgNominals.Add(Value)
                EnabledTypes = (EnabledTypes Or (1 << Code))
            Next NomNode

            Exit Do
        Loop

        WriteLog("Bill Validator device parameters in use :")
        WriteLog("     DebugLevel = " & cfgDebugLevel.ToString)
        WriteLog("     ComPortName = " & cfgComPort)
        WriteLog("     ComPortBaudRate = " & cfgBaudRate.ToString)
        WriteLog("     ComPortReadTimeout = " & cfgReadTimeOut.ToString)
        WriteLog("Bill Validator PermissibleNominals :")
        For Each nom As Integer In cfgNominals
            WriteLog("     " & nom.ToString)
        Next
        'If cfgDebugLevel >= 2 Then WriteLog("     EnabledTypes = " & Convert.ToString(EnabledTypes, 2))

        BV = New Ports.SerialPort
        'BV.StartBits=1

        'Dim pn As String = ""
        'For Each pn In Ports.SerialPort.GetPortNames
        '    MsgBox(pn)
        'Next
        'BV.PortName = pn  'last port

        'InitCOM(int COMi, LPSTR Str,int iTimeOut=300)
        '{
        '   DCB dcb,dcb1;
        '   COMMTIMEOUTS CommTimeOuts;
        '   PurgeComm(hCOMPort,-1);
        '   CloseCOM();
        '   SetupComm(OpenCOM(COMi),65535,0xffff);
        BV.ReadBufferSize = 65534
        BV.WriteBufferSize = &HFFFF - 1 '=65534
        '   GetCommState(hCOMPort, &dcb);
        '   if(!BuildCommDCB(Str,&dcb1))return FALSE;
        BV.PortName = cfgComPort '"COM1"
        ' // Filling in the DCB
        '          dcb.BaudRate = dcb1.BaudRate;
        BV.BaudRate = cfgBaudRate '9600
        '          dcb.ByteSize = dcb1.ByteSize;
        BV.DataBits = 8
        '          dcb.Parity = dcb1.Parity;
        BV.Parity = Ports.Parity.None
        '          dcb.StopBits = dcb1.StopBits;
        BV.StopBits = 1
        '      dcb.fBinary=1;          // binary mode, no EOF check
        '      dcb.fParity=0;          // enable parity checking
        '      dcb.fAbortOnError=FALSE; // abort reads/writes on error
        '          dcb.fDtrControl=DTR_CONTROL_DISABLE;
        BV.DtrEnable = False
        '          dcb.fRtsControl=RTS_CONTROL_DISABLE;
        BV.RtsEnable = False
        '          dcb.fOutxCtsFlow=FALSE;
        '          dcb.fOutxDsrFlow=FALSE;
        '          dcb.fDsrSensitivity=FALSE;
        '          dcb.fOutX=FALSE;
        BV.Handshake = Ports.Handshake.None
        ' //---------------
        '  if(!SetCommState(hCOMPort, &dcb))return FALSE;

        '  CommTimeOuts.ReadTotalTimeoutConstant=iTimeOut;
        '  CommTimeOuts.ReadTotalTimeoutMultiplier=11;
        BV.ReadTimeout = cfgReadTimeOut + 11 * 6
        '  CommTimeOuts.WriteTotalTimeoutConstant=200;
        '  CommTimeOuts.WriteTotalTimeoutMultiplier=11;
        BV.WriteTimeout = 200 + 11 * 6
        '  return SetCommTimeouts( hCOMPort, &CommTimeOuts ) ;
        'BV.ReceivedBytesThreshold = 6

        '                    SYNC ADDR LNG  CMD   CRC1  CRC0
        'Dim cmd As Byte() = {&H2, &H3, &H6, &H30, &H41, &HB3}
        'MsgBox(Hex(CalculateCRC(cmd)))

    End Sub

    Public Sub Initialize() Implements ITerminalBillValidator.Initialize

        Try
            BV.Open()
            If Not BV.IsOpen Then
                WriteLog("Open failed")
                Throw New ApplicationException("Не удалось открыть " & BV.PortName)
                Exit Sub
            Else
                WriteLog("Opened successfully")

                'AddHandler BV.DataReceived, AddressOf OnDataReceived
                AddHandler BV.ErrorReceived, AddressOf OnErrorReceived
                AddHandler BV.PinChanged, AddressOf OnPinChanged

                If CmdReset() Then
                    WriteLog("Reset was acknowledged")
                Else
                    WriteLog("Reset failed with ErrorCode = " & iLastError.ToString)
                    Throw New ApplicationException("Ошибки при выполнении команды RESET")
                    Exit Sub
                End If

                'Дождаться состояния Unit disabled
                Do
                    If CmdPoll() Then
                        WriteLog("State = " & CType(PollResults.Z1, States).ToString)
                        Select Case PollResults.Z1
                            Case &H1C 'Rejected
                                WriteLog("Reject Reason = " & CType(PollResults.Z2, RejCodes).ToString)
                            Case &H47 'Failure
                                WriteLog("Failure Reason = " & CType(PollResults.Z2, FailCodes).ToString)
                            Case &H80, &H81, &H82
                                WriteLog("Bill Type = " & CType(PollResults.Z2, BillTypeCodes).ToString)
                            Case Else '1-byte responses
                        End Select
                    Else
                        WriteLog("Poll failed with ErrorCode = " & iLastError.ToString)
                        'Exit Sub
                    End If
                    Thread.Sleep(200)
                Loop Until PollResults.Z1 = States.ST_DISABLED

                If CmdStatus() Then
                    WriteLog("Enabled = " & Convert.ToString(BillStatus.Enabled, 2) & _
                           ", Security = " & Convert.ToString(BillStatus.Security, 2))
                Else
                    WriteLog("Get Status failed with ErrorCode = " & iLastError.ToString)
                    'Exit Sub
                End If

            End If
        Catch ex As Exception 'When Not TypeOf ex Is ApplicationException
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение инициализации купюроприемника", ex)
        Finally
            If BV.IsOpen Then
                BV.DiscardInBuffer()
                BV.DiscardOutBuffer()
                BV.Close()
            End If
            'RemoveHandler BV.DataReceived, AddressOf OnDataReceived
            RemoveHandler BV.ErrorReceived, AddressOf OnErrorReceived
            RemoveHandler BV.PinChanged, AddressOf OnPinChanged
        End Try

    End Sub

    Public Function AcceptMoney(ByVal waitMillis As Integer) As Integer Implements ITerminalBillValidator.AcceptMoney

        Dim UserTimeOut As Integer = waitMillis
        Dim UserMoney As Integer = 0

        'Можно не закрывать порт при инициализации, а только отключить обработчики событий
        Try
            BV.Open()
            If Not BV.IsOpen Then
                WriteLog("Open failed")
                Throw New ApplicationException("Не удалось открыть " & BV.PortName)
                Exit Function
            Else
                WriteLog("Opened successfully")

                'AddHandler BV.DataReceived, AddressOf OnDataReceived
                AddHandler BV.ErrorReceived, AddressOf OnErrorReceived
                AddHandler BV.PinChanged, AddressOf OnPinChanged

                'Разрешить прием заданных русских денег
                If CmdBillType(EnabledTypes, &H0) Then
                    WriteLog("Enable Bill Types was acknowledged")
                Else
                    WriteLog("Enable Bill Types failed with ErrorCode = " & iLastError.ToString)
                    Throw New ApplicationException("Не удалось разрешить прием всех типов банкнот")
                    Exit Function
                End If

                'Дождаться состояния Idling
                Do
                    If CmdPoll() Then
                        WriteLog("State = " & CType(PollResults.Z1, States).ToString)
                        Select Case PollResults.Z1
                            Case &H1C 'Rejected
                                WriteLog("Reject Reason = " & CType(PollResults.Z2, RejCodes).ToString)
                            Case &H47 'Failure
                                WriteLog("Failure Reason = " & CType(PollResults.Z2, FailCodes).ToString)
                                Throw New ApplicationException("Аппаратная ошибка " & CType(PollResults.Z2, FailCodes).ToString & " при опросе состояния купюроприемника")
                                Exit Try
                            Case &H80, &H81, &H82
                                WriteLog("Bill Type = " & CType(PollResults.Z2, BillTypeCodes).ToString)
                                'если купюра уже есть, то выйти
                                If PollResults.Z1 = States.ST_PACKED Then Exit Try
                                'если купюра уже вставлена, то идти ждать окончания процесса
                                If PollResults.Z1 = States.ST_ACCEPTING Then Exit Do
                            Case &H41, &H42, &H43, &H44
                                'продолжать бесполезно
                                Throw New ApplicationException("Состояние купюроприемника " & CType(PollResults.Z1, States).ToString & " требует вмешательства")
                                Exit Try
                            Case Else '1-byte responses
                        End Select
                    Else
                        WriteLog("Poll failed with ErrorCode = " & iLastError.ToString)
                        'Exit Sub
                    End If
                    Thread.Sleep(200)
                Loop Until PollResults.Z1 = States.ST_IDLING

                'Убедиться, что разрешенные типы банкнот установлены
                If CmdStatus() Then
                    WriteLog("Enabled = " & Convert.ToString(BillStatus.Enabled, 2) & _
                           ", Security = " & Convert.ToString(BillStatus.Security, 2))
                Else
                    WriteLog("Get Status failed with ErrorCode = " & iLastError.ToString)
                    Throw New ApplicationException("Ошибка при чтении разрешенных типов банкнот")
                    Exit Function
                End If

                'Дождаться состояния Stacked, периодически проверяя, не истекло ли время
                'Timer function returns 0.0 at midnight
                Dim ElapsedTime As TimeSpan
                Dim UserTime As TimeSpan = TimeSpan.FromMilliseconds(UserTimeOut)
                Dim StartTime As DateTime = DateTime.Now
                Do
                    If CmdPoll() Then
                        WriteLog("State = " & CType(PollResults.Z1, States).ToString)
                        Select Case PollResults.Z1
                            Case &H1C 'Rejected
                                WriteLog("Reject Reason = " & CType(PollResults.Z2, RejCodes).ToString)
                            Case &H47 'Failure
                                WriteLog("Failure Reason = " & CType(PollResults.Z2, FailCodes).ToString)
                                Throw New ApplicationException("Аппаратная ошибка " & CType(PollResults.Z2, FailCodes).ToString & " при опросе состояния купюроприемника")
                                Exit Try
                            Case &H80, &H81, &H82
                                WriteLog("Bill Type = " & CType(PollResults.Z2, BillTypeCodes).ToString)
                            Case &H41, &H42, &H43, &H44
                                'продолжать бесполезно
                                Throw New ApplicationException("Состояние купюроприемника " & CType(PollResults.Z1, States).ToString & " требует вмешательства")
                                Exit Try
                            Case Else '1-byte responses
                        End Select
                    Else
                        WriteLog("Poll failed with ErrorCode = " & iLastError.ToString)
                        'Exit Function
                    End If
                    'UserTimeOut = UserTimeOut - 200
                    'If UserTimeOut <= 0 Then Exit Do
                    ElapsedTime = DateTime.Now.Subtract(StartTime)
                    If ElapsedTime > UserTime Then 'время истекло
                        'если процесс приема уже идет, то подождем еще немного
                        Select Case PollResults.Z1
                            Case States.ST_ACCEPTING, States.ST_PACKING, States.ST_BUSY, States.ST_PAUSED
                            Case Else
                                Exit Do
                        End Select
                    End If
                    Thread.Sleep(200)
                Loop Until PollResults.Z1 = States.ST_PACKED

            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение приема банкноты", ex)
        Finally
            'Запретить прием всех денег
            If CmdBillType(&H0, &H0) Then
                WriteLog("Disable Bill Types was acknowledged")
            Else
                WriteLog("Disable Bill Types failed with ErrorCode = " & iLastError.ToString)
            End If
            ''Убедиться, что все типы банкнот запрещены
            'If CmdStatus() Then
            '    WriteLog("Enabled = " & Convert.ToString(BillStatus.Enabled, 2) & _
            '           ", Security = " & Convert.ToString(BillStatus.Security, 2))
            'Else
            '    WriteLog("Get Status failed with ErrorCode = " & iLastError.ToString)
            'End If
            Dim SavedPollResults As STRUC_PolResults = PollResults
            If CmdPoll() Then
                WriteLog("Final Poll successfully completed")
            Else
                WriteLog("Final Poll failed with ErrorCode = " & iLastError.ToString)
            End If
            PollResults = SavedPollResults

            If BV.IsOpen Then
                BV.DiscardInBuffer()
                BV.DiscardOutBuffer()
                BV.Close()
            End If
            'RemoveHandler BV.DataReceived, AddressOf OnDataReceived
            RemoveHandler BV.ErrorReceived, AddressOf OnErrorReceived
            RemoveHandler BV.PinChanged, AddressOf OnPinChanged
        End Try

        If PollResults.Z1 = States.ST_PACKED Then 'что-то принято
            Select Case PollResults.Z2
                Case 2
                    UserMoney = 10
                Case 3
                    UserMoney = 50
                Case 4
                    UserMoney = 100
                Case 5
                    UserMoney = 500
                Case 6
                    UserMoney = 1000
                Case 7
                    UserMoney = 5000
                Case Else
                    'оставить 0
            End Select
        End If
        'MsgBox("Принято " & UserMoney.ToString & " рублей")
        Return UserMoney

    End Function

    Public Function AcceptMoneyInterruptable(ByRef Break As Boolean) As Integer Implements ITerminalBillValidator.AcceptMoneyInterruptable

        'Dim UserTimeOut As Integer = waitMillis
        Dim UserMoney As Integer = 0
        PollResults.Z1 = 0
        PollResults.Z2 = 0

        'Можно не закрывать порт при инициализации, а только отключить обработчики событий
        Try
            BV.Open()
            If Not BV.IsOpen Then
                WriteLog("Open failed")
                Throw New ApplicationException("Не удалось открыть " & BV.PortName)
                Exit Function
            Else
                WriteLog("Opened successfully")

                'AddHandler BV.DataReceived, AddressOf OnDataReceived
                AddHandler BV.ErrorReceived, AddressOf OnErrorReceived
                AddHandler BV.PinChanged, AddressOf OnPinChanged

                'Разрешить прием заданных русских денег
                If CmdBillType(EnabledTypes, &H0) Then
                    WriteLog("Enable Bill Types was acknowledged")
                Else
                    WriteLog("Enable Bill Types failed with ErrorCode = " & iLastError.ToString)
                    Throw New ApplicationException("Не удалось разрешить прием всех типов банкнот")
                    Exit Function
                End If

                'Дождаться состояния Idling
                Do
                    If CmdPoll() Then
                        WriteLog("State = " & CType(PollResults.Z1, States).ToString)
                        Select Case PollResults.Z1
                            Case &H1C 'Rejected
                                WriteLog("Reject Reason = " & CType(PollResults.Z2, RejCodes).ToString)
                            Case &H47 'Failure
                                WriteLog("Failure Reason = " & CType(PollResults.Z2, FailCodes).ToString)
                                Throw New ApplicationException("Аппаратная ошибка " & CType(PollResults.Z2, FailCodes).ToString & " при опросе состояния купюроприемника")
                                Exit Try
                            Case &H80, &H81, &H82
                                WriteLog("Bill Type = " & CType(PollResults.Z2, BillTypeCodes).ToString)
                                'если купюра уже есть, то выйти
                                If PollResults.Z1 = States.ST_PACKED Then Exit Try
                                'если купюра уже вставлена, то идти ждать окончания процесса
                                If PollResults.Z1 = States.ST_ACCEPTING Then Exit Do
                            Case &H41, &H42, &H43, &H44
                                'продолжать бесполезно
                                Throw New ApplicationException("Состояние купюроприемника " & CType(PollResults.Z1, States).ToString & " требует вмешательства")
                                Exit Try
                            Case Else '1-byte responses
                        End Select
                    Else
                        WriteLog("Poll failed with ErrorCode = " & iLastError.ToString)
                        'Exit Sub
                    End If
                    If Break Then Exit Try
                    Thread.Sleep(200)
                Loop Until PollResults.Z1 = States.ST_IDLING

                'Убедиться, что разрешенные типы банкнот установлены
                If CmdStatus() Then
                    WriteLog("Enabled = " & Convert.ToString(BillStatus.Enabled, 2) & _
                           ", Security = " & Convert.ToString(BillStatus.Security, 2))
                Else
                    WriteLog("Get Status failed with ErrorCode = " & iLastError.ToString)
                    Throw New ApplicationException("Ошибка при чтении разрешенных типов банкнот")
                    Exit Function
                End If

                'Дождаться состояния Stacked, периодически проверяя, не прервана ли операция пользователем
                'Timer function returns 0.0 at midnight
                'Dim ElapsedTime As TimeSpan
                'Dim UserTime As TimeSpan = TimeSpan.FromMilliseconds(UserTimeOut)
                'Dim StartTime As DateTime = DateTime.Now
                Do
                    If CmdPoll() Then
                        WriteLog("State = " & CType(PollResults.Z1, States).ToString)
                        Select Case PollResults.Z1
                            Case &H1C 'Rejected
                                WriteLog("Reject Reason = " & CType(PollResults.Z2, RejCodes).ToString)
                            Case &H47 'Failure
                                WriteLog("Failure Reason = " & CType(PollResults.Z2, FailCodes).ToString)
                                Throw New ApplicationException("Аппаратная ошибка " & CType(PollResults.Z2, FailCodes).ToString & " при опросе состояния купюроприемника")
                                Exit Try
                            Case &H80, &H81, &H82
                                WriteLog("Bill Type = " & CType(PollResults.Z2, BillTypeCodes).ToString)
                            Case &H41, &H42, &H43, &H44
                                'продолжать бесполезно
                                Throw New ApplicationException("Состояние купюроприемника " & CType(PollResults.Z1, States).ToString & " требует вмешательства")
                                Exit Try
                            Case Else '1-byte responses
                        End Select
                    Else
                        WriteLog("Poll failed with ErrorCode = " & iLastError.ToString)
                        'Exit Function
                    End If
                    'ElapsedTime = DateTime.Now.Subtract(StartTime)
                    'If ElapsedTime > UserTime Then 'время истекло
                    If Break Then ' пора заканчивать
                        'если процесс приема уже идет, то подождем еще немного
                        Select Case PollResults.Z1
                            Case States.ST_ACCEPTING, States.ST_PACKING, States.ST_BUSY, States.ST_PAUSED
                            Case Else
                                Exit Do
                        End Select
                    End If
                    Thread.Sleep(200)
                Loop Until PollResults.Z1 = States.ST_PACKED

            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Throw New ApplicationException("Аварийное завершение приема банкноты", ex)
        Finally
            'Запретить прием всех денег
            If CmdBillType(&H0, &H0) Then
                WriteLog("Disable Bill Types was acknowledged")
            Else
                WriteLog("Disable Bill Types failed with ErrorCode = " & iLastError.ToString)
            End If
            ''Убедиться, что все типы банкнот запрещены
            'If CmdStatus() Then
            '    WriteLog("Enabled = " & Convert.ToString(BillStatus.Enabled, 2) & _
            '           ", Security = " & Convert.ToString(BillStatus.Security, 2))
            'Else
            '    WriteLog("Get Status failed with ErrorCode = " & iLastError.ToString)
            'End If
            Dim SavedPollResults As STRUC_PolResults = PollResults
            If CmdPoll() Then
                WriteLog("Final Poll successfully completed")
            Else
                WriteLog("Final Poll failed with ErrorCode = " & iLastError.ToString)
            End If
            PollResults = SavedPollResults

            If BV.IsOpen Then
                BV.DiscardInBuffer()
                BV.DiscardOutBuffer()
                BV.Close()
            End If
            'RemoveHandler BV.DataReceived, AddressOf OnDataReceived
            RemoveHandler BV.ErrorReceived, AddressOf OnErrorReceived
            RemoveHandler BV.PinChanged, AddressOf OnPinChanged
        End Try

        If PollResults.Z1 = States.ST_PACKED Then 'что-то принято
            Select Case PollResults.Z2
                Case 2
                    UserMoney = 10
                Case 3
                    UserMoney = 50
                Case 4
                    UserMoney = 100
                Case 5
                    UserMoney = 500
                Case 6
                    UserMoney = 1000
                Case 7
                    UserMoney = 5000
                Case Else
                    'оставить 0
            End Select
        End If
        'MsgBox("Принято " & UserMoney.ToString & " рублей")
        Return UserMoney

    End Function

    Public Function GetAcceptableBillDenominations() As IList(Of Integer) Implements ITerminalBillValidator.GetAcceptableBillDenominations
        Return cfgNominals
    End Function

End Class
