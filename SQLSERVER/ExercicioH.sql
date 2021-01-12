USE SI2Trab1

GO

--DROP PROCEDURE AddItemsFat


CREATE OR ALTER PROCEDURE AddItemsFat
		@desc_item varchar(100),
		@desconto decimal(2,1),
		@num_uni numeric,
		@codigo_fat nvarchar(12),
		@sku varchar(25)
AS 
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRANSACTION 
		BEGIN TRY
		IF EXISTS (SELECT estado FROM Fatura WHERE codigo_fat = @codigo_fat AND estado = 'Em atualização')
		BEGIN
			IF ( @desc_item is null OR @desconto is null OR @num_uni is null OR @codigo_fat is null OR @sku is null)
				RAISERROR('Parametro a null', 15, 1);
			IF NOT EXISTS ( SELECT * FROM Produto WHERE desc_prod = @desc_item AND sku=@sku)
				RAISERROR('Produto inexistente', 15, 1);
			ELSE
			BEGIN
				DECLARE @num_item int
				IF NOT EXISTS(SELECT * FROM Item WHERE codigo_fat = @codigo_fat)
					SET @num_item=1
				ELSE
					SET @num_item = (SELECT (COUNT(codigo_fat)) FROM Item WHERE codigo_fat=@codigo_fat) 
				PRINT @num_item
				DECLARE @codigo_na_fat nvarchar(19), @sum_uni int, @id_item int
				BEGIN
					IF EXISTS ( SELECT * FROM Item WHERE num_item=@num_item AND sku=@sku AND codigo_fat =@codigo_fat)
					--IF(@id_item = @num_item AND @codigo_na_fat = @codigo_fat )
					BEGIN
						IF NOT EXISTS(SELECT * FROM Item WHERE codigo_fat = @codigo_fat)
							SET @sum_uni=@num_item
						ELSE
							SET @sum_uni =  ((SELECT num_uni FROM ITEM WHERE num_item=@num_item AND codigo_fat = @codigo_fat) + @num_uni)
						UPDATE Item
							SET num_item = @num_item, desc_item = @desc_item, desconto = @desconto, num_uni = @sum_uni, codigo_fat = @codigo_fat, sku=@sku
							WHERE num_item = @num_item AND codigo_fat = @codigo_fat AND sku= @sku;
					END
					ELSE
					BEGIN
						IF EXISTS(SELECT * FROM Item WHERE codigo_fat = @codigo_fat)
							SET @num_item = @num_item+1
						INSERT INTO Item (num_item, desc_item, desconto, num_uni, codigo_fat,sku) VALUES (@num_item, @desc_item, @desconto, @num_uni, @codigo_fat,@sku)
					END
					INSERT INTO Item_Hist(num_item,desc_item,desconto, num_uni, codigo_fat, sku) --atualizar o o historico da fatura
						VALUES (@num_item,@desc_item,@desconto,@num_uni,@codigo_fat,@sku)
				END
			END
		END
		ELSE RAISERROR('Fatura não está em atualização', 15, 1);
			COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO


