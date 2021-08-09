CREATE TYPE [dbo].[BulkInsertTable] AS TABLE (
    [UserName]      [dbo].[UserName]      NOT NULL,
    [Password]      [dbo].[Password]      NOT NULL,
    [Experience]    [dbo].[Experience]    NULL,
    [DateOfJoining] [dbo].[DateOfJoining] NULL,
    [PhoneNumber]   [dbo].[PhoneNumber]   NULL,
    [Subject]       [dbo].[Subject]       NULL,
    [Type]          [dbo].[Type]          NULL);

