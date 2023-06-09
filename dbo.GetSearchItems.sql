CREATE PROC GetSearchItems
AS
BEGIN
	SELECT bookCode,title,genre,authorLast,authorFirst,inStock
	FROM book JOIN author
	ON book.authorNum = author.authorNum
END