USE [master]
GO
/****** Object:  Database [K22CNT4-HoangVanKhai-TTCD1]    Script Date: 11/2/2024 2:09:48 PM ******/
CREATE DATABASE [K22CNT4-HoangVanKhai-TTCD1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'K22CNT4-HoangVanKhai-TTCD1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\K22CNT4-HoangVanKhai-TTCD1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'K22CNT4-HoangVanKhai-TTCD1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\K22CNT4-HoangVanKhai-TTCD1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [K22CNT4-HoangVanKhai-TTCD1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ARITHABORT OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET RECOVERY FULL 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET  MULTI_USER 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'K22CNT4-HoangVanKhai-TTCD1', N'ON'
GO
USE [K22CNT4-HoangVanKhai-TTCD1]
GO
/****** Object:  Table [dbo].[Cay]    Script Date: 11/2/2024 2:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tencay] [nvarchar](50) NOT NULL,
	[Iddanhmuc] [int] NOT NULL,
	[Soluong] [int] NOT NULL,
	[Dongia] [decimal](18, 0) NOT NULL,
	[Hinhanh] [nvarchar](500) NOT NULL,
	[Trangthai] [bit] NOT NULL,
 CONSTRAINT [PK_Cay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucCay]    Script Date: 11/2/2024 2:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucCay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tendanhmuc] [nvarchar](110) NOT NULL,
	[Trangthai] [bit] NOT NULL,
 CONSTRAINT [PK_DanhMucCay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 11/2/2024 2:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[Id] [int] NOT NULL,
	[Idcay] [int] NOT NULL,
	[Idnguoidung] [int] NOT NULL,
	[soluong] [int] NOT NULL,
	[tonggiatien] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 11/2/2024 2:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](110) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Sdt] [int] NOT NULL,
	[Matkhau] [nchar](50) NOT NULL,
	[Trangthai] [bit] NOT NULL,
	[Vaitro] [bit] NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cay] ON 

INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (2, N'Cây Hạnh Phúc', 1, 13132, CAST(100000 AS Decimal(18, 0)), N'/Uploads/files/12200_cay-hanh-phuc-noi-that.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (3, N'Cây hoa tường vi', 1, 500, CAST(400000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2024/08/cay-hoa-tuong-vi-hong-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (4, N'Cây hoa giấy ', 1, 1230, CAST(99999 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2019/07/cay-hoa-giay-o-hoi-an-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (5, N'Cây huyết dụ', 1, 100, CAST(135000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2024/08/cay-huyet-du-dep-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (6, N'Cây kim ngân đơn thân lớn', 1, 999, CAST(888888 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2023/05/cay-kim-ngan-don-than-lon-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (7, N'Kim ngân củ to ', 1, 100, CAST(30000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2023/04/chau-cay-kim-ngan-cu-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (8, N'Cây Nhất Mạt Hương', 1, 50, CAST(30000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2022/11/cay-nhat-mat-huong-dep-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (9, N'Cây cau nga mi ', 1, 30, CAST(55555 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2024/08/cay-cau-nga-mi-trong-trong-nha-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (10, N'Trầu bà đế vương', 1, 30, CAST(200000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2021/12/cay-trau-ba-de-vuong-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (11, N'Cây phát tài núi 3 thân ', 1, 1000, CAST(999999 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2022/06/cay-phat-tai-nui-3-than-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (12, N'Cây bàng nhật ', 1, 2999, CAST(302990 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2023/03/la-cay-bang-cam-thach-la-nho-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (13, N'Cây bàng cẩm lá thạch ', 1, 200, CAST(30000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2022/04/cay-bang-cam-thach-la-tim-dep-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (14, N'Cây lưỡi hổ mix ', 1, 300, CAST(20000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2022/08/cay-luoi-ho-mix-420x420.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (15, N'Cây thông caribe', 1, 55, CAST(9000000 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2023/06/thong-caribe-255x255.jpg', 1)
INSERT [dbo].[Cay] ([Id], [Tencay], [Iddanhmuc], [Soluong], [Dongia], [Hinhanh], [Trangthai]) VALUES (16, N'Cây Nhất Mạt Hương', 1, 300000, CAST(437457 AS Decimal(18, 0)), N'https://webcaycanh.com/wp-content/uploads/2022/11/cay-nhat-mat-huong-255x255.jpg', 1)
SET IDENTITY_INSERT [dbo].[Cay] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMucCay] ON 

INSERT [dbo].[DanhMucCay] ([Id], [Tendanhmuc], [Trangthai]) VALUES (1, N'1', 1)
SET IDENTITY_INSERT [dbo].[DanhMucCay] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([Id], [Ten], [Email], [Sdt], [Matkhau], [Trangthai], [Vaitro]) VALUES (1, N'khai', N'khai135668@gmail.com', 99977555, N'123                                               ', 1, 1)
INSERT [dbo].[NguoiDung] ([Id], [Ten], [Email], [Sdt], [Matkhau], [Trangthai], [Vaitro]) VALUES (2, N'khai', N'khai135668@gmail.com', 866983529, N'123456                                            ', 1, 0)
INSERT [dbo].[NguoiDung] ([Id], [Ten], [Email], [Sdt], [Matkhau], [Trangthai], [Vaitro]) VALUES (3, N'khai', N'khai1@gmail.com', 1234567890, N'khaiv                                             ', 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Ten], [Email], [Sdt], [Matkhau], [Trangthai], [Vaitro]) VALUES (4, N'khai', N'khai36@gmail.com', 1093057712, N'123                                               ', 1, 0)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
ALTER TABLE [dbo].[NguoiDung] ADD  CONSTRAINT [DF_NguoiDung_Trangthai]  DEFAULT ((1)) FOR [Trangthai]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  CONSTRAINT [DF_NguoiDung_Vaitro]  DEFAULT ((0)) FOR [Vaitro]
GO
ALTER TABLE [dbo].[Cay]  WITH CHECK ADD  CONSTRAINT [FK_Cay_DanhMucCay] FOREIGN KEY([Iddanhmuc])
REFERENCES [dbo].[DanhMucCay] ([Id])
GO
ALTER TABLE [dbo].[Cay] CHECK CONSTRAINT [FK_Cay_DanhMucCay]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_Cay] FOREIGN KEY([Idcay])
REFERENCES [dbo].[Cay] ([Id])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_Cay]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_NguoiDung] FOREIGN KEY([Idnguoidung])
REFERENCES [dbo].[NguoiDung] ([Id])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_NguoiDung]
GO
USE [master]
GO
ALTER DATABASE [K22CNT4-HoangVanKhai-TTCD1] SET  READ_WRITE 
GO
