SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] 
FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start], [Name]

--WHERE YEAR([Start]) >= 2011 AND 
--		YEAR([Start]) <= 2012

--WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012