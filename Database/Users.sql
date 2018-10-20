CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(25) NOT NULL, 
	[Email] NVARCHAR(255) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Company] NVARCHAR(255) NOT NULL, 
    [DateCreated] DATETIMEOFFSET NOT NULL DEFAULT (getdate())    
) AS Node;

GO

CREATE INDEX [IX_Users_UserName] ON [dbo].[Users] ([UserName])

GO

CREATE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email])

GO

CREATE INDEX [IX_Users_Company] ON [dbo].[Users] ([Company])

GO

CREATE INDEX [IX_Users_DateCreated] ON [dbo].[Users] ([DateCreated])
