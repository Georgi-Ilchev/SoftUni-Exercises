CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) 
AS
SELECT a.Id, ah.FirstName, ah.LastName, a.Balance,
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
 FROM AccountHolders ah
 JOIN Accounts a ON ah.Id = a.AccountHolderId
 WHERE A.Id = @accountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1