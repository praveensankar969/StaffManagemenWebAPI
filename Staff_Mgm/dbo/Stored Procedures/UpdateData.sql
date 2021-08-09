CREATE PROCEDURE UpdateData @Id INTEGER
	,@UserName VARCHAR(25) = NULL
	,@Password VARCHAR(20) = NULL
	,@Experience INTEGER = NULL
	,@DateOfJoining DATETIME = NULL
	,@PhoneNumber VARCHAR(10) = NULL
	,@Subject VARCHAR(15) = NULL
	,@Type VARCHAR(15) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE customers
	SET Username = isNull(@UserName, UserName)
		,Password = isNull(@Password, Password)
		,Experience = isNull(@Experience, Experience)
		,DateOfJoining = isNull(@DateOfJoining, DateOfJoining)
		,PhoneNumber = isNull(@PhoneNumber, PhoneNumber)
		,Subject = isNull(@Subject, Subject)
		,Type = isNull(@Type, Type)
	WHERE Id = @Id
END