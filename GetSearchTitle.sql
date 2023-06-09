CREATE PROC GetSearchTitle
@title char(40)
AS
BEGIN
	SELECT book.bookCode,book.title,book.genre,author.authorLast,author.authorFirst,inventory.inStock,inventory.amount,book.authorNum,book.publisherCode
	FROM book INNER JOIN author
		ON book.authorNum = author.authorNum
			  INNER JOIN inventory
		ON book.bookCode = inventory.bookCode
	WHERE book.title = @title
END