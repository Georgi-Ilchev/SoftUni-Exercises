SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries C
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON mc.MountainId = m.Id
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode
