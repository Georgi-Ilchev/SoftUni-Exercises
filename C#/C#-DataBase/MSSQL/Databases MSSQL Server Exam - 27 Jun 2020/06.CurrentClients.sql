SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	   DATEDIFF(DAY, IssueDate, '04/24/2017') AS [Days going],
	   [Status]
FROM Clients c
JOIN Jobs j ON c.ClientId = j.ClientId
WHERE [Status] <> 'Finished'