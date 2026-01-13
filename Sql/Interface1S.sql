EXEC sp_configure 'show advanced options', 1
GO
RECONFIGURE
GO
-- Разрешаем cmdshell и Ole Automation
EXEC sp_configure 'xp_cmdshell', 1
EXEC sp_configure 'Ole Automation Procedures', 1
RECONFIGURE
GO

--SELECT * FROM sys.all_objects where name like 'tg%'
-----------------------------------------------------------------------------------------------------------
-- Создаем таблицу глобвальных настроек
IF OBJECT_ID ( 'GblSettings', 'U' ) IS NOT NULL 
    DROP TABLE dbo.GblSettings;
GO

CREATE TABLE dbo.GblSettings(
	KeyName	varchar(20) NOT NULL,
	KeyValue varchar(1000),
	CONSTRAINT [PK_GblSettings] PRIMARY KEY CLUSTERED (KeyName ASC )
	)
INSERT INTO dbo.GblSettings (KeyName, KeyValue)
VALUES ('Exchange1CPath', 'C:\Temp\Domodedovo')

INSERT INTO dbo.GblSettings (KeyName, KeyValue)
VALUES ('Exchange1CDebugMode', '2')


-----------------------------------------------------------------------------------------------------------

IF OBJECT_ID('Ex1CFileNum', 'U') IS NOT NULL 
    DROP TABLE dbo.Ex1CFileNum;
GO

CREATE TABLE dbo.Ex1CFileNum(
	FileName	varchar(7)
	)
GO
	
DELETE FROM dbo.Ex1CFileNum
go
INSERT INTO dbo.Ex1CFileNum VALUES('0000000')
GO

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1CHistory', 'U') IS NOT NULL 
    DROP TABLE dbo.Ex1CHistory;
GO

CREATE TABLE dbo.Ex1CHistory(
	Id int IDENTITY(1,1) NOT NULL,
	[FileName]	varchar(255) NOT NULL,
	Direction	varchar(3) NOT NULL,
	ServiceDate	datetime	NOT NULL,
	Content		varchar(4000) NULl,
	ErrCode		varchar(3) NOT NULL,
	ErrText		varchar(255) NULL,
	CONSTRAINT [PK_Ex1CHistory] PRIMARY KEY CLUSTERED ([Id] ASC )
	)
go

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('RussianDate', 'FN') IS NOT NULL 
    DROP FUNCTION dbo.RussianDate;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 04.09.2008
-- Description:	Преобразование даты в формат YYYYMMDD
-- =============================================
--select dbo.RussianDate('20080803') 
CREATE FUNCTION dbo.RussianDate (@p1 datetime)
RETURNS Varchar(8)
AS
BEGIN

DECLARE @strdate Varchar(8)

SELECT @strdate = CONVERT(varchar(8),@p1, 112)
RETURN @strdate
END
GO

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('ContractPlaces', 'FN') IS NOT NULL 
    DROP FUNCTION dbo.ContractPlaces;
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 04.09.2008
-- Description:	Возвращает список мест для данного договора
-- =============================================
--select dbo.ContractPlaces(6) 
CREATE FUNCTION dbo.ContractPlaces (@p1 int)
RETURNS Varchar(255)
AS
BEGIN

DECLARE @strPlaces varchar(255), @Place varchar(255)
SET @strPlaces=''

declare c_places CURSOR LOCAL   FOR 
SELECT DISTINCT pl.Number 
from 
	dbo.Contracts c JOIN 
	dbo.ContractRentalPlaces p ON c.Id=p.ContractId JOIN 
	dbo.RentalPlaces pl ON p.RentalPlaceId=pl.Id --AND p.DateFrom=c.DateFrom
WHERE c.Id=@p1
ORDER BY pl.Number

OPEN c_places

FETCH NEXT FROM c_places INTO @Place
WHILE @@FETCH_STATUS = 0
	begin
		SET @strPlaces=@strPlaces+', '+@Place
		FETCH NEXT FROM c_places INTO @Place
	end
