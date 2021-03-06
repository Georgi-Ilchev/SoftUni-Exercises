CREATE TRIGGER DeleteProducts 
ON Products INSTEAD OF DELETE 
AS
BEGIN
	DECLARE @deletedProductId INT = (SELECT p.Id
								     FROM Products p
								     JOIN deleted d ON d.Id = p.Id)

	DELETE FROM ProductsIngredients
	WHERE ProductId = @deletedProductId

	DELETE FROM Feedbacks
	WHERE ProductId = @deletedProductId

	DELETE FROM Products
	WHERE Id = @deletedProductId
END