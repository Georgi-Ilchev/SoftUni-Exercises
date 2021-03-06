CREATE OR ALTER PROC usp_DepositMoney(@AccountID INT, @MoneyAmmount DECIMAL (15,4)) AS
BEGIN TRANSACTION

	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountID)

	IF(@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account id!', 16,1)
		RETURN
	END

	IF(@MoneyAmmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Negative amount!', 16,1)
		RETURN
    END

    UPDATE Accounts
	SET Balance += @MoneyAmmount
	WHERE Id = @AccountID
COMMIT

EXEC usp_DepositMoney 1, 247.78
SELECT * FROM Logs
SELECT * FROM NotificationEmails WHERE Id = 1