USE SI2Trab1;

GO

CREATE OR ALTER PROCEDURE PopulateTables
AS
	INSERT INTO Estado_FAT (estado_ft) VALUES
		('Emitida'),
		('Em atualização'),
		('Proforma'),
		('Anulada');

	INSERT INTO Estado_NC (estado_nc) VALUES
		('Emitida'),
		('Em atualização');

	INSERT INTO Codigo_NotaCred(ano, nr_nc) VALUES
		(2002,12343),
		(2001,12347);
		

	INSERT INTO Contribuinte (nif, nome, morada) VALUES
		(111222333,'Inês', 'Rua 121'),
		(111222444,'Diogo', 'Rua 122'),
		(111222555,'Ricardo', 'Rua 123');
			
	INSERT INTO Codigo_Fatura (ano, nr_fat) VALUES
		(2002,12343),
		(2001,12344),
		(2001,12345),
		(2001,12346),
		(2001,12347);
		
	INSERT INTO Fatura (codigo_fat,ano ,nr_fat, dt_emissao, dt_criacao, val_total, val_iva, estado,nif) VALUES
		(CONCAT('FT',2002,'-',12343),2002,12343, NULL, '2002-02-20 11:30:40', NULL,NULL, 'Emitida',111222444),
		(CONCAT('FT',2001,'-',12344),2001,12344, NULL, '2001-01-20 12:30:40', NULL,NULL, 'Em atualização',111222333),
		(CONCAT('FT',2001,'-',12345),2001,12345,'2001-01-20 12:35:30', '2001-01-20 12:30:40', 22.2,23, 'Proforma',111222333),
		(CONCAT('FT',2001,'-',12346),2001,12346,'2001-01-20 14:35:30', '2001-01-21 13:10:40', 50.0,23, 'Emitida',111222444),
        (CONCAT('FT',2001,'-',12347),2001,12347,'2001-01-20 16:35:30', '2001-01-22 14:20:40', 100.2,23, 'Anulada',111222555);
	
	INSERT INTO Nota_Cred (codigo_nc,ano,nr_nc, dt_emissao, dt_criacao, val_nc, estado, codigo_fat) VALUES
		(CONCAT('NC',2002,'-',12343),2002,12343, NULL, '2002-02-20 11:30:40', NULL, 'EM atualização','FT2002-12343'),
		(CONCAT('NC',2001,'-',12347),2001,12347,'2001-01-20 16:35:30', '2001-01-22 14:20:40', 100.2, 'Emitida','FT2001-12347');

	INSERT INTO Produto (sku, desc_prod, perc_iva, preco_unit) VALUES 
		('321321', 'bolachas', 23, 1.5),
		('321455', 'bolo', 23, 5.0),
		('321456', 'banana', 23, 0.69),
		('321457','papaia',23,1.30),
		('321458','bacalhau',23,4.99)

	INSERT INTO Item (num_item, desc_item, desconto, num_uni, codigo_fat,sku) VALUES
		(1,'bolachas',0.2,6,'FT2001-12344','321321'),
		(2,'banana',0.5,10,'FT2001-12344','321456'),
		(1,'bolachas',0.2,6,'FT2001-12345','321321'),
		(1,'bolo',null,0.1,'FT2001-12346','321455'),
		(1,'bacalhau',0.2,10,'FT2002-12343','321458'),
		(1, 'banana', null,0.5, 'FT2001-12347','321456');

	INSERT INTO Item_NC (quantidade, num_item, codigo_nc, codigo_fat) VALUES
		(3,1,'NC2002-12343', 'FT2002-12343'),
		(1,1,'NC2001-12347','FT2001-12347');
	

	INSERT INTO Fatura_Hist (dt_atualizacao, ultimo_estado, dt_emissao, dt_criacao, val_total, val_iva, codigo_fat,nif) VALUES 	
		('2001-01-20 12:36:00','Em atualização',NULL, '2001-01-20 12:30:40',NULL,NULL,'FT2001-12344',111222333),
		('2001-01-20 12:33:00','Emitida','2001-01-20 12:35:30', '2001-01-20 12:30:40',22.2,23,'FT2001-12345',111222333),
		('2001-01-20 13:33:00','Emitida','2001-01-22 14:20:40', '2001-01-20 16:35:30',100.2,23,'FT2001-12347',111222555), 
		('2001-01-20 13:50:00','Em atualização','2001-01-22 14:20:40', '2001-01-20 16:35:30',100.2,23,'FT2001-12347',111222555); 

	INSERT INTO Item_Hist (num_item, desc_item, desconto, num_uni, codigo_fat, sku) VALUES
		(1,'bolachas',0.2,6,'FT2001-12345','321321'),
		(2,'bolo',null,0.1,'FT2001-12346','321455'),
		(3,'banana',null,0.5,'FT2001-12347','321456');
	
GO

EXEC PopulateTables;

SELECT * FROM Estado_FAT;
SELECT * FROM Fatura;
SELECT * FROM Estado_NC;
SELECT * FROM Codigo_NotaCred;
SELECT * FROM Nota_Cred;
SELECT * FROM Contribuinte;
SELECT * FROM Item;
SELECT * FROM Produto;
SELECT * FROM Item_NC;
SELECT * FROM Fatura_Hist;
SELECT * FROM Item_Hist;
						