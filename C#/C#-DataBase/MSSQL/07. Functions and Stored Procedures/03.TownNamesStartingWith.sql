CREATE OR ALTER PROC usp_GetTownsStartingWith(@startingWord VARCHAR(MAX)) AS
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @startingWord + '%'

GO
EXEC dbo.usp_GetTownsStartingWith 'b'

--without 'OR ALTER' for judge!!!