SELECT s.[Name],
	   s.Manufacturer
FROM TravelCards tc
JOIN Colonists c ON c.Id = tc.ColonistId
JOIN Journeys j ON j.Id = tc.JourneyId
JOIN Spaceships s ON s.Id = j.SpaceshipId
WHERE DATEDIFF(YEAR, BirthDate, '01/01/2019') < 30
	  AND tc.JobDuringJourney LIKE 'Pilot'
ORDER BY s.[Name]
