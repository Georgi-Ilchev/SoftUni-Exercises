SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
WHERE p.Elevation > 2835 AND
	  mc.CountryCode LIKE 'BG'
ORDER BY p.Elevation DESC