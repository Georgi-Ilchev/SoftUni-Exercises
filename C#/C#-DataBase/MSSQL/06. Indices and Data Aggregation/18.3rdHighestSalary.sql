SELECT DepartmentID, ThirdHighestSalary 
FROM ( SELECT DepartmentID,
	   MAX(Salary) AS ThirdHighestSalary,
	   DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
       FROM Employees
       GROUP BY DepartmentID, Salary) AS SalaryRanking
WHERE SalaryRanking.[Rank] = 3



SELECT DISTINCT k.DepartmentID, k.Salary 
FROM (SELECT DepartmentID, Salary,
	  DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranked]
      FROM Employees) AS k
WHERE k.Ranked = 3