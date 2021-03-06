CREATE OR ALTER PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(15,4)) AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)
DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

IF(@account IS NULL)
BEGIN 
	ROLLBACK
	RAISERROR('Invalid account id!', 16,1)
	RETURN
END

IF(@MoneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16,1)
	RETURN
END

IF(@accountBalance - @MoneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds!', 16,1)
	RETURN
END

UPDATE Accounts
SET Balance -= @MoneyAmount
WHERE Id = @AccountId
COMMIT


SELECT * FROM Accounts WHERE ID = 1
EXEC usp_WithdrawMoney 1, 200