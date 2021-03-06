CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000 

--WHERE DATEPART(YEAR, HireDate) > 2000