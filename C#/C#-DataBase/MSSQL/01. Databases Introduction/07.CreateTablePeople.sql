CREATE DATABASE People

CREATE TABLE People
(
   Id INT PRIMARY KEY Identity,
   [Name] NVARCHAR(200) NOT NULL,
   [Picture] VARBINARY(MAX), 
   Height DECIMAL(5,2),
   [Weight] DECIMAL(5,2),
   Gender CHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
   Birthdate DATE NOT NULL,
   Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) Values
('Pesho', Null, 1.76, 86.00, 'm', '1998-08-21', Null),
('Gosho', Null, 1.86, 71.50, 'm', '1999-01-13', Null),
('Gergana', Null, 1.52, 49.00, 'f', '2001-06-28', Null),
('Stamat', Null, 1.66, 65.00, 'm', '1956-03-02', Null),
('Avram', Null, 1.91, 99.00, 'm', '2005-10-11', Null)