CREATE PROCEDURE TodosMedico
AS
SELECT * FROM Medico
GO;

EXEC TodosMedico

create function BuscaMedico
(
	@Especialidade varchar(100)
)
returns table
as
return
(
	select MedicoUsuario.Nome as Médico, 
	Especialidade.TituloEspecialidade as Especialidade
	from Especialidade
	inner join Medico on Medico.IdEspecialidade = Especialidade.IdEspecialidade
	inner join Usuario as MedicoUsuario on Medico.IdUsuario = MedicoUsuario.IdUsuario
	where Especialidade.TituloEspecialidade = @Especialidade
);

select * from BuscaMedico('Cardiologista')


SELECT * FROM TipoUsuario
SELECT * FROM Clinica
SELECT * FROM Usuario
SELECT * FROM Paciente
SELECT * FROM Especialidade
SELECT * FROM Medico
SELECT * FROM Consulta
SELECT * FROM Feedback

select 
	Usuario.Nome AS NomePaciente,
	Paciente.CPF AS CPFPaciente,
	Consulta.DataConsulta,
	Consulta.HorarioConsulta,
	CONCAT (Clinica.NomeFantasia, ' - ' ,Clinica.Endereco) AS EnderecoClinica,
	MedicoUsuario.Nome AS NomeMedico,
	Especialidade.TituloEspecialidade AS Especialidade,
	Medico.CRM AS CRMMedico,
	Consulta.Prontuario

from Consulta
inner join Paciente on Consulta.IdPaciente = Paciente.IdPaciente
inner join Medico on Consulta.IdMedico = Medico.IdMedico
inner join Usuario on Paciente.IdUsuario = Usuario.IdUsuario
INNER JOIN Usuario AS MedicoUsuario ON Medico.IdUsuario = MedicoUsuario.IdUsuario
inner join Clinica on Usuario.IdClinica = Clinica.IdClinica
inner join Especialidade on Medico.IdEspecialidade = Especialidade.IdEspecialidade
