CREATE PROC ViewUserActivity
AS
	SELECT *
	FROM activity
	ORDER BY accountID ASC, username ASC