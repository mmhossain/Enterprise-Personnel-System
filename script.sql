USE [master]
GO
/****** Object:  Database [ssepsdb]    Script Date: 10/13/2020 4:58:30 PM ******/
CREATE DATABASE [ssepsdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ssepsdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ssepsdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ssepsdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ssepsdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ssepsdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ssepsdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ssepsdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ssepsdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ssepsdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ssepsdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ssepsdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ssepsdb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ssepsdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ssepsdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ssepsdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ssepsdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ssepsdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ssepsdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ssepsdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ssepsdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ssepsdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ssepsdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ssepsdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ssepsdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ssepsdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ssepsdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ssepsdb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ssepsdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ssepsdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ssepsdb] SET  MULTI_USER 
GO
ALTER DATABASE [ssepsdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ssepsdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ssepsdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ssepsdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ssepsdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ssepsdb] SET QUERY_STORE = OFF
GO
USE [ssepsdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/13/2020 4:58:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRoles]    Script Date: 10/13/2020 4:58:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRoles](
	[EmployeeId] [nvarchar](450) NOT NULL,
	[ERoleId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[ERoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/13/2020 4:58:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[ManagerId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ERoles]    Script Date: 10/13/2020 4:58:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ERoles](
	[ERoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ERoles] PRIMARY KEY CLUSTERED 
(
	[ERoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200820135242_Initial', N'3.0.0')
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00001', 1)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00002', 1)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00003', 1)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00004', 2)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00005', 3)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00006', 4)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00002', 5)
INSERT [dbo].[EmployeeRoles] ([EmployeeId], [ERoleId]) VALUES (N'SSEPS-00007', 5)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00001', N'Jeffrey', N'Wells', NULL)
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00002', N'Victor', N'Atkins', N'SSEPS-00001')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00003', N'Kelli', N'Hamilton', N'SSEPS-00001')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00004', N'Adam', N'Braun', N'SSEPS-00002')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00005', N'Lois', N'Martinez', N'SSEPS-00003')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00006', N'Brian', N'Cruz', N'SSEPS-00002')
INSERT [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [ManagerId]) VALUES (N'SSEPS-00007', N'Michael', N'Lind', N'SSEPS-00003')
SET IDENTITY_INSERT [dbo].[ERoles] ON 

INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (1, N'Director')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (2, N'IT, Support')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (3, N'Support')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (4, N'Accounting')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (5, N'Analyst')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (6, N'Analyst, Sales')
INSERT [dbo].[ERoles] ([ERoleId], [Name]) VALUES (7, N'IT, Sales')
SET IDENTITY_INSERT [dbo].[ERoles] OFF
/****** Object:  Index [IX_EmployeeRoles_ERoleId]    Script Date: 10/13/2020 4:58:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeRoles_ERoleId] ON [dbo].[EmployeeRoles]
(
	[ERoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Employees_ManagerId]    Script Date: 10/13/2020 4:58:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_ManagerId] ON [dbo].[Employees]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoles_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRoles_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[EmployeeRoles]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoles_ERoles_ERoleId] FOREIGN KEY([ERoleId])
REFERENCES [dbo].[ERoles] ([ERoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeRoles] CHECK CONSTRAINT [FK_EmployeeRoles_ERoles_ERoleId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees_ManagerId]
GO
USE [master]
GO
ALTER DATABASE [ssepsdb] SET  READ_WRITE 
GO
