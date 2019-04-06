CREATE TABLE [dbo].[characterSpells] (
    [characterID] INT NOT NULL,
    [spellID]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([characterID] ASC, [spellID] ASC),
    CONSTRAINT [FK_characterSpells_character] FOREIGN KEY ([characterID]) REFERENCES [dbo].[character] ([Id]),
    CONSTRAINT [FK_characterSpells_spells] FOREIGN KEY ([spellID]) REFERENCES [dbo].[spells] ([Id])
);

