CREATE TABLE [dbo].[skill] (
    [Id]          INT NOT NULL IDENTITY,
    [Name]        NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (256) NULL,
    CONSTRAINT [PK__skill__3214EC0710A73719] PRIMARY KEY CLUSTERED ([Id] ASC)
);

