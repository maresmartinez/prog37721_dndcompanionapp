CREATE TABLE [dbo].[bgTypeIdeal] (
    [TypeId]  INT NOT NULL,
    [IdealId] INT NOT NULL,
    CONSTRAINT [PK_bgTypeIdeal] PRIMARY KEY CLUSTERED ([TypeId] ASC, [IdealId] ASC),
    CONSTRAINT [FK_bgTypeIdeal_bgTypeIdeal] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[backgroundType] ([Id]),
    CONSTRAINT [FK_bgTypeIdeal_ideal] FOREIGN KEY ([IdealId]) REFERENCES [dbo].[ideal] ([Id])
);

