CREATE PROC ViewUsers
AS
	SELECT *
	FROM account
	ORDER BY type ASC, username ASC