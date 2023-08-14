SELECT * FROM TipoUsuario
SELECT * FROM Clinica
SELECT * FROM Usuario
SELECT * FROM Paciente
SELECT * FROM Especialidade
SELECT * FROM Medico
SELECT * FROM Consulta
SELECT * FROM Feedback

select 
	Usuario.Nome AS Usuario,
	TipoDeUsuario.TituloTipoUsuario AS Permissão,
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'CONFIRMADO' ELSE 'NAO CONFIRMADO' END AS Presença,
	Evento.Nome as NomeEvento,
	Evento.Descricao AS DescricãoEvento,
	Evento.DataEvento AS DataEvento,
	Evento.HorarioEvento AS HorarioEvento,
	CONCAT (Instituicao.Nome, ' - ' ,Instituicao.Endereco) AS EnderecoEvento,
	ComentarioEvento.Descricao AS Comentario

from Consulta
inner join Paciente on Consulta.IdPaciente = Paciente.IdPaciente
inner join Medico on Consulta.IdMedico = Medico.IdMedico
inner join Usuario on Medico.IdUsuario = Usuario.IdUsuario
inner join Usuario AS U on Paciente.IdUsuario = U.IdUsuario