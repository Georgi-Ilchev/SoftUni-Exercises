CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(18,4), 
										 @yearlyInterestRate FLOAT, 
										 @numberOfYears INT)
RETURNS DECIMAL(18, 4) AS
BEGIN
	DECLARE @sum DECIMAL(18,4)

	SET @sum = @initialSum * (POWER((1 + @yearlyInterestRate), @numberOfYears))

	RETURN @sum
END
