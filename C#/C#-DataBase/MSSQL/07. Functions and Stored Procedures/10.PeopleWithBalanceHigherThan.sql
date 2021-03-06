CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18,4)) AS
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders ah
		JOIN Accounts a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @number
	ORDER BY ah.FirstName, ah.LastName

GO
EXEC usp_GetHoldersWithBalanceHigherThan 15000