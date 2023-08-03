-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
select
	Veterinario.Nome,
	Veterinario.CRMV

from Veterinario



-- listar todas as raças que começam com a letra S
select
	Raca.IdRaca,
	Raca.Nome

from 
	Raca

where 
	Nome LIKE 's%'



-- listar todos os tipos de pet que terminam com a letra O
select
	TipoDePet.IdTipo,
	TipoDePet.Nome

from 
	TipoDePet

where 
	Nome LIKE '%o'


-- listar todos os pets mostrando os nomes dos seus donos
select
	Pet.IdPet,
	Pet.NomeDono AS Dono,
	Pet.Nome,
	TipoDePet.Nome AS Tipo,
	Raca.Nome AS Raça

from Pet
inner join TipoDePet on Pet.IdTipo = TipoDePet.IdTipo
inner join Raca on Pet.IdRaca = Raca.IdRaca



-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido
select
	Atendimento.IdAtendimento,
	Veterinario.Nome AS Veterinario,
		Raca.Nome AS Raça,
	Pet.Nome AS NomePet,
	TipoDePet.Nome AS Tipo,
	Pet.NomeDono AS Dono


from Atendimento
inner join Veterinario on Atendimento.IdVeterinario = Veterinario.IdVeterinario
inner join Pet on Atendimento.IdPet = Pet.IdPet
inner join TipoDePet on Pet.IdTipo = TipoDePet.IdTipo
inner join Raca on Pet.IdRaca = Raca.IdRaca

