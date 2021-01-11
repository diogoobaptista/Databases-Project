USE SI2Trab1

GO

CREATE OR ALTER FUNCTION ListOfNotaCred(@ano numeric(4))
RETURNS @ret TABLE (
        codigo_nc nvarchar(12),
        ano numeric(4),
        nr_nc numeric(5),
        dt_emissao datetime,
        dt_criacao datetime,
        val_nc numeric(6,2),
        estado varchar(15),
		codigo_fat nvarchar(12)
)
AS
BEGIN
    insert into @ret select * from Nota_Cred where ano=@ano
    RETURN
END

GO

--select * from ListOfNotaCred(2001)
--drop function ListOfNotaCred

