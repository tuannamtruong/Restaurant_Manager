Create database RestaurantManagementApplication_DB
GO

Use RestaurantManagementApplication_DB
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE [dbo].[GuestTable] (
    [Id]     INT            NOT NULL,
    [Name]   NVARCHAR (100) NULL DEFAULT N'No Name',
    [Status] NVARCHAR (100) NULL DEFAULT N'Empty',
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



CREATE TABLE [dbo].[Account] (
    [Id]          INT            NOT NULL,
    [DisplayName] NVARCHAR (100) NOT NULL,
    [UserName]    NCHAR (100)    NOT NULL,
    [Password]    NCHAR (100)    NOT NULL,
    [Type]        INT            NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[FoodCategory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Food]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [IdCategory] INT NOT NULL, 
    [Price] DECIMAL NOT NULL
)
CREATE TABLE [dbo].[Bill]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DateCheckIn] DATE NOT NULL, 
    [DateCheckOut] DATE NULL, 
    [IdTable] INT NOT NULL, 
    [Status] BIT NULL, 
    CONSTRAINT [FK_Bill_ToGuestTable] FOREIGN KEY ([IdTable]) REFERENCES [GuestTable]([Id])
)

CREATE TABLE [dbo].[BillInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdBill] INT NULL, 
    [IdFood] INT NULL, 
    [Count] INT NULL, 
    CONSTRAINT [FK_BillInfo_ToBill] FOREIGN KEY ([IdBill]) REFERENCES [Bill]([Id]), 
    CONSTRAINT [FK_BillInfo_ToFood] FOREIGN KEY ([IdFood]) REFERENCES [Food]([Id])
)