close c_places
DEALLOCATE c_places

IF len(@strPlaces)>1 
	SET @strPlaces=substring(@strPlaces,2,255)

RETURN @strPlaces
END
GO



-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_ReplyScan', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_ReplyScan;
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 29.08.2008
-- Description:	Обработка ответов от 1С
-- =============================================
--exec dbo.Ex1C_ReplyScan
CREATE PROCEDURE dbo.Ex1C_ReplyScan
AS
BEGIN
SET NOCOUNT ON

--читаем путь до каталога обмена в GblSettings
declare @FolderName varchar(100)
SELECT @FolderName=KeyValue FROM dbo.GblSettings WHERE KeyName='Exchange1CPath'
IF @@ROWCOUNT<>1
	RAISERROR  ('В таблице dbo.GblSettings не найдена запись с KeyName=''Exchange1CPath''', 16,1)
IF RIGHT(@FolderName,1)='\' SET @FolderName =LEFT(@FolderName,Len(@FolderName)-1)
SET @FolderName=@FolderName+'\OUT'

--А есть ли такой каталог?

DECLARE @FSO INT, @Folder INT, @R INT
EXEC @R = sp_OACreate 'Scripting.FileSystemObject', @FSO OUT
EXEC @R = sp_OAMethod @FSO, 'GetFolder', @Folder OUT, @FolderName

IF @Folder IS NULL 
	RAISERROR  ('Не существует каталог %s', 16,1,@FolderName)
ELSE
    EXEC sp_OADestroy @Folder

EXEC sp_OADestroy @FSO

--Читаем список файлов ответов
DECLARE @str varchar(255)
DECLARE @FileList TABLE ([FileName] varchar(255))
SET @str='dir /b '+@FolderName+'\*.xml'
insert into @FileList EXEC xp_cmdshell @str;
DELETE from @FileList WHERE [FileName] IS NULL
SELECT @R=count(*) FROM @FileList WHERE UPPER([FileName]) LIKE '%.RES.XML'
IF @R=0
	RETURN	--нечего обрабатывать

--цикл по всем файлам ответов
declare c_file CURSOR LOCAL   FOR 
	select [FileName] FROM @FileList WHERE UPPER([FileName]) LIKE '%.RES.XML' ORDER BY substring([FileName],2,255)

DECLARE @FileName varchar(255)

OPEN c_file

FETCH NEXT FROM c_file INTO @FileName
WHILE @@FETCH_STATUS = 0
	begin
		EXEC dbo.Ex1C_ReplyService @FolderName, @FileName
		FETCH NEXT FROM c_file INTO @FileName
	end

close c_file
DEALLOCATE c_file

END
GO


-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_ReplyService', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_ReplyService;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 29.08.2008
-- Description:	Обработка одного файла ответа от 1С
-- =============================================
--EXEC dbo.Ex1C_ReplyService 'D:\1\IN', 'SP20080801_1_1.res.xml'
Create PROCEDURE dbo.Ex1C_ReplyService @FolderName varchar(255), @FileName varchar(255)
AS
BEGIN
declare @xml xml, @path varchar(255), @Level int
set @path = +@FolderName+'\'+@FileName
declare @sql nvarchar(4000)

