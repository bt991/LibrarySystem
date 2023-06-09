CREATE PROC DeleteUserRequest
@activityID int
AS
	DELETE FROM activity
	WHERE activityID = @activityID