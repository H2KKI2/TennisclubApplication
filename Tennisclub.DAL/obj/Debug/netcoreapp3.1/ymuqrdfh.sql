IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Genders] (
    [Id] tinyint NOT NULL,
    [Name] varchar(10) NOT NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Leagues] (
    [Id] tinyint NOT NULL,
    [Name] varchar(20) NOT NULL,
    CONSTRAINT [PK_Leagues] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [Id] tinyint NOT NULL IDENTITY,
    [Name] varchar(20) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Members] (
    [Id] int NOT NULL IDENTITY,
    [FederationNr] varchar(10) NOT NULL,
    [FirstName] varchar(25) NOT NULL,
    [LastName] varchar(35) NOT NULL,
    [Birthdate] date NOT NULL,
    [GenderId] tinyint NOT NULL,
    [Address] varchar(70) NOT NULL,
    [Number] varchar(6) NOT NULL,
    [Addition] varchar(2) NULL,
    [Zipcode] varchar(6) NOT NULL,
    [City] varchar(30) NOT NULL,
    [PhoneNr] varchar(15) NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Members_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Games] (
    [Id] int NOT NULL IDENTITY,
    [GameNumber] varchar(10) NOT NULL,
    [MemberId] int NOT NULL,
    [LeagueId] tinyint NOT NULL,
    [Date] date NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_Leagues_LeagueId] FOREIGN KEY ([LeagueId]) REFERENCES [Leagues] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Games_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MemberFines] (
    [Id] int NOT NULL IDENTITY,
    [FineNumber] integer NOT NULL,
    [MemberId] int NOT NULL,
    [Amount] decimal(7,2) NOT NULL,
    [HandoutDate] date NOT NULL,
    [PaymentDate] date NULL,
    CONSTRAINT [PK_MemberFines] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MemberFines_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MemberRoles] (
    [Id] int NOT NULL IDENTITY,
    [MemberId] int NOT NULL,
    [RoleId] tinyint NOT NULL,
    [StartDate] date NOT NULL,
    [EndDate] date NULL,
    CONSTRAINT [PK_MemberRoles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MemberRoles_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameResults] (
    [Id] int NOT NULL IDENTITY,
    [GameId] int NOT NULL,
    [SetNr] tinyint NOT NULL,
    [ScoreTeamMember] tinyint NOT NULL,
    [ScoreOpponent] tinyint NOT NULL,
    CONSTRAINT [PK_GameResults] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameResults_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genders]'))
    SET IDENTITY_INSERT [Genders] ON;
INSERT INTO [Genders] ([Id], [Name])
VALUES (CAST(1 AS tinyint), 'Man');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genders]'))
    SET IDENTITY_INSERT [Genders] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genders]'))
    SET IDENTITY_INSERT [Genders] ON;
INSERT INTO [Genders] ([Id], [Name])
VALUES (CAST(2 AS tinyint), 'Vrouw');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genders]'))
    SET IDENTITY_INSERT [Genders] OFF;

GO

CREATE UNIQUE INDEX [IX_GameResults_GameId] ON [GameResults] ([GameId]);

GO

CREATE UNIQUE INDEX [IX_GameResults_SetNr] ON [GameResults] ([SetNr]);

GO

CREATE UNIQUE INDEX [IX_Games_GameNumber] ON [Games] ([GameNumber]);

GO

CREATE INDEX [IX_Games_LeagueId] ON [Games] ([LeagueId]);

GO

CREATE INDEX [IX_Games_MemberId] ON [Games] ([MemberId]);

GO

CREATE UNIQUE INDEX [IX_Genders_Name] ON [Genders] ([Name]);

GO

CREATE UNIQUE INDEX [IX_Leagues_Name] ON [Leagues] ([Name]);

GO

CREATE UNIQUE INDEX [IX_MemberFines_FineNumber] ON [MemberFines] ([FineNumber]);

GO

CREATE INDEX [IX_MemberFines_MemberId] ON [MemberFines] ([MemberId]);

GO

