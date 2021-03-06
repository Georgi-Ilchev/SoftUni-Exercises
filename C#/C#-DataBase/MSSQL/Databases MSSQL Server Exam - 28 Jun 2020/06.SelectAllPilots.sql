SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS [full_name]
FROM TravelCards tc
JOIN Colonists c ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.id