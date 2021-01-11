IF(db_id(N'SI2Trab1') IS NULL) CREATE DATABASE SI2Trab1; -- Create the database if it doesn't exist yet

USE SI2Trab1;

GO

CREATE OR ALTER PROCEDURE CreateTables
AS
	
	CREATE TABLE Estado_FAT (
		estado_ft varchar(15) primary key
	);

	CREATE TABLE Estado_NC (
		estado_nc varchar(15) primary key
	);

	CREATE TABLE Codigo_NotaCred(
		ano numeric(4),
		nr_nc numeric(5),
		primary key (ano,nr_nc)		
	);


	CREATE TABLE Codigo_Fatura(
		ano numeric(4),
		nr_fat numeric(5),
		primary key (ano,nr_fat)		
	);

	CREATE TABLE Contribuinte (
		nif numeric(9) primary key,
		nome varchar(50),
		morada varchar(100)
	);

	CREATE TABLE Fatura (	
		codigo_fat nvarchar(12) primary key,
		ano numeric(4) not null,
		nr_fat numeric(5) not null,	
		dt_emissao nvarchar(19),
		dt_criacao nvarchar(19) not null,
		val_total numeric (6,2),
		val_iva int,
		estado varchar(15) not null,
		nif numeric(9),
		foreign key (estado) references Estado_FAT(estado_ft),
		foreign key (ano,nr_fat) references Codigo_Fatura(ano,nr_fat),
		foreign key (nif) references Contribuinte(nif)
	);	
	
	CREATE TABLE Nota_Cred (
		codigo_nc nvarchar(12) primary key, -- NCyyyy-xxxxx
		ano numeric(4) not null,
		nr_nc numeric(5) not null,	
		dt_emissao nvarchar(19),
		dt_criacao nvarchar(19) not null,
		val_nc numeric(6,2),
		estado varchar(15) not null,
		codigo_fat nvarchar(12),
		foreign key (estado) references Estado_NC(estado_nc) ,
		foreign key (codigo_fat) references Fatura(codigo_fat) ,
		foreign key (ano,nr_nc) references Codigo_NotaCred(ano,nr_nc)
	);

	CREATE TABLE Produto (
        sku varchar(25) primary key,
        desc_prod varchar(100),
        perc_iva int,
        preco_unit numeric(2) not null,
    );

	CREATE TABLE Item (
        num_item int ,
        desc_item varchar(100),
        desconto decimal(2,1) check (desconto >= 0 AND desconto <=1),
        num_uni numeric not null,
        codigo_fat nvarchar(12) not null,
		sku varchar(25),
        foreign key (codigo_fat) references Fatura (codigo_fat),
		foreign key (sku) references Produto (sku),
        primary key(num_item,codigo_fat)
    );

	CREATE TABLE Item_NC (
        quantidade int primary key,
        codigo_nc nvarchar(12),
        num_item int,
        codigo_fat nvarchar(12) not null,
        foreign key (num_item,codigo_fat) references Item (num_item,codigo_fat),
        foreign key (codigo_nc) references Nota_Cred (codigo_nc)
    );

	CREATE TABLE Fatura_Hist (
		dt_atualizacao nvarchar(19),
		ultimo_estado varchar(15) not null,
		dt_emissao nvarchar(19),
		dt_criacao nvarchar(19) not null,
		val_total numeric (6,2),
		val_iva int,
		codigo_fat nvarchar(12) not null,
		nif numeric(9),
		foreign key (codigo_fat) references Fatura (codigo_fat),
		foreign key (nif) references Contribuinte (nif)
	);

	CREATE TABLE Item_Hist (
		num_item int,
		desc_item varchar(100),
		desconto decimal(2,1) check (desconto >= 0 AND desconto <=1),
		num_uni numeric not null,
		codigo_fat nvarchar(12) not null,
		sku varchar(25),
		foreign key (codigo_fat) references Fatura (codigo_fat)
	);

GO

EXEC CreateTables;