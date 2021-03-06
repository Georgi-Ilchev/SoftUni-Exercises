SELECT c.ContinentName AS ContinentName,
	   SUM(CONVERT(BIGINT,cou.AreaInSqKm)) AS CountriesArea,
	   SUM(CONVERT(BIGINT,cou.[Population])) AS [Population]
FROM Continents c
JOIN Countries cou ON c.ContinentCode = cou.ContinentCode
GROUP BY c.ContinentName
ORDER BY [Population] DESC



SELECT c.ContinentName AS ContinentName,
	   SUM(CAST((cou.AreaInSqKm) AS BIGINT)) AS CountriesArea,
	   SUM(CAST((cou.[Population]) AS BIGINT)) AS [Population]
FROM Continents c
JOIN Countries cou ON c.ContinentCode = cou.ContinentCode
GROUP BY c.ContinentName
ORDER BY [Population] DESC