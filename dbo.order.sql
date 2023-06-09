CREATE TABLE [dbo].[order]
(
	[orderID] DECIMAL(3) NOT NULL PRIMARY KEY, 
    [orderType] CHAR(4) NOT NULL, 
    [bookCode] CHAR(4) NOT NULL, 
    [price] DECIMAL(4, 2) NOT NULL, 
    [amount] DECIMAL(2) NOT NULL
)
