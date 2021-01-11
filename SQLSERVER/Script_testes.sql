USE SI2Trab1

GO
-----------------------------SCRIPT DE TESTES-----------------------------

------------- TESTE EXERCICIO D -------------
DECLARE @sku varchar(25)
DECLARE @nif nvarchar(12) ,@nome nvarchar(50),@morada nvarchar(100), @novo_estado nvarchar(12)
DECLARE @desc_item varchar(100),@desconto decimal(2,1),@num_uni numeric,@codigo_fat nvarchar(12)

PRINT 'TESTE DO EXERCICIO D'
PRINT 'INSERIR NOVO PRODUTO'
BEGIN TRANSACTION
	EXEC AddNewProduct @sku = '789789', @desc_prod = 'chocolate', @perc_iva = 23, @preco_unit = 5.99;
	SET @sku = (SELECT sku FROM Produto WHERE sku = '789789')
	if (@sku = '789789' )
		print 'OK: ADDED NEW PRODUCT'
	else
		print 'NOK: NO PRODUCT WAS INSERT'
ROLLBACK
PRINT '-----------------------------'

PRINT 'EDITAR NOVO PRODUTO'
BEGIN TRANSACTION
	EXEC EditNewProduct @sku= '321321', @desc_prod =3, @perc_iva = 23, @preco_unit = 45;
	SET @sku = (SELECT sku FROM Produto WHERE sku = '321321')
	if (@sku = '321321' )
		print 'OK: PRODUCT EDITED'
	else
		print 'NOK: NO PRODUCT EDITED'
ROLLBACK
PRINT '-----------------------------'

PRINT 'REMOVER PRODUTO'
BEGIN TRANSACTION
	EXEC RemoveProduct @sku= '321457';
	if NOT EXISTS (SELECT * FROM Produto WHERE sku = '321457' )
		print 'OK: PRODUCT REMOVED'
	else
		print 'NOK: NO PRODUCT REMOVED'
ROLLBACK
PRINT '-----------------------------'

PRINT 'REMOVER PRODUTO QUE EXISTE NOS ITENS '
BEGIN TRANSACTION
	EXEC RemoveProduct @sku= '321456';
	if EXISTS (SELECT * FROM Produto WHERE sku = '321456' )
		print 'OK:  NO PRODUCT REMOVED'
	else
	BEGIN
		print 'NOK:PRODUCT REMOVED'
	END
ROLLBACK


------------- TESTE EXERCICIO E -------------
PRINT 'TESTE DO EXERCICIO E' ;
declare @numero nvarchar(12) PRINT ''
PRINT 'Proxima Fatura'
BEGIN TRANSACTION
	EXEC @numero = getNextFatCod @tipo_codigo='FT'
	PRINT @numero
	if( @numero = 'FT2020-11111' ) 
		PRINT 'OK:Next number is the->FT2020-11111'
	else
		PRINT 'NOK:Next number is not the->FT2020-11111'

ROLLBACK
PRINT '-----------------------------'
BEGIN TRANSACTION
	PRINT 'Próxima Nota de Credito'
	EXEC @numero = getNextFatCod @tipo_codigo='NC'
	if( @numero = 'NC2020-11111' ) 
		PRINT 'OK:Next number is the->NC2020-11111'
	else
		PRINT 'NOK:Next number is not the->NC2020-11111'

ROLLBACK
PRINT '-----------------------------'
BEGIN TRANSACTION
	PRINT 'Testar que apenas se pode ser passado NC ou FT'
	EXEC @numero = getNextFatCod @tipo_codigo='aa'
	if( @numero IS NULL ) 
		PRINT 'OK:Next number is the->NULL'
	else
		PRINT 'NOK:Next number is not the->NOT NULL'

ROLLBACK

------------- TESTE EXERCICIO F -------------
PRINT 'TESTE DO EXERCICIO F' ;
PRINT '-----------------------------'
PRINT 'Criar Fatura'
BEGIN TRANSACTION
	EXEC p_criafatura @nif = 111222333, @nome= 'Inês', @morada ='Rua 121'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Fatura_Hist WHERE codigo_fat='FT2020-11111') AND EXISTS (SELECT * FROM Contribuinte WHERE nif=111222333)
		PRINT 'OK:Fatura FT2020-11111 was created'
	else
		PRINT 'NOK:Fatura FT2020-11111 was not created'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Criar Fatura para nif que nao existe em sistema'
