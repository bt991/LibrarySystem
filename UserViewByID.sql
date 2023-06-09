CREATE PROC UserViewByID
@accountID int
AS
	SELECT *
	FROM account
	WHERE accountID = @accountID