SELECT 
	FirstName, 
	LastName, 
	FORMAT(BirthDate, 'MM-dd-yyyy'), 
	c.[Name] AS HomeTown,
	Email
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY HomeTown