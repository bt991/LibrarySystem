CREATE PROC [GetUserFirstName]
@userFirst char(25)
AS
		SELECT *
		FROM account
		WHERE userFirst = @userFirst