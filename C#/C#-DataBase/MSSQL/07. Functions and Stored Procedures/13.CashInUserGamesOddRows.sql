CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
	RETURN (SELECT SUM(k.TotalCash) AS TotalCash
	FROM (SELECT Cash AS TotalCash,
	   ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
       FROM Games g
       JOIN UsersGames ug ON g.Id = ug.GameId
       WHERE [Name] = @gameName) k
WHERE k.RowNumber % 2 != 0)

GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')