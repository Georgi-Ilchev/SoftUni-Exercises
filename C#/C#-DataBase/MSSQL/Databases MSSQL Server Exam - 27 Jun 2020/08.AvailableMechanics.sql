SELECT CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics m
LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
WHERE j.JobId IS NULL OR
		      'Finished' = ALL(Select j.[Status]
							   FROM Jobs j
							   WHERE j.MechanicId = m.MechanicId)
GROUP BY FirstName, LastName, m.MechanicId
ORDER BY m.MechanicId