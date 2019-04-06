CREATE TABLE [dbo].[raceLanguage] (
    [RaceID]     INT NOT NULL,
    [LanguageID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([RaceID] ASC, [LanguageID] ASC),
    CONSTRAINT [FK_raceLanguage_languages] FOREIGN KEY ([LanguageID]) REFERENCES [dbo].[languages] ([Id]),
    CONSTRAINT [FK_raceLanguage_race] FOREIGN KEY ([RaceID]) REFERENCES [dbo].[race] ([Id])
);