set @sql = N'SET @xml = (SELECT * FROM OPENROWSET(BULK ''' + @path + ''', SINGLE_BLOB) AS fd)'


BEGIN TRY
	SELECT @Level=KeyValue FROM dbo.GblSettings WHERE KeyName='Exchange1CDebugMode'
	exec sp_executesql @sql, N'@xml xml out', @xml = @xml out
	DECLARE @IdDoc int
	EXEC sp_xml_preparedocument @IdDoc OUTPUT, @xml

	DECLARE @type varchar(20), @id int, @type1s	varchar(255), @code1s varchar(255), @code int, @Status varchar(255)

	SELECT @type=[type], @id=id, @type1s=type1s, @code1s=code1s FROM  OPENXML (@IdDoc, '/ImportResult/Object',1)
            WITH ([type] nvarchar(100), [id] int, [type1s] nvarchar(100), [code1s] nvarchar(100))
	SELECT @code=code FROM  OPENXML (@IdDoc, '/ImportResult/Status',1)
            WITH ([code] int)
	SELECT @Status=Status FROM  OPENXML (@IdDoc, '/ImportResult',2)
            WITH ([Object] nvarchar(255), [Status] nvarchar(255))
	exec sp_xml_removedocument @IdDoc
	IF @type NOT IN ('Contract','ServicePayment','RentalPayment','Act')
		BEGIN
			RAISERROR  ('Неизвестный тип объекта ''%s''', 16,1,@type)
		END

	IF @type='Contract'
		BEGIN
			UPDATE dbo.Contracts
			SET
				 Contract1SCode=@code1s
				,Status=CASE WHEN @code=0 THEN 3 ELSE 0 END
				,StatusMessage=@Status
				,StatusDatetime=getdate()
			WHERE Id=@id
			IF @@ROWCOUNT<>1
				RAISERROR  ('Нет контракта с Id=%d', 16,1,@id)
		END
	ELSE IF @type='ServicePayment'
		BEGIN
			UPDATE dbo.ServicePayments
			SET
				 Payment1SCode=@code1s
				,Status=CASE WHEN @code=0 THEN 3 ELSE 0 END
				,StatusMessage=@Status
				,StatusDatetime=getdate()
			WHERE Id=@id
			IF @@ROWCOUNT<>1
				RAISERROR  ('Нет платежа за доп.услуги с Id=%d', 16,1,@id)
		END
	ELSE IF @type='RentalPayment'
		BEGIN
			UPDATE dbo.RentalPayments
			SET
				 Payment1SCode=@code1s
				,Status=CASE WHEN @code=0 THEN 3 ELSE 0 END
				,StatusMessage=@Status
				,StatusDatetime=getdate()
			WHERE Id=@id
			IF @@ROWCOUNT<>1
				RAISERROR  ('Нет арендного платежа с Id=%d', 16,1,@id)
		END
	ELSE IF @type='Act'
		BEGIN
			UPDATE dbo.FactInvoices
			SET
				 FactInvoice1SCode=@code1s,
				 Status=CASE WHEN @code=0 THEN 3 ELSE 0 END
				,StatusMessage=@Status
				,StatusDatetime=getdate()
			WHERE Id=@id
			IF @@ROWCOUNT<>1
				RAISERROR  ('Нет контракта с Id=%d', 16,1,@id)
		END
	
	EXEC dbo.Ex1C_History @path, @Level, @code, @Status

--exec dbo.Ex1C_ReplyScan

--удаляем обработанный файл.
--SET @sql='delete '+@path
--	EXEC xp_cmdshell @sql;

	RETURN
END TRY

BEGIN CATCH
	DECLARE @err int, @errtext varchar(255)
	SET @err=ERROR_NUMBER()
	SET @errtext=ERROR_MESSAGE()
	EXEC dbo.Ex1C_History @path, @Level, @err, @errtext

	SET @sql='delete '+@path
	--EXEC xp_cmdshell @sql;

END CATCH;

END
GO

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_History', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_History;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 29.08.2008
-- Description:	Формирование записи в историю
-- =============================================
--exec dbo.Ex1C_History
CREATE PROCEDURE dbo.Ex1C_History @FileName varchar(100), @Level int, @errcode int, @err varchar(255)
AS
BEGIN
SET NOCOUNT ON

DECLARE @fso int,@ts int, @R int
DECLARE  @t table(id int IDENTITY, txt nvarchar(4000));

