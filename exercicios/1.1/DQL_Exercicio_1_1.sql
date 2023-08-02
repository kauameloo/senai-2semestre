-- DQL
	-- listar as pessoas em ordem alfabetica reversa, mostrando seus telefones, seus e-mails e suas CNHS

		--script sem usar join
SELECT 

	P.Nome, 
	T.Numero AS Telefone, 
	E.Endereco AS Email, 
	P.CNH
FROM 

	Pessoa AS P,
	Email AS E,
	Telefone AS T
WHERE 

	P.IdPessoa = E.IdPessoa 
	AND P.IdPessoa = T.IdPessoa
ORDER BY 
	Nome DESC

insert into Pessoa 
values 
	('Gabriel', '0987678'),
	('Paula', '1923570'),
	('Vitoria', '2218491'),
	('Gustavo', '5217625');


select 
	* 
from 
	Pessoa full outer join Telefone on Pessoa.IdPessoa = Telefone.IdPessoa

