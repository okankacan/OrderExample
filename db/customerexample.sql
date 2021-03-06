USE [master]
GO
/****** Object:  Database [CustomerExample]    Script Date: 9.02.2021 17:53:41 ******/
CREATE DATABASE [CustomerExample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerExample', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\CustomerExample.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomerExample_log', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\CustomerExample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomerExample] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerExample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerExample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerExample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerExample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerExample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerExample] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerExample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerExample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerExample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerExample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerExample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerExample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerExample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerExample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerExample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerExample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerExample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerExample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerExample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerExample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerExample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerExample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerExample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerExample] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerExample] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerExample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerExample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerExample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerExample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CustomerExample] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CustomerExample]
GO
/****** Object:  Table [dbo].[CustomerOrderDetails]    Script Date: 9.02.2021 17:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerOrderId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_CustomerOrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerOrders]    Script Date: 9.02.2021 17:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_CustomerOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9.02.2021 17:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[PhoneNumber] [nvarchar](10) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 9.02.2021 17:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Barcode] [nvarchar](150) NULL,
	[Description] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
USE [master]
GO
ALTER DATABASE [CustomerExample] SET  READ_WRITE 
GO