IF @errcode<>0 OR @Level=2
	BEGIN
		EXEC @R = sp_OACreate 'Scripting.FileSystemObject', @fso OUT
		EXEC @R = sp_OAMethod @fso, 'OpenTextFile', @ts out, @FileName
		insert INTO @t(txt)	EXEC @R =   sp_OAMethod @ts, 'ReadAll'
		EXEC sp_OAMethod @ts, 'Close'

		INSERT INTO dbo.Ex1CHistory
			([FileName], [Direction], [ServiceDate], [Content], [ErrCode],[ErrText])
		    SELECT 
			 FileName=@FileName
			,Direction='IN'
			,ServiceDate=getdate()
			,Content=txt
			,ErrCode=@errcode
			,ErrText=@err
		FROM @t
	END
END
GO

--------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_DocCreate', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_DocCreate;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anm
-- Create date: 29.08.2008
-- Description:	Формирование xml файлов экспорта в 1С
-- =============================================
--exec dbo.Ex1C_DocCreate 'RP',29
--Параметр @docType может принимать значения: 'Contract','RentalPayment','ServicePayment', 'Act'
CREATE PROCEDURE dbo.Ex1C_DocCreate @DocType varchar(100), @DocId int
AS
BEGIN
SET NOCOUNT ON

--проверяем тип документа
IF @DocType NOT IN ('AC','CT','RP','SP')
	BEGIN
		RAISERROR  ('Неизвестный тип документа %s', 16,1,@DocType)
		RETURN
	END

--читаем путь до каталога обмена в GblSettings
declare @FolderName varchar(100)

SELECT @FolderName=KeyValue FROM dbo.GblSettings WHERE KeyName='Exchange1CPath'

IF @@ROWCOUNT<>1
	BEGIN
		RAISERROR  ('В таблице dbo.GblSettings не найдена запись с KeyName=''Exchange1CPath''', 16,1)
		RETURN
	END

IF RIGHT(@FolderName,1)='\' SET @FolderName =LEFT(@FolderName,Len(@FolderName)-1)
SET @FolderName=@FolderName+'\IN'

--А есть ли такой каталог?

DECLARE @FSO INT, @Folder INT, @R INT, @File INT, @FileName varchar(255)
EXEC @R = sp_OACreate 'Scripting.FileSystemObject', @FSO OUT
EXEC @R = sp_OAMethod @FSO, 'GetFolder', @Folder OUT, @FolderName

IF @Folder IS NULL 
	BEGIN
		RAISERROR  ('Не существует каталог обмена с 1С %s', 16,1,@FolderName)
		RETURN
	END

--SELECT @Folder

EXEC sp_OADestroy @Folder

--UPDATE dbo.Ex1CFileNum SET FileName=FileName+1;
--UPDATE dbo.Ex1CFileNum SET FileName=REPLICATE ( '0',7-len(FileName))+FileName;

--Формируем имя файла экспорта
IF @DocType='AC' OR @DocType='CT'
	SELECT @FileName=@FolderName+'\'+@DocType+dbo.RussianDate(GetDate())+'_'+LTRIM(STR(@DocId))
ELSE IF @DocType='RP'
	SELECT @FileName=@FolderName+'\'+@DocType+dbo.RussianDate(GetDate())+'_'+LTRIM(STR(TerminalId))
			+'_'+LTRIM(STR(@DocId))
	FROM dbo.RentalPayments WHERE Id=@DocId
ELSE IF @DocType='SP'
	SELECT @FileName=@FolderName+'\'+@DocType+dbo.RussianDate(GetDate())+'_'+LTRIM(STR(TerminalId))
			+'_'+LTRIM(STR(@DocId))
	FROM dbo.ServicePayments WHERE Id=@DocId

SET @FileName=@FileName+'.XML' 

--SELECT @FileName

--Выполняем проверки и формирование документов
DECLARE @Xml varchar(8000)

IF @DocType='CT'	--Проверяем Контракт
	EXEC @R=dbo.Ex1C_DocCreate_CT @DocId, @Xml OUT
ELSE IF @DocType='RP'	--Проверяем платеж за аренду
	EXEC @R=dbo.Ex1C_DocCreate_RP @DocId, @Xml OUT
ELSE IF @DocType='SP'	--Проверяем платеж за дополнительные услуги
	EXEC @R=dbo.Ex1C_DocCreate_SP @DocId, @Xml OUT
