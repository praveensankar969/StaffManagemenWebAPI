CREATE PROCEDURE InsertData @UserName VARCHAR(25)
	,@Password VARCHAR(20)
	,@Experience INTEGER
	,@DateOfJoining DATETIME
	,@PhoneNumber VARCHAR(10)
	,@Subject VARCHAR(15)
	,@Type VARCHAR(15)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO customers (
		UserName
		,Password
		,Experience
		,DateOfJoining
		,PhoneNumber
		,Subject
		,Type
		)
	VALUES (
		@UserName
		,@Password
		,@Experience
		,@DateOfJoining
		,@PhoneNumber
		,@Subject
		,@Type
		)
END