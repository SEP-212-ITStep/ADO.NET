USE [master]
GO
/****** Object:  Database [warehouse]    Script Date: Tue,08-Nov-22 23:24:25 ******/
CREATE DATABASE [warehouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'warehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\warehouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'warehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\warehouse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [warehouse] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [warehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [warehouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [warehouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [warehouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [warehouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [warehouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [warehouse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [warehouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [warehouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [warehouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [warehouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [warehouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [warehouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [warehouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [warehouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [warehouse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [warehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [warehouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [warehouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [warehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [warehouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [warehouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [warehouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [warehouse] SET RECOVERY FULL 
GO
ALTER DATABASE [warehouse] SET  MULTI_USER 
GO
ALTER DATABASE [warehouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [warehouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [warehouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [warehouse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [warehouse] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [warehouse] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'warehouse', N'ON'
GO
ALTER DATABASE [warehouse] SET QUERY_STORE = OFF
GO
USE [warehouse]
GO
/****** Object:  Table [dbo].[goods]    Script Date: Tue,08-Nov-22 23:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goods](
	[good's name] [nvarchar](20) NOT NULL,
	[type] [nvarchar](20) NOT NULL,
	[quantity] [int] NOT NULL,
	[cost] [money] NOT NULL,
	[delivery date] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: Tue,08-Nov-22 23:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers](
	[good's name] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[supplier] [nvarchar](50) NOT NULL,
	[delivery date] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[types]    Script Date: Tue,08-Nov-22 23:24:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[types](
	[type] [nchar](10) NULL,
	[supplier] [nchar](10) NULL,
	[good's name] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[goods] ([good's name], [type], [quantity], [cost], [delivery date]) VALUES (N'tylenol', N'material', 99, 777782.0000, N'1988.11.11')
GO
INSERT [dbo].[suppliers] ([good's name], [type], [supplier], [delivery date]) VALUES (N'tyre', N'', N'toyo', N'2023.04.31')
GO
INSERT [dbo].[types] ([type], [supplier], [good's name]) VALUES (N'tyre      ', N'Matador   ', NULL)
GO
USE [master]
GO
ALTER DATABASE [warehouse] SET  READ_WRITE 
GO
