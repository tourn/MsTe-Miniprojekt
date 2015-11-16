
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2015 15:47:12
-- Generated from EDMX file: C:\Users\Frank\Documents\Vorlesungen HS15\MsTe\02_Uebungen\99_Miniprojekt\Vorgabe\AutoReservation.Dal\AutoReservationDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoReservation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Reservation_Auto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK_Reservation_Auto];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservation_Kunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservation] DROP CONSTRAINT [FK_Reservation_Kunde];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auto];
GO
IF OBJECT_ID(N'[dbo].[Kunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kunde];
GO
IF OBJECT_ID(N'[dbo].[Reservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservation];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Autos'
CREATE TABLE [dbo].[Autos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Marke] nvarchar(20)  NOT NULL,
    [Tagestarif] int  NOT NULL
);
GO

-- Creating table 'Kunden'
CREATE TABLE [dbo].[Kunden] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nachname] nvarchar(20)  NOT NULL,
    [Vorname] nvarchar(20)  NOT NULL,
    [Geburtsdatum] datetime  NOT NULL
);
GO

-- Creating table 'Reservationen'
CREATE TABLE [dbo].[Reservationen] (
    [ReservationNr] int IDENTITY(1,1) NOT NULL,
    [AutoId] int  NOT NULL,
    [KundeId] int  NOT NULL,
    [Von] datetime  NOT NULL,
    [Bis] datetime  NOT NULL
);
GO

-- Creating table 'Autos_LuxusklasseAuto'
CREATE TABLE [dbo].[Autos_LuxusklasseAuto] (
    [Basistarif] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Autos_MittelklasseAuto'
CREATE TABLE [dbo].[Autos_MittelklasseAuto] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Autos_StandardAuto'
CREATE TABLE [dbo].[Autos_StandardAuto] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Autos'
ALTER TABLE [dbo].[Autos]
ADD CONSTRAINT [PK_Autos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kunden'
ALTER TABLE [dbo].[Kunden]
ADD CONSTRAINT [PK_Kunden]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReservationNr] in table 'Reservationen'
ALTER TABLE [dbo].[Reservationen]
ADD CONSTRAINT [PK_Reservationen]
    PRIMARY KEY CLUSTERED ([ReservationNr] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_LuxusklasseAuto'
ALTER TABLE [dbo].[Autos_LuxusklasseAuto]
ADD CONSTRAINT [PK_Autos_LuxusklasseAuto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_MittelklasseAuto'
ALTER TABLE [dbo].[Autos_MittelklasseAuto]
ADD CONSTRAINT [PK_Autos_MittelklasseAuto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Autos_StandardAuto'
ALTER TABLE [dbo].[Autos_StandardAuto]
ADD CONSTRAINT [PK_Autos_StandardAuto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AutoId] in table 'Reservationen'
ALTER TABLE [dbo].[Reservationen]
ADD CONSTRAINT [FK_Reservation_Auto]
    FOREIGN KEY ([AutoId])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservation_Auto'
CREATE INDEX [IX_FK_Reservation_Auto]
ON [dbo].[Reservationen]
    ([AutoId]);
GO

-- Creating foreign key on [KundeId] in table 'Reservationen'
ALTER TABLE [dbo].[Reservationen]
ADD CONSTRAINT [FK_Reservation_Kunde]
    FOREIGN KEY ([KundeId])
    REFERENCES [dbo].[Kunden]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservation_Kunde'
CREATE INDEX [IX_FK_Reservation_Kunde]
ON [dbo].[Reservationen]
    ([KundeId]);
GO

-- Creating foreign key on [Id] in table 'Autos_LuxusklasseAuto'
ALTER TABLE [dbo].[Autos_LuxusklasseAuto]
ADD CONSTRAINT [FK_LuxusklasseAuto_inherits_Auto]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Autos_MittelklasseAuto'
ALTER TABLE [dbo].[Autos_MittelklasseAuto]
ADD CONSTRAINT [FK_MittelklasseAuto_inherits_Auto]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Autos_StandardAuto'
ALTER TABLE [dbo].[Autos_StandardAuto]
ADD CONSTRAINT [FK_StandardAuto_inherits_Auto]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Autos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------