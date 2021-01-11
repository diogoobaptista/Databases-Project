USE SI2Trab1
GO

CREATE OR ALTER VIEW ResumoFat
AS
	SELECT codigo_fat,dt_criacao,dt_emissao,estado,val_total,val_iva,nome,Contribuinte.nif FROM Fatura INNER JOIN Contribuinte on Fatura.nif = Contribuinte.nif 

go
CREATE OR ALTER TRIGGER TriggerEstado ON ResumoFat
    instead of INSERT, DELETE, UPDATE            
AS
	IF UPDATE(estado)
		BEGIN
			PRINT 'Yes you can do that'
		END
	ELSE
		raiserror('Nope, you can only update estado',16,1)
	
go
/*
Update ResumoFat
	set ResumoFat.estado = 'ola'
	where ResumoFat.codigo_fat = 'FT2001-12344'

*/
--SELECT * FROM	ResumoFat
--drop view ResumoFat
--drop trigger TriggerEstado
