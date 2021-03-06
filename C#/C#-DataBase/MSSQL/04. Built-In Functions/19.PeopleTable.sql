USE Orders

CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL,
	BirthDate DATE NOT NULL
)

INSERT INTO People([Name], BirthDate)
VALUES ('Victor', '2000-12-07 00:00:00.000'),
       ('Steven', '1992-09-10 00:00:00.000'),
       ('Stephen', '1910-09-19 00:00:00.000'),
       ('John', '2010-01-06 00:00:00.000')


SELECT [Name],
	DATEDIFF(YEAR, BirthDate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, BirthDate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, BirthDate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, BirthDate, GETDATE()) AS [Age in Minutes]
FROM People