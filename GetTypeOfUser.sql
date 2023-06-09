CREATE PROC GetTypeOfUser
@username char(15),
@password char(15)
AS
	SELECT type
	FROM account
	WHERE username = @username AND password = @password