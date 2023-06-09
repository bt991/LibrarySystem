CREATE PROC BookAddOrEdit
@bookCode char(4),
@title char(40),
@publisherCode char(3),
@genre char(3),
@authorNum decimal(2,0)
AS
	IF @bookCode = NULL
	BEGIN
		INSERT INTO book(bookCode, title, publisherCode, genre, authorNum)
		VALUES (@bookCode, @title, @publisherCode, @genre, @authorNum)
	END
	ELSE
	BEGIN
		UPDATE book
		SET
			bookCode = @bookCode,
			title = @title,
			publisherCode = @publisherCode,
			genre = @genre,
			authorNum = @authorNum
		WHERE bookCode = @bookCode
	END