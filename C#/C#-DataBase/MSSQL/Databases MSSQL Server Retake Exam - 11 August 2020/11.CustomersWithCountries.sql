CREATE OR ALTER VIEW v_UserWithCountries AS
SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   ct.[Name] AS CountryName
FROM Customers c
JOIN Countries ct ON c.CountryId = ct.Id

GO
--only 'create' and without 'go' for judge
SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age
