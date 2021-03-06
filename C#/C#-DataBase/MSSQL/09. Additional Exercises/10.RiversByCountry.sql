SELECT c.CountryName AS CountryName,
	   ct.ContinentName,
	   ISNULL(COUNT(r.Id), 0) AS RiversCount,
	   ISNULL(SUM(r.Length), 0) AS TotalLength
FROM Countries c
JOIN Continents ct ON c.ContinentCode = ct.ContinentCode
LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryName, ct.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName ASC