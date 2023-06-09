CREATE PROC GetUserID
@accountID int
AS
		SELECT *
		FROM activity
		WHERE accountID = @accountID