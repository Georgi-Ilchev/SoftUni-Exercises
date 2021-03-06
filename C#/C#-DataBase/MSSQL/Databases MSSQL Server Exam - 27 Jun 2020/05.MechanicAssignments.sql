SELECT CONCAT(m.FirstName, ' ', M.LastName) AS Mechanic,
	   j.[Status],
	   j.IssueDate
FROM Jobs j
JOIN Mechanics m ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId