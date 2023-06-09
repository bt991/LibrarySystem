CREATE PROC CheckValidBook
@bookCode char(4),
@title char(40)
AS
	SELECT book.bookCode,book.title,inventory.amount
	FROM book JOIN inventory
	ON book.bookCode = inventory.bookCode
	WHERE book.bookCode = @bookCode AND book.title = @title