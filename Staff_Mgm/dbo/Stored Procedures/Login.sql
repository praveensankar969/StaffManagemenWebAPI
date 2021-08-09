CREATE PROCEDURE LOGIN @UserName VARCHAR(15)
	,@Password VARCHAR(15)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM customers
	WHERE Username = @UserName
		AND Password = @Password
END