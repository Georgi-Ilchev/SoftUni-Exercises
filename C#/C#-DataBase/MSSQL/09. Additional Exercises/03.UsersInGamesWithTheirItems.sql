SELECT 	u.Username,
		g.[Name] AS Game,
		COUNT(i.Id) AS [Items Count],
		SUM(i.Price) AS [Items Price]
FROM UsersGames ug
JOIN Users u ON u.Id = ug.UserId
JOIN Games g ON g.Id = ug.GameId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
GROUP BY u.Username, g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC
