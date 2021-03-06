CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR (50), 
	LastName VARCHAR (50), 
	MiddleName VARCHAR (50), 
	JobTitle VARCHAR (50),
    DepartmentId INT, 
	Salary DECIMAL (15,2)
)

CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted