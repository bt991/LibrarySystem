CREATE PROC ActivityIDByTitle
@title char(40)
AS
	SELECT activityID
	FROM activity
	WHERE title = @title