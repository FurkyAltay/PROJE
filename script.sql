USE [master]
GO
/****** Object:  Database [PROJE]    Script Date: 13.12.2024 22:17:27 ******/
CREATE DATABASE [PROJE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROJE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PROJE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROJE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PROJE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PROJE] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROJE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROJE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROJE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROJE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROJE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROJE] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROJE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PROJE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROJE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROJE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROJE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROJE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROJE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROJE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROJE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROJE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PROJE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROJE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROJE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROJE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROJE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROJE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROJE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROJE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PROJE] SET  MULTI_USER 
GO
ALTER DATABASE [PROJE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROJE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROJE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROJE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROJE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROJE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PROJE] SET QUERY_STORE = ON
GO
ALTER DATABASE [PROJE] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PROJE]
GO
/****** Object:  Table [dbo].[arıza]    Script Date: 13.12.2024 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[arıza](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[müsteri_adi] [nchar](10) NULL,
	[müsteri_soyadi] [nchar](10) NULL,
	[tel] [nchar](10) NULL,
	[marka_adi] [nchar](25) NULL,
	[parca_adi] [nchar](10) NULL,
	[arıza1] [nvarchar](300) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 13.12.2024 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici](
	[k_adi] [nchar](20) NULL,
	[sifre] [nchar](20) NULL,
	[re_sifre] [nchar](20) NULL,
	[e_mail] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marka]    Script Date: 13.12.2024 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marka_adi] [nchar](25) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[müsteri1]    Script Date: 13.12.2024 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[müsteri1](
	[müsteri_id] [int] IDENTITY(1,1) NOT NULL,
	[müsteri_adi] [nchar](10) NULL,
	[müsteri_soyadi] [nchar](10) NULL,
	[tel] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parca1]    Script Date: 13.12.2024 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parca1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parca_adi] [nchar](10) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[arıza] ON 

INSERT [dbo].[arıza] ([id], [müsteri_adi], [müsteri_soyadi], [tel], [marka_adi], [parca_adi], [arıza1]) VALUES (2011, N'furkan    ', N'altay     ', N'55        ', N'HP                       ', N'RAM       ', NULL)
SET IDENTITY_INSERT [dbo].[arıza] OFF
GO
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'1                   ', N'1                   ', N'1                   ', N'1                                                 ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'caner               ', N'5555                ', N'5555                ', N'caner@mail.com                                    ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'gadir               ', N'0000                ', N'0000                ', N'gadir@gmail.com                                   ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'yasin               ', N'0000                ', N'0000                ', N'ysn@gmail.com                                     ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'canerr              ', N'0000                ', N'0000                ', N'canerrr@h.com                                     ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'fahri               ', N'0000                ', N'0000                ', N'fahri@gmail.com                                   ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'özcan               ', N'0000                ', N'0000                ', N'ö@gmail.com                                       ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'cerhawk             ', N'316952              ', N'316952              ', N'ceren@gmail.com                                   ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'erkutt              ', N'0000                ', N'0000                ', N'e@gmail.com                                       ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'yasinhoca           ', N'0000                ', N'0000                ', N'yasinhoca@gmail.com                               ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'sema                ', N'0000                ', N'0000                ', N'kljhkşj                                           ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'MURAT               ', N'5555                ', N'5555                ', N'KHLJK                                             ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'sefa                ', N'0000                ', N'0000                ', N'sefa@gmail.com                                    ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'2                   ', N'2                   ', N'2                   ', N'2                                                 ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'yusuf               ', N'315269              ', N'315269              ', N'yok                                               ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'yunus               ', N'5234                ', N'5234                ', N'yunus@gmail.com                                   ')
INSERT [dbo].[kullanici] ([k_adi], [sifre], [re_sifre], [e_mail]) VALUES (N'AYŞO                ', N'1                   ', N'1                   ', N'1                                                 ')
GO
SET IDENTITY_INSERT [dbo].[marka] ON 

INSERT [dbo].[marka] ([id], [marka_adi]) VALUES (1, N'ASUS                     ')
INSERT [dbo].[marka] ([id], [marka_adi]) VALUES (2, N'HP                       ')
INSERT [dbo].[marka] ([id], [marka_adi]) VALUES (3, N'ACER                     ')
INSERT [dbo].[marka] ([id], [marka_adi]) VALUES (9, N'DELL                     ')
INSERT [dbo].[marka] ([id], [marka_adi]) VALUES (7, N'EXCALİBUR                ')
SET IDENTITY_INSERT [dbo].[marka] OFF
GO
SET IDENTITY_INSERT [dbo].[müsteri1] ON 

INSERT [dbo].[müsteri1] ([müsteri_id], [müsteri_adi], [müsteri_soyadi], [tel]) VALUES (1, N'furkan    ', N'altay     ', N'55555     ')
SET IDENTITY_INSERT [dbo].[müsteri1] OFF
GO
SET IDENTITY_INSERT [dbo].[parca1] ON 

INSERT [dbo].[parca1] ([id], [parca_adi]) VALUES (1, N'ANAKART   ')
INSERT [dbo].[parca1] ([id], [parca_adi]) VALUES (2, N'RAM       ')
INSERT [dbo].[parca1] ([id], [parca_adi]) VALUES (3, N'CPU       ')
INSERT [dbo].[parca1] ([id], [parca_adi]) VALUES (4, N'GPU       ')
SET IDENTITY_INSERT [dbo].[parca1] OFF
GO
USE [master]
GO
ALTER DATABASE [PROJE] SET  READ_WRITE 
GO
