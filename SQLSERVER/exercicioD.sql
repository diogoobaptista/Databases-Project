
USE SI2Trab1

GO
-------------------------------INSERIR INFO DE UM PRODUTO-------------------------------

CREATE OR ALTER PROCEDURE AddNewProduct
	@sku varchar(25),
	@desc_prod varchar(100),
	@perc_iva int,
	@preco_unit numeric(2)
	

AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED -- DOUBLE CHECK
	BEGIN TRANSACTION  
		BEGIN TRY
			IF (@sku is null OR @desc_prod is null OR @perc_iva is null OR @preco_unit is null)
				RAISERROR('Missing parameters', 15, 1);
			INSERT INTO Produto (sku, desc_prod, perc_iva, preco_unit) VALUES (@sku, @desc_prod, @perc_iva, @preco_unit);
			COMMIT;
		END TRY
		BEGIN CATCH 
			ROLLBACK;
			THROW;
		END CATCH
GO

--EXEC AddNewProduct @sku = '789789', @desc_prod = 'chocolate', @perc_iva = 23, @preco_unit = 5.99;

--SELECT * FROM Produto WHERE sku = '789789';
--DROP PROCEDURE AddNewProduct;
--DELETE FROM Produto WHERE sku = '789789';

-------------------------------Editar info de um produto-------------------------------

CREATE OR ALTER PROCEDURE EditNewProduct
		@sku varchar(25),
		@desc_prod varchar(100),
		@perc_iva int,
		@preco_unit numeric(2)
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
	BEGIN TRANSACTION 
		BEGIN TRY
			IF (@sku is null OR @desc_prod is null OR @perc_iva is null OR @preco_unit is null)
				RAISERROR('Missing parameters', 15, 1);
			IF NOT EXISTS (SELECT * FROM Produto WHERE sku=@sku)
				RAISERROR('That product type doesn''t exist', 15, 1);
			UPDATE Produto
				SET desc_prod = @desc_prod, perc_iva = @perc_iva, preco_unit = @preco_unit
				WHERE sku = @sku;
			COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO

--EXEC EditNewProduct @sku= '321321', @desc_prod =3, @perc_iva = 23, @preco_unit = 45;
--SELECT * FROM Produto WHERE sku = '321321';
--update Produto SET preco_unit= 1.5 where sku = '321321'
--DROP PROCEDURE EditNewProduct;

-------------------------------Remover um produto-------------------------------
GO
	CREATE OR ALTER PROCEDURE RemoveProduct
		@sku varchar(25)
AS 
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
BEGIN TRANSACTION 
	BEGIN TRY 
		IF(@sku is null) 
			RAISERROR('Missing sku parameter', 15,1);
		IF EXISTS (SELECT * FROM Item WHERE sku=@sku)
			PRINT('Produto is used on Itens');
		ELSE
			DELETE FROM Produto WHERE sku = @sku;
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW;
	END CATCH
GO


--EXEC RemoveProduct @sku = '321321';
--SELECT * FROM Produto WHERE sku = '321321';
--DROP PROCEDURE RemoveProduct;
		

