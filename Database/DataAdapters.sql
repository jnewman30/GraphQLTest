﻿CREATE TABLE [dbo].[DataAdapters]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [AdapterTypeId] INT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL,
	[Endpoint] NVARCHAR(MAX) NOT NULL,
	[Metadata] NVARCHAR(MAX),
    [IsRowActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_DataAdapters_DataAdapterTypes] FOREIGN KEY ([AdapterTypeId]) REFERENCES [DataAdapterTypes]([Id])
) AS Node

GO

CREATE INDEX [IX_DataAdapters_Name] ON [dbo].[DataAdapters] ([Name])

GO

CREATE INDEX [IX_DataAdapters_IsRowActive] ON [dbo].[DataAdapters] ([IsRowActive])
