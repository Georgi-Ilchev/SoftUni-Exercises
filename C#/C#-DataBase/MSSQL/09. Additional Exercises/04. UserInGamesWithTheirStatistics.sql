WITH help AS (SELECT ug.UserId,
					 ug.GameId,
					 SUM(s.Strength) AS Strength,
					 SUM(s.Defence) AS Defence,
					 SUM(s.Speed) AS Speed,
					 SUM(s.Mind) AS Mind,
					 SUM(s.Luck) AS Luck
			  FROM UsersGames ug
			  JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
			  JOIN Items i ON ugi.ItemId = i.Id
			  JOIN [Statistics] s ON s.Id = i.StatisticId
			  GROUP BY ug.UserId, ug.GameId)



SELECT DISTINCT u.Username,
				g.[Name] AS Game,
				MAX(c.[Name]) AS [Character],
				MAX(s1.Strength) + MAX(s2.Strength) + MAX(h.Strength) AS Strength,
				MAX(s1.Defence) + MAX(s2.Defence) + MAX(h.Defence) AS Defence,
				MAX(s1.Speed) + MAX(s2.Speed) + MAX(h.Speed) AS Speed,
				MAX(s1.Mind) + MAX(s2.Mind) + MAX(h.Mind) AS Mind,
				MAX(s1.Luck) + MAX(s2.Luck) + MAX(h.Luck) AS Luck
FROM UsersGames ug
JOIN Users u ON u.Id = ug.UserId
JOIN Games g ON g.Id = ug.GameId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
JOIN Characters c ON c.Id = ug.CharacterId
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN [Statistics] s1 ON s1.Id = c.StatisticId
JOIN [Statistics] s2 ON s2.Id = gt.BonusStatsId
JOIN help h ON h.UserId = u.Id AND
			   h.GameId = g.Id
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC