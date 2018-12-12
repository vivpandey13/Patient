USE [master]
GO

/****** Object:  Database [PatientDemo]    Script Date: 12-12-2018 23:57:48 ******/
CREATE DATABASE [PatientDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PatientDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PatientDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PatientDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [PatientDemo] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PatientDemo] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PatientDemo] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PatientDemo] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PatientDemo] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PatientDemo] SET ARITHABORT OFF 
GO

ALTER DATABASE [PatientDemo] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PatientDemo] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PatientDemo] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PatientDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PatientDemo] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PatientDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PatientDemo] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PatientDemo] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PatientDemo] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PatientDemo] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PatientDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PatientDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PatientDemo] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PatientDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PatientDemo] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PatientDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PatientDemo] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PatientDemo] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PatientDemo] SET  MULTI_USER 
GO

ALTER DATABASE [PatientDemo] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PatientDemo] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PatientDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PatientDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PatientDemo] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PatientDemo] SET QUERY_STORE = OFF
GO

USE [PatientDemo]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [PatientDemo] SET  READ_WRITE 
GO

