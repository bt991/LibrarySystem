CREATE PROC ActivityByUsername
@username char(15)
AS
	SELECT *
	FROM activity
	WHERE accountID IN 
		(SELECT accountID
		FROM activity
		WHERE username = @username)