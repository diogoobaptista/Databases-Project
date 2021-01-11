USE SI2Trab1

GO
CREATE OR ALTER PROCEDURE AtualizarEstadoFat
    @codigo_fat nvarchar(12),
	@novo_estado varchar(15)
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED -- DOUBLE CHECK
    BEGIN TRANSACTION
        BEGIN TRY
			IF EXISTS (SELECT estado FROM Fatura WHERE codigo_fat = @codigo_fat AND (estado = 'Em atualização' OR estado= 'Proforma'))
				BEGIN
					DECLARE @boolean bit = 0
					DECLARE @data nvarchar(19) = null
					SET @data = FORMAT(GETDATE(), 'yyyy-MM-dd HH:mm:ss')
				 	IF EXISTS((SELECT estado FROM Fatura WHERE codigo_fat = @codigo_fat AND estado= 'Proforma')) 
						AND (@novo_estado = 'Anulada' OR @novo_estado= 'Emitida')
							SET @boolean = 1
			
					IF EXISTS((SELECT estado FROM Fatura WHERE codigo_fat = @codigo_fat AND estado= 'Em Atualização'))
						SET @boolean = 1

					IF(@boolean = 1)
						BEGIN
							IF(@novo_estado = 'Emitida')	
								BEGIN
								INSERT INTO Fatura_Hist(dt_atualizacao,ultimo_estado,dt_emissao, dt_criacao, val_total, val_iva, codigo_fat,nif) --atualizar o o historico da fatura
									VALUES (@data,@novo_estado ,@data,(SELECT dt_criacao FROM Fatura WHERE codigo_fat = @codigo_fat),(SELECT val_total FROM Fatura WHERE codigo_fat = @codigo_fat),(SELECT val_iva FROM Fatura WHERE codigo_fat = @codigo_fat),@codigo_fat,(SELECT nif FROM Fatura WHERE codigo_fat = @codigo_fat))
								UPDATE Fatura SET estado = @novo_estado, dt_emissao= @data WHERE codigo_fat = @codigo_fat
								END
							ELSE
								BEGIN
									INSERT INTO Fatura_Hist(dt_atualizacao,ultimo_estado,dt_emissao, dt_criacao, val_total, val_iva, codigo_fat,nif) --atualizar o o historico da fatura
										VALUES (@data,@novo_estado ,(SELECT dt_criacao FROM Fatura WHERE codigo_fat = @codigo_fat),(SELECT dt_criacao FROM Fatura WHERE codigo_fat = @codigo_fat),(SELECT val_total FROM Fatura WHERE codigo_fat = @codigo_fat),(SELECT val_iva FROM Fatura WHERE codigo_fat = @codigo_fat),@codigo_fat,(SELECT nif FROM Fatura WHERE codigo_fat = @codigo_fat))
									UPDATE Fatura SET estado = @novo_estado WHERE codigo_fat = @codigo_fat
								END
						END
				END
			ELSE RAISERROR('Fatura inalterável', 15, 1);
	COMMIT;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			THROW;
		END CATCH
GO
