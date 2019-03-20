CREATE TABLE [Feature](
	[ID] int primary key identity(1,1) not null,
	[Name] NVARCHAR(50) not null,
	[Description] NVARCHAR(100) not null,
);

CREATE TABLE [Languages](
	[ID] int primary key identity(1,1) not null,
	[Language] nvarchar(50) not null
);

CREATE TABLE [Skills](
	[ID] int primary key identity(1,1) not null,
	[Skill] nvarchar(50) not null
);

CREATE TABLE [Spells](
	[ID] int primary key identity(1,1) not null,
	[Name] nvarchar(50) not null,
	[CastingTime] int not null,
	[Duration] int not null,
	[Range] int not null,
	[Description] nvarchar(100) not null
);

