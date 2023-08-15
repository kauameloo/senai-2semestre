INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES('admin'), ('medico'), ('paciente')

INSERT INTO Clinica(NomeFantasia, CNPJ, Endereco, HoraAbertura, HoraFechamento, RazaoSocial)
VALUES('Health Clinic', 75829057638621, 'Rua Niteroi, 180 - Centro SCS', '07:00', '22:00', 'Health Clinic S.A' )

INSERT INTO Usuario(IdClinica ,IdTipoUsuario, Nome, Email, Senha)
VALUES(1 ,1,'Kaua Melo', 'kaua@email.com', 'kaua1234'), (1, 2, 'Eduardo Costa', 'edu@email.com', 'edu1234'), (1, 3, 'Carlos Roque', 'carlos@email.com', 'carlos1234'), (1, 3,'Paulo Silva', 'paulo@email.com', 'paulo0123'), (1, 2, 'Julio Alves', 'julio@email.com', 'julio1234')

INSERT INTO Paciente(IdUsuario, CPF)
VALUES(3, 28391075432), (4, '82719402754')

INSERT INTO Especialidade(TituloEspecialidade)
VALUES('Cardiologista'), ('Pediatra')

INSERT INTO Medico(IdUsuario, IdEspecialidade, CRM)
VALUES(2, 1, 748290), (5, 2, 817205)

INSERT INTO Consulta(IdPaciente, IdMedico, DataConsulta, HorarioConsulta, Prontuario)
VALUES(1, 1, '20/08/2023', '15:30', 'Coração quebrado pela ex, forte dores e aperto no peito')

INSERT INTO Feedback(IdPaciente, Descricao)
VALUES(1, 'Fui muito bem atendido, agora estou sem dores')







INSERT INTO Usuario(IdClinica ,IdTipoUsuario, Email, Senha)
VALUES(1, 2, 'julio@email.com', 'julio1234')

INSERT INTO Consulta(IdPaciente, IdMedico, DataConsulta, HorarioConsulta, Prontuario)
VALUES(2, 2, '17/08/2023', '18:30', 'Dor de garganta')