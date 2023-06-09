USE [master]
GO
/****** Object:  Database [HimanshuPracticalTaskDB]    Script Date: 29-05-2023 19:22:57 ******/
CREATE DATABASE [HimanshuPracticalTaskDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HimanshuPracticalTaskDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HimanshuPracticalTaskDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HimanshuPracticalTaskDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HimanshuPracticalTaskDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HimanshuPracticalTaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HimanshuPracticalTaskDB', N'ON'
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET QUERY_STORE = OFF
GO
USE [HimanshuPracticalTaskDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29-05-2023 19:22:57 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 29-05-2023 19:22:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EducationName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29-05-2023 19:22:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[EducationId] [int] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Website] [nvarchar](max) NULL,
	[GitLink] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230529130001_init', N'6.0.16')
GO
SET IDENTITY_INSERT [dbo].[Educations] ON 

INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (1, N'BE')
INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (2, N'B.Pharm')
INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (3, N'Medical')
INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (4, N'Diploma')
INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (5, N'Arts')
INSERT [dbo].[Educations] ([Id], [EducationName]) VALUES (6, N'B.Com')
SET IDENTITY_INSERT [dbo].[Educations] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (1, N'Himanshu123', N'Ladva', 1, N'himanshu@admin.com', N'Himanshu@123', N'https://www.tyve.biz', N'Provident dolore si', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (2, N'Karna', N'Ladva', 4, N'karan@admin.com', N'karan@admin.com', N'https://www.tyve.biz', N'Provident dolore sida', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (4, N'Stuart', N'Nicholson', 5, N'qity@mailinator.com', N'Ut ad exercitationem', N'https://www.gyp.org', N'In iste provident m', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (5, N'Nehru', N'Callahan', 1, N'hodugewe@mailinator.com', N'Impedit ipsum harum', N'https://www.syjypawydaca.com', N'Rem perspiciatis ve', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (6, N'Roary', N'Page', 1, N'koturupysa@mailinator.com', N'Dolores tenetur temp', N'https://www.vubadygukuxope.org.au', N'Molestiae neque pers', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [EducationId], [Email], [Password], [Website], [GitLink], [IsDeleted]) VALUES (7, N'Harrison', N'Alston', 5, N'myvovig@mailinator.com', N'Voluptatibus sunt ad', N'https://www.favumewak.us', N'Sed labore vitae min', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Users_EducationId]    Script Date: 29-05-2023 19:22:58 ******/
CREATE NONCLUSTERED INDEX [IX_Users_EducationId] ON [dbo].[Users]
(
	[EducationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Educations_EducationId] FOREIGN KEY([EducationId])
REFERENCES [dbo].[Educations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Educations_EducationId]
GO
USE [master]
GO
ALTER DATABASE [HimanshuPracticalTaskDB] SET  READ_WRITE 
GO
