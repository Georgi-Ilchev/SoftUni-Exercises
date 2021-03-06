--1
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryCode CHAR(2) NOT NULL FOREIGN KEY REFERENCES Countries(CountryCode)
)

--2
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--3
ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0

--4
UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (SELECT CountryCode 
					  FROM (SELECT c.CountryCode 
                            FROM Countries c
						        JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
						        JOIN Rivers ri ON ri.Id = cr.RiverId
						    GROUP BY c.CountryCode
						    HAVING COUNT(ri.RiverName) > 3) AS asd)

--5
SELECT m.[Name] AS Monastery,
	   c.CountryName AS Country
FROM Monasteries m
JOIN Countries c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.[Name]