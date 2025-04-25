CREATE DATABASE BibliotecaDB;

USE BibliotecaDB;

CREATE TABLE Livro (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Titulo NVARCHAR(100) NOT NULL,
	ISBN NVARCHAR(20) NOT NULL,
	idEditora INT NOT NULL
)

CREATE TABLE Editora (
	idEditora INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(100) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL
)

CREATE TABLE Autor (
	idAutor INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(100) NOT NULL
)

CREATE TABLE Categoria (
	idCategoria INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(100) NOT NULL
)

CREATE TABLE Exemplar(
	idExemplar INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idLivro INT NOT NULL,
	Quantidade INT NOT NULL
)

CREATE TABLE Usuario (
	idUsuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nome NVARCHAR(100) NOT NULL,
	Email NVARCHAR(20),
	CPF NVARCHAR(11) NOT NULL,
	Telefone NVARCHAR(11),
	DataCadastro DATETIME DEFAULT GETDATE(),
	Situacao BIT NOT NULL
)

CREATE TABLE Professor(
	idProfessor INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	idUsuario INT NOT NULL,
	RP INT NOT NULL --DEFAULT NEWGUID()
)

CREATE TABLE Aluno(
	idAluno INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	idUsuario INT NOT NULL,
	RA INT NOT NULL
)

CREATE TABLE AutorLivro (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idAutor INT NOT NULL,
	idLivro INT NOT NULL
)

CREATE TABLE LivroCategoria (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idLivro INT NOT NULL,
	idCategoria INT NOT NULL
)

CREATE TABLE Emprestimo (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DataEmprestimo DATETIME NOT NULL DEFAULT GETDATE(),
	idUsuario INT NOT NULL,
	idLivro INT NOT NULL, 
	DataDevolucao DATETIME,
	DataDevolucaoPrevista UNIQUE DATETIME DEFAULT GETDATE()+7	
)

CREATE TABLE Reserva (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idLivro INT NOT NULL, 
	idUsuario INT NOT NULL,
	DataReserva DATETIME NOT NULL DEFAULT GETDATE(),
	PrevisaoDevolucao DATETIME NOT NULL UNIQUE
)

ALTER TABLE Livro
add constraint FK_idEditora_id FOREIGN KEY (idEditora) references Editora(idEditora);
 
ALTER TABLE Exemplar
add constraint FK_Livro_id foreign key (idLivro) references Livro(id);
 
ALTER TABLE Professor
ADD CONSTRAINT FK_Usuario_id FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);
 
ALTER TABLE Aluno
ADD CONSTRAINT FK_id_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);
 
ALTER TABLE AutorLivro
ADD CONSTRAINT FK_id_Autor FOREIGN KEY (idAutor) REFERENCES Autor(idAutor),
CONSTRAINT FK_Livroid FOREIGN KEY (idLivro) REFERENCES Livro(id);
 
ALTER TABLE LivroCategoria
ADD CONSTRAINT FK_idLivro FOREIGN KEY (idLivro) REFERENCES Livro(id),
CONSTRAINT FK_idCategoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria);
 
ALTER TABLE Emprestimo
ADD CONSTRAINT FK_Usuarioid FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
CONSTRAINT FK_id_Livroid FOREIGN KEY (idLivro) REFERENCES Livro(id);
 
ALTER TABLE Reserva
ADD CONSTRAINT FK_IDdoLivro FOREIGN KEY (idLivro) REFERENCES Livro(id),
CONSTRAINT FK_idUsuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);

ALTER TABLE Emprestimo 
ADD CONSTRAINT UQ_DataDevolucaoPrevista UNIQUE (DataDevolucaoPrevista)

ALTER TABLE Reserva
ADD CONSTRAINT UQ_PrevisaoDevolucao UNIQUE (PrevisaoDevolucao),
CONSTRAINT FK_PrevisaoDevolucao FOREIGN KEY (PrevisaoDevolucao) REFERENCES Emprestimo(DataDevolucaoPrevista);

CREATE TABLE LogSistema (
	id INT NOT NULL IDENTITY(1,1),
	Mensagem NVARCHAR(MAX) NOT NULL,
	DataRegistro DATETIME NOT NULL	
)

CREATE TRIGGER trg_UsuarioInserido
ON Usuario
AFTER INSERT
AS
BEGIN
	INSERT INTO LogSistema (Mensagem, DataRegistro)
	SELECT 'Novo Usuario Inserido: ' + Nome, GETDATE() 
	FROM inserted;
END;

CREATE TRIGGER trg_ProfessorInserido
ON Professor
AFTER INSERT
AS
BEGIN
	INSERT INTO LogSistema (Mensagem, DataRegistro)
	SELECT 'Novo Professor Inserido: ' 
	+ (SELECT Nome 
		FROM Usuario 
		WHERE idUsuario = SCOPE_IDENTITY()
		) 
	+ 'com o RP: ' + RP, GETDATE() 
	FROM inserted;
END;

CREATE TRIGGER trg_AlunoInserido
ON Aluno
AFTER INSERT
AS
BEGIN
	INSERT INTO LogSistema (Mensagem, DataRegistro)
	SELECT 'Novo Aluno Inserido: ' 
	+ (SELECT Nome 
		FROM Usuario 
		WHERE idUsuario = SCOPE_IDENTITY()
		) 
	+ 'com o RA: ' + RA, GETDATE() 
	FROM inserted;
END;

SELECT * FROM LogSistema

CREATE OR ALTER PROCEDURE sp_InserirAluno
@NomeAluno NVARCHAR(MAX), 
@CPF NVARCHAR(MAX),
@RA INT
AS
BEGIN
	DECLARE @idUsuario INT;

	INSERT INTO Usuario (Nome, CPF, Situacao)
	VALUES(@NomeAluno, @CPF, 1)
	
	SET @idUsuario = SCOPE_IDENTITY();
	
	INSERT INTO Aluno (idUsuario, RA)
	VALUES(@idUsuario, @RA)
END;

EXEC sp_InserirAluno 'Fabiane Cunha', 1357, 890

INSERT INTO Aluno (idUsuario, RA)
VALUES(6, 890)

SELECT * FROM Usuario u 
INNER JOIN Aluno a 
ON u.idUsuario = a.idUsuario 

SELECT * FROM Usuario
SELECT * FROM Aluno
