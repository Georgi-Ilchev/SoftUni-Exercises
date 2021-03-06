CREATE PROC usp_AssignProject(@emPloyeeId INT, @projectID INT)
AS
BEGIN TRAN
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emPloyeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

IF(@employee IS NULL OR @project IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid employee id or project id!', 16, 1)
	RETURN
END

DECLARE @employeeProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emPloyeeId)

IF(@employeeProjects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!',16,2)
END

INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
							 (@emPloyeeId, @projectID)
COMMIT

--
EXEC usp_AssignProject 2, 1

SELECT * FROM EmployeesProjects WHERE EmployeeID = 2