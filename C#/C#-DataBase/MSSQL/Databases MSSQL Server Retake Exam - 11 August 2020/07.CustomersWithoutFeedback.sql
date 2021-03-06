SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   c.PhoneNumber,
	   c.Gender
FROM Customers c
LEFT JOIN Feedbacks f ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id ASC