CREATE FUNCTION udf_GetCost(@jobsId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
DECLARE @result DECIMAL(15,2)
SET @result = (SELECT SUM(p.Price * op.Quantity) AS TotalSum
			   FROM Jobs j
			   JOIN Orders o ON j.JobId = o.JobId
			   JOIN OrderParts op ON op.OrderId = o.OrderId
			   JOIN Parts p ON p.PartId = op.PartId
			   WHERE j.JobId = @jobsId
			   GROUP BY j.JobId)

IF(@result IS NULL)
	SET @result = 0
	RETURN @result
END