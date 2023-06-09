CREATE PROC OrderAddOrEdit
@orderID int,
@orderType char(4),
@bookCode char(4),
@title char(40),
@amount decimal(2,0),
@authorNum decimal(2,0)
AS
	IF @orderID = 0
	BEGIN
		INSERT INTO adminOrders (orderType, bookCode, title, amount, authorNum)
		VALUES (@orderType, @bookCode, @title, @amount, @authorNum)
	END
	ELSE
	BEGIN
		UPDATE adminOrders
		SET
			orderType = @orderType,
			bookCode = @bookCode,
			title = @title,
			amount = @amount,
			authorNum = @authorNum
		WHERE orderID = @orderID
	END