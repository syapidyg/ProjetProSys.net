USE [master]
GO
/****** Object:  Database [MasterInfoChef]    Script Date: 02/12/2022 10:30:58 ******/
CREATE DATABASE [MasterInfoChef]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MasterInfoChef', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MasterInfoChef.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MasterInfoChef_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MasterInfoChef_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MasterInfoChef] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterInfoChef].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterInfoChef] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterInfoChef] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterInfoChef] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterInfoChef] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterInfoChef] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterInfoChef] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterInfoChef] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterInfoChef] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterInfoChef] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterInfoChef] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterInfoChef] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterInfoChef] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterInfoChef] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterInfoChef] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterInfoChef] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MasterInfoChef] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterInfoChef] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterInfoChef] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterInfoChef] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterInfoChef] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterInfoChef] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterInfoChef] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterInfoChef] SET RECOVERY FULL 
GO
ALTER DATABASE [MasterInfoChef] SET  MULTI_USER 
GO
ALTER DATABASE [MasterInfoChef] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterInfoChef] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterInfoChef] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterInfoChef] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MasterInfoChef] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MasterInfoChef] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MasterInfoChef', N'ON'
GO
ALTER DATABASE [MasterInfoChef] SET QUERY_STORE = OFF
GO
USE [MasterInfoChef]
GO
/****** Object:  Table [dbo].[client]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[id_client] [int] NOT NULL,
	[num_table] [int] NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[commande]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[commande](
	[id_client] [int] NOT NULL,
	[id_table] [int] NOT NULL,
	[nom] [int] NOT NULL,
	[prix] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comporte]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comporte](
	[id] [int] NOT NULL,
	[id_table] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materiels_en_cuisine]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materiels_en_cuisine](
	[id] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[nbr] [int] NOT NULL,
	[commun] [bit] NOT NULL,
 CONSTRAINT [PK_materiels_en_cuisine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materiels_en_salle]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materiels_en_salle](
	[id] [int] NOT NULL,
	[nom] [varchar](max) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[nbr] [varchar](max) NOT NULL,
	[commun] [bit] NOT NULL,
 CONSTRAINT [PK_materiels_en_salle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produits]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produits](
	[id] [int] NOT NULL,
	[nom] [varchar](max) NOT NULL,
	[type] [varchar](max) NOT NULL,
	[stock] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recette2]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recette2](
	[id] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[categorie] [varchar](50) NOT NULL,
	[tps_cuisson] [time](7) NOT NULL,
	[tps_preparation] [time](7) NOT NULL,
	[tps_respos] [time](7) NOT NULL,
	[instructions] [varchar](max) NOT NULL,
	[prix] [money] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservation]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservation](
	[id_client] [int] NOT NULL,
	[nom_client] [varchar](max) NOT NULL,
	[nbre_place] [varchar](50) NOT NULL,
	[heure] [varchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[id_table] [int] NOT NULL,
	[nbre_table] [int] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[id_table] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zone_de_stockage]    Script Date: 02/12/2022 10:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zone_de_stockage](
	[id_stock] [int] NOT NULL,
	[nom] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_zone_de_stockage] PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_zone_de_stockage_1]    Script Date: 02/12/2022 10:30:59 ******/
CREATE NONCLUSTERED INDEX [IX_zone_de_stockage_1] ON [dbo].[zone_de_stockage]
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_zone_de_stockage_2]    Script Date: 02/12/2022 10:30:59 ******/
CREATE NONCLUSTERED INDEX [IX_zone_de_stockage_2] ON [dbo].[zone_de_stockage]
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[commande]  WITH CHECK ADD  CONSTRAINT [FK_commande_client] FOREIGN KEY([id_client])
REFERENCES [dbo].[client] ([id_client])
GO
ALTER TABLE [dbo].[commande] CHECK CONSTRAINT [FK_commande_client]
GO
ALTER TABLE [dbo].[commande]  WITH CHECK ADD  CONSTRAINT [FK_commande_Table] FOREIGN KEY([id_table])
REFERENCES [dbo].[Table] ([id_table])
GO
ALTER TABLE [dbo].[commande] CHECK CONSTRAINT [FK_commande_Table]
GO
USE [master]
GO
ALTER DATABASE [MasterInfoChef] SET  READ_WRITE 
GO
