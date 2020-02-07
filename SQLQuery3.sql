CREATE TABLE [dbo].[Login] (
    [Login_Id] INT    NOT NULL PRIMARY KEY IDENTITY,
    [UserName] NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL
);

