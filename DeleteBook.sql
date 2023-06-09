CREATE PROC DeleteBook
@bookCode char(4)
AS
	DELETE
	FROM book
	WHERE bookCode = @bookCode