CREATE TABLE [dbo].[bgTypeBond] (
    [TypeId] INT NOT NULL,
    [BondId] INT NOT NULL,
    CONSTRAINT [PK_bgTypeBond] PRIMARY KEY CLUSTERED ([TypeId] ASC, [BondId] ASC),
    CONSTRAINT [FK_bgTypeBond_backgroundType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[backgroundType] ([Id]),
    CONSTRAINT [FK_bgTypeBond_bond] FOREIGN KEY ([BondId]) REFERENCES [dbo].[bond] ([Id])
);

