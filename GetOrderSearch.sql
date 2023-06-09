CREATE PROC GetOrderSearch
AS
BEGIN
	SELECT adminOrders.bookCode,book.title,book.authorNum,inventory.amount

	FROM adminOrders
			INNER JOIN book
		ON adminOrders.bookCode = book.bookCode
			INNER JOIN inventory
		ON adminOrders.bookCode = inventory.bookCode
END