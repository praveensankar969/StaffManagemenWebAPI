CREATE TABLE [dbo].[customers] (
    [Id]            INT          IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [UserName]      VARCHAR (25) NOT NULL,
    [Password]      VARCHAR (20) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    [Experience]    INT          NULL,
    [DateOfJoining] DATETIME     NULL,
    [PhoneNumber]   VARCHAR (10) NULL,
    [Subject]       VARCHAR (15) NULL,
    [Type]          VARCHAR (15) NULL
);


GO
CREATE CLUSTERED INDEX [user_index]
    ON [dbo].[customers]([UserName] ASC);


GO
CREATE NONCLUSTERED INDEX [exp_index]
    ON [dbo].[customers]([Experience] ASC);

