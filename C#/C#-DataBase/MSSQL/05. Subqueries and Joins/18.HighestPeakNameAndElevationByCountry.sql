SELECT TOP(5) k.Country, k.[Highest Peak Name], k.[Highest Peak Elevation], k.Mountain
FROM (SELECT
		 CountryName AS Country,
		 ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
		 ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
		 ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
		 DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
	  FROM Countries c
	  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	  LEFT JOIN Mountains m ON mc.MountainId = m.Id
	  LEFT JOIN Peaks p ON m.Id = p.MountainId
	  GROUP BY CountryName, p.PeakName, m.MountainRange) AS k
WHERE Ranked = 1
ORDER BY Country, [Highest Peak Name]
