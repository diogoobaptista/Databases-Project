USE SI2Trab1

GO

GO
CREATE OR ALTER FUNCTION getNextFatCod(@tipo_codigo nvarchar(2))
RETURNS nvarchar(12) 
AS
	BEGIN
		DECLARE @numero numeric(5)
		DECLARE @data numeric(4) 
		DECLARE @retorno nvarchar(12) 
		if(@tipo_codigo != 'FT' AND @tipo_codigo != 'NC')
		BEGIN 
			SET @retorno = NULL
		END
		else
		BEGIN
			SET @data = YEAR(GETDATE())
			if(@tipo_codigo = 'FT')
			BEGIN
				IF exists (SELECT * FROM Codigo_Fatura WHERE ano=@data)
				BEGIN
					SET @numero = (SELECT TOP 1 nr_fat FROM Codigo_Fatura WHERE ano=@data ORDER BY nr_fat DESC)
					SET @numero = @numero + 1
				END
				ELSE 
					SET @numero = 11111					
			END
			if(@tipo_codigo = 'NC')
			BEGIN
				IF exists (SELECT * FROM Codigo_NotaCred WHERE ano=@data)
				BEGIN
					SET @numero = (SELECT TOP 1 nr_nc FROM Codigo_NotaCred WHERE ano=@data ORDER BY nr_nc DESC)
					SET @numero = @numero + 1
				END
				ELSE
					SET @numero = 11111
			END
		SET @retorno = CONCAT(@tipo_codigo,@data,'-',@numero)
		END
		RETURN @retorno
	END 
GO
--DROP function getNextFatCod


