--DML - INSERIR DADOS

INSERT INTO Veterinario VALUES('Kaua'), ('Ryudy')

INSERT INTO TipoDePet VALUES('Gato'), ('Cachorro')

INSERT INTO Raca VALUES('Persa'), ('Golden')

INSERT INTO Pet VALUES(1, 1, 'Thor', 'Paula', '23/05/2023'), (2, 2, 'Max', 'Roger', '10/02/2020')

INSERT INTO Atendimento VALUES(2, 1), (1, 2)


SELECT * FROM Veterinario
SELECT * FROM TipoDePet
SELECT * FROM Raca
SELECT * FROM Pet
SELECT * FROM Atendimento

UPDATE Veterinario
SET CRMV = '2753944820'
WHERE IdVeterinario = 2