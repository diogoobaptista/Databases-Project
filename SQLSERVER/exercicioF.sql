USE SI2Trab1

GO

GO
CREATE OR ALTER FUNCTION getNextNr(@tipo_codigo nvarchar(2),@codigo nvarchar(12), @ano numeric(4))
RETURNS numeric(5)
AS
	BEGIN
		DECLARE @res TABLE  (   ---tabela para o ano e número da fatura em separado
				valor nvarchar(5))
		DECLARE @numero numeric(5)
		DECLARE @replace nvarchar(10)
		if(@tipo_codigo != 'FT' AND @tipo_codigo != 'NC')
		BEGIN 
			SET @numero = NULL
		END
		else
		BEGIN
			SET @replace = REPLACE ( @codigo , @tipo_codigo , '' ) -- tirar FT ficando apenas com yyyy-xxxxx
			insert into @res SELECT * FROM STRING_SPLIT (@replace,'-') -- colocar na tabela o ano numa linha e o number noutra
			SET @numero = (SELECT * FROM @res EXCEPT (SELECT TOP 1 valor FROM @res)) -- buscar o numero da fatura à tabela			
		END
		RETURN @numero --xxxxx
	END 
GO

GO
CREATE OR ALTER PROCEDURE p_criafatura
		@nif numeric(9),
		@nome nvarchar(50),
		@morada nvarchar(100)

AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED -- DOUBLE CHECK
	BEGIN TRANSACTION  
		BEGIN TRY	
			IF (@nif is null)
				PRINT('Missing NIF');
			ELSE
			BEGIN
				DECLARE @codigo_fat nvarchar(12)
				DECLARE @nr_ft numeric(5)
				DECLARE @ano numeric(4)
				DECLARE @dt_cr varchar (19)
				SET @ano = YEAR(GETDATE())
				SET @codigo_fat = [dbo].[getNextFatCod]('FT') -- FTyyyy-xxxxx
				SET @nr_ft = [dbo].[getNextNr]('FT',@codigo_fat,@ano) --buscar xxxxx
				SET @dt_cr = FORMAT(GETDATE(), 'yyyy-MM-dd HH:mm:ss') --buscar a data atual com o formato exigido
				IF NOT EXISTS ( SELECT * FROM Contribuinte WHERE nif = @nif)
				BEGIN
					INSERT INTO  Contribuinte(nif, nome, morada) VALUES (@nif,@nome,@morada)
				END
				INSERT INTO Codigo_Fatura(ano, nr_fat) VALUES(@ano,@nr_ft) 
				INSERT INTO Fatura(codigo_fat,ano ,nr_fat, dt_emissao, dt_criacao, val_total, val_iva, estado,nif) 
					VALUES(CONCAT('FT',@ano,'-',@nr_ft),@ano,@nr_ft,null,@dt_cr,null,null,'Em atualização',@nif)
				INSERT INTO Fatura_Hist(dt_atualizacao,ultimo_estado,dt_emissao, dt_criacao, val_total, val_iva, codigo_fat,nif) --atualizar o o historico da fatura
					VALUES (@dt_cr, 'Em atualização',null,@dt_cr,null,null,CONCAT('FT',@ano,'-',@nr_ft),@nif)
			END
		COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO
--DROP PROC p_criafatura
--EXEC p_criafatura @nif = 111222333, @nome= 'Inês', @morada ='Rua 121'
--SELECT * FROM Fatura;
--DELETE FROM Fatura WHERE codigo_fat='FT2020-12349'

--SELECT * FROM Codigo_Fatura;
--DELETE FROM Codigo_Fatura WHERE ano=2020  AND nr_fat=12349

--SELECT * FROM Contribuinte;
--DELETE FROM Contribuinte WHERE nif=111111111

--SELECT * FROM Fatura_Hist


