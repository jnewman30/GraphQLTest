CREATE TABLE [dbo].[DataAdapterTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Enum] AS (power((2),[Id])), 
    [Name] NVARCHAR(255) NOT NULL, 
    [IsRowActive] BIT NOT NULL DEFAULT 1
)
