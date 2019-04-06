CREATE TABLE [dbo].[characterSkills] (
    [CharacterID] INT NOT NULL,
    [SkillID]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CharacterID] ASC, [SkillID] ASC),
    CONSTRAINT [FK_characterSkills_character] FOREIGN KEY ([CharacterID]) REFERENCES [dbo].[character] ([Id]),
    CONSTRAINT [FK_characterSkills_skill] FOREIGN KEY ([SkillID]) REFERENCES [dbo].[skill] ([Id])
);

