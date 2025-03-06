CREATE DATABASE Aula2;
GO

USE Aula2;
GO

CREATE TABLE Pessoa 
( 
 Nome VARCHAR(20),  
 Email VARCHAR(20),  
 ID INT PRIMARY KEY IDENTITY(1,1),  
); 


CREATE TABLE Telefone 
( 
 DDD INT,  
 Numero INT,  
 IDPessoa INT NOT NULL,  
); 

ALTER TABLE Telefone ADD FOREIGN KEY(IDPessoa) REFERENCES Pessoa (ID)


SELECT * FROM Pessoa
SELECT * FROM Telefone

INSERT INTO Pessoa (Nome, Email)
VALUES ('Felipe', 'a@a.com.br')

INSERT INTO Pessoa (Nome, Email)
VALUES ('Breno', 'b@b.com.br'),
('Camily','c@c.com.br')

INSERT INTO Telefone(DDD, Numero)
VALUES (16, 1234)

INSERT INTO Telefone(DDD, Numero, IDPessoa)
VALUES (19, 4321, 2)

SELECT p.Id, p.Nome, p.Email, t.DDD, t.Numero
FROM Pessoa p
INNER JOIN Telefone t
ON t.IDPessoa = p.ID