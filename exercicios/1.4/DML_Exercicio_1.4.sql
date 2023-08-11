-- DML - Inserir dados nas tabelas

-- Usar o banco criado
USE Exercicio_1_4

-- Inserir dados na tabela
INSERT INTO Artistas(Nome)
VALUES ('Eduardo'), ('Carlos'), ('Gabriel')

INSERT INTO	Estilos(Nome)
VALUES ('Rock'), ('MPB'), ('Pop')

INSERT INTO AlbunsEstilos(IdAlbum, IdEstilo)
VALUES (1, 1), (2, 3), (3, 2), (4, 2)

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
VALUES 
    ('Gustavo', 'gustavo@email.com', 'musica123', 'Usuário'),
    ('Guilherme', 'guilherme@email.com', 'guilherme159', 'Administrador')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMinutos, Ativo)
VALUES
    (1, 'Programming musics', '2022-12-20', 'São Caetano do Sul', 112, 1),
    (2, 'SQL-M Sequential Music', '2023-04-01', 'São Paulo', 183, 1),
    (2, 'Coders EP', '2022-10-25', 'Santo André', 98, 1),
	(3, 'Database Manager Sounds', '2023-11-15', 'Presidente Epitácio', 55, 0)
