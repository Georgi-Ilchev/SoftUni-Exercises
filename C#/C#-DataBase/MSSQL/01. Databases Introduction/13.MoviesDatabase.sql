CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
	--Directors (Id, DirectorName, Notes)
)


CREATE TABLE Genres
(
	Id INT IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
	--Genres (Id, GenreName, Notes)
)


CREATE TABLE Categories
(
	Id INT IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
	--Categories (Id, CategoryName, Notes)
)

CREATE TABLE Movies
(
	Id INT IDENTITY,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT,
	CategoryId INT,
	Rating INT,
	Notes VARCHAR(MAX)
	--(Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Genres
ADD CONSTRAINT PK_Genres PRIMARY KEY (Id)

ALTER TABLE Categories
ADD CONSTRAINT PK_Categories PRIMARY KEY (Id)

ALTER TABLE Movies
ADD CONSTRAINT PK_Movies PRIMARY KEY (Id)


INSERT INTO Directors(DirectorName, Notes) VALUES
('Ivan', 'Ivan is a good film maker ;)'),
('Pesho', 'Pesho is a good film maker ;)'),
('Gosho', 'Gosho is a good film maker ;)'),
('Pepa', 'Pepa is a good film maker ;)'),
('Stivi', 'Stivi is a good film maker ;)')

INSERT INTO Genres(GenreName, Notes) VALUES
('Horror', 'very scary'),
('Comedy', 'very comedy'),
('Triler', 'very triler'),
('funny', 'very funny'),
('Shortmovie', 'very short')

INSERT INTO Categories(CategoryName, Notes) VALUES
('fantasy', NULL),
('fantasyY', NULL),
('fantasyYY', NULL),
('fantasyYYY', NULL),
('fantasyYYY', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('King- kong', 1, 2001, 96, 1, 1, 10, 'nice'),
('King- kongg', 2, 2010, 97, 2, 2, 5, 'nice'),
('Kingg- kong', 3, 2020, 92, 3, 3, 10, 'nice'),
('Kinggg- kong', 4, 2002, 93, 4, 4, 9, 'nice'),
('King- konggg', 5, 2003, 87, 5, 5, 8, 'nice')