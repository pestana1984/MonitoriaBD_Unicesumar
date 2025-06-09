USE master;
GO

CREATE DATABASE AulaMonitoriaBD;
GO

USE AulaMonitoriaBD;
GO

CREATE TABLE Pessoa (
	Nome VARCHAR(50),
	Telefone VARCHAR(12),
	Idade INT
);

INSERT INTO Pessoa(Nome, Idade)
			VALUES('Felipe', 40);

SELECT *
FROM Pessoa;

INSERT INTO Pessoa(Nome, Telefone, Idade)
VALUES('Iasmyn',98765, 23),
('Tarsio', 4567, 29),
('Roberto', '1234', 25),
('Alex', '4567', '22')

UPDATE Pessoa
SET Telefone = '67890'
WHERE Nome = 'Iasmyn'

UPDATE Pessoa
SET Idade = 30
WHERE Nome = 'Alex'

DELETE Pessoa
WHERE Nome = 'Alex';


USE CEP2004;
GO

DROP DATABASE AulaMonitoriaBD;
GO