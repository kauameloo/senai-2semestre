INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES('admin'), ('medico'), ('paciente')

INSERT INTO Clinica(NomeFantasia, CNPJ, Endereco, HoraAbertura, HoraFechamento, RazaoSocial)
VALUES('Health Clinic', 75829057638621, 'Rua Niteroi, 180 - Centro SCS', '07:00', '22:00', 'Health Clinic S.A' )

INSERT INTO Usuario(IdClinica ,IdTipoUsuario, Email, Senha)
VALUES(1 ,1, 'kaua@email.com', 'kaua1234'), (1, 2, 'edu@email.com', 'edu1234'), (1, 3, 'carlos@email.com', 'carlos1234')

INSERT INTO Paciente(IdUsuario, Nome, CPF)
VALUES(3, 'Carlos Roque', 28391075432)

INSERT INTO Especialidade(TituloEspecialidade)
VALUES('Cardiologista')

INSERT INTO Medico(IdUsuario, IdEspecialidade, Nome, CRM)
VALUES(2, 1, 'Eduardo Costa', 748290)

INSERT INTO Consulta(IdPaciente, IdMedico, DataConsulta, HorarioConsulta, Prontuario)
VALUES(1, 1, '20/08/2023', '15:30', 'Coração quebrado pela ex, forte dores e aperto no peito')

INSERT INTO Feedback(IdPaciente, Descricao)
VALUES(1, 'Fui muito bem atendido, agora estou sem dores')


