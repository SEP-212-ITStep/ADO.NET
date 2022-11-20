USE [master]
GO
/****** Object:  Database [Fruits&Vegetables]    Script Date: 20.11.2022 16:04:48 ******/
CREATE DATABASE [Fruits&Vegetables]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fruits&Vegetables', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Fruits&Vegetables.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fruits&Vegetables_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Fruits&Vegetables_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Fruits&Vegetables] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fruits&Vegetables].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fruits&Vegetables] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fruits&Vegetables] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fruits&Vegetables] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fruits&Vegetables] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fruits&Vegetables] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET RECOVERY FULL 
GO
ALTER DATABASE [Fruits&Vegetables] SET  MULTI_USER 
GO
ALTER DATABASE [Fruits&Vegetables] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fruits&Vegetables] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fruits&Vegetables] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fruits&Vegetables] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fruits&Vegetables] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fruits&Vegetables] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Fruits&Vegetables', N'ON'
GO
ALTER DATABASE [Fruits&Vegetables] SET QUERY_STORE = OFF
GO
USE [Fruits&Vegetables]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20.11.2022 16:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NOT NULL,
	[Type] [ntext] NOT NULL,
	[Color] [ntext] NOT NULL,
	[Calory] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Type], [Color], [Calory]) VALUES (1, N'apple', N'fruit', N'red', 150)
INSERT [dbo].[Products] ([Id], [Name], [Type], [Color], [Calory]) VALUES (2, N'grapes', N'fruit', N'purple', 300)
INSERT [dbo].[Products] ([Id], [Name], [Type], [Color], [Calory]) VALUES (3, N'carrot', N'vegetable', N'orange', 150)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
USE [master]
GO
ALTER DATABASE [Fruits&Vegetables] SET  READ_WRITE 
GO
