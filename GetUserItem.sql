CREATE PROC GetUserItem
@username char(15)
AS
		SELECT *
		FROM account
		WHERE username = @username