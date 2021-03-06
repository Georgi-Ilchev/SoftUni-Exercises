DECLARE @userName VARCHAR(50) = 'Stamat'
DECLARE @gameName VARCHAR(50) = 'Safflower'

DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = @userName)
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = @gameName)

DECLARE @userMoney DECIMAL (15,4) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemsTotalPrice DECIMAL(15,4)
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

BEGIN TRANSACTION
	SET @ItemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	IF(@UserMoney - @ItemsTotalPrice >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameID FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)

		UPDATE UsersGames
		SET Cash -= @ItemsTotalPrice
		WHERE GameId = @GameID AND UserId = @UserID
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
BEGIN TRANSACTION
	SET @ItemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

	IF(@UserMoney - @ItemsTotalPrice >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameID FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)

		UPDATE UsersGames
		SET Cash -= @ItemsTotalPrice
		WHERE GameId = @GameID AND UserId = @UserID
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SELECT [Name] AS [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @userGameID)
ORDER BY [Item Name]
