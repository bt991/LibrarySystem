CREATE PROC GetUserLastName
@userLast char(25)
AS
		SELECT *
		FROM account
		WHERE userLast = @userLast