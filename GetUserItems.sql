CREATE PROC GetUserItems
@username char(15),
@userFirst char(25),
@userLast char(25)
AS
	IF @userFirst = NULL AND @userLast = NULL
	BEGIN
		SELECT *
		FROM account
		WHERE username = @username
	END
	ELSE
	IF @username = NULL AND @userLast = NULL
	BEGIN
		SELECT *
		FROM account
		WHERE userFirst = @userFirst
	END
	ELSE
	IF @username = NULL AND @userFirst = NULL
	BEGIN
		SELECT *
		FROM account
		WHERE userLast = @userLast
	END