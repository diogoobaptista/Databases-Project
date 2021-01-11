USE SI2Trab1

GO

CREATE OR ALTER PROCEDURE AtualizarValorTotal
    @codigo_fat nvarchar(12)
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED -- DOUBLE CHECK
    BEGIN TRANSACTION
        BEGIN TRY
			IF EXISTS (SELECT estado FROM Fatura WHERE codigo_fat = @codigo_fat AND estado = 'Em atualização')
				BEGIN
					DECLARE @tabela1 TABLE (num_item int ,desc_item varchar(100), desconto decimal(2,1), num_uni numeric, codigo_fat nvarchar(12),sku varchar(25), desc_prod varchar(100),perc_iva int,preco_unit numeric(2) )
					INSERT INTO @tabela1 SELECT  num_item,desc_item,desconto,num_uni,codigo_fat,Item.sku,desc_prod,perc_iva,preco_unit
						FROM Item JOIN Produto ON Produto.sku = Item.sku  WHERE codigo_fat = @codigo_fat
					DECLARE @total_val numeric(4,2) = 0
					DECLARE @i int =1
					WHILE @i <= (SELECT TOP 1 num_item FROM @tabela1 ORDER BY num_item DESC )
						BEGIN
							DECLARE	@num_aux int=  (SELECT num_uni FROM @tabela1 WHERE num_item = @i)
							DECLARE @test_desc decimal(2,1) =(1- (SELECT desconto FROM @tabela1 WHERE num_item =@i))
							DECLARE @preco_aux numeric(4,2) = (SELECT preco_unit FROM @tabela1 WHERE num_item = @i) * @test_desc
							SET @preco_aux = @preco_aux * @num_aux
							SET @total_val = @total_val + @preco_aux
							SET @i = @i+1
						END
					UPDATE Fatura SET val_total = @total_val WHERE codigo_fat = @codigo_fat
					INSERT INTO Fatura_Hist(dt_atualizacao,ultimo_estado,dt_emissao, dt_criacao, val_total, val_iva, codigo_fat,nif) --atualizar o o historico da fatura
					VALUES (FORMAT(GETDATE(), 'yyyy-MM-dd HH:mm:ss'), 'Em atualização',null,(SELECT dt_criacao FROM Fatura WHERE codigo_fat = @codigo_fat),@total_val,null,@codigo_fat,(SELECT nif FROM Fatura WHERE codigo_fat = @codigo_fat))
				END
			ELSE RAISERROR('Fatura não está em atualização', 15, 1);
		COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO


--USE SI2Trab1
--select * FROM @tabela1

--Select * From Item;
--Select * From Fatura;
--Select * From Produto;
--Select * From Fatura_Hist;
--DROP PROCEDURE AtualizarValorTotal;


--SELECT * FROM Item WHERE  codigo_fat = 'FT2020-12348'