
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/07/2021 20:39:14
-- Generated from EDMX file: C:\Users\mizukami\source\repos\5032ass1.0\5032ass1.0\Controllers\Model1.edmx
-- --------------------------------------------------

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Booking_Name] nvarchar(max)  NOT NULL,
    [Booking_Date] date  NOT NULL,
    [Booking_Email] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL,
    [Booking_Rate] nvarchar(max)  NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'ClassSet'
CREATE TABLE [dbo].[ClassSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Class_Name] nvarchar(max)  NOT NULL,
    [Class_Des] nvarchar(max)  NOT NULL,
    [Class_Rate] nvarchar(max)  NOT NULL,
    [Class_Lng] nvarchar(max)  NOT NULL,
    [Class_Lat] nvarchar(max)  NOT NULL,
    [Class_Date] date NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassSet'
ALTER TABLE [dbo].[ClassSet]
ADD CONSTRAINT [PK_ClassSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Class_Id] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_BookingClass]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[ClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingClass'
CREATE INDEX [IX_FK_BookingClass]
ON [dbo].[BookingSet]
    ([Class_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
