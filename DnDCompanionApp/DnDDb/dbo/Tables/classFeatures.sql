CREATE TABLE [dbo].[classFeatures] (
    [ClassId]   INT NOT NULL,
    [FeatureId] INT NOT NULL,
    CONSTRAINT [PK_classFeatures_1] PRIMARY KEY CLUSTERED ([ClassId] ASC, [FeatureId] ASC),
    CONSTRAINT [FK_classFeatures_class] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[class] ([Id]),
    CONSTRAINT [FK_classFeatures_features] FOREIGN KEY ([FeatureId]) REFERENCES [dbo].[features] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [PK_classFeatures]
    ON [dbo].[classFeatures]([ClassId] ASC, [FeatureId] ASC);

