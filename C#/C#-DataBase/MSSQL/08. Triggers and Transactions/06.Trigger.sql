--1-------------
SELECT * 
FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
WHERE ug.Id = 38

SELECT * 
FROM Items
WHERE Id = 2

SELECT * 
FROM UserGameItems
WHERE UserGameId = 38 AND ItemId = 14

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (14, 38)

CREATE OR ALTER TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT = (SELECT ItemId FROM inserted)
DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF (@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
	(@itemId, @userGameId)
END



--2--------------
SELECT * 
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
WHERE g.Name = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

UPDATE UsersGames
SET Cash += 50000
WHERE GameId = (SELECT Id FROM Games WHERE Name = 'Bali') AND 
	  UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))



--3------------
CREATE OR ALTER PROC usp_BuyItem (@userId INT, @itemId INT, @gameId INT)
AS
BEGIN TRANSACTION
DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)

IF (@user IS NULL OR @item IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid user or item id!', 16, 1)
	RETURN
END

DECLARE @userCash DECIMAL(15,2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemPrice DECIMAL (15,2) = (SELECT Price FROM Items WHERE Id = @itemId)

IF(@userCash - @itemPrice < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds!', 16, 2)
	RETURN
END

UPDATE UsersGames
SET Cash -= @itemPrice
WHERE UserId = @userId AND GameId = @gameId

DECLARE @userGameID DECIMAL(15,2) = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (@itemId, @userGameID)

COMMIT


DECLARE @counter INT = 251;

WHILE(@counter <= 299)
BEGIN
	EXEC usp_BuyItem 22, @counter, 212
	EXEC usp_BuyItem 37, @counter, 212
	EXEC usp_BuyItem 52, @counter, 212
	EXEC usp_BuyItem 61, @counter, 212

	SET @counter += 1;
END

DECLARE @counter2 INT = 501;

WHILE(@counter2 <= 539)
BEGIN
	EXEC usp_BuyItem 22, @counter2, 212
	EXEC usp_BuyItem 37, @counter2, 212
	EXEC usp_BuyItem 52, @counter2, 212
	EXEC usp_BuyItem 61, @counter2, 212

	SET @counter2 += 1;
END

SELECT * FROM UsersGames WHERE GameId = 212;




--4--------------
SELECT u.Username, g.[Name], ug.Cash, i.[Name] 
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games G on ug.GameId = g.Id
JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
JOIN Items i ON ugi.ItemId = i.Id
WHERE g.[Name] = 'Bali'
ORDER BY u.Username, i.[Name]