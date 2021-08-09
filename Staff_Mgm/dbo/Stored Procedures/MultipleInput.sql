CREATE PROCEDURE MultipleInput @input [dbo].[BulkInsertTable] readonly
AS
BEGIN
	INSERT INTO customers (
		UserName
		,Password
		,Experience
		,DateOfJoining
		,PhoneNumber
		,Subject
		,Type
		)
	SELECT *
	FROM @input
END