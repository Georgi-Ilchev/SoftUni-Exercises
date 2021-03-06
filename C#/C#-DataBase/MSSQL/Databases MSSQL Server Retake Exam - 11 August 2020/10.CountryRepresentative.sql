SELECT c.CountryName, 
	   c.DistributorName
FROM (SELECT c.[Name] AS CountryName,
	         d.[Name] AS DistributorName,
	         DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS top1
		FROM Countries c
		JOIN Distributors d ON d.CountryId = c.Id
		LEFT JOIN Ingredients i ON d.Id = i.DistributorId
		GROUP BY c.[Name], d.[Name]) AS c
WHERE c.top1 = 1
ORDER BY c.CountryName, c.DistributorName