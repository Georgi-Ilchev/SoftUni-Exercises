SELECT COUNT(*) AS count
FROM TravelCards tc
JOIN Journeys j ON tc.JourneyId = j.Id
JOIN Colonists c ON c.Id = tc.ColonistId
WHERE j.Purpose LIKE 'Technical'
GROUP BY j.Purpose
