SELECT Peaks.PeakName, 
		Rivers.RiverName,
		--LOWER (CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName)-1))) AS Mix
		LOWER (LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS MIX
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

