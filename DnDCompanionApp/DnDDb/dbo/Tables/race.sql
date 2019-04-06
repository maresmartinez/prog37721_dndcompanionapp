CREATE TABLE [dbo].[race] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'race', @level2type = N'COLUMN', @level2name = N'Description';

