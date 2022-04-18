
DECLARE @Person1 UNIQUEIDENTIFIER SET @Person1=NEWID()
DECLARE @Person2 UNIQUEIDENTIFIER SET @Person2=NEWID()
DECLARE @Person3 UNIQUEIDENTIFIER SET @Person3=NEWID()

INSERT INTO Person VALUES
(@Person1,'Juan Velez','1053981234','3103719234','juan@gmail.com','Junio05+',CAST ('1992-06-05 20:44:11' AS DATETIME),1,GETDATE(),GETDATE()),
(@Person2,'Marcela Higinio','1053324567','3103719987','marce@gmail.com','Noviembre25+',CAST ('1992-11-25 20:44:11' AS DATETIME),2,GETDATE(),GETDATE()),
(@Person3,'Ariana Vasquez','1053899456','310500403','ari@gmail.com','Febrero12+',CAST ('2000-02-12 20:44:11' AS DATETIME),2,GETDATE(),GETDATE())

DECLARE @Product1 UNIQUEIDENTIFIER SET @Product1=NEWID()
DECLARE @Product2 UNIQUEIDENTIFIER SET @Product2=NEWID()
DECLARE @Product3 UNIQUEIDENTIFIER SET @Product3=NEWID()
DECLARE @Product4 UNIQUEIDENTIFIER SET @Product4=NEWID()
DECLARE @Product5 UNIQUEIDENTIFIER SET @Product5=NEWID()
DECLARE @Product6 UNIQUEIDENTIFIER SET @Product6=NEWID()

INSERT INTO Product VALUES
(@Product1,'Camisa',50000,1),
(@Product2,'Pantalon',25000,1),
(@Product3,'Zapatos',20000,1),
(@Product4,'Tenis',25000,1),
(@Product5,'Falda',100000,1),
(@Product6,'Blusa',200000,1)

DECLARE @Tax UNIQUEIDENTIFIER SET @Tax=NEWID()
INSERT INTO Tax VALUES(@Tax,0.19,'Iva 19%',1)

DECLARE @Discount1 UNIQUEIDENTIFIER SET @Discount1=NEWID()
DECLARE @Discount2 UNIQUEIDENTIFIER SET @Discount2=NEWID()
DECLARE @Discount3 UNIQUEIDENTIFIER SET @Discount3=NEWID()
DECLARE @Discount4 UNIQUEIDENTIFIER SET @Discount4=NEWID()
DECLARE @Discount5 UNIQUEIDENTIFIER SET @Discount5=NEWID()

INSERT INTO Discount VALUES
(@Discount1,0.0,'Sin Descuento',1),
(@Discount2,0.05,'Descuento de 5%',1),
(@Discount3,0.1,'Descuento de 10%',1),
(@Discount4,0.15,'Descuento de 15%',1),
(@Discount5,0.2,'Descuento de 20%',1)


DECLARE @Bill1 UNIQUEIDENTIFIER SET @Bill1=NEWID()
DECLARE @Bill2 UNIQUEIDENTIFIER SET @Bill2=NEWID()
DECLARE @Bill3 UNIQUEIDENTIFIER SET @Bill3=NEWID()

INSERT INTO Bill VALUES 
(@Bill1,GETDATE(),1,100000,0,19000,119000,@Person2,@Tax,@Discount1),
(@Bill2,GETDATE(),2,200000,20000,34200,214200,@Person2,@Tax,@Discount3),
(@Bill3,GETDATE(),3,300000,15000,54150,339150,@Person3,@Tax,@Discount2)

DECLARE @BillDetail1 UNIQUEIDENTIFIER SET @BillDetail1=NEWID()
DECLARE @BillDetail2 UNIQUEIDENTIFIER SET @BillDetail2=NEWID()
DECLARE @BillDetail3 UNIQUEIDENTIFIER SET @BillDetail3=NEWID()
DECLARE @BillDetail4 UNIQUEIDENTIFIER SET @BillDetail4=NEWID()
DECLARE @BillDetail5 UNIQUEIDENTIFIER SET @BillDetail5=NEWID()
DECLARE @BillDetail6 UNIQUEIDENTIFIER SET @BillDetail6=NEWID()

INSERT INTO BillDetail VALUES 
(@BillDetail1,1,50000,@Bill1,@Product1),
(@BillDetail2,2,25000,@Bill1,@Product2),
(@BillDetail3,5,20000,@Bill2,@Product3),
(@BillDetail4,4,25000,@Bill2,@Product4),
(@BillDetail5,1,100000,@Bill3,@Product5),
(@BillDetail6,1,200000,@Bill3,@Product6)


INSERT INTO Message VALUES
(1,2,'Oops, an error has occurred! Please contact our support team.'),
(2,2,'The minimum value must be less than the greater.'),
(3,2,'Does not exist.'),
(4,2,'Required.'),
(5,2,'It exceeds the allowed values.'),
(6,2,'The transaction was not processed.'),
(7,2,'It already exists.'),
(1,1,'Successful response.')