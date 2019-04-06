CREATE TABLE [dbo].[bgTypeFlaw] (
    [TypeId] INT NOT NULL,
    [FlawId] INT NOT NULL,
    CONSTRAINT [PK_bgTypeFlawId] PRIMARY KEY CLUSTERED ([TypeId] ASC, [FlawId] ASC),
    CONSTRAINT [FK_bgTypeFlawId_backgroundType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[backgroundType] ([Id]),
    CONSTRAINT [FK_bgTypeFlawId_flaw] FOREIGN KEY ([FlawId]) REFERENCES [dbo].[flaw] ([Id])
);

