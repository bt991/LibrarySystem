CREATE PROC GetUsername
@username char(15)
AS
		SELECT *
		FROM activity
		WHERE username = @username