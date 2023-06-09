CREATE PROC ViewBooks
AS
	SELECT book.bookCode
	FROM book
		INNER JOIN adminOrders
	ON book.bookCode = adminOrders.bookCode
	ORDER BY book.bookCode ASC