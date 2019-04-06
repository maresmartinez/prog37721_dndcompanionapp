CREATE TABLE [dbo].[features] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_features] PRIMARY KEY CLUSTERED ([Id] ASC)
);

