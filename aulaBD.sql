CREATE DATABASE AulaBD;
GO

USE AulaBD;
GO

CREATE TABLE Estudante 
( 
 CPF VARCHAR(14) PRIMARY KEY NOT NULL,  
 Nome NVARCHAR(50) NOT NULL,
 RA INT NOT NULL, 
 idDepartamento INT NOT NULL,  
 Telefone VARCHAR(11),  
); 

CREATE TABLE Disciplina 
( 
 Codigo INT PRIMARY KEY,  
 CargaHoraria INT NOT NULL,  
 Nome NVARCHAR(30) NOT NULL,  
); 

CREATE TABLE Departamento 
( 
 ID INT PRIMARY KEY,  
 Coordenador NVARCHAR(30) NOT NULL,
 Recorrencia BIT NOT NULL,
 Descrição NVARCHAR(MAX),  
); 

CREATE TABLE Professor 
( 
 CPF VARCHAR(14) PRIMARY KEY,  
 Nome NVARCHAR(30) NOT NULL,  
 RP INT NOT NULL,  
 Telefone VARCHAR(11),  
 Email NVARCHAR(20),  
); 

CREATE TABLE Matricula 
( 
 Nota INT,  
 Desempenho INT,  
 CodigoDisciplina INT ,  
 CPFEstudante INT,  
); 

CREATE TABLE Trabalha 
( 
 CPFProfessor INT,  
 idDepartamento INT,  
); 

CREATE TABLE Ministra 
( 
 CodigoDisciplina INT,  
 CPFProfessor INT,  
); 

CREATE TABLE Oferece 
( 
 Ementa NVARCHAR(MAX) NOT NULL,  
 Periodo INT,  
 CodigoDisciplina INT,  
 IDDepartamento INT,  
); 

ALTER TABLE Estudante ADD FOREIGN KEY(idDepartamento) REFERENCES Departamento (ID)
ALTER TABLE Matricula ADD FOREIGN KEY(CodigoDisciplina) REFERENCES Disciplina (Codigo)
ALTER TABLE Matricula ADD FOREIGN KEY(CPFEstudante) REFERENCES Estudante (CPF)
ALTER TABLE Trabalha ADD FOREIGN KEY(CPFProfessor) REFERENCES Professor (CPF)
ALTER TABLE Trabalha ADD FOREIGN KEY(IDDepartamento) REFERENCES Departamento (ID)
ALTER TABLE Ministra ADD FOREIGN KEY(CodigoDisciplina) REFERENCES Disciplina (Codigo)
ALTER TABLE Ministra ADD FOREIGN KEY(CPFProfessor) REFERENCES Professor (CPF)
ALTER TABLE Oferece ADD FOREIGN KEY(CodigoDisciplina) REFERENCES Disciplina (Codigo)
ALTER TABLE Oferece ADD FOREIGN KEY(IDDepartamento) REFERENCES Departamento (ID)
