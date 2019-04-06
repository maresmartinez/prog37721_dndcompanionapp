CREATE TABLE [dbo].[spells] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [castingTime] INT            NOT NULL,
    [Duration]    INT            NOT NULL,
    [Range]       INT            NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK__spells__3214EC073B5FD8DD] PRIMARY KEY CLUSTERED ([Id] ASC)
);

