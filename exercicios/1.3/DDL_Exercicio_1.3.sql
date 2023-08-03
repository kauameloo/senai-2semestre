--DDL - CRIAR DB
CREATE DATABASE Exercicio_1_3

USE Exercicio_1_3

--CRIAR TABELAS
CREATE TABLE Veterinario
(
	IdVeterinario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
);

CREATE TABLE TipoDePet
(
	IdTipo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
);

CREATE TABLE Raca
(
	IdRaca INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
);

CREATE TABLE Pet
(
	IdPet INT PRIMARY KEY IDENTITY,
	IdTipo INT FOREIGN KEY REFERENCES TipoDePet(IdTipo),
	IdRaca INT FOREIGN KEY REFERENCES Raca(IdRaca),
	Nome VARCHAR(20) NOT NULL,
	NomeDono VARCHAR(20) NOT NULL,
	Nascimento DATE NOT NULL,
);

CREATE TABLE Atendimento
(
	IdAtendimento INT PRIMARY KEY IDENTITY,
	IdVeterinario INT FOREIGN KEY REFERENCES Veterinario(IdVeterinario),
	IdPet INT FOREIGN KEY REFERENCES Pet(IdPet),
);


SELECT * FROM Veterinario
SELECT * FROM TipoDePet
SELECT * FROM Raca
SELECT * FROM Pet
SELECT * FROM Atendimento

ALTER TABLE Veterinario
ADD CRMV VARCHAR(10)