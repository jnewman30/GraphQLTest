CREATE TABLE [dbo].[Properties]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[PropertyTypeId] INT NOT NULL,
    [Name] NVARCHAR(255) NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    [IsRowActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Properties_PropertyType] FOREIGN KEY ([PropertyTypeId]) REFERENCES [PropertyTypes]([Id]) 
) AS Node

GO

CREATE INDEX [IX_Properties_Name] ON [dbo].[Properties] ([Name])

GO

CREATE INDEX [IX_Properties_IsRowActive] ON [dbo].[Properties] ([IsRowActive])
