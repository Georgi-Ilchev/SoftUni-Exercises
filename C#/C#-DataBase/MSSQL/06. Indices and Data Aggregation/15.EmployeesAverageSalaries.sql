SELECT * 
INTO EmployeesAverageSalaries
FROM Employees
WHERE Salary > 30000

DELETE 
	FROM EmployeesAverageSalaries
	WHERE ManagerID LIKE '42'

UPDATE EmployeesAverageSalaries
SET Salary += 5000
WHERE DepartmentID LIKE '1'

SELECT DepartmentID,
	   AVG(Salary) AS AverageSalary
FROM EmployeesAverageSalaries
GROUP BY DepartmentID
