use p1g1

-- Stored procedures

go

CREATE PROCEDURE CONDOMINIUM.p_insertAviso (@ID_Predio int, @Data date, @Titulo varchar(25), @Descricao varchar(100) = null, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.Aviso (ID_Predio, Data, Titulo, Descricao) VALUES (@ID_Predio, @Data, @Titulo, @Descricao);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_InsertCondominoAviso (@ID_Aviso int, @CC char(9))
AS
BEGIN
	INSERT CONDOMINIUM.CONDOMINO_RECEBE_AVISO(ID_Aviso, CC) VALUES(@ID_Aviso, @CC);
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertPredio (@Nome varchar(50), @Latitude decimal(12,9), @Longitude decimal(12,9), @Morada varchar(100) = NULL, @Cidade varchar(25) = Null, @Codigo_Postal char(8) = NULL, @Area decimal(8,2) = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.Predio (Nome, Latitude, Longitude, Morada, Cidade, Codigo_Postal, Area) VALUES (@Nome, @Latitude, @Longitude, @Morada, @Cidade, @Codigo_Postal, @Area);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertFracao (@Area decimal(8,2), @Piso int, @Tipo varchar(25), @ID_Predio int, @Zona varchar(15) = NULL, @Quota decimal(19,2) = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.Fracao (Area, Piso, Tipo, ID_Predio, Zona, Quota) VALUES (@Area, @Piso, @Tipo, @ID_Predio, @Zona, @Quota);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertCondomino (@CC char(8), @Nome varchar(50), @NIF char(9), @e_mail varchar(50) = NULL)
AS
BEGIN
	Insert CONDOMINIUM.Condomino (CC, Nome, NIF, e_mail) VALUES (@CC, @Nome, @NIF, @e_mail);
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertNota (@ID_Predio int, @Data date, @Titulo varchar(25), @Descricao varchar(100) = null, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.Nota (ID_Predio, Data, Titulo, Descricao) VALUES (@ID_Predio, @Data, @Titulo, @Descricao);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertCompra (@ID_Fracao int, @CC_Condomino char(8), @Data_Compra date, @Data_Venda date = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.COMPRA (ID_Fracao, CC_Condomino, Data_compra, Data_venda) VALUES (@ID_Fracao, @CC_Condomino, @Data_compra, @Data_venda);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertItem (@Nome varchar(50), @Balanco decimal(19,2), @Orcamento_ID int)
AS
BEGIN
	INSERT CONDOMINIUM.Item (Nome, balanco, orcamento_ID) VALUES (@Nome, @Balanco, @Orcamento_ID);
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertManutencao (@ID_Predio int, @Data date, @Titulo varchar(25), @Descricao varchar(100) = NULL, @tipo varchar(25) = NULL, @Id_Outros_Pagamentos int = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.MANUTENCAO (ID_Predio, Data, Titulo, Descricao, tipo, Id_Outros_Pagamentos) VALUES (@ID_Predio, @Data, @Titulo, @Descricao, @tipo, @Id_Outros_Pagamentos);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertOrcamento (@ID_Predio int, @Data_Inicial date, @Data_Final date, @Titulo varchar(25), @Descricao varchar(100) = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.ORCAMENTO (ID_Predio, Data_Inicial, Data_Final, Titulo, Descricao) VALUES (@ID_Predio, @Data_Inicial, @Data_Final, @Titulo, @Descricao);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertOutrosPagamentos (@Data date, @suj_fiscal_nif char(9), @Balanco decimal(19,2), @ID_Predio int, @Descricao varchar(100) = NULL, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.OUTROS_PAGAMENTOS(Data, suj_fiscal_nif, Balanco, ID_Predio, Descricao) VALUES (@Data, @suj_fiscal_nif, @Balanco, @ID_Predio, @Descricao);
	SET @new_id = SCOPE_IDENTITY();
END


go

CREATE PROCEDURE CONDOMINIUM.p_insertPagamentoQuota  (@Mes date, @Data date, @Balanco decimal(19,2), @ID_Fracao int, @new_id int OUTPUT)
AS
BEGIN
	Insert CONDOMINIUM.PAGAMENTO_QUOTA(Mes, Data, Balanco, ID_Fracao) VALUES (@Mes, @Data, @Balanco, @ID_Fracao);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertReuniao (@ID_Predio int, @Data date, @Titulo varchar(25), @Descricao varchar(100) = NULL, @Ata varchar(1000) = NULL, @new_id int OUTPUT)
AS
BEGIN
	INSERT CONDOMINIUM.REUNIAO(ID_Predio, Data, Titulo, Descricao, Ata) VALUES (@ID_Predio, @Data, @Titulo, @Descricao, @Ata);
	SET @new_id = SCOPE_IDENTITY();
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertSujeitoFiscal (@NIF char(9), @Nome varchar(50), @e_mail varchar(50) = NULL, @Morada varchar(100) = NULL)
AS
BEGIN
	INSERT CONDOMINIUM.SUJEITO_FISCAL(NIF, Nome, e_mail, Morada) VALUES (@NIF, @Nome, @e_mail, @Morada);
END

go

CREATE PROCEDURE CONDOMINIUM.p_InsertCondominoReuniao (@ID_Reuniao int, @CC char(9))
AS
BEGIN
	INSERT CONDOMINIUM.CONDOMINO_PARTICIPA_REUNIAO(ID_Reuniao, CC) VALUES(@ID_Reuniao, @CC);
END


go

CREATE PROCEDURE CONDOMINIUM.p_updateCompra(@Data_compra date, @Data_venda date, @ID_Fracao int, @CC char(9), @ID int)
as
BEGIN
	UPDATE CONDOMINIUM.COMPRA SET Data_compra=@Data_compra, Data_venda=@Data_venda, ID_Fracao=@ID_Fracao, CC_Condomino=@CC
	WHERE ID=@ID;
END

go

CREATE PROCEDURE CONDOMINIUM.p_updateFracao(@ID int, @Area decimal(8,2), @Piso int, @Tipo varchar(25), @ID_Predio int, @Zona varchar(15) = NULL, @Quota decimal(19,2) = NULL)
AS
BEGIN
	UPDATE CONDOMINIUM.FRACAO SET Area=@Area, ID_Predio=@ID_Predio, Tipo=@Tipo, Piso=@Piso, Zona=@Zona, Quota=@Quota WHERE ID=@ID;
END

go

CREATE PROCEDURE CONDOMINIUM.p_deletePhotosOfFraction(@ID int)
AS
BEGIN
	DELETE CONDOMINIUM.FOTO_FRACAO WHERE ID_Fracao=@ID;
END

go

CREATE PROCEDURE CONDOMINIUM.p_savePhotoOfFracao(@ID int, @Localizacao_Ficheiro varchar(100))
AS
BEGIN
	INSERT CONDOMINIUM.FOTO_FRACAO (ID_Fracao, Localizacao_ficheiro) VALUES (@ID, @Localizacao_Ficheiro);
END

go

CREATE PROCEDURE CONDOMINIUM.p_deleteFraction(@ID int)
AS
BEGIN
	DELETE CONDOMINIUM.FRACAO WHERE ID=@ID;
END

go


CREATE PROCEDURE CONDOMINIUM.p_updatePredio (@Nome varchar(50), @Latitude decimal(12,9), @Longitude decimal(12,9), @ID int, @Morada varchar(100) = NULL, @Cidade varchar(25) = NULL, @Codigo_Postal char(8) = NULL, @Area decimal(8,2) = NULL)
AS
BEGIN
	UPDATE CONDOMINIUM.Predio SET Nome=@Nome, Latitude=@Latitude, @Longitude=@Longitude, Morada=@Morada, Cidade=@Cidade, Codigo_Postal=@Codigo_Postal, Area=@Area WHERE ID=@ID;
END

go

CREATE PROCEDURE CONDOMINIUM.p_deletePhotosPredio (@ID int)
as
BEGIN
	DELETE CONDOMINIUM.FOTOS_PREDIO WHERE ID=@ID;
END

go

CREATE PROCEDURE CONDOMINIUM.p_insertPhotosPredio(@ID int, @Localizacao_Ficheiro varchar(100))
AS
BEGIN
	INSERT CONDOMINIUM.FOTOS_PREDIO (ID, Localizacao_ficheiro) VALUES (@ID, @Localizacao_Ficheiro);
END

go

CREATE PROCEDURE CONDOMINIUM.p_deletePredio(@ID int)
AS
BEGIN
	DELETE CONDOMINIUM.PREDIO WHERE ID=@ID;
END
-- Queries
go

CREATE FUNCTION getAllSujeitosFiscais () RETURNS Table
AS
	RETURN(	SELECT *
			FROM CONDOMINIUM.SUJEITO_FISCAL);


go

CREATE FUNCTION getReunioesOfBuilding (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN ( SELECT *
             FROM CONDOMINIUM.REUNIAO
             WHERE ID_Predio=@ID_Predio AND DATA>=@InitialDate AND DATA<=@FinalDate);

go

CREATE FUNCTION getCondominosOnReunion (@ID int) RETURNS TABLE
AS
	RETURN(	 SELECT CC, Nome, E_mail, NIF
             FROM CONDOMINIUM.CONDOMINO
             WHERE CC IN (
				SELECT CC
				FROM CONDOMINIUM.CONDOMINO_PARTICIPA_REUNIAO
				WHERE ID_Reuniao=@ID)
			);

go

CREATE FUNCTION getQuotasOfBuilding (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN(	 SELECT Pagamento_quota.ID as PID, Data, Balanco, ID_Fracao, Mes, Piso, Zona, Quota, Area, Tipo, ID_Predio
             FROM CONDOMINIUM.PAGAMENTO_QUOTA JOIN CONDOMINIUM.FRACAO ON ID_FRACAO=FRACAO.ID
             WHERE DATA>=@InitialDate AND DATA<=@FinalDate AND ID_FRACAO IN (
				SELECT ID FROM CONDOMINIUM.FRACAO WHERE ID_PREDIO=@ID_Predio
                )
			);

go

CREATE FUNCTION getQuotasAtrasadasOfBuilding (@ID_Predio int, @Initial_Month date, @End_Month date) RETURNS Table
AS
	RETURN (SELECT COUNT(PAGMES.ID) AS QUOTES_ON_DAY, COUNT(*) AS ALL_QUOTES
            FROM CONDOMINIUM.Condomino JOIN (
            	SELECT *
            	FROM CONDOMINIUM.COMPRA
            	WHERE Data_Compra<=@Initial_Month) as C
            ON CC=CC_Condomino JOIN CONDOMINIUM.Fracao ON ID_Fracao=Fracao.ID LEFT OUTER JOIN (
				SELECT *
				FROM CONDOMINIUM.PAGAMENTO_QUOTA
				WHERE PAGAMENTO_QUOTA.Mes>@Initial_Month AND PAGAMENTO_QUOTA.Mes<=@End_Month
		        ) AS PAGMES ON PAGMES.ID_Fracao=FRACAO.ID
            WHERE ID_Predio=@ID_Predio AND Data_compra<CURRENT_TIMESTAMP AND (Data_venda IS NULL OR Data_venda>CURRENT_TIMESTAMP));

go

CREATE FUNCTION getOutrosPagamentos (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN (SELECT Outros_pagamentos.ID as OID, Data, Balanco, Descricao, NIF, Nome, E_mail, Morada
            FROM CONDOMINIUM.OUTROS_PAGAMENTOS JOIN CONDOMINIUM.SUJEITO_FISCAL ON NIF=suj_fiscal_nif
            WHERE ID_Predio=@ID_Predio AND Data>=@InitialDate AND Data<=@FinalDate
			);

go

CREATE FUNCTION getOrcamentoFromBuilding (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN(	SELECT *
			FROM CONDOMINIUM.ORCAMENTO
			WHERE DATA_INICIAL<=@FinalDate AND DATA_FINAL>=@InitialDate AND ID_Predio=@ID_Predio
			);

go

CREATE FUNCTION getItemsFromOrcamento (@ID int) RETURNS TABLE
AS
	RETURN(	SELECT nome, balanco
            FROM CONDOMINIUM.ITEM
            WHERE orcamento_ID=@ID
			);

go

CREATE FUNCTION getCondominosOnAlert (@ID int) RETURNS TABLE
AS
	RETURN(	SELECT CC, Nome, E_mail, NIF
            FROM CONDOMINIUM.CONDOMINO
            WHERE CC IN (	SELECT CC
				FROM CONDOMINIUM.CONDOMINO_RECEBE_AVISO
				WHERE ID_Aviso=@ID)
			);

go

CREATE FUNCTION getAllManutencoesAndPaymentsOfBuilding(@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN(
			SELECT Manutencao.ID as MID, Manutencao.Data as MData, 
					Titulo, Manutencao.Descricao As MDescricao, 
					tipo, Id_Outros_Pagamentos, OUTROS_PAGAMENTOS.Data as OData,
					Balanco, OUTROS_PAGAMENTOS.Descricao as ODescricao, NIF, Nome, e_mail, Morada
            FROM CONDOMINIUM.MANUTENCAO JOIN CONDOMINIUM.OUTROS_PAGAMENTOS ON Id_Outros_Pagamentos=OUTROS_PAGAMENTOS.ID JOIN CONDOMINIUM.SUJEITO_FISCAL ON suj_fiscal_nif=NIF
            WHERE MANUTENCAO.ID_Predio=@ID_Predio AND Manutencao.DATA>=@InitialDate AND Manutencao.DATA<=@FinalDate 
			
			UNION
			
			SELECT Manutencao.ID as MID, Manutencao.Data as MData, 
					Titulo, Manutencao.Descricao As MDescricao, 
		            tipo, NULL as ID_Outros_Pagamentos, NULL as OData, NULL as Balanco, NULL as ODescricao, NULL as NIF, NULL as Nome, NULL as e_mail, NULL as Morada
			FROM CONDOMINIUM.MANUTENCAO
			WHERE MANUTENCAO.ID_Predio=@ID_Predio AND MANUTENCAO.Id_Outros_Pagamentos IS NULL AND DATA>=@InitialDate AND DATA<=@FinalDate
			);

go

CREATE FUNCTION getAllCurrentCondominosFromBuilding(@ID_Predio int) RETURNS TABLE
AS
	RETURN(
			SELECT DISTINCT CC,Nome, NIF, E_mail
            FROM CONDOMINIUM.Condomino JOIN CONDOMINIUM.COMPRA ON CC=CC_Condomino JOIN CONDOMINIUM.Fracao ON ID_Fracao=Fracao.ID
            WHERE ID_Predio=@ID_Predio AND Data_compra<CURRENT_TIMESTAMP AND (Data_venda IS NULL OR Data_venda>CURRENT_TIMESTAMP)
			);

go

CREATE FUNCTION getAllCondominosFromBuilding(@ID_Predio int) RETURNS TABLE
as
	RETURN(
			SELECT DISTINCT CC,Nome, NIF, E_mail
            FROM CONDOMINIUM.Condomino JOIN CONDOMINIUM.COMPRA ON CC=CC_Condomino JOIN CONDOMINIUM.Fracao ON ID_Fracao=Fracao.ID
            WHERE ID_Predio=@ID_Predio
			);

go

CREATE FUNCTION getAllCondominos(@ID_Predio int) RETURNS TABLE
as
	RETURN(
			SELECT DISTINCT CC,Nome, NIF, E_mail
            FROM CONDOMINIUM.Condomino
			);

go

CREATE FUNCTION getNumberOfCurrentCondominos(@ID_Predio int) RETURNS int
as
BEGIN
	DECLARE @number int;
	SELECT @number=COUNT(*) FROM getAllCurrentCondominosFromBuilding(@ID_Predio);
	return @number;
END

go

CREATE FUNCTION getCurrentCondomino(@ID int) RETURNS TABLE
AS
	RETURN(	SELECT CC, Nome, e_mail, NIF
            FROM CONDOMINIUM.CONDOMINO JOIN CONDOMINIUM.COMPRA ON CC = CC_CONDOMINO JOIN CONDOMINIUM.FRACAO ON ID_FRACAO = FRACAO.ID
            WHERE Fracao.ID = @ID AND Data_compra <= CURRENT_TIMESTAMP AND(Data_venda IS NULL OR Data_venda >= CURRENT_TIMESTAMP)
			);

go

CREATE FUNCTION getCondominoBetweenDates(@ID int, @StartDate date, @EndDate date = NULL) RETURNS TABLE
AS
	RETURN(	SELECT CC, Nome, e_mail, NIF
            FROM CONDOMINIUM.CONDOMINO JOIN CONDOMINIUM.COMPRA ON CC = CC_CONDOMINO JOIN CONDOMINIUM.FRACAO ON ID_FRACAO = FRACAO.ID
            WHERE Fracao.ID = @ID AND ((@EndDate IS NULL AND Data_venda IS NULL) OR 
										(Data_venda IS NULL AND @EndDate>=Data_compra) OR
										(@EndDate IS NULL AND @StartDate<=Data_venda) OR
										(@StartDate<=Data_venda AND @EndDate>= Data_compra))
			);

go

CREATE FUNCTION getFractionsOfCondomino(@CC char(9), @ID_Predio int) RETURNS TABLE
AS
	RETURN(	SELECT Fracao.ID as ID, Piso, Zona, Quota, Area, Tipo, Fracao.ID_Predio as ID_Predio
			FROM CONDOMINIUM.CONDOMINO JOIN CONDOMINIUM.COMPRA ON CC = CC_CONDOMINO JOIN CONDOMINIUM.FRACAO ON ID_FRACAO = FRACAO.ID
            WHERE Condomino.CC = @CC AND ID_Predio=@ID_Predio AND Data_compra < CURRENT_TIMESTAMP AND(Data_venda IS NULL OR Data_venda > CURRENT_TIMESTAMP)
			);

go

CREATE FUNCTION getAllComprasOfFraction(@ID int) RETURNS TABLE
AS
	RETURN(	SELECT CC, Nome, e_mail, NIF, Data_compra, Data_venda, Compra.ID as ID
            FROM CONDOMINIUM.CONDOMINO JOIN CONDOMINIUM.COMPRA ON CC = CC_CONDOMINO JOIN CONDOMINIUM.FRACAO ON ID_FRACAO = FRACAO.ID
            WHERE Fracao.ID = @ID
			);

go

CREATE FUNCTION getImagesFromFraction(@ID int) RETURNS TABLE
AS
	RETURN(SELECT * FROM CONDOMINIUM.FOTO_FRACAO WHERE ID_Fracao=@ID);

go

CREATE FUNCTION getCompraDate (@ID_Fracao int) RETURNS TABLE
AS
	RETURN(	SELECT Compra.Data_compra as date
			FROM CONDOMINIUM.COMPRA JOIN CONDOMINIUM.FRACAO ON ID_FRACAO = @Id_Fracao
			WHERE Fracao.ID = @ID_Fracao AND Data_compra < CURRENT_TIMESTAMP AND(Data_venda IS NULL OR Data_venda > CURRENT_TIMESTAMP));

go

CREATE FUNCTION getLastQuota(@ID_Fracao int) RETURNS TABLE
AS
	RETURN(	SELECT TOP 1 mes
			FROM CONDOMINIUM.Fracao JOIN CONDOMINIUM.PAGAMENTO_QUOTA ON ID_Fracao=Fracao.ID
            WHERE Fracao.ID=@ID_Fracao
            ORDER BY mes DESC);

go


CREATE FUNCTION getAllFractionsFromPredio(@ID_Predio int) RETURNS TABLE
AS
	RETURN(	SELECT * FROM CONDOMINIUM.Fracao WHERE ID_Predio=@ID_Predio);

go

CREATE FUNCTION countFractionByType(@ID_Predio int, @Tipo varchar(25)) RETURNS int
AS
BEGIN
	DECLARE @fractions int;
	SELECT @fractions=COUNT(ID) FROM CONDOMINIUM.Fracao WHERE ID_Predio=@ID_Predio AND Tipo=@Tipo;
	RETURN @fractions;
END

go

CREATE FUNCTION getFractionByID (@ID int) RETURNS TABLE
AS
	RETURN(SELECT * FROM CONDOMINIUM.Fracao WHERE ID=@ID);

go

CREATE FUNCTION getAllBuildings() RETURNS TABLE
AS
	RETURN(SELECT * FROM CONDOMINIUM.PREDIO);

go

CREATE FUNCTION getImagesFromPredio(@ID_PREDIO int) RETURNS TABLE
AS
	RETURN(SELECT * FROM CONDOMINIUM.FOTOS_PREDIO WHERE ID=@ID_PREDIO);

go

CREATE FUNCTION getCurrentCondominosQuotasAndFracoes(@ID_Predio int, @dtstart date, @dtend date) RETURNS TABLE
AS
	RETURN(
			SELECT Fracao.ID as ID, CC,Nome, NIF, E_mail, mes, Area, Tipo, Zona, Fracao.ID_Predio as ID_Predio, Piso, Quota, Data_Compra
            FROM CONDOMINIUM.Condomino JOIN CONDOMINIUM.COMPRA ON CC=CC_Condomino 
            	JOIN CONDOMINIUM.Fracao ON ID_Fracao=Fracao.ID LEFT OUTER JOIN (
				
					SELECT mes, ID_Fracao
					FROM CONDOMINIUM.PAGAMENTO_QUOTA
					WHERE mes>@dtstart AND Mes<=@dtend
				) as PAG ON PAG.ID_Fracao = Fracao.ID
			WHERE ID_Predio=@ID_Predio AND Data_compra<CURRENT_TIMESTAMP AND (Data_venda IS NULL OR Data_venda>CURRENT_TIMESTAMP));

go

CREATE FUNCTION getAllQuotasWithinYear(@Predio_ID int, @dtstart date, @dtend date) RETURNS TABLE
AS
	RETURN(	SELECT Mes, Fracao.ID as ID, Piso, Zona, Quota, Area, Tipo, Fracao.ID_Predio as ID_Predio, Nome, Data_compra, Data_venda
			FROM (SELECT Mes, ID_Fracao FROM CONDOMINIUM.PAGAMENTO_QUOTA WHERE Mes>=@dtstart AND Mes<=@dtend) as PAG RIGHT OUTER JOIN 
			CONDOMINIUM.FRACAO ON PAG.ID_Fracao=Fracao.ID LEFT OUTER JOIN 
				(SELECT data_venda, Data_compra, ID_Fracao, CC_Condomino FROM CONDOMINIUM.COMPRA 
				WHERE Data_venda IS NULL AND Data_compra<=@dtend ) as COMP 
				ON COMP.ID_Fracao=Fracao.ID LEFT OUTER JOIN CONDOMINIUM.Condomino ON CC=CC_Condomino 
			WHERE FRACAO.ID_Predio=@Predio_ID);

go

CREATE FUNCTION getNextEvents(@ID_Predio int) RETURNS TABLE
AS
	RETURN(
			SELECT *
            FROM
            (	(
				SELECT ID, Data, Titulo 
				FROM CONDOMINIUM.REUNIAO 
				WHERE ID_Predio=@ID_Predio AND CURRENT_TIMESTAMP<Data)
			UNION
				( SELECT ID, Data, Titulo 
				FROM CONDOMINIUM.NOTA
				WHERE ID_Predio=@ID_Predio AND CURRENT_TIMESTAMP<Data)
			UNION
				( SELECT ID, Data, Titulo 
				FROM CONDOMINIUM.AVISO 
				WHERE ID_Predio=@ID_Predio AND CURRENT_TIMESTAMP<Data)
			UNION
				( SELECT ID, Data, Titulo 
				FROM CONDOMINIUM.MANUTENCAO 
				WHERE ID_Predio=@ID_Predio AND CURRENT_TIMESTAMP<Data)
				) AS Q1);

go

CREATE FUNCTION getDayEvents(@ID_Predio int, @Date date) RETURNS TABLE
AS
	RETURN(
			SELECT *
			FROM
			(    (
					SELECT ID, Data, Titulo 
					FROM CONDOMINIUM.REUNIAO 
					WHERE ID_Predio=@ID_Predio AND @Date=Data)
				UNION
					( SELECT ID, Data, Titulo 
					FROM CONDOMINIUM.NOTA
					WHERE ID_Predio=@ID_Predio AND @Date=Data)
				UNION
					( SELECT ID, Data, Titulo 
					FROM CONDOMINIUM.AVISO 
					WHERE ID_Predio=@ID_Predio AND @Date=Data)
				UNION
					( SELECT ID, Data, Titulo 
					FROM CONDOMINIUM.MANUTENCAO 
					WHERE ID_Predio=@ID_Predio AND @Date=Data)
					) AS Q1);

go

CREATE FUNCTION getBuildingTransactions (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS TABLE
AS
	RETURN(	SELECT Data, Balanco
			FROM (
				(SELECT Data, Balanco
				FROM CONDOMINIUM.OUTROS_PAGAMENTOS 
				WHERE ID_Predio=@ID_Predio AND Data>=@InitialDate AND Data<=@FinalDate)
			UNION
				(SELECT Data, Balanco
				FROM CONDOMINIUM.PAGAMENTO_QUOTA
				WHERE DATA>=@InitialDate AND DATA<=@FinalDate AND ID_FRACAO IN (
					SELECT ID FROM CONDOMINIUM.FRACAO WHERE ID_PREDIO=@ID_Predio
					)
				)
			) AS all_payments);

go

CREATE FUNCTION getSumTransactions (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS DECIMAL(19,2)
AS
BEGIN
	DECLARE @SUMTR DECIMAL(19,2);
	SET @SUMTR = 0;
	SELECT @SUMTR = SUM(pa_sum)
    FROM (
		(
			SELECT SUM(Balanco) as pa_sum 
        	FROM CONDOMINIUM.OUTROS_PAGAMENTOS 
        	WHERE ID_Predio=@ID_Predio AND Data>=@InitialDate AND Data<=@FinalDate)
        UNION
        (
        	SELECT SUM(Balanco) as pa_sum 
        	FROM CONDOMINIUM.PAGAMENTO_QUOTA
        	WHERE DATA>=@InitialDate AND DATA<=@FinalDate AND ID_FRACAO IN (
				SELECT ID FROM CONDOMINIUM.FRACAO WHERE ID_PREDIO=@ID_Predio
			)
        )
	) AS all_payments;
	RETURN @SUMTR;
END

go

CREATE FUNCTION getSumReceita (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS DECIMAL(19,2)
AS
BEGIN
	DECLARE @SUMRE DECIMAL(19,2);
	SET @SUMRE = 0;
	SELECT @SUMRE=SUM(pa_sum)
    FROM (
		(SELECT SUM(Balanco) as pa_sum 
		FROM CONDOMINIUM.OUTROS_PAGAMENTOS 
        WHERE ID_Predio=@ID_Predio AND Data>=@InitialDate AND Data<=@FinalDate AND Balanco>0)
        UNION
        (SELECT SUM(Balanco) as pa_sum 
        FROM CONDOMINIUM.PAGAMENTO_QUOTA
        WHERE DATA>=@InitialDate AND DATA<=@FinalDate AND ID_FRACAO IN (
			SELECT ID FROM CONDOMINIUM.FRACAO WHERE ID_PREDIO=@ID_Predio
            ) AND Balanco>0 
        )
	) AS all_payments
	RETURN @SUMRE;
END

go

CREATE FUNCTION getSumDespesa (@ID_Predio int, @InitialDate date, @FinalDate date) RETURNS DECIMAL(19,2)
AS
BEGIN
	DECLARE @SUMDES DECIMAL(19,2);
	SET @SUMDES = 0;
	SELECT @SUMDES=SUM(pa_sum)
    FROM (
		(SELECT SUM(Balanco) as pa_sum 
		FROM CONDOMINIUM.OUTROS_PAGAMENTOS 
        WHERE ID_Predio=@ID_Predio AND Data>=@InitialDate AND Data<=@FinalDate AND Balanco<0)
        UNION
        (SELECT SUM(Balanco) as pa_sum 
        FROM CONDOMINIUM.PAGAMENTO_QUOTA
        WHERE DATA>=@InitialDate AND DATA<=@FinalDate  AND ID_FRACAO IN (
			SELECT ID FROM CONDOMINIUM.FRACAO WHERE ID_PREDIO=@ID_Predio
            ) AND Balanco<0
        )
	) AS all_payments
	RETURN @SUMDES;
END