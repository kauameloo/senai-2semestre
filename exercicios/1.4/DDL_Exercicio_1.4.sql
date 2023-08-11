-- DDL - Criar bancos e tabelas

-- Criar o banco de dados
CREATE DATABASE Exercicio_1_4;

-- Usar o banco criado
USE Exercicio_1_4;

-- Criar tabelas do banco
CREATE TABLE Artistas (
	IdArtista INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30) NOT NULL,
);

CREATE TABLE Estilos (
	IdEstilo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(40) NOT NULL UNIQUE,
);

CREATE TABLE Albuns (
	IdAlbum INT PRIMARY KEY IDENTITY,
	IdArtista INT FOREIGN KEY REFERENCES Artistas(IdArtista) NOT NULL,
	Titulo VARCHAR(80) NOT NULL,
	DataLancamento DATE NOT NULL,
	Localizacao VARCHAR(50) NOT NULL,
	QtdMinutos INT NOT NULL,
	Ativo BIT NOT NULL,
);

CREATE TABLE AlbunsEstilos (
	IdAlbum INT FOREIGN KEY REFERENCES Albuns(IdAlbum) NOT NULL,
	IdEstilo INT FOREIGN KEY REFERENCES Estilos(IdEstilo) NOT NULL,
);

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(32) NOT NULL,
	Permissao VARCHAR(40) NOT NULL,
);
