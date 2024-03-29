USE [master]
GO
/****** Object:  Database [Godofa]    Script Date: 26/12/2023 17:59:44 ******/
CREATE DATABASE [Godofa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Godofa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Godofa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Godofa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Godofa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Godofa] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Godofa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Godofa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Godofa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Godofa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Godofa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Godofa] SET ARITHABORT OFF 
GO
ALTER DATABASE [Godofa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Godofa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Godofa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Godofa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Godofa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Godofa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Godofa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Godofa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Godofa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Godofa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Godofa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Godofa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Godofa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Godofa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Godofa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Godofa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Godofa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Godofa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Godofa] SET  MULTI_USER 
GO
ALTER DATABASE [Godofa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Godofa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Godofa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Godofa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Godofa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Godofa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Godofa] SET QUERY_STORE = ON
GO
ALTER DATABASE [Godofa] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Godofa]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[NationalityIdentity] [varchar](11) NOT NULL,
	[HireDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameCategories]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameCategories](
	[GameCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[GameCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GameCategories] PRIMARY KEY CLUSTERED 
(
	[GameCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameKeys]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameKeys](
	[GameKeyId] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[KeyOfGame] [varchar](50) NOT NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK_GameKeys] PRIMARY KEY CLUSTERED 
(
	[GameKeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [varchar](50) NOT NULL,
	[PlatformId] [int] NOT NULL,
	[GameCategoryId] [int] NOT NULL,
	[GameTypeId] [int] NOT NULL,
	[Description] [varchar](200) NULL,
	[ImagePath] [varchar](50) NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameTypes]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTypes](
	[GameTypeId] [int] IDENTITY(1,1) NOT NULL,
	[GameTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GameTypes] PRIMARY KEY CLUSTERED 
(
	[GameTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[ClaimId] [int] IDENTITY(1,1) NOT NULL,
	[ClaimName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [float] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[PlatformId] [int] IDENTITY(1,1) NOT NULL,
	[PlatformName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[PlatformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[GameId] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[Price] [float] NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddresses]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AdressLine] [varchar](200) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[UserClaimId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[UserClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Phone] [varchar](13) NOT NULL,
	[PhotoPath] [varchar](50) NULL,
	[RegistrationDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VirtualCurrencies]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VirtualCurrencies](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyTypeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CurrencyKey] [varchar](50) NOT NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK_VirtualCurrencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VirtualCurrencyTypes]    Script Date: 26/12/2023 17:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VirtualCurrencyTypes](
	[VirtualCurrencyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[VirtualCurrencyTypeName] [varchar](50) NOT NULL,
	[GameId] [int] NOT NULL,
 CONSTRAINT [PK_VirtualCurrencyTypes] PRIMARY KEY CLUSTERED 
(
	[VirtualCurrencyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 26/12/2023 17:59:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_1]    Script Date: 26/12/2023 17:59:44 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_1] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_Games]
GO
ALTER TABLE [dbo].[GameKeys]  WITH CHECK ADD  CONSTRAINT [FK_GameKeys_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[GameKeys] CHECK CONSTRAINT [FK_GameKeys_Products]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_GameCategories] FOREIGN KEY([GameCategoryId])
REFERENCES [dbo].[GameCategories] ([GameCategoryId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_GameCategories]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_GameTypes] FOREIGN KEY([GameTypeId])
REFERENCES [dbo].[GameTypes] ([GameTypeId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_GameTypes]
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Platforms] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([PlatformId])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Platforms]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Games]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([ProductCategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories]
GO
ALTER TABLE [dbo].[UserAddresses]  WITH CHECK ADD  CONSTRAINT [FK_UserAddress_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserAddresses] CHECK CONSTRAINT [FK_UserAddress_Users]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([ClaimId])
REFERENCES [dbo].[OperationClaims] ([ClaimId])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
ALTER TABLE [dbo].[VirtualCurrencies]  WITH CHECK ADD  CONSTRAINT [FK_VirtualCurrencies_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[VirtualCurrencies] CHECK CONSTRAINT [FK_VirtualCurrencies_Products]
GO
ALTER TABLE [dbo].[VirtualCurrencies]  WITH CHECK ADD  CONSTRAINT [FK_VirtualCurrencies_VirtualCurrencyTypes] FOREIGN KEY([CurrencyTypeId])
REFERENCES [dbo].[VirtualCurrencyTypes] ([VirtualCurrencyTypeId])
GO
ALTER TABLE [dbo].[VirtualCurrencies] CHECK CONSTRAINT [FK_VirtualCurrencies_VirtualCurrencyTypes]
GO
ALTER TABLE [dbo].[VirtualCurrencyTypes]  WITH CHECK ADD  CONSTRAINT [FK_VirtualCurrencyTypes_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([GameId])
GO
ALTER TABLE [dbo].[VirtualCurrencyTypes] CHECK CONSTRAINT [FK_VirtualCurrencyTypes_Games]
GO
USE [master]
GO
ALTER DATABASE [Godofa] SET  READ_WRITE 
GO
