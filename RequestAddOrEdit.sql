CREATE PROC RequestAddOrEdit
@activityID decimal(3,0),
@username char(15),
@userFirst char(25),
@userLast char(25),
@type char(10),
@bookCode char(4),
@title char(40),
@accountID int
AS
	IF @activityID = 0
	BEGIN
		INSERT INTO activity (username, userFirst, userLast, type, bookCode, title, accountID)
		VALUES (@username, @userFirst, @userLast, @type, @bookCode, @title, @accountID)
	END
	ELSE
	BEGIN
		UPDATE activity
		SET
			username = @username,
			userFirst = @userFirst,
			userLast = @userLast,
			type = @type,
			bookCode = @bookCode,
			title = @title
		WHERE activityID = @activityID
	END