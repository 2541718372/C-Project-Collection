USE [master]
GO
/****** Object:  Database [school]    Script Date: 2023/12/7 13:19:50 ******/
CREATE DATABASE [school]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'school', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\school.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'school_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\school_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [school] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [school].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [school] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [school] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [school] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [school] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [school] SET ARITHABORT OFF 
GO
ALTER DATABASE [school] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [school] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [school] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [school] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [school] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [school] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [school] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [school] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [school] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [school] SET  DISABLE_BROKER 
GO
ALTER DATABASE [school] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [school] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [school] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [school] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [school] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [school] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [school] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [school] SET RECOVERY FULL 
GO
ALTER DATABASE [school] SET  MULTI_USER 
GO
ALTER DATABASE [school] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [school] SET DB_CHAINING OFF 
GO
ALTER DATABASE [school] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [school] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [school] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'school', N'ON'
GO
USE [school]
GO
/****** Object:  Table [dbo].[student]    Script Date: 2023/12/7 13:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[sex] [nchar](10) NULL,
	[age] [int] NULL,
	[ssid] [nchar](10) NULL,
	[classes] [nchar](10) NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 2023/12/7 13:19:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](10) NULL,
	[password] [nchar](10) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[student] ON 

INSERT [dbo].[student] ([id], [name], [sex], [age], [ssid], [classes]) VALUES (1, N'张青山       ', N'男         ', 19, N'22040105  ', N'物联网一班     ')
INSERT [dbo].[student] ([id], [name], [sex], [age], [ssid], [classes]) VALUES (2, N'陈小红       ', N'女         ', 20, N'22040201  ', N'物联网二班     ')
INSERT [dbo].[student] ([id], [name], [sex], [age], [ssid], [classes]) VALUES (3, N'李小刚       ', N'男         ', 18, N'22040107  ', N'物联网一班     ')
SET IDENTITY_INSERT [dbo].[student] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [password]) VALUES (1, N'sa        ', N'123456    ')
INSERT [dbo].[users] ([id], [username], [password]) VALUES (2, N'root      ', N'root      ')
SET IDENTITY_INSERT [dbo].[users] OFF
USE [master]
GO
ALTER DATABASE [school] SET  READ_WRITE 
GO
