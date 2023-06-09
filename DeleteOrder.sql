CREATE PROC DeleteOrder
@orderID int
AS
	DELETE
	FROM adminOrders
	WHERE orderID = @orderID