CREATE TABLE [dbo].[characterBackground] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [PersonalityID1]   INT NOT NULL,
    [PersonalityID2]   INT NOT NULL,
    [IdealID1]         INT NOT NULL,
    [IdealID2]         INT NOT NULL,
    [BondID1]          INT NOT NULL,
    [BondID2]          INT NOT NULL,
    [FlawID1]          INT NOT NULL,
    [FlawID2]          INT NOT NULL,
    [BackgroundTypeID] INT NOT NULL,
    CONSTRAINT [PK_charbackground] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_charbackground_backgroundtyp] FOREIGN KEY ([BackgroundTypeID]) REFERENCES [dbo].[backgroundType] ([Id]),
    CONSTRAINT [FK_charbackground_bond1] FOREIGN KEY ([BondID1]) REFERENCES [dbo].[bond] ([Id]),
    CONSTRAINT [FK_charbackground_bond2] FOREIGN KEY ([BondID2]) REFERENCES [dbo].[bond] ([Id]),
    CONSTRAINT [FK_charbackground_flaw1] FOREIGN KEY ([FlawID1]) REFERENCES [dbo].[flaw] ([Id]),
    CONSTRAINT [FK_charbackground_flaw2] FOREIGN KEY ([FlawID2]) REFERENCES [dbo].[flaw] ([Id]),
    CONSTRAINT [FK_charbackground_ideal] FOREIGN KEY ([IdealID1]) REFERENCES [dbo].[ideal] ([Id]),
    CONSTRAINT [FK_charbackground_ideal2] FOREIGN KEY ([IdealID2]) REFERENCES [dbo].[ideal] ([Id]),
    CONSTRAINT [FK_charbackground_personality1] FOREIGN KEY ([PersonalityID1]) REFERENCES [dbo].[personality] ([Id]),
    CONSTRAINT [FK_charbackground_personality2] FOREIGN KEY ([PersonalityID2]) REFERENCES [dbo].[personality] ([Id])
);

