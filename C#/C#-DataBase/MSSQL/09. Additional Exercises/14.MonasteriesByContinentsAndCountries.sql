--1
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

--2--3
INSERT INTO Monasteries ([Name], CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

--4
SELECT c.ContinentName AS ContinentName,
	   cu.CountryName AS CountryName,
	   COUNT(m.Id) AS MonasteriesCount
FROM Continents c
JOIN Countries cu ON c.ContinentCode = cu.ContinentCode
LEFT JOIN Monasteries m ON m.CountryCode = cu.CountryCode
WHERE IsDeleted = 0
GROUP BY c.ContinentName, cu.CountryName
ORDER BY MonasteriesCount DESC, CountryName ASC