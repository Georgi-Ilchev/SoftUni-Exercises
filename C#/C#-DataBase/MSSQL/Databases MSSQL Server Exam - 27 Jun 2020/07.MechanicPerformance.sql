SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId 

