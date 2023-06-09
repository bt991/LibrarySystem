CREATE PROC GetActivityType
@type char(10)
AS
		SELECT *
		FROM activity
		WHERE type = @type