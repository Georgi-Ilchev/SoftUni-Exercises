CREATE DATABASE Minions
USE Minions

CREATE TABLE Minions
(
  Id INT PRIMARY KEY,
  [Name] VARCHAR(30),
  Age INT
)

CREATE TABLE Towns
(
  Id INT PRIMARY KEY,
  [Name] VARCHAR(50)
)

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns (Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--SELECT * FROM Towns
--SELECT * FROM Minions

--Delete all info from tables
DELETE FROM Minions

--Delete tables
DROP TABLE Minions
DROP TABLE Towns


--7 


