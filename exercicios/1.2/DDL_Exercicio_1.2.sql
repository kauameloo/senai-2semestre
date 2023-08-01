--DDL - CRIAR DB
CREATE DATABASE Exercicio_1_2

USE Exercicio_1_2

--CRIAR TABELAS
CREATE TABLE Marca
(
	IdMarca INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
);

CREATE TABLE Modelo
(
	IdModelo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
);

CREATE TABLE Cliente
(
	IdCliente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
	CPF VARCHAR(11) NOT NULL UNIQUE,
);

CREATE TABLE Veiculo
(
	IdVeiculo INT PRIMARY KEY IDENTITY,
	IdModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo),
	IdMarca INT FOREIGN KEY REFERENCES Marca(IdMarca),
	Placa VARCHAR(7) NOT NULL UNIQUE
);

CREATE TABLE Aluguel
(
	IdAluguel INT PRIMARY KEY IDENTITY,
	IdVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
);

SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Veiculo
SELECT * FROM Aluguel