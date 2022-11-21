USE [master]
GO
/****** Object:  Database [Machines]    Script Date: 21.11.2022 23:52:47 ******/
CREATE DATABASE [Machines]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Machines', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\Machines.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Machines_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\Machines_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Machines] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Machines].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Machines] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Machines] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Machines] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Machines] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Machines] SET ARITHABORT OFF 
GO
ALTER DATABASE [Machines] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Machines] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Machines] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Machines] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Machines] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Machines] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Machines] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Machines] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Machines] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Machines] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Machines] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Machines] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Machines] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Machines] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Machines] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Machines] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Machines] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Machines] SET RECOVERY FULL 
GO
ALTER DATABASE [Machines] SET  MULTI_USER 
GO
ALTER DATABASE [Machines] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Machines] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Machines] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Machines] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Machines] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Machines] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Machines', N'ON'
GO
ALTER DATABASE [Machines] SET QUERY_STORE = OFF
GO
USE [Machines]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 21.11.2022 23:52:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[Name] [nvarchar](50) NULL,
	[RealiseDate] [int] NULL,
	[Id] [int] NULL,
	[Engine] [nvarchar](50) NULL,
	[Brakes] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[AdditionalInfo] [nvarchar](50) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Machines] SET  READ_WRITE 
GO