CREATE UNIQUE INDEX [IX_MemberRoles_EndDate] ON [MemberRoles] ([EndDate]) WHERE [EndDate] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_MemberRoles_MemberId] ON [MemberRoles] ([MemberId]);

GO

CREATE UNIQUE INDEX [IX_MemberRoles_RoleId] ON [MemberRoles] ([RoleId]);

GO

CREATE UNIQUE INDEX [IX_MemberRoles_StartDate] ON [MemberRoles] ([StartDate]);

GO

CREATE UNIQUE INDEX [IX_Members_FederationNr] ON [Members] ([FederationNr]);

GO

CREATE INDEX [IX_Members_GenderId] ON [Members] ([GenderId]);

GO

CREATE UNIQUE INDEX [IX_Roles_Name] ON [Roles] ([Name]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226122608_Init', N'3.1.9');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [Name])
VALUES (CAST(1 AS tinyint), 'Voorzitter'),
(CAST(2 AS tinyint), 'Bestuurslid'),
(CAST(3 AS tinyint), 'Secretaris'),
(CAST(4 AS tinyint), 'Penningmeester'),
(CAST(5 AS tinyint), 'Speler');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201226123030_AddDefaultRoles', N'3.1.9');

GO

ALTER TABLE [Members] ADD [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201227195000_AddSoftDelete', N'3.1.9');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201228181803_UpdateBirthDate', N'3.1.9');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201228193027_UpdateIsDeleted', N'3.1.9');

GO

DROP INDEX [IX_MemberRoles_MemberId] ON [MemberRoles];

GO

CREATE INDEX [IX_MemberRoles_MemberId] ON [MemberRoles] ([MemberId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201230111255_UpdateMemberRoleMemberId', N'3.1.9');

GO

DROP INDEX [IX_MemberRoles_RoleId] ON [MemberRoles];

GO

CREATE INDEX [IX_MemberRoles_RoleId] ON [MemberRoles] ([RoleId]);

GO

CREATE UNIQUE INDEX [IX_MemberRoles_MemberId_RoleId] ON [MemberRoles] ([MemberId], [RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201230111626_UpdateMemberRoleIndex', N'3.1.9');

GO

DROP INDEX [IX_MemberRoles_EndDate] ON [MemberRoles];

GO

DROP INDEX [IX_MemberRoles_StartDate] ON [MemberRoles];

GO

DROP INDEX [IX_MemberRoles_MemberId_RoleId] ON [MemberRoles];

GO

CREATE INDEX [IX_MemberRoles_EndDate] ON [MemberRoles] ([EndDate]);

GO

CREATE INDEX [IX_MemberRoles_StartDate] ON [MemberRoles] ([StartDate]);

GO

CREATE UNIQUE INDEX [IX_MemberRoles_MemberId_RoleId_StartDate_EndDate] ON [MemberRoles] ([MemberId], [RoleId], [StartDate], [EndDate]) WHERE [EndDate] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201230112004_UpdateMemberRoleIndex2', N'3.1.9');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201230112307_UpdateMemberRoles_RemoveRoleMap', N'3.1.9');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] ON;
INSERT INTO [Leagues] ([Id], [Name])
VALUES (CAST(1 AS tinyint), 'Recreatief');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] ON;
INSERT INTO [Leagues] ([Id], [Name])
VALUES (CAST(2 AS tinyint), 'Competitie');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] ON;
INSERT INTO [Leagues] ([Id], [Name])
VALUES (CAST(3 AS tinyint), 'Toptennis');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Leagues]'))
    SET IDENTITY_INSERT [Leagues] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210101121205_UpdateLeagues', N'3.1.9');

GO

DROP INDEX [IX_GameResults_GameId] ON [GameResults];

GO

DROP INDEX [IX_GameResults_SetNr] ON [GameResults];

GO

CREATE UNIQUE INDEX [IX_GameResults_GameId_SetNr] ON [GameResults] ([GameId], [SetNr]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210102223453_FixGameResults', N'3.1.9');

GO

