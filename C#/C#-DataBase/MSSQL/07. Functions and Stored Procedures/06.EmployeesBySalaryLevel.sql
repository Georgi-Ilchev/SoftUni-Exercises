CREATE PROC usp_EmployeesBySalaryLevel(@parameterLevel VARCHAR(MAX)) AS
	SELECT	e.FirstName, e.LastName
	FROM Employees e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @parameterLevel

GO
EXEC usp_EmployeesBySalaryLevel 'high'