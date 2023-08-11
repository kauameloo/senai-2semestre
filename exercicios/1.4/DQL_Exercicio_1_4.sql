-- DQL - Data Query Language

USE Exercicio_1_4

SELECT * FROM Albuns

-- listar todos os usuários administradores, sem exibir suas senhas
SELECT
	Usuarios.Nome,
	Usuarios.Email,
	Usuarios.Permissao
FROM Usuarios
WHERE Usuarios.Permissao = 'Administrador'

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT
	Albuns.Titulo AS 'Título do Álbum',
	Albuns.DataLancamento AS 'Data de Lançamento',
	Albuns.Localizacao AS 'Localização',
	Albuns.QtdMinutos AS 'Duração',
	Albuns.Ativo AS 'Ativo?',
	Artistas.Nome AS 'Artista',
	Estilos.Nome AS 'Estilo'
FROM Albuns
	INNER JOIN Artistas ON Albuns.IdArtista = Artistas.IdArtista
	INNER JOIN AlbunsEstilos ON Albuns.IdAlbum = AlbunsEstilos.IdAlbum
	INNER JOIN Estilos ON AlbunsEstilos.IdEstilo = Estilos.IdEstilo
WHERE
	-- Mostra somente os álbuns lançados em 2023 e em diante
	Albuns.DataLancamento > '2023'

-- listar os dados de um usuário através do e-mail e senha
SELECT
	Usuarios.Nome,
	Usuarios.Email,
	Usuarios.Senha,
	Usuarios.Permissao
FROM Usuarios
WHERE
	Usuarios.Email LIKE 'gustavo@email.com'
	AND Usuarios.Senha LIKE 'musica123'

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum
SELECT
	Albuns.Titulo AS 'Título do Álbum',
	Albuns.DataLancamento AS 'Data de Lançamento',
	Albuns.Localizacao AS 'Localização',
	Albuns.QtdMinutos AS 'Duração',
	Albuns.Ativo AS 'Ativo?',
	Artistas.Nome AS 'Artista',
	Estilos.Nome AS 'Estilo'
FROM Albuns
	INNER JOIN Artistas ON Albuns.IdArtista = Artistas.IdArtista
	INNER JOIN AlbunsEstilos ON Albuns.IdAlbum = AlbunsEstilos.IdAlbum
	INNER JOIN Estilos ON AlbunsEstilos.IdEstilo = Estilos.IdEstilo
WHERE
	-- Mostra somente os álbuns ativos
	Albuns.Ativo LIKE 1
