CREATE PROCEDURE usp_GetEmployeesFromTown(@townName VARCHAR(MAX)) AS
	SELECT e.FirstName, e.LastName
	FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName

GO
EXEC dbo.usp_GetEmployeesFromTown 'Sofia'