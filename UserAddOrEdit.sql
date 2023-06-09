CREATE PROC UserAddOrEdit
@accountID int,
@type char(5),
@username char(15),
@password char(15),
@userFirst char(25),
@userLast char(25),
@email varchar(50)
AS
	IF @accountID = 0
	BEGIN
		INSERT INTO account (type, username, password, userFirst, userLast, email)
		VALUES (@type, @username, @password, @userFirst, @userLast, @email)
	END
	ELSE
	BEGIN
		UPDATE account
		SET
			type = @type,
			username = @username,
			password = @password,
			userFirst = @userFirst,
			userLast = @userLast,
			email = @email
		WHERE accountID = @accountID
	END