-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
select 
	Aluguel.IdAluguel,
	Cliente.Nome AS Cliente,
	Modelo.Nome AS Modelo
from Aluguel
inner join Cliente on Aluguel.IdCliente = Cliente.IdCliente
inner join Veiculo on Aluguel.IdVeiculo = Veiculo.IdVeiculo
inner join Modelo on Modelo.IdModelo = Veiculo.IdModelo


-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
select 
	Aluguel.IdAluguel,
	Cliente.Nome AS Cliente,
	Modelo.Nome AS Modelo
from Aluguel
inner join Cliente on Aluguel.IdCliente = 1 AND Cliente.IdCliente = 1
inner join Veiculo on Aluguel.IdVeiculo = Veiculo.IdVeiculo
inner join Modelo on Modelo.IdModelo = Veiculo.IdModelo