SELECT p.PeakName, m.MountainRange, c.CountryName, cn.ContinentName
FROM Peaks p
JOIN Mountains m ON m.Id = p.MountainId
JOIN MountainsCountries mc ON mc.MountainId = m.Id
JOIN Countries c ON mc.CountryCode = c.CountryCode
JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName