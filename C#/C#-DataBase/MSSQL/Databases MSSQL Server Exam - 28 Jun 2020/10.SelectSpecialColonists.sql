SELECT *
FROM (SELECT 
			tc.JobDuringJourney,
			c.FirstName + ' ' + c.LastName AS FullName,
			DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
		FROM TravelCards tc
		JOIN Colonists c ON c.Id = tc.ColonistId) AS RankQuery
WHERE JobRank = 2
