CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(MAX),
	Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT AccountId FROM inserted)
	DECLARE @oldSum DECIMAL (15,2) = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @newSum DECIMAL (15,2) = (SELECT TOP(1) NewSum FROM inserted)

	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
	(
		@accountId,
		'Balance change for account: ' + CAST(@accountId AS varchar(20)),
		'On ' + CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + 
		CAST(@oldSum AS varchar(20)) + ' to ' + 
		CAST(@newSum AS varchar(20))
	)

	UPDATE Accounts
	SET Balance += 100
	WHERE Id = 1

	SELECT * FROM Accounts 
	WHERE Id = 1