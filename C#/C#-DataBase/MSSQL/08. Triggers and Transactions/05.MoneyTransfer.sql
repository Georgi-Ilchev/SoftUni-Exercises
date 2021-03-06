CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId, @Amount
EXEC usp_DepositMoney @receiverId, @Amount
COMMIT

SELECT * FROM Accounts WHERE Id = 1 OR Id = 2
EXEC usp_TransferMoney 2, 1, 500