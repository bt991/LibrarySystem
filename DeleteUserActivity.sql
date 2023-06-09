CREATE PROC DeleteUserActivity
@activityID int
AS
	DELETE FROM activity
	WHERE activityID = @activityID