ELSE IF @DocType='AC'	--Проверяем счет-фактуру
	EXEC @R=dbo.Ex1C_DocCreate_AC @DocId, @Xml OUT

IF @R<>0
	BEGIN
		RAISERROR  (@Xml, 16,1)
		RETURN
	END

--Формируем документ требуемого типа.

EXEC @R = sp_OAMethod @FSO, 'CreateTextFile', @File OUT, @FileName,1
IF @R <>0
	BEGIN
		RAISERROR  ('Ошибка создания файла для передачи в 1С %s', 16,1,@FileName)
		RETURN
	END
	
SET @xml='<?xml version="1.0" encoding="windows-1251"?> '+@xml
--SELECT @xml
EXEC @R = sp_OAMethod @File, 'Write',NULL, @xml
IF @R <>0
	BEGIN
		RAISERROR  ('Ошибка записи в файл для передачи в 1С %s', 16,1,@FileName)
		RETURN
	END
EXEC @R = sp_OAMethod @File, 'Close'

IF @R <>0
	BEGIN
		RAISERROR  ('Ошибка завершения записи в файл для передачи в 1С %s', 16,1,@FileName)
		RETURN
	END

EXEC sp_OADestroy @File
EXEC sp_OADestroy @FSO

IF @DocType='CT'	--Проверяем Контракт
	UPDATE dbo.Contracts SET Status=2, StatusDatetime=getdate() WHERE Id=@DocId
ELSE IF @DocType='RP'	--Проверяем платеж за аренду
	UPDATE dbo.RentalPayments SET Status=2, StatusDatetime=getdate() WHERE Id=@DocId
ELSE IF @DocType='SP'	--Проверяем платеж за дополнительные услуги
	UPDATE dbo.ServicePayments SET Status=2, StatusDatetime=getdate() WHERE Id=@DocId
ELSE IF @DocType='AC'	--Проверяем счет-фактуру
	UPDATE dbo.FactInvoices SET Status=2, StatusDatetime=getdate() WHERE Id=@DocId

IF (SELECT KeyValue FROM dbo.GblSettings WHERE KeyName='Exchange1CDebugMode')=2
	INSERT INTO dbo.Ex1CHistory 
		(FileName,Direction,ServiceDate,Content,ErrCode,ErrText)
	VALUES
		(@FileName, 'IN', getdate(), @Xml, 0, 'Ok')
RETURN 0

END
GO

------------------------------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_DocCreate_CT', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_DocCreate_CT;
GO

CREATE PROCEDURE  dbo.Ex1C_DocCreate_CT (@DocId int, @Str varchar(8000) OUT)
AS
BEGIN
--Выполняем проверки документа
DECLARE @Date datetime, @ContractId int,  @Amount money

DECLARE @ContractNumber varchar(255), @CrDateTime datetime, @CrUserId int
DECLARE @DateFrom datetime, @DateTo datetime, @IsCashless bit
DECLARE @CashlessPaymentControlDate datetime, @Client1SCode varchar(255)

DECLARE @ErrText varchar(255)
SET @ErrText=''

SELECT
	@ContractNumber=ContractNumber, 
	@CrDateTime=CrDateTime,
	@CrUserId=CrUserId,
	@DateFrom=DateFrom,
	@DateTo=DateTo,
	@IsCashless=IsCashless,
	@CashlessPaymentControlDate=CashlessPaymentControlDate,
	@Client1SCode=Client1SCode
FROM dbo.Contracts 
WHERE Id=@DocId

IF  @ContractNumber IS NULL OR len(@ContractNumber)<1
	SET @ErrText=@ErrText+'Не задан номер договора. '
IF @CrDateTime IS NULL OR @DateFrom IS NULL OR @DateTo IS null
	SET @ErrText=@ErrText+'Не определены даты создания и/иди срок действия  договора. '
IF @DateFrom>=@DateTo
	SET @ErrText=@ErrText+'Дата окончания должна быть позже даты начала договора. '
