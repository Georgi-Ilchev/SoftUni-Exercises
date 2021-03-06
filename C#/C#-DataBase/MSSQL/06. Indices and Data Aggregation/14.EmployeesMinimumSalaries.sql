SELECT DepartmentID,
	   MIN(Salary) AS MinumumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND 
	  HireDate > '01-01-2000'
GROUP BY DepartmentID