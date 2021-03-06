CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(MAX) 
AS
BEGIN
	DECLARE @result VARCHAR(MAX)
	IF @salary < 30000
	SET @result = 'Low'

	ELSE IF @salary <= 50000
	SET @result = 'Average'

	ELSE
	SET @result = 'High'

	RETURN @result
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees