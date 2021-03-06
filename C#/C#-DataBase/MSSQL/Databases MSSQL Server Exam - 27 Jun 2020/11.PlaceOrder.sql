CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50), @quantity INT)
AS
BEGIN
	IF(@quantity <= 0)
	THROW 50012, 'Part quantity must be more than zero!', 1 

	IF(@jobId IN (SELECT JobId FROM Jobs WHERE [Status] = 'Finished'))
	THROW 50011, 'This job is not active!', 1

	IF(@jobId NOT IN (SELECT JobId FROM Jobs))
	THROW 50013, 'Job not found!', 1

	IF(@serialNumber NOT IN (SELECT SerialNumber FROM Parts))
	THROW 50014, 'Part not found!', 1


	IF(@jobId IN (SELECT JobId FROM Orders) AND
				 (SELECT IssueDate FROM Orders WHERE JobId = @jobId) IS NULL)
	BEGIN
		DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)
		DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

		IF(@orderId IN (SELECT OrderId FROM OrderParts) AND @partId IN (SELECT PartId FROM OrderParts))
		BEGIN
			UPDATE OrderParts
			SET Quantity += @quantity
			WHERE OrderId = @orderId AND PartId = @partId
		END
		ELSE
		BEGIN
			INSERT INTO OrderParts(OrderId, PartId, Quantity) 
			VALUES (@orderId, @partId, @quantity)
		END
	END
COMMIT
END

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


--10/10w

CREATE PROCEDURE usp_PlaceOrder(@JobId INT, @PartSerialNumber VARCHAR(50), @Quantity INT)
AS
    IF ((SELECT Status
         FROM Jobs
         WHERE JobId = @JobId) = 'Finished')
        THROW 50011, 'This job is not active!', 1
    IF (@Quantity <= 0)
        THROW 50012, 'Part quantity must be more than zero!', 1

DECLARE
    @job INT = (SELECT JobId
                FROM Jobs
                WHERE JobId = @JobId)
    IF (@job IS NULL)
        THROW 50013, 'Job not found!', 1

DECLARE
    @partId INT = (SELECT PartId
                   FROM Parts
                   WHERE SerialNumber = @PartSerialNumber)
    IF (@partId IS NULL)
        BEGIN
            THROW 50014, 'Part not found!', 1
        END
    IF ((SELECT OrderId
         FROM Orders
         WHERE JobId = @JobId
           AND IssueDate IS NULL) IS NULL)
        BEGIN
            INSERT INTO Orders (JobId, IssueDate, Delivered)
            VALUES (@JobId, NULL, 0)
        END

DECLARE
    @orderId INT= (
        SELECT OrderId
        FROM Orders
        WHERE JobId = @JobId
          AND IssueDate IS NULL
    )

DECLARE
    @orderPartsQuantity INT = (SELECT Quantity
                               FROM OrderParts
                               WHERE OrderId = @orderId
                                 AND PartId = @partId)
    IF (@orderPartsQuantity IS NULL)
        BEGIN
            INSERT INTO OrderParts (OrderId, PartId, Quantity)
            VALUES (@orderId, @partId, @Quantity)
        END
    ELSE
        BEGIN
            UPDATE OrderParts
            SET Quantity += @Quantity
            WHERE OrderId = @orderId
              AND PartId = @partId
        END