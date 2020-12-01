
USE [ENGMERCEDES]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[URUNAD] [nvarchar](100) NULL,
	[URUNACIKLAMA] [text] NULL,
	[URUNMARKA] [int] NULL,
	[URUNFIYAT] [decimal](18, 0) NULL,
	[KATEGORIID] [int] NULL,
	[ALTKATEGORIID] [int] NULL,
	[ISAPPROVED] [bit] NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
	[MARKAADI] [nvarchar](50) NULL,
	[URUNILKRESIM] [varbinary](max) NULL,
	[URUNILKRESIMYOL] [nvarchar](200) NULL,
	[URUNOEMKOD] [nvarchar](150) NULL,
	[URUNKODU] [nvarchar](150) NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunResim]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunResim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RESIMAD] [nvarchar](150) NULL,
	[RESIM] [varbinary](max) NULL,
	[RESIMYOL] [nvarchar](250) NULL,
	[URUNID] [int] NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
 CONSTRAINT [PK_UrunResim] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_UIUrunDetay]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_UIUrunDetay]
as
SELECT u.ID, u.URUNAD, u.URUNACIKLAMA, u.URUNFIYAT, u.ISAPPROVED, u.URUNILKRESIMYOL, u.URUNILKRESIM, ur.RESIM, ur.RESIMYOL
FROM     dbo.Urun AS u INNER JOIN
                  dbo.UrunResim AS ur ON u.ID = ur.URUNID
