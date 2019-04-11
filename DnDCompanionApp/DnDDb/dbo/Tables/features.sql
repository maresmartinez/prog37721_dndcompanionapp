CREATE TABLE [dbo].[features] (
    [Id]          INT NOT NULL IDENTITY,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_features] PRIMARY KEY CLUSTERED ([Id] ASC)
);