IF @IsCashless=1 AND @CashlessPaymentControlDate IS null
	SET @ErrText=@ErrText+'При разреш. безналичных расчетах, должна быть задана контрольная дата поступления платежа. '
IF @Client1SCode IS null
	SET @ErrText=@ErrText+'Не задан код клиента в системе 1С. '

IF len(@ErrText)>0
	BEGIN
		SET @Str=@ErrText
		RETURN 1
	END

--Формируем документ
	SET @Str=	(SELECT 
					 c.Id
					,Client1SCode=isnull(c.Client1SCode,'')
					,c.ContractNumber
					,c.RentalServiceId
					,c.ClientName
					,c.IsCashless
					,PlacePrice=CONVERT(Decimal(12,2),c.PlacePrice)
					,Places=dbo.ContractPlaces(c.Id)
					,CreationDate=dbo.RussianDate(c.CrDateTime)
					,DateFrom=dbo.RussianDate(c.DateFrom)
					,DateTo=dbo.RussianDate(c.DateTo)
					,DissolutionDate=dbo.RussianDate(c.DissolutionDate)
				FROM dbo.Contracts c
				WHERE c.Id=@DocId
				FOR xml raw('Contract')
				)
RETURN 0
END
GO

--------------------------------------------------------------------
IF OBJECT_ID('Ex1C_DocCreate_RP', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_DocCreate_RP;
GO


CREATE PROCEDURE  dbo.Ex1C_DocCreate_RP (@DocId int, @Str varchar(8000) OUT)
AS
BEGIN

--Выполняем проверки документа
DECLARE @TerminalId int, @ContractId int, @PaidSum money, @Price money, @DateTime datetime, @ShiftNumber int

DECLARE @ErrText varchar(255)
SET @ErrText=''

SELECT @TerminalId=TerminalId,
		@ContractId=ContractId,
		@PaidSum=PaidSum,
		@DateTime=[DateTime],
		@ShiftNumber=ShiftNumber
FROM dbo.RentalPayments WHERE Id=@DocId

IF @PaidSum IS NULL OR @PaidSum<=0.0
	SET @ErrText=@ErrText+'Сумма платежа должна быть >0.00. '
IF @TerminalId IS NULL
	SET @ErrText=@ErrText+'Не определен номер терминала '
IF  @ContractId IS NULL
	SET @ErrText=@ErrText+'Не определен договор аренды. '
IF @DateTime IS NULL
	SET @ErrText=@ErrText+'Не определена дата платежа. '
IF @ShiftNumber IS NULL
	SET @ErrText=@ErrText+'Не определен операционный день платежа (№ кассовой ленты). '

IF len(@ErrText)>0
	BEGIN
		SET @Str=@ErrText
		RETURN 1
	END
SET @Str=	(SELECT 
			 rp.[Id]
			,[DateTime]=dbo.RussianDate(rp.[DateTime])
			,rp.[ContractId]
			,rp.[TerminalId]
			,rp.[ContractPlaceId]
			,Client1SCode=isnull(c.Client1SCode,'')
			,[PaidSum]=CONVERT(Decimal(12,2),rp.[PaidSum])
			FROM [dbo].[RentalPayments] rp LEFT JOIN dbo.Contracts c ON c.Id=rp.ContractId
			WHERE rp.Id=@DocId
			FOR xml raw('RentalPayment')
			)

RETURN 0
END
GO

----------------------------------------------------------------------
IF OBJECT_ID('Ex1C_DocCreate_SP', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_DocCreate_SP;
GO



CREATE PROCEDURE  dbo.Ex1C_DocCreate_SP (@DocId int, @Str varchar(8000) OUT)
AS
BEGIN

--Выполняем проверки документа
DECLARE @TerminalId int, @PaidSum money, @Price money, @DateTime datetime, @ShiftNumber int

DECLARE @ErrText varchar(255)
SET @ErrText=''

SELECT @TerminalId=TerminalId,
		@Price=Price,
		@PaidSum=PaidSum,
		@DateTime=[DateTime],
		@ShiftNumber=ShiftNumber
FROM dbo.ServicePayments WHERE Id=@DocId
IF @PaidSum IS NULL OR @PaidSum<=0.0
	SET @ErrText=@ErrText+'Сумма платежа должна быть >0.00. '
IF @Price IS NULL OR @Price<=0.0
	SET @ErrText=@ErrText+'Цена услуги должна быть определена и >0.00. '
IF @TerminalId IS NULL
	SET @ErrText=@ErrText+'Не определен номер терминала '
IF @DateTime IS NULL
	SET @ErrText=@ErrText+'Не определена дата платежа. '
IF @ShiftNumber IS NULL
	SET @ErrText=@ErrText+'Не определен операционный день платежа (№ кассовой ленты). '

IF len(@ErrText)>0
	BEGIN
		SET @Str=@ErrText
		RETURN 1
	END

--Формируем документ требуемого типа.
	
SET @Str=	(SELECT 
			 sp.Id
			,[DateTime]=dbo.RussianDate(sp.[DateTime])
			,sp.TerminalId
			,[PaidSum]=CONVERT(Decimal(12,2),sp.[PaidSum])
			FROM [dbo].[ServicePayments] sp 
			WHERE sp.Id=@DocId
			FOR xml raw('ServicePayment')
			)
RETURN 0
END
GO

------------------------------------------------------------------------------
IF OBJECT_ID('Ex1C_DocCreate_AC', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Ex1C_DocCreate_AC;
GO


CREATE PROCEDURE  dbo.Ex1C_DocCreate_AC (@DocId int, @Str varchar(8000) OUT)
AS
BEGIN

--Выполняем проверки документа
DECLARE @Date datetime, @ContractId int, @DateFrom datetime, @DateTo datetime, @Amount money

DECLARE @ErrText varchar(255)
SET @ErrText=''

SELECT 
	@Date=[Date],
	@ContractId=ContractId,
	@DateFrom=DateFrom,
	@DateTo=DateTo,
	@Amount=[Amount]
FROM dbo.FactInvoices WHERE Id=@DocId
IF @Date IS NULL OR @DateFrom IS NULL OR @DateTo IS null
	SET @ErrText=@ErrText+'Не определены дата Счет-фактуры или период оказания услуг. '
IF @ContractId IS null
	SET @ErrText=@ErrText+'Не задан договор, по которому выпускается счет-фактура. '
IF @Amount IS NULL OR @Amount<=0.0
	SET @ErrText=@ErrText+'Сумма счет-фактуры должна быть >0.00. '

IF len(@ErrText)>0
	BEGIN
		SET @Str=@ErrText
		RETURN 1
	END

SET @Str=	(SELECT 
			 fi.[Id]
			,[Sum]=CONVERT(Decimal(12,2),fi.Amount)
			,[Date]=dbo.RussianDate(fi.[Date])
			,fi.[ContractId]
			,Client1SCode=isnull(c.Client1SCode,'')
			FROM dbo.FactInvoices fi LEFT JOIN dbo.Contracts c ON c.Id=fi.ContractId
			WHERE fi.Id=@DocId
			FOR xml raw('Act')
			)
RETURN 0
END
GO

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('tgiu_Contracts', 'TR') IS NOT NULL 
    DROP TRIGGER dbo.tgiu_Contracts;
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgiu_Contracts] ON [dbo].[Contracts]
FOR INSERT, UPDATE
AS

BEGIN
	declare @DocType varchar(100)
	declare @DocId int
	declare @ReturnCode int, @n int

	SET @DocType='CT'
	
	SELECT @n=count(1) FROM inserted WHERE Status=1

	IF @n >1
	BEGIN
		
		declare c_inserted CURSOR LOCAL FORWARD_ONLY  FOR 
			select i.Id from inserted i;

		OPEN c_inserted

		FETCH NEXT FROM c_inserted INTO @DocId
		WHILE @@FETCH_STATUS = 0
			begin
				exec dbo.Ex1C_DocCreate @DocType, @DocId
				FETCH NEXT FROM c_inserted INTO @DocId
			end

		close c_inserted
		deallocate c_inserted
	END

ELSE IF @n=1
	BEGIN

		select @DocId=i.Id from inserted i 	
		exec dbo.Ex1C_DocCreate @DocType, @DocId
	END

END

GO


-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('tgiu_FactInvoices', 'TR') IS NOT NULL 
    DROP TRIGGER dbo.tgiu_FactInvoices;
GO


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgiu_FactInvoices] ON [dbo].[FactInvoices]
FOR INSERT, UPDATE
AS

BEGIN
	declare @DocType varchar(100)
	declare @DocId int
	declare @ReturnCode int, @n int

	SET @DocType='AC'
	SELECT @n=count(1) FROM inserted WHERE Status=1

	IF @n >1
	BEGIN
		
		declare c_inserted CURSOR LOCAL FORWARD_ONLY  FOR 
			select i.Id from inserted i;

		OPEN c_inserted

		FETCH NEXT FROM c_inserted INTO @DocId
		WHILE @@FETCH_STATUS = 0
			begin
				exec dbo.Ex1C_DocCreate @DocType, @DocId
				FETCH NEXT FROM c_inserted INTO @DocId
			end

		close c_inserted
		deallocate c_inserted
	END

	ELSE IF @n=1
	BEGIN

		select @DocId=i.Id from inserted i 	
		exec dbo.Ex1C_DocCreate @DocType, @DocId
	END

END

GO

-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('tgiu_RentalPayments', 'TR') IS NOT NULL 
    DROP TRIGGER dbo.tgiu_RentalPayments;
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgiu_RentalPayments] ON [dbo].[RentalPayments]
FOR INSERT, UPDATE
AS

