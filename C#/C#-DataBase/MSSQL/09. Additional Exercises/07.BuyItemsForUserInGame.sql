DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = 'Alex');
DECLARE @GameId INT = (SELECT Id FROM Games WHERE [Name] = 'Edinburgh');
DECLARE @ugId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND
													 GameId = @GameId);



UPDATE UsersGames
SET Cash -= (SELECT SUM(i.Price)
			 FROM Items i
			 WHERE i.[Name] IN ('Blackguard', 'Bottomless Potion of Amplification',
                                'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin',
                                'Golden Gorget of Leoric', 'Hellfire Amulet'))
WHERE Id = @ugId								



INSERT INTO UserGameItems(ItemId, UserGameId) VALUES
((SELECT Id FROM Items WHERE [Name] = 'Blackguard'), @ugId),
((SELECT Id FROM Items WHERE [Name] = 'Bottomless Potion of Amplification'), @ugId),
((SELECT Id FROM Items WHERE [Name] = 'Eye of Etlich (Diablo III)'), @ugId),
((SELECT Id FROM Items WHERE [Name] = 'Gem of Efficacious Toxin'), @ugId),
((SELECT Id FROM Items WHERE [Name] = 'Golden Gorget of Leoric'), @ugId),
((SELECT Id FROM Items WHERE [Name] = 'Hellfire Amulet'), @ugId)



SELECT u.Username,
	   g.[Name],
	   ug.Cash,
	   i.[Name]
FROM UsersGames ug
JOIN Users u ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE g.[Name] = 'Edinburgh'
ORDER BY i.[Name]
