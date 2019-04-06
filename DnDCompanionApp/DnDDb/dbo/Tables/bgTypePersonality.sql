CREATE TABLE [dbo].[bgTypePersonality] (
    [TypeId]        INT NOT NULL,
    [PersonalityId] INT NOT NULL,
    CONSTRAINT [PK_bgTypePersonality] PRIMARY KEY CLUSTERED ([TypeId] ASC, [PersonalityId] ASC),
    CONSTRAINT [FK_bgTypePersonality_personality] FOREIGN KEY ([PersonalityId]) REFERENCES [dbo].[personality] ([Id])
);

