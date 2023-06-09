CREATE PROC GetSearchItems
AS
BEGIN
	SELECT book.bookCode,book.title,book.genre,book.publisherCode,
		book.authorNum,author.authorFirst,author.authorLast,inventory.inStock,
		inventory.amount

	FROM book
			INNER JOIN author
		ON book.authorNum = author.authorNum
			INNER JOIN inventory
		ON book.bookCode = inventory.bookCode
END