BEGIN TRANSACTION
	EXEC p_criafatura @nif = 111222000, @nome= 'abx', @morada ='Rua '
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Fatura_Hist WHERE codigo_fat='FT2020-11111') AND EXISTS (SELECT * FROM Contribuinte WHERE nif=111222333)
		PRINT 'OK:Fatura FT2020-11111 was created because and was added the nif'
	else
		PRINT 'NOK:Fatura FT2020-11111 was not created'

ROLLBACK

PRINT '-----------------------------'
PRINT 'Criar Fatura e não dar o nif'
BEGIN TRANSACTION
	EXEC p_criafatura @nif = null, @nome= 'abx', @morada ='Rua '
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Fatura_Hist WHERE codigo_fat='FT2020-11111') AND EXISTS (SELECT * FROM Contribuinte WHERE nif=111222333)
		PRINT 'NOK:Fatura FT2020-11111 was created '
	else
		PRINT 'OK:Fatura FT2020-11111 was not created'

ROLLBACK


------------- TESTE EXERCICIO G -------------
PRINT 'TESTE DO EXERCICIO G' ;
PRINT '-----------------------------'
PRINT 'Criar Nota Crédito'
BEGIN TRANSACTION
	EXEC AddNewNC  @codigo_fat = 'FT2001-12346';
	if EXISTS (SELECT * FROM Nota_Cred WHERE codigo_fat='FT2001-12346' ) 
		PRINT 'OK:Nota Crédito NC2001-12346 was created'
	else
		PRINT 'NOK:Nota Crédito NC2001-12346 was not created'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Criar Nota Crédito para fatura inexistente'
BEGIN TRANSACTION
	EXEC AddNewNC  @codigo_fat = 'FT2001-12349';
	if EXISTS (SELECT * FROM Nota_Cred WHERE codigo_fat='FT2001-12349' ) 
		PRINT 'NOK:Nota Crédito NC2001-12349 was created'
	else
		PRINT 'OK:Nota Crédito NC2001-12349 was not created'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Criar Nota Crédito para uma fatura não emitida'
BEGIN TRANSACTION
	EXEC AddNewNC  @codigo_fat = 'FT2001-12344';
	if EXISTS (SELECT * FROM Nota_Cred WHERE codigo_fat='FT2001-12344' ) 
		PRINT 'NOK:Nota Crédito NC2001-12344 was created'
	else
		PRINT 'OK:Nota Crédito NC2001-12344 was not created'
ROLLBACK



------------- TESTE EXERCICIO H -------------
PRINT 'TESTE DO EXERCICIO H' ;

PRINT 'Adicionar Item a fatura '
BEGIN TRANSACTION
	EXEC p_criafatura @nif = 111222333, @nome= 'Inês', @morada ='Rua 121'
	EXEC AddItemsFat @desc_item = 'banana',  @desconto=0.5, @num_uni = 6, @codigo_fat='FT2020-11111', @sku= '321456'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Item WHERE desc_item='banana' AND desconto=0.5 AND num_uni = 6 AND codigo_fat='FT2020-11111' AND sku= '321456') 
		AND EXISTS (SELECT * FROM Item_Hist WHERE desc_item='banana' AND desconto=0.5 AND num_uni = 6 AND codigo_fat='FT2020-11111' AND sku= '321456')
		PRINT 'OK:Item was added FT2020-11111'
	else
		PRINT 'NOK:Item not was added FT2020-11111'
ROLLBACK

PRINT '-----------------------------'

