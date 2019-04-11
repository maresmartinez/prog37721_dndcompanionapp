CREATE TABLE [dbo].[backgroundType] (
    [Id]          INT NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_backgroundType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

