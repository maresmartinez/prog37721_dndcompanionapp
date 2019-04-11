CREATE TABLE [dbo].[class] (
    [Id]             INT NOT NULL IDENTITY,
    [Name]           NVARCHAR (128) NOT NULL,
    [Description]    NVARCHAR (256) NOT NULL,
    [hitDice]        INT            NOT NULL,
    [primaryAbility] NVARCHAR (64)  NOT NULL,
    [save1]          NVARCHAR (64)  NOT NULL,
    [save2]          NVARCHAR (64)  NOT NULL,
    CONSTRAINT [PK__class__3214EC07211F9033] PRIMARY KEY CLUSTERED ([Id] ASC)
);

