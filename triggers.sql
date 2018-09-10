
-- Triggers

use p1g1;

CREATE TRIGGER t_insertPagamentoQuota ON CONDOMINIUM.PAGAMENTO_QUOTA
AFTER INSERT, UPDATE
AS
BEGIN
	Declare @ID_Fracao int;
	Declare @LastQuotaMes date;
	Declare @CompraMes date;
	Declare @MonthQuota date;
	Declare @MonthInserted date;
	Declare @QuotaInserted decimal(19,2);
	Declare @QuotaFracao decimal(19,2);

	SELECT @ID_Fracao = ID_Fracao, @MonthInserted = Mes, @QuotaInserted = Balanco FROM inserted;

	SELECT @LastQuotaMes = mes FROM getLastQuota(@ID_Fracao);
	SELECT @CompraMes = date FROM getCompraDate(@ID_Fracao);
	

	-- Condomino must EXIST
	IF NOT EXISTS(SELECT * FROM getCurrentCondomino(@ID_Fracao))
	BEGIN
		ROLLBACK TRAN;
		RAISERROR('Fração não possui condómino!', 16, 1);
	END

	-- Get Month to pay quota
	IF @LastQuotaMes>@CompraMes
		SET @MonthQuota = @LastQuotaMes;
	ELSE
		SET @MonthQuota = @CompraMes;

	-- Check if month is valid
	IF YEAR(@MonthQuota) != YEAR(@MonthInserted) OR MONTH(@MonthQuota) != MONTH(@MonthInserted)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR('Mês inserido inválido. Não foram pagas quotas anteriores, ou o mês inserido é anterior à data de compra da fração.', 16, 1);
	END
	
	-- Check if quota is correct
	SELECT @QuotaFracao = Quota FROM getFractionByID(@ID_Fracao);

	IF @QuotaFracao IS NOT NULL AND @QuotaFracao != @QuotaInserted
	BEGIN
		ROLLBACK TRAN;
		RAISERROR('Quota não corresponde ao valor definido na fração.', 16, 1);
	END


END

go


CREATE TRIGGER t_insertCompra ON CONDOMINIUM.COMPRA
AFTER INSERT, UPDATE
AS
BEGIN

	DECLARE @ID_Fracao int;
	DECLARE @CC char(9);
	DECLARE @CondominoNumber int;
	DECLARE @Data_Compra date;
	DECLARE @Data_venda date;

	SELECT @ID_Fracao = ID_Fracao FROM INSERTED;
	SELECT @Data_Compra = Data_compra FROM INSERTED;
	SELECT @Data_venda = Data_venda FROM INSERTED;

	SELECT @CondominoNumber = COUNT(*) FROM getCondominoBetweenDates(@ID_Fracao, @Data_Compra, @Data_venda);

	-- If we made a buy and it already exists one condomino (after the insertion, the number of condominos is two or more)
	IF EXISTS(SELECT Data_compra FROM inserted) AND @CondominoNumber>1
	BEGIN
		ROLLBACK TRAN;
		RAISERROR('Compra inválida. Existe atualmente um condómino que possui a fração. Para efetuar a compra, efetue a venda do condómino atual antes.', 16, 1);
	END
	

END

