CREATE TABLE [dbo].[PropertyTypes]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Enum] AS power([Id], 2),
    [Name] NVARCHAR(255) NOT NULL, 
    [IsRowActive] BIT NOT NULL DEFAULT 1
)
