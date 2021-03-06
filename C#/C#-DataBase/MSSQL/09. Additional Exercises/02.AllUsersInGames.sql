SELECT 
	g.[Name] AS Game,
	gt.[Name] AS [Game Type],
	u.Username AS Username,
	ug.[Level] AS [Level],
	ug.Cash,
	c.[Name] AS [Character]
FROM UsersGames ug
JOIN Games g ON g.Id = ug.GameId
JOIN GameTypes gt ON g.GameTypeId = gt.Id
JOIN Users u ON ug.UserId = u.Id
JOIN Characters c ON c.Id = ug.CharacterId
ORDER BY [Level] DESC, Username, Game