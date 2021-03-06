SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
  FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
 WHERE e.HireDate > '1999-01-01' AND
	(d.[Name] IN ('Sales', 'Finance'))
ORDER BY HireDate




SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
  FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Sales', 'Finance')
 WHERE e.HireDate > '1999-01-01'
ORDER BY HireDate