GO
/****** Object:  UserDefinedFunction [dbo].[funcGetProductDetail]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[funcGetProductDetail](@urunid int)
returns table
as
return 
select * from vw_UIUrunDetay where ID=@urunid
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KATEGORIADI] [nvarchar](250) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marka]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MARKAADI] [nvarchar](250) NULL,
	[MARKARESIM] [image] NULL,
	[MARKARESIMYOL] [nvarchar](250) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_UrunList]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_UrunList]
as
SELECT u.ID, u.URUNMARKA, m.MARKAADI, u.ISAPPROVED, u.ALTKATEGORIID, k.KATEGORIADI, u.KATEGORIID, u.CREATEDDATE, u.UPDATEDDATE, u.URUNACIKLAMA, u.URUNAD, u.URUNFIYAT, u.URUNILKRESIM, u.URUNILKRESIMYOL, 
                  u.URUNOEMKOD, u.URUNKODU
FROM     dbo.Urun AS u INNER JOIN
                  dbo.Kategori AS k ON u.KATEGORIID = k.ID INNER JOIN
                  dbo.Marka AS m ON u.URUNMARKA = m.ID
GO
/****** Object:  Table [dbo].[AltKategori]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AltKategori](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KATEGORIID] [int] NULL,
	[ALTKATEGORIADI] [nvarchar](250) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
 CONSTRAINT [PK_AltKategori] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_AltAndKat]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_AltAndKat]
as
SELECT al.ID, al.ALTKATEGORIADI, k.KATEGORIADI, al.CREATEDDATE, al.UPDATEDDATE
FROM     dbo.AltKategori AS al INNER JOIN
                  dbo.Kategori AS k ON k.ID = al.KATEGORIID
GO
/****** Object:  View [dbo].[vw_UrunDetay]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_UrunDetay]
as
SELECT u.ID, u.URUNAD, u.URUNACIKLAMA, u.URUNFIYAT, k.KATEGORIADI, ak.ALTKATEGORIADI, m.MARKAADI, u.ISAPPROVED, u.URUNILKRESIM, u.URUNILKRESIMYOL, u.CREATEDDATE, u.UPDATEDDATE
FROM     dbo.Urun AS u INNER JOIN
                  dbo.Kategori AS k ON k.ID = u.KATEGORIID INNER JOIN
                  dbo.AltKategori AS ak ON ak.ID = u.ALTKATEGORIID INNER JOIN
                  dbo.Marka AS m ON m.ID = u.URUNMARKA
GO
/****** Object:  View [dbo].[vw_UrunModel]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_UrunModel]
as
SELECT u.ID, u.KATEGORIID, u.ALTKATEGORIID, u.URUNMARKA, u.URUNACIKLAMA, u.URUNAD, u.ISAPPROVED, k.KATEGORIADI, ak.ALTKATEGORIADI, m.MARKAADI, u.CREATEDDATE, u.UPDATEDDATE, u.URUNFIYAT
FROM     dbo.Urun AS u INNER JOIN
                  dbo.Kategori AS k ON k.ID = u.KATEGORIID INNER JOIN
                  dbo.AltKategori AS ak ON ak.ID = u.ALTKATEGORIID INNER JOIN
                  dbo.Marka AS m ON m.ID = u.ID
GO
/****** Object:  Table [dbo].[AltReklam]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AltReklam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REKLAMRESIM1] [varbinary](max) NULL,
	[[REKLAMRESIM2] [varbinary](max) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
 CONSTRAINT [PK_AltReklam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ayarlar]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ayarlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SITEBASLIK] [nvarchar](50) NULL,
	[SITELOGO] [varbinary](max) NULL,
	[SITEACIKLAMA] [nvarchar](50) NULL,
	[SITEMAIL] [nvarchar](50) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
	[SITELOGOYOL] [nvarchar](250) NULL,
	[SITETELEFON] [nvarchar](50) NULL,
	[SITETELEFON2] [nvarchar](50) NULL,
	[SITEADRES] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ayarlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KULLANICIADI] [nvarchar](50) NULL,
	[KULLANICISIFRE] [nvarchar](50) NULL,
	[KULLANICIRESIM] [varbinary](max) NULL,
	[LOGINDATE] [datetime] NULL,
	[KULLANICITELEFON] [nvarchar](50) NULL,
	[LOGOUTDATE] [datetime] NULL,
	[KULLANICIMAİL] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reklam]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reklam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REKLAMADI] [nvarchar](50) NULL,
	[REKLAMRESIM1] [varbinary](max) NULL,
	[REKLAMRESIMYOL] [nvarchar](100) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
	[REKLAMRESIM2] [varbinary](max) NULL,
	[REKLAMRESIM3] [varbinary](max) NULL,
 CONSTRAINT [PK_Reklam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sirket]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sirket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HAKKIMIZDA] [text] NULL,
	[MISYONUMUZ] [text] NULL,
	[VIZYONUMUZ] [text] NULL,
	[RESIM1] [varbinary](max) NULL,
	[RESIM2] [varbinary](max) NULL,
	[RESIM3] [varbinary](max) NULL,
 CONSTRAINT [PK_Sirket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SLIDERAD] [nvarchar](50) NULL,
	[SLIDERYOL] [nvarchar](250) NULL,
	[SLIDERIMAGE] [varbinary](max) NULL,
	[CREATEDDATE] [datetime] NULL,
	[UPDATEDDATE] [datetime] NULL,
	[ISAPPROVED] [bit] NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SosyalMedya]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SosyalMedya](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FACEBOOK] [nvarchar](250) NULL,
	[INSTAGRAM] [nvarchar](250) NULL,
	[TWITTER] [nvarchar](250) NULL,
	[LINKEDIN] [nvarchar](250) NULL,
	[YOUTUBE] [nvarchar](250) NULL,
	[WHATSAPP] [nvarchar](250) NULL,
 CONSTRAINT [PK_SosyalMedya] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_AltKategori] FOREIGN KEY([ALTKATEGORIID])
REFERENCES [dbo].[AltKategori] ([ID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_AltKategori]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Kategori] FOREIGN KEY([KATEGORIID])
REFERENCES [dbo].[Kategori] ([ID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Kategori]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Marka] FOREIGN KEY([URUNMARKA])
REFERENCES [dbo].[Marka] ([ID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Marka]
GO
ALTER TABLE [dbo].[UrunResim]  WITH CHECK ADD  CONSTRAINT [FK_UrunResim_Urun] FOREIGN KEY([URUNID])
REFERENCES [dbo].[Urun] ([ID])
GO
ALTER TABLE [dbo].[UrunResim] CHECK CONSTRAINT [FK_UrunResim_Urun]
GO
/****** Object:  StoredProcedure [dbo].[LogInDate]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LogInDate]
(
@id int,
@logindate datetime
)
as
begin
update Kullanici  set LOGINDATE=@logindate where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[LogOutDate]    Script Date: 25.11.2020 13:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LogOutDate]
(
@id int,
@dateout datetime
)
as
begin
update Kullanici set LOGOUTDATE=@dateout where ID=@id
end
GO
USE [master]
GO
ALTER DATABASE [ENGMERCEDES] SET  READ_WRITE 
GO