PRINT 'Adicionar Item a fatura  e de seguida depois atualizar esse mesmo produto em questao de aumentar o numero de unidades e atualizar desconto'
BEGIN TRANSACTION
	EXEC p_criafatura @nif = 111222333, @nome= 'Inês', @morada ='Rua 121'
	EXEC AddItemsFat @desc_item = 'banana',  @desconto=0.5, @num_uni = 6, @codigo_fat='FT2020-11111', @sku= '321456'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Item WHERE desc_item='banana' AND desconto=0.5 AND num_uni = 6 AND codigo_fat='FT2020-11111' AND sku= '321456') 
		PRINT 'OK:Item was added FT2020-11111'
	else
		PRINT 'NOK:Item not was added FT2020-11111'
	EXEC AddItemsFat @desc_item = 'banana',  @desconto=0.2, @num_uni = 6, @codigo_fat='FT2020-11111', @sku= '321456'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Item WHERE desc_item='banana' AND desconto=0.2 AND num_uni = 12 AND codigo_fat='FT2020-11111' AND sku= '321456') 
		PRINT 'OK:Item was updated FT2020-11111'
	else
		PRINT 'NOK:Item not was updated FT2020-11111'
ROLLBACK

PRINT '-----------------------------'

PRINT 'Adicionar Item a fatura que não existe num produto'
BEGIN TRANSACTION
	EXEC p_criafatura @nif = 111222333, @nome= 'Inês', @morada ='Rua 121'
	EXEC AddItemsFat @desc_item = 'ananas',  @desconto=0.5, @num_uni = 6, @codigo_fat='FT2020-11111', @sku= '122334'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-11111' ) AND EXISTS (SELECT * FROM Item WHERE desc_item='ananas' AND desconto=0.5 AND num_uni = 6 AND codigo_fat='FT2020-11111' AND sku= '122334') 
		PRINT 'NOK:Item was added FT2020-11111'
	else
		PRINT 'OK:Item not was added FT2020-11111'
ROLLBACK

PRINT '-----------------------------'

PRINT 'Adicionar Item a fatura que nao está em atualização'
BEGIN TRANSACTION
	EXEC AddItemsFat @desc_item = 'ananas',  @desconto=0.5, @num_uni = 6, @codigo_fat='FT2020-12347', @sku= '122334'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2020-12347' ) AND EXISTS (SELECT * FROM Item WHERE desc_item='ananas' AND desconto=0.5 AND num_uni = 6 AND codigo_fat='FT2020-12347' AND sku= '122334') 
		PRINT 'NOK:Item was added FT2020-12348'
	else
		PRINT 'OK:Item not was added FT2020-12348'
ROLLBACK
PRINT '-----------------------------'
------------- TESTE EXERCICIO I -------------
PRINT 'TESTE DO EXERCICIO I' ;

PRINT 'Atualizar o Valor total da fatura '
BEGIN TRANSACTION
	EXEC AtualizarValorTotal @codigo_fat='FT2001-12344'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12344' AND val_total=14.60 ) 
		PRINT 'OK:Was updated the total value in FT2001-12344'
	else
		PRINT 'NOK:Not Was updated the total value in FT2001-12344'
ROLLBACK

PRINT '-----------------------------'
------------- TESTE EXERCICIO J -------------
PRINT 'TESTE DO EXERCICIO J' ;
PRINT 'Obter lista de um ano das notas de credito '

declare @ano
numeric(4) PRINT ''
BEGIN TRANSACTION
	DECLARE @res TABLE  (  
			codigo_nc nvarchar(12),
			ano numeric(4),
			nr_nc numeric(5),
			dt_emissao datetime,
			dt_criacao datetime,
			val_nc numeric(6,2),
			estado varchar(15),
			codigo_fat nvarchar(12)
		)
	INSERT INTO @res SELECT * FROM [dbo].[ListOfNotaCred](2001)
	if (( SELECT COUNT(ano) FROM Nota_Cred WHERE Nota_Cred.ano= 2001) = (SELECT COUNT(*) FROM @res))
		PRINT 'OK:A lista obtida é coerente com as nc existentes na tabela Nota_Cred para o ano 2001 '
	else
		PRINT 'NOK:A lista obtida é errada '

ROLLBACK

PRINT '-----------------------------'
------------- TESTE EXERCICIO K -------------
PRINT 'TESTE DO EXERCICIO K' ;

