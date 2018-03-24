CREATE TABLE [meta].[Packages]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(255) NOT NULL, 
    [SourceSystemId] TINYINT NOT NULL, 
    CONSTRAINT [FK_Packages_2_SourceSystems] FOREIGN KEY ([SourceSystemId]) REFERENCES [meta].[SourceSystems]([Id])
)