BEGIN
	declare @DocType varchar(100)
	declare @DocId int
	declare @ReturnCode int, @n int

	SET @DocType='RP'
	SELECT @n=count(1) FROM inserted WHERE Status=1

	IF @n >1
	BEGIN
		
		declare c_inserted CURSOR LOCAL FORWARD_ONLY  FOR 
			select i.Id from inserted i;

		OPEN c_inserted

		FETCH NEXT FROM c_inserted INTO @DocId
		WHILE @@FETCH_STATUS = 0
			begin
				exec dbo.Ex1C_DocCreate @DocType, @DocId
				FETCH NEXT FROM c_inserted INTO @DocId
			end

		close c_inserted
		deallocate c_inserted
	END

	ELSE IF @n=1
	BEGIN
		select @DocId=i.Id from inserted i 	
		exec dbo.Ex1C_DocCreate @DocType, @DocId
	END

END

GO


-----------------------------------------------------------------------------------------------------------
IF OBJECT_ID('tgiu_ServicePayments', 'TR') IS NOT NULL 
    DROP TRIGGER dbo.tgiu_ServicePayments;
GO
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgiu_ServicePayments] ON [dbo].[ServicePayments]
FOR INSERT, UPDATE
AS

BEGIN
	declare @DocType varchar(100)
	declare @DocId int
	declare @ReturnCode int, @n int

	SET @DocType='SP'
	SELECT @n=count(1) FROM inserted WHERE Status=1

	IF @n >1
	BEGIN
		
		declare c_inserted CURSOR LOCAL FORWARD_ONLY  FOR 
			select i.Id from inserted i;

		OPEN c_inserted

		FETCH NEXT FROM c_inserted INTO @DocId
		WHILE @@FETCH_STATUS = 0
			begin
				exec dbo.Ex1C_DocCreate @DocType, @DocId
				FETCH NEXT FROM c_inserted INTO @DocId
			end

		close c_inserted
		deallocate c_inserted
	END

	ELSE IF @n=1
	BEGIN

		select @DocId=i.Id from inserted i 	
		exec dbo.Ex1C_DocCreate @DocType, @DocId
	END

END

GO
