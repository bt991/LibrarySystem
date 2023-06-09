CREATE PROC DeleteUserFromDB
@accountID int
AS
	DELETE
	FROM account
	WHERE accountID = @accountID

	DELETE
	FROM activity
	WHERE accountID = @accountID