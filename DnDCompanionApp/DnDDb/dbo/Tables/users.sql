CREATE TABLE [dbo].[users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [fullName] NVARCHAR (128) NOT NULL,
    [userName] NVARCHAR (128) NOT NULL,
    [Password] NVARCHAR (128) NOT NULL,
    [Salt]     NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([userName] ASC)
);

