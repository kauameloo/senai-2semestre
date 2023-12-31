CREATE DATABASE HealthClinic_Tarde

USE HealthClinic_Tarde

CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(50) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(50) NOT NULL,
	HoraAbertura TIME NOT NULL,
	HoraFechamento TIME NOT NULL,
	RazaoSocial VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
)

CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	CPF VARCHAR(11) NOT NULL UNIQUE
)

CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TituloEspecialidade VARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	CRM VARCHAR(6) NOT NULL UNIQUE
)

CREATE TABLE Feedback
(
	IdFeedback INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	Descricao VARCHAR(200) NOT NULL
)

CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	DataConsulta DATE NOT NULL,
	HorarioConsulta TIME NOT NULL,
	Prontuario VARCHAR(200)
)
