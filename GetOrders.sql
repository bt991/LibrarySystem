CREATE PROC GetOrders
AS
BEGIN
	SELECT adminOrders.orderID, adminOrders.orderType, adminOrders.bookCode, adminOrders.title, adminOrders.amount,adminOrders.authorNum, author.authorLast, author.authorFirst
	FROM adminOrders INNER JOIN author
		ON adminOrders.authorNum = author.authorNum
END