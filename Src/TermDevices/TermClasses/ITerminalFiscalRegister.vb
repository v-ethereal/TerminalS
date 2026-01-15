'namespace TerminalTest.Devices
''' <summary>
''' Интерфейс доступа к фискальному регистратору (ФР).
''' </summary>
Public Interface ITerminalFiscalRegister
    ''' <summary>
    ''' Инициализация устройства.
    ''' 
    ''' В методе выполняется программный сброс устройства, в ходе которого выполняются следующие операции:
    ''' 1) если в аппарате присутствует незавершенный чек, отмена его, извлечение и отрез (если сброс этого не делает)
    ''' 2) сброс устройства
    ''' 3) перевод в режим готовности (если сброс этого не делает).
    ''' 
    ''' Если при инициализации происходит ошибка (порт занят, устройство не отвечает и т.п.), бросается исключение.
    ''' </summary>
    Sub Initialize()

    ''' <summary>
    ''' Печать чека об оплате аренды.
    ''' Формируется и выводится на печать фискальный документ.
    ''' Каждый оплачиваемый день аренды должен идти отдельной строкой со следующими полями: 
    ''' 1) наименование товара - "Аренда места№__ за _._.___". В случае недоплаты, доплаты или переплаты дописывать в конце " /частично", "/доплата" или "/переплата" соответственно. 
    ''' 2) количество - 1 
    ''' 3) цена - цена аренды этого дня или размер доплаты неполностью оплаченого дня или размер остатка на последний оплачиваемый день 
    ''' 
    '''  Считать суммой принятых денег сумму переданных платежей по всем дням. 
    ''' </summary>
    ''' <param name="paymentsInfo">информация об оплатах и стоимостях аренды одного места по дням аренды</param>
    Sub PrintRentalReceipt(ByVal paymentsInfo As IList(Of DayRentalPaymentInfo))

    ''' <summary>
    ''' Печать чека об оплате дополнительной услуги.
    ''' Формируется и выводится на печать фискальный документ.
    ''' Чек на оплату дополнительной услуги должен выводиться одной строкой со следующими полями: 
    ''' 1) наименование товара - наименование услуги. В случае недоплаты или переплаты дописывать в конце " /частично", "/переплата" соответственно. При формировании строки наименования товара обрезать наименование услуги таким образом, чтобы полная строка наименования товара была не более 40 символов длиной. 
    ''' 2) количество - 1 
    ''' 3) цена - сумма внесенных денег  
    '''  </summary>
    ''' <param name="serviceName">Наименование услуги</param>
    ''' <param name="servicePrice">Цена услуги. Используется только для опеределения факта переплаты и недоплаты</param>
    ''' <param name="paidSum">Сумма внесенных денег</param>
    Sub PrintAdditionalServiceReceipt(ByVal serviceName As String, ByVal servicePrice As Decimal, ByVal paidSum As Decimal)

    ''' <summary>
    ''' Печать отчета по неоплаченным местам на чековой ленте.
    ''' Формируется и выводится на печать документ произвольного вида. 
    ''' Формат документа: 
    ''' 1) строка заголовка - "      Список неоплаченных мест за _..___" 
    ''' 2) разделитель - пустая строка 
    ''' 3) необходимое количество строк с номерами неоплаченных мест в формате 
    '''                       "sssssss sssssss sssssss sssssss sssssss sssssss" (табулированный список, выравнивание номеров по левому краю в маске) 
    ''' 4) отрезать
    ''' Новый вариант
    ''' 1) пустая строка
    ''' 2) пустая строка
    ''' 3) строка заголовка - "      СПИСОК НЕОПЛАЧЕННЫХ МЕСТ ЗА dd.MM.yyyy"
    ''' 4) разделитель - пустая строка 
    ''' 5) строка заголовка - "        Отчет сформирован dd.MM.yyyy hh:mm" - текущее время
    ''' 6) разделитель - пустая строка 
    ''' 7) необходимое количество строк с номерами неоплаченных мест в формате 
    '''                       "  sssssss sssssss sssssss sssssss sssssss sssssss" (табулированный список, выравнивание номеров по левому краю в маске) 
    ''' 8) пустая строка
    ''' 9) разделитель -      "================== Конец отчета =================="
    ''' 6) отрезать
''' </summary>
''' <param name="controlDate">дата контроля</param>
''' <param name="unpaidPlaces">список неоплаченных на дату контроля мест</param>
    Sub PrintUnpaidRentalPlacesReport(ByVal controlDate As DateTime, ByVal unpaidPlaces As IList(Of String))

    ''' <summary>
    ''' Печать X-отчета.
    ''' Вызов штатного метода печати X-отчета фискальным регистратором.
    ''' </summary>
    Sub PrintXReport()

    ''' <summary>
    ''' Печать Z-отчета.
    ''' Вызов штатного метода печати Z-отчета фискальным регистратором.
    ''' </summary>
    Sub PrintZReport()

    ''' <summary>
    ''' Печать отчета о смене с детализацией по услугам.
    ''' Если при выполнении происходит ошибка, бросается исключение.
    ''' 
    ''' Формат документа: 
    ''' 1) пустая строка
    ''' 2) пустая строка
    ''' 3) строка заголовка - "     ДЕТАЛИЗАЦИЯ СУТОЧНОГО ОТЧЕТА ПО УСЛУГАМ" 
    ''' 4) строка заголовка - "     ТЕРМИНАЛ: sssssssssssssssssssssssssssssssssss" 
    ''' 5) пустая строка
    ''' 6) строка заголовка - "        Отчет сформирован dd.MM.yyyy hh:mm" - текущее время
    ''' 7) пустая строка
    ''' 8) цикл строк по списку услуг - 
    '''                       "sssssssssssssssssssssssssssssssssss  #########0.00"
    '''    после каждой строки пустая строка
    ''' 9) разделитель -      "=================================================="
    ''' 10) строка -           "ИТОГО:			                    #########0.00"
    ''' 11) пустая строка
    ''' 12) разделитель -     "================== Конец отчета =================="
    ''' 13) отрезать
    ''' </summary>
    ''' <param name="terminalName">имя терминала (номер кассы и т.п.)</param>
    ''' <param name="servicesShiftInfo">информация об итогах смены по услугам</param>
    Sub PrintShiftSummaryReport(ByVal terminalName As String, ByVal servicesShiftInfo As IList(Of ServiceShiftSummaryInfo))

    ''' <summary>
    ''' Печать парковочного талона
    ''' </summary>
    ''' <param name="StartDate">дата, время заезда</param>
    ''' <param name="BarCode">номер парковочного талона, составной номер дата_заезда.номер_талона</param>
    ''' <param name="Price">стоимость парковки за час</param>
    ''' <param name="Penalty">стоимость парковки без учёта времени</param>
    Sub PrintParkingToken(ByVal startDate As Date, ByVal barCode As String, ByVal price As Decimal, ByVal penalty As Decimal)

    ''' <summary>
    ''' Печать выездного талона
    ''' </summary>
    ''' <param name="CardNumber">номер парковочной карты</param>
    ''' <param name="StartDate">дата, время заезда</param>
    ''' <param name="FinishDate">дата, время оплаты</param>
    ''' <param name="ExternalPayment">парковка будет оплачена в системе ParkTime</param>
    ''' <param name="PaidSum">оплаченная сумма</param>
    Sub PrintParkingExitTicket(ByVal cardNumber As String, ByVal startDate As Date, ByVal finishDate As Date, ByVal externalPayment As Boolean, ByVal paidSum As Decimal)

    ''' <summary>
    ''' Печать чека для парковки почасовой
    ''' </summary>
    ''' <param name="ParkingTicketNumber">Номер парковочного талона</param>
    ''' <param name="StartDate">Дата заезда</param>
    ''' <param name="EndDate">Даты выезда</param>
    ''' <param name="servicePrice">тариф за 1 час парковки</param>
    ''' <param name="needPaySum">сумма которую необходимо заплатить 
    ''' Вариант 1. Если кол-во часов парковки меньше или равно 4 часа, то платим кол-во часов * тариф за 1 час
    ''' Вариант 2. Если кол-во часов парковки больше 4 часа, то платим тариф парковки без учёта времени - 500 руб
    ''' </param>
    ''' <param name="realPaySum">сумма реально оплаченная</param>
    ''' <remarks></remarks>
    Sub PrintParkingPerHourReceipt(ByVal parkingTicketNumber As String, ByVal startDate As Date, ByVal endDate As Date, ByVal servicePrice As Decimal, ByVal needPaySum As Decimal, ByVal realPaySum As Decimal)

    ''' <summary>
    ''' Печать чека для парковки без учёта времени или потери парковочного талона
    ''' </summary>
    ''' <param name="servicePrice">тариф услуги парковка без учёта времени</param>
    ''' <param name="realPaySum">сумма реально оплаченная</param>
    ''' <remarks></remarks>
    Sub PrintParkingWithoutTimeReceipt(ByVal servicePrice As Decimal, ByVal realPaySum As Decimal)

    Sub PrintAdditionalServiceReceiptEx(ByVal serviceName As String, ByVal servicePrice As Decimal, ByVal paidSum As Decimal, ByVal InfoItems As IList(Of String))

    ''' <summary>
    ''' Печать штрих кода администратора зала для выдачи парковочного талона
    ''' </summary>
    Sub PrintAccessCode(ByVal accessCode As String)
End Interface

''' <summary>
''' Информация об оплате аренды за один день.
''' </summary>
Public Structure DayRentalPaymentInfo
    Private _placeNumber As String
    Private _date As DateTime
    Private _price As Decimal
    Private _paidSum As Decimal

    ''' <summary>
    ''' Номер места, за которое производится оплата.
    ''' </summary>
    Public Property PlaceNumber() As String
        Get
            Return _placeNumber
        End Get
        Set(ByVal value As String)
            _placeNumber = value
        End Set
    End Property

    ''' <summary>
    ''' Дата, за которую производится оплата.
    ''' </summary>
    Public Property [Date]() As DateTime
        Get
            Return _date
        End Get
        Set(ByVal value As DateTime)
            _date = value
        End Set
    End Property

    ''' <summary>
    ''' Стоимость аренды за указанный день.
    ''' Используется для определения факта переплаты и недоплаты.
    ''' </summary>
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property

    ''' <summary>
    ''' Сумма внесенных денег за оплату указанного дня.
    ''' </summary>
    Public Property PaidSum() As Decimal
        Get
            Return _paidSum
        End Get
        Set(ByVal value As Decimal)
            _paidSum = value
        End Set
    End Property

End Structure
''' <summary>
''' Информация об итогах смены по одной услуге.
''' </summary>
Public Structure ServiceShiftSummaryInfo
    Private _servicePaidTotal As Decimal
    Private _serviceQuantity As Integer
    Private _serviceName As String

    ''' <summary>
    ''' Наименование услуги.
    ''' </summary>
    Public Property ServiceName() As String
        Get
            Return _serviceName
        End Get
        Set(ByVal value As String)
            _serviceName = value
        End Set
    End Property

    ''' <summary>
    ''' Количество продаж услуги.
    ''' </summary>
    Public Property ServiceQuantity() As Integer
        Get
            Return _serviceQuantity
        End Get
        Set(ByVal value As Integer)
            _serviceQuantity = value
        End Set
    End Property

    ''' <summary>
    ''' Сумма по услуге.
    ''' </summary>
    Public Property ServicePaidTotal() As Decimal
        Get
            Return _servicePaidTotal
        End Get
        Set(ByVal value As Decimal)
            _servicePaidTotal = value
        End Set
    End Property

End Structure