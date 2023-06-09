CREATE TABLE [dbo].[account] (
    [accountID] INT           NOT NULL ,
    [type]      CHAR (5)      NULL,
    [username]  CHAR (15)     NULL,
    [password]  CHAR (15)     NULL,
    [userFirst] CHAR (25)     NULL,
    [userLast]  CHAR (25)     NULL,
    [email]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([accountID] ASC)
);

