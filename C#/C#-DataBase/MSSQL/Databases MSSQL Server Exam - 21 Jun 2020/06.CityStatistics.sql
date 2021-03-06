SELECT c.[Name] AS City,
	   COUNT(c.Id) AS Hotels
FROM Hotels h
JOIN Cities c ON h.CityId = c.Id
GROUP BY c.Id, c.[Name]
ORDER BY Hotels DESC, City