CREATE TABLE [dbo].[inventory]
(
	[bookCode] CHAR(4) NOT NULL PRIMARY KEY, 
    [inStock] CHAR(2) NOT NULL, 
    [amount] DECIMAL(2) NULL
)
