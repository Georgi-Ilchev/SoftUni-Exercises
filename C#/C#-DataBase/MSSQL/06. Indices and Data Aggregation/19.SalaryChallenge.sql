SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees e
WHERE e.Salary > (SELECT AVG(Salary)
                  FROM Employees e1
                  WHERE e.DepartmentID = e1.DepartmentID)
ORDER BY e.DepartmentID