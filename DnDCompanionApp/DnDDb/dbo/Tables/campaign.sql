CREATE TABLE [dbo].[campaign] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (128) NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [dungeonMasterId] INT            NOT NULL,
    CONSTRAINT [PK__campaign__3214EC074BF884FE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

