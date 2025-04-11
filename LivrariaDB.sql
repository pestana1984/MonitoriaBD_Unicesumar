CREATE DATABASE LivrariaDB;

USE LivrariaDB;

CREATE TABLE Livraria (
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Gerente NVARCHAR(40) NOT NULL UNIQUE,
	Nome NVARCHAR(20) NOT NULL
);

CREATE TABLE Editora (
	Codigo INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nome NVARCHAR(20) NOT NULL UNIQUE,
	Gerente NVARCHAR(40) NOT NULL
);

CREATE TABLE Cliente (
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Documento NVARCHAR(14) NOT NULL UNIQUE,
	Nome NVARCHAR(40) NOT NULL
);

CREATE TABLE Livro (
	ISBN VARCHAR(16) PRIMARY KEY NOT NULL,
	Nome NVARCHAR(100) NOT NULL,
	Autor NVARCHAR(40) NOT NULL,
	Assunto NVARCHAR(40) NOT NULL,
	Editora NVARCHAR(20) NOT NULL UNIQUE, 
	CONSTRAINT FK_Editora_Nome FOREIGN KEY (Editora) REFERENCES Editora(Nome)	
);

CREATE TABLE Estoque (
	Quantidade INT NOT NULL,
	ISBN VARCHAR(16) NOT NULL UNIQUE,
	CONSTRAINT FK_Livro_ISBN FOREIGN KEY (ISBN) REFERENCES Livro(ISBN)
);

CREATE TABLE ListaLivros (
	Cliente INT NOT NULL UNIQUE,
	ISBN VARCHAR(16) NOT NULL UNIQUE,
	CONSTRAINT FK_Cliente_ID FOREIGN KEY (Cliente) REFERENCES Cliente(ID),
	CONSTRAINT FK_ListaLivro_ISBN FOREIGN KEY (ISBN) REFERENCES Livro(ISBN)
);

CREATE TABLE Endereco (
	Numero INT NOT NULL,
	Logradouro NVARCHAR(100) NOT NULL,
	Cidade NVARCHAR(50) NOT NULL,
	Bairro NVARCHAR(20) NOT NULL,
	ClienteID INT NULL,
	CodigoEditora INT NULL,
	CONSTRAINT FK_ClienteID_ID FOREIGN KEY (ClienteID) REFERENCES Cliente(ID),
	CONSTRAINT FK_Editora_Codigo FOREIGN KEY (CodigoEditora) REFERENCES Editora(Codigo)
);

ALTER TABLE Endereco DROP CONSTRAINT FK_ClienteID_ID, FK_Editora_Codigo
ALTER TABLE Endereco DROP COLUMN ClienteID, CodigoEditora
ALTER TABLE Endereco ADD ClienteID INT NULL, CodigoEditora INT NULL
ALTER TABLE Endereco ADD CONSTRAINT FK_ClienteID_ID FOREIGN KEY (ClienteID) REFERENCES Cliente(ID)
ALTER TABLE Endereco ADD CONSTRAINT FK_Editora_Codigo FOREIGN KEY (CodigoEditora) REFERENCES Editora(Codigo)

ALTER TABLE Endereco ADD CONSTRAINT CHK_Somente_Uma_FK CHECK (
	(ClienteID IS NOT NULL AND CodigoEditora IS NULL) OR
	(ClienteID IS NULL AND CodigoEditora IS NOT NULL)
)

CREATE TABLE Telefone (
	CodigoPais INT NOT NULL,
	DDD INT NOT NULL,
	Numero INT NOT NULL,
	EditoraCodigo INT NOT NULL UNIQUE,
	ClienteID INT NOT NULL UNIQUE,
	CONSTRAINT FK_EditoraCodigo_ID FOREIGN KEY (EditoraCodigo) REFERENCES Editora(Codigo),
	CONSTRAINT FK_IDCliente_ID FOREIGN KEY (ClienteID) REFERENCES Cliente(Id)
);

ALTER TABLE Livro ADD Disponivel BIT NOT NULL;

INSERT INTO Editora (Nome, Gerente)
VALUES('Da Terra', 'Fagner'),
('Millenium', 'Fagner'),
('Kinder', 'Fagner')

SELECT * FROM Editora


INSERT INTO Livro (ISBN, Nome, Autor, Assunto, Editora, Disponivel)
VALUES(123, 'Peter Pan', 'Felipe', 'Ficção', 'Da Terra', 1),
('456', 'Penso Enriqueço', 'Andrew Carnigie', 'Desenvolvimento Pessoal', 'Millenium', 1),
(789, 'Os crimes ABC', 'Agatha Christie', 'Policial', 'Kinder', 1)

SELECT * FROM Livro WHERE Disponivel = 1

CREATE TRIGGER trg_DeletarLivro
ON Livro
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Livro
	SET Disponivel = 0 -- FALSO
END;

CREATE OR ALTER TRIGGER trg_LivroComprado
ON Livro
INSTEAD OF UPDATE
AS
BEGIN
	PRINT 'Livro Cadastrado com sucesso!'
END

UPDATE Livro SET Disponivel = 1
WHERE Nome = 'Peter Pan'


ALTER TABLE Cliente DROP CONSTRAINT UQ__Cliente__AF73706DAE4A86D1
ALTER TABLE Cliente DROP COLUMN Documento

CREATE TABLE ClientePF (
	ClienteID INT NOT NULL,
	CPF VARCHAR(14) NOT NULL UNIQUE,
	CONSTRAINT FK_ClientePF_ID FOREIGN KEY (ClienteID) REFERENCES Cliente(ID)
)

ALTER TABLE ClientePF ADD Profissao NVARCHAR(40) NOT NULL

CREATE TABLE ClientePJ (
	ClienteID INT NOT NULL,
	CNPJ VARCHAR(17) NOT NULL PRIMARY KEY,
	Ramo NVARCHAR(40) NOT NULL,
	CONSTRAINT FK_ClientePJ_ID FOREIGN KEY (ClienteID) REFERENCES Cliente(ID)
)


INSERT INTO Cliente(Nome)
VALUES('Zé Lelé')

SELECT id FROM Cliente WHERE Nome = 'Zé Lelé'

CREATE OR ALTER PROCEDURE sp_InserirClientePF 
	@Nome NVARCHAR(100), 
	@CPF BIGINT, 
	@Profissao VARCHAR(50)
	
AS
BEGIN
	DECLARE @ClienteID INT
	INSERT INTO Cliente(Nome)
	VALUES(@Nome)
	SET @ClienteID = (SELECT id FROM inserted);
	
	INSERT INTO ClientePF(ClienteID, CPF, Profissao)
	VALUES(@ClienteID, @CPF, @Profissao)
END


EXEC sp_InserirClientePF 'Keylla', '123', 'Estudante'

SELECT * FROM ClientePF


INSERT INTO Cliente(Nome)
VALUES('Keylla')

INSERT INTO ClientePF(ClienteID, CPF, Profissao)
VALUES(SELECT id FROM Cliente WHERE Nome = 'Keylla', '123', 'Estudante')