PRINT 'Atualizar estado de fatura de em atualização para anulada '--pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Anulada', @codigo_fat = 'FT2001-12344'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12344' AND estado='Anulada') 
		PRINT 'OK:Estado pode ser atualizado'
	else
		PRINT 'NOK:Estado não pode ser atualizado'
ROLLBACK
PRINT '-----------------------------'

PRINT 'Atualizar estado de fatura de em atualização para emitida '--pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Emitida', @codigo_fat = 'FT2001-12344'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12344' AND estado='Emitida') 
		PRINT 'OK:Estado pode ser atualizado'
	else
		PRINT 'NOK:Estado não pode ser atualizado'
ROLLBACK
PRINT '-----------------------------'

PRINT 'Atualizar estado de fatura de em atualização para proforma '--pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Proforma', @codigo_fat = 'FT2001-12344'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12344' AND estado='Proforma') 
		PRINT 'OK:Estado pode ser atualizado'
	else
		PRINT 'NOK:Estado não pode ser atualizado'
ROLLBACK
PRINT '-----------------------------'

PRINT 'Atualizar estado de fatura de em anulada para emitida '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Emitida', @codigo_fat = 'FT2001-12347'
	if  EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12347' AND estado='Emitida') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK
PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em anulada para em atualização '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Em atualização', @codigo_fat = 'FT2001-12347'
	if  EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12347' AND estado='Em atualização') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em anulada para proforma '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Proforma', @codigo_fat = 'FT2001-12347'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12347' AND estado='Proforma') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em emitida para anulada '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Anulada', @codigo_fat = 'FT2001-12346'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12346' AND estado='Anulada') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em emitida para em atualização '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Em atualização', @codigo_fat = 'FT2001-12346'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12346' AND estado='Em atualização') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em emitida para proforma '--n pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Proforma', @codigo_fat = 'FT2001-12346'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12346' AND estado='Proforma') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em proforma para em atualização ' --nao pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Em atualização', @codigo_fat = 'FT2001-12345'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12345' AND estado='Em atualização') 
		PRINT 'NOK:Estado pode ser atualizado'
	else
		PRINT 'OK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em proforma para emitida '--pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Emitida', @codigo_fat = 'FT2001-12345'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12345' AND estado='Emitida') 
		PRINT 'OK:Estado pode ser atualizado'
	else
		PRINT 'NOK:Estado não pode ser atualizado'
ROLLBACK

PRINT '-----------------------------'
PRINT 'Atualizar estado de fatura de em proforma para anulada '--pode
BEGIN TRANSACTION
	EXEC AtualizarEstadoFat @novo_estado = 'Anulada', @codigo_fat = 'FT2001-12345'
	if EXISTS (SELECT * FROM Fatura WHERE codigo_fat='FT2001-12345' AND estado='Anulada') 
		PRINT 'OK:Estado pode ser atualizado'
	else
		PRINT 'NOK:Estado não pode ser atualizado'
ROLLBACK

------------- TESTE EXERCICIO L -------------

PRINT 'Exercicio L'
PRINT''
PRINT'TEST 1'
PRINT 'Atualizar estado de fatura numa VIEW '
BEGIN TRANSACTION
	BEGIN TRY
		BEGIN
			Update ResumoFat SET ResumoFat.estado = 'Emitida' WHERE ResumoFat.codigo_fat = 'FT2001-12344'
			PRINT 'OK:Estado foi atualizado na vista'
		END 
	END TRY
	BEGIN CATCH
		PRINT 'NOK:Estado não foi atualizado na vista'
	END CATCH
ROLLBACK
--------------------------------
PRINT 'Atualizar estado de fatura numa VIEW '
BEGIN TRANSACTION
	BEGIN TRY
		BEGIN
			Update ResumoFat SET ResumoFat.nome = 'Emitida' WHERE ResumoFat.codigo_fat = 'FT2001-12344'
			PRINT 'NOK:Fatura foi atualizada na vista'
		END 
	END TRY
	BEGIN CATCH
		PRINT 'OK:Fatura não foi atualizada na vista'
	END CATCH
ROLLBACK
