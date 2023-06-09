CREATE TABLE [dbo].[activity] (
    [activityID] DECIMAL (3) IDENTITY (1, 1) NOT NULL,
    [username]   CHAR (15)   NOT NULL,
    [userFirst]  CHAR (25)   NOT NULL,
    [userLast]   CHAR (25)   NOT NULL,
    [type]       CHAR (10)   NOT NULL,
    [bookCode]   CHAR (4)    NOT NULL,
    [title]      CHAR (40)   NOT NULL,
    [accountID] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([activityID] ASC)
);

