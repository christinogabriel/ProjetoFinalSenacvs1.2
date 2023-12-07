/*USE PetHeaven;*/

/*CREATE TABLE Estoque (
    IdProduto INT PRIMARY KEY,
    NomeProduto VARCHAR(255),
    ValorProduto DECIMAL(10, 2) NOT NULL,
	QuantidadeProduto INT UNIQUE NOT NULL,
);*/

/*SELECT *FROM Estoque*/

/*INSERT INTO Estoque (IdProduto, NomeProduto, ValorProduto, QuantidadeProduto) 
VALUES
    (1, 'Ra��o Golden', 38.99, 10),
    (2, 'Coleira XYZ', 69.99, 20),
    (3, 'Biscoitos PetHeaven', 15.99, 55);*/

/*SELECT*FROM Estoque*/

/*CREATE TABLE Compras (
    IdProduto INT PRIMARY KEY,
    NomeProduto VARCHAR(255)UNIQUE NOT NULL,
    ValorProduto DECIMAL(10, 2),
    FOREIGN KEY (IdProduto) REFERENCES Estoque(IdProduto) -- Substitua "Produtos" e "Id" pelo nome da tabela de produtos e pela chave prim�ria correspondente
);*/

/*SELECT*FROM Compras;*/

/*INSERT INTO Compras (IdProduto, NomeProduto, ValorProduto) 
VALUES
    (1, 'Ra��o Golden', 38.99),
    (2, 'Coleira XYZ', 69.99),
    (3, 'Biscoitos PetHeaven', 15.99);*/

/*ALTER TABLE Compras
ADD NomeClliente DATETIME;*/


/*ALTER TABLE Compras
ADD Endere�o DATETIME;*/

/*SELECT*FROM Compras*/

/*UPDATE Compras
SET NomeCliente = 'Gabriel', Endere�o = 'Rua �lvaro Alvim ,98'*/




