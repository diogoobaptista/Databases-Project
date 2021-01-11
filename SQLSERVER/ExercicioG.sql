USE SI2Trab1

GO

CREATE OR ALTER PROCEDURE AddNewNC
		@codigo_fat nvarchar(12)

AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED -- DOUBLE CHECK
	BEGIN TRANSACTION  
		BEGIN TRY
			IF EXISTS (SELECT * FROM Fatura WHERE codigo_fat = @codigo_fat AND estado ='Emitida')
			BEGIN
				DECLARE @codigo_nc nvarchar(12), @ano numeric(4)
				DECLARE @replace nvarchar(10)
				DECLARE @nr_nc numeric(5)
				SET @ano = YEAR(GETDATE()) -- ano atual
				SET @codigo_nc = [dbo].[getNextFatCod]('NC') -- NCyyyy-xxxxx
				SET @nr_nc = [dbo].[getNextNr]('NC',@codigo_nc,@ano) 
				INSERT INTO Codigo_NotaCred(ano, nr_nc) VALUES (@ano, @nr_nc);
				INSERT INTO Nota_Cred (codigo_nc, ano, nr_nc, dt_emissao, dt_criacao, val_nc, estado,codigo_fat) VALUES (@codigo_nc, @ano, @nr_nc, NULL, FORMAT(GETDATE(), 'yyyy-MM-dd HH:mm:ss'), NULL, 'Em Atualização', @codigo_fat)
			END
			ELSE RAISERROR('Fatura inexistente ou não emitida', 15, 1);
			COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO

--EXEC AddNewNC @ano = 2001, @nr_nc = 12344, @codigo_nc= 'NC2001-12344', @dt_emissao='2001-01-20 11:55:20', @dt_criacao='2001-01-20 10:50:40', @val_nc=34.2, @estado ='Emitida';

--SELECT * FROM Codigo_NotaCred;
--SELECT * FROM Nota_Cred;

--DROP PROCEDURE AddNewNC

--DELETE FROM Nota_Cred WHERE codigo_nc= 'NC2001-12344';
--DELETE FROM Codigo_NotaCred WHERE ano=2001 AND nr_nc=12344;
