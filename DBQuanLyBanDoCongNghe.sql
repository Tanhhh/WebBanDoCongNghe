USE [master]
GO
/****** Object:  Database [DBQuanLyBanDoCongNghe]    Script Date: 12/14/2023 7:21:46 PM ******/
CREATE DATABASE [DBQuanLyBanDoCongNghe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBQuanLyBanDoCongNghe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBQuanLyBanDoCongNghe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBQuanLyBanDoCongNghe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBQuanLyBanDoCongNghe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBQuanLyBanDoCongNghe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET RECOVERY FULL 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET  MULTI_USER 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBQuanLyBanDoCongNghe', N'ON'
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET QUERY_STORE = OFF
GO
USE [DBQuanLyBanDoCongNghe]
GO
/****** Object:  Table [dbo].[tb_Brand]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Brand](
	[MaBrand] [int] IDENTITY(1,1) NOT NULL,
	[TenBrand] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Brand] PRIMARY KEY CLUSTERED 
(
	[MaBrand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Category]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Category](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[Position] [int] NULL,
	[IsActive] [bit] NULL,
	[Link] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Category] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ChiTietOrder]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ChiTietOrder](
	[MaDonHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tb_ChiTietOrder] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ChiTietOrder-Traveler]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ChiTietOrder-Traveler](
	[MaDonHang] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tb_ChiTietOrder-Traveler] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ChucNang]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ChucNang](
	[MaChucNang] [int] IDENTITY(1,1) NOT NULL,
	[TenChucNang] [nvarchar](150) NULL,
 CONSTRAINT [PK_tb_ChucNang] PRIMARY KEY CLUSTERED 
(
	[MaChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Color]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Color](
	[MaColor] [int] IDENTITY(1,1) NOT NULL,
	[TenColor] [nvarchar](150) NULL,
	[ImageColor] [nvarchar](max) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Color] PRIMARY KEY CLUSTERED 
(
	[MaColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Contact]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[HoTen] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](255) NULL,
	[LyDo] [nvarchar](255) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[MaNhanVien] [int] NULL,
	[IsXuLy] [bit] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Customer]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Customer](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](200) NULL,
	[TaiKhoan] [varchar](100) NULL,
	[MatKhau] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[ImageUser] [nvarchar](max) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_tb_Customer] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_CustomerCode]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CustomerCode](
	[CustomerCodeId] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[MaDiscount] [int] NULL,
	[IsSuDung] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UseDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_DiscountCode]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DiscountCode](
	[MaDiscount] [int] IDENTITY(1,1) NOT NULL,
	[TenDiscount] [nvarchar](150) NULL,
	[DiscountCode] [varchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Quantity] [int] NULL,
	[Value] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[SoDiemCanDoi] [int] NULL,
 CONSTRAINT [PK_tb_DiscountCode] PRIMARY KEY CLUSTERED 
(
	[MaDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_FavoriteProduct]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_FavoriteProduct](
	[MaYeuThich] [int] NOT NULL,
	[MaKH] [int] NULL,
	[MaSanPham] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaYeuThich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Memory]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Memory](
	[MaMemory] [int] IDENTITY(1,1) NOT NULL,
	[TenMemory] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Memory] PRIMARY KEY CLUSTERED 
(
	[MaMemory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NhanVien]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](150) NULL,
	[TaiKhoan] [varchar](100) NULL,
	[MatKhau] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[ImageNhanVien] [nchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsQuanTriVien] [bit] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Order]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Order](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[MaPhuongThucThanhToan] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[IsThanhToan] [bit] NULL,
	[IsHoanThanh] [bit] NULL,
	[IsHuyDon] [bit] NULL,
	[TotalPayment] [decimal](18, 2) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsXacNhan] [bit] NULL,
	[TrangThai] [nvarchar](max) NULL,
	[MaNhanVien] [int] NULL,
	[LyDoHuyDon] [nvarchar](max) NULL,
	[IsDongGoi] [bit] NULL,
	[IsVanChuyen] [bit] NULL,
	[CustomerCodeID] [int] NULL,
	[IsNhanDiem] [bit] NULL,
 CONSTRAINT [PK_tb_Order] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PhanQuyen]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PhanQuyen](
	[MaChucNang] [int] NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaChucNang] ASC,
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PhuongThucThanhToan]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PhuongThucThanhToan](
	[MaPhuongThucThanhToan] [int] IDENTITY(1,1) NOT NULL,
	[TenPhuongThucThanhToan] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_PhuongThucThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaPhuongThucThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Product]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Product](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Detail] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[PriceSale] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[ImageProduct] [nvarchar](max) NULL,
	[Link] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsSoldOut] [bit] NULL,
	[IsSale] [bit] NULL,
	[IsNew] [bit] NULL,
	[IsHot] [bit] NULL,
	[SeoTitle] [nvarchar](max) NULL,
	[SeoDescription] [nvarchar](max) NULL,
	[SeoKeywords] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[MaProductCategory] [int] NULL,
	[MaBrand] [int] NULL,
	[MaColor] [int] NULL,
	[MaMemory] [int] NULL,
 CONSTRAINT [PK_tb_Product] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductCategory]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductCategory](
	[MaProductCategory] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[Position] [int] NULL,
	[IsActive] [bit] NULL,
	[Link] [varchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_ProductCategory_1] PRIMARY KEY CLUSTERED 
(
	[MaProductCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductImages]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductImages](
	[MaImages] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](500) NULL,
	[IsDefault] [bit] NULL,
	[MaSanPham] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_ProductImages] PRIMARY KEY CLUSTERED 
(
	[MaImages] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductReview]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductReview](
	[MaReview] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NULL,
	[MaKH] [int] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[Rating] [int] NULL,
	[NgayDanhGia] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaReview] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TaiKhoanNganHang]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TaiKhoanNganHang](
	[MaSoTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenNganHang] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[SoTaiKhoan] [varchar](50) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_TaiKhoanNganHang] PRIMARY KEY CLUSTERED 
(
	[MaSoTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TichDiem]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TichDiem](
	[SoDiemCongGanNhat] [int] NULL,
	[TongSoDiem] [int] NULL,
	[MaDonHang] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[MaTichDiem] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaDiscount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTichDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Traveler]    Script Date: 12/14/2023 7:21:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Traveler](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber1] [varchar](20) NULL,
	[PhoneNumber2] [varchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[Ghichu] [nvarchar](500) NULL,
	[TotalPayment] [decimal](18, 2) NULL,
	[MaPhuongThucThanhToan] [int] NULL,
	[IsThanhToan] [bit] NULL,
	[IsHoanThanh] [bit] NULL,
	[IsHuyDon] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsXacNhan] [bit] NULL,
	[TrangThaiDon] [nvarchar](max) NULL,
	[MaNhanVien] [int] NULL,
	[IsDongGoi] [bit] NULL,
	[IsVanChuyen] [bit] NULL,
	[LyDoHuyDon] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_Traveler] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_Brand] ON 

INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (8, N'Sony', NULL, NULL, CAST(N'2022-11-20T15:53:28.457' AS DateTime), CAST(N'2022-11-20T15:53:28.457' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (9, N'Apple', NULL, NULL, CAST(N'2022-11-24T14:52:39.100' AS DateTime), CAST(N'2022-12-09T02:25:52.250' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (10, N'Nokia', NULL, NULL, CAST(N'2022-11-28T23:39:15.407' AS DateTime), CAST(N'2022-11-28T23:39:15.407' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (11, N'Xiaomi', NULL, NULL, CAST(N'2022-12-09T02:23:59.660' AS DateTime), CAST(N'2022-12-09T02:23:59.660' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (12, N'SamSung', NULL, NULL, CAST(N'2022-12-09T02:24:13.503' AS DateTime), CAST(N'2022-12-09T02:24:13.503' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (13, N'LG', NULL, NULL, CAST(N'2022-12-09T02:24:25.107' AS DateTime), CAST(N'2022-12-09T02:24:25.107' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (14, N'Oppo', NULL, NULL, CAST(N'2022-12-09T02:25:14.933' AS DateTime), CAST(N'2022-12-09T02:25:14.933' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (15, N'Vivo', NULL, NULL, CAST(N'2022-12-09T02:26:05.237' AS DateTime), CAST(N'2022-12-09T02:26:05.237' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (16, N'Huawei', NULL, NULL, CAST(N'2022-12-09T02:26:19.490' AS DateTime), CAST(N'2022-12-09T02:26:19.490' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (17, N'Asus', NULL, NULL, CAST(N'2022-12-09T02:26:45.503' AS DateTime), CAST(N'2022-12-09T02:26:45.503' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (18, N'Dell', NULL, NULL, CAST(N'2022-12-09T02:26:58.463' AS DateTime), CAST(N'2022-12-09T02:26:58.463' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (19, N'HP', NULL, NULL, CAST(N'2022-12-09T02:27:07.000' AS DateTime), CAST(N'2022-12-09T02:27:07.000' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (20, N'MSI', NULL, NULL, CAST(N'2022-12-09T02:27:14.507' AS DateTime), CAST(N'2022-12-09T02:27:14.507' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (21, N'Lenovo', NULL, NULL, CAST(N'2022-12-09T02:27:24.777' AS DateTime), CAST(N'2022-12-09T02:27:24.777' AS DateTime), NULL)
INSERT [dbo].[tb_Brand] ([MaBrand], [TenBrand], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (22, N'Acer', NULL, NULL, CAST(N'2022-12-09T02:27:32.173' AS DateTime), CAST(N'2022-12-09T02:27:32.173' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Category] ON 

INSERT [dbo].[tb_Category] ([MaDanhMuc], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreateDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (21, N'Trang chủ', NULL, 1, 1, N'trang-chu', CAST(N'2022-11-24T02:40:38.173' AS DateTime), NULL, CAST(N'2022-12-13T00:27:26.950' AS DateTime), NULL)
INSERT [dbo].[tb_Category] ([MaDanhMuc], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreateDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (23, N'Sản Phẩm', NULL, 2, 1, N'san-pham', CAST(N'2022-11-24T21:55:54.730' AS DateTime), NULL, CAST(N'2022-12-09T01:50:27.120' AS DateTime), NULL)
INSERT [dbo].[tb_Category] ([MaDanhMuc], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreateDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (25, N'Giới thiệu', NULL, 3, 1, N'gioi-thieu', CAST(N'2022-12-04T20:09:02.143' AS DateTime), NULL, CAST(N'2023-12-09T13:06:01.933' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_Category] OFF
GO
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2226, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2227, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2227, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2228, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2229, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2230, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2231, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2232, 23, CAST(25000000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2233, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2233, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2234, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2234, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2235, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2235, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2236, 23, CAST(25000000.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2237, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2238, 22, CAST(28990000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2239, 23, CAST(25000000.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2240, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2241, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2242, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2243, 22, CAST(28990000.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2244, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2245, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2246, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2247, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2250, 22, CAST(28990000.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2251, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2252, 22, CAST(28990000.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2255, 28, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2259, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2260, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2261, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2262, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2263, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2264, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2265, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2266, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2267, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2268, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2269, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2270, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2271, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2274, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2275, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2276, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2277, 22, CAST(28990000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2278, 24, CAST(22800000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tb_ChiTietOrder] ([MaDonHang], [MaSanPham], [Price], [Quantity]) VALUES (2279, 23, CAST(25000000.00 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[tb_ChucNang] ON 

INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (1, N'Quản lý navbar')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (2, N'Quản lý danh mục sản phẩm')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (3, N'Quản lý danh sách sản phẩm')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (4, N'Quản lý danh sách thương hiệu')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (5, N'Quản lý màu sắc')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (6, N'Quản lý bộ nhớ')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (7, N'Quản lý mã giảm giá')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (8, N'Quản lý đơn hàng khách hàng')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (9, N'Quản lý đơn hàng khách vãng lai')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (10, N'Quản lý ban quản trị')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (11, N'Quản lý khách hàng thành viên')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (12, N'Quản lý phương thức thanh toán')
INSERT [dbo].[tb_ChucNang] ([MaChucNang], [TenChucNang]) VALUES (13, N'Quản lý tài khoản ngân hàng')
SET IDENTITY_INSERT [dbo].[tb_ChucNang] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Color] ON 

INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Màu gold', N'/Uploads/images/Color/Screenshot%202022-12-09%20014332.png', NULL, NULL, CAST(N'2022-11-20T15:57:40.313' AS DateTime), CAST(N'2022-12-09T01:47:37.547' AS DateTime), NULL)
INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (9, N'Màu bạc', N'/Uploads/images/Color/Screenshot%202022-12-09%20014541.png', NULL, NULL, CAST(N'2022-12-09T01:47:31.287' AS DateTime), CAST(N'2022-12-09T01:47:31.287' AS DateTime), NULL)
INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (10, N'Màu đen', N'/Uploads/images/Color/Screenshot%202022-12-09%20035753.png', NULL, NULL, CAST(N'2022-12-09T03:59:21.407' AS DateTime), CAST(N'2022-12-09T03:59:21.407' AS DateTime), NULL)
INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (11, N'Màu tím', N'/Uploads/images/Color/Screenshot%202022-12-09%20041204.png', NULL, NULL, CAST(N'2022-12-09T04:12:48.060' AS DateTime), CAST(N'2022-12-09T04:12:48.060' AS DateTime), NULL)
INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (12, N'Màu tím nhạt', N'/Uploads/images/Color/Screenshot%202022-12-09%20043019.png', NULL, NULL, CAST(N'2022-12-09T04:31:00.567' AS DateTime), CAST(N'2022-12-09T04:31:00.567' AS DateTime), NULL)
INSERT [dbo].[tb_Color] ([MaColor], [TenColor], [ImageColor], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (13, N'màu trắng', N'/Uploads/images/Color/Screenshot%202022-12-09%20114308.png', NULL, NULL, CAST(N'2022-12-09T11:39:56.107' AS DateTime), CAST(N'2022-12-09T11:43:53.987' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_Color] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Contact] ON 

INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (38, NULL, N'Lê Tấn Hào', N'0123456789', N'letuananh@gmail.com', N'aaaaaa', N'bbbbbbbbbb', CAST(N'2023-11-21T18:54:37.000' AS DateTime), 7, 1, CAST(N'2023-11-23T21:57:39.817' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (39, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'Mấy giờ đóng cửa', N'qqqqq', CAST(N'2023-11-23T20:12:49.000' AS DateTime), 5, 1, CAST(N'2023-11-23T20:44:07.777' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (40, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'hello', N'how are u', CAST(N'2023-11-23T20:26:01.000' AS DateTime), 7, 1, CAST(N'2023-11-23T21:38:35.237' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (41, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'aaa', N'bbbbbbbbb', CAST(N'2023-11-23T20:34:05.000' AS DateTime), 7, 1, CAST(N'2023-11-23T21:29:41.033' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (42, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'aaa', N'bbbbbbbbb', CAST(N'2023-11-23T20:34:06.000' AS DateTime), 5, 1, CAST(N'2023-11-23T20:36:11.513' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (43, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'điện thoại hư', N'màn hình oledddd nét căng', CAST(N'2023-11-23T21:43:13.387' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (44, NULL, N'Lê Tuấn Anh', N'0123456789', N'letuananh@gmail.com', N'aaaaaa', N'âbbbbbbbbbbb', CAST(N'2023-11-23T22:00:11.000' AS DateTime), 7, 1, CAST(N'2023-11-23T22:00:23.637' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (45, NULL, N'Tuấn Anh', N'0944110044', N'letuananh@gmail.com', N'aaaaaa', N'bbbbbbbbb', CAST(N'2023-11-24T10:49:38.013' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (46, 9, N'Lê Tuấn Anh', N'0944110044', N'letuananh4282@gmail.com', N'Tại vì sao', N'cảm xúc kia', CAST(N'2023-11-24T10:50:18.813' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (47, NULL, N'Lê Tuấn Anh', N'0944110044', N'letuananh@gmail.com', N'aaaaaa', N'aaaa', CAST(N'2023-11-24T13:09:47.000' AS DateTime), 5, 1, CAST(N'2023-11-24T13:10:30.553' AS DateTime))
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (48, NULL, N'Lê Tuấn Anh', N'0944110044', N'letuananh@gmail.com', N'aaaaaa', N'Alo 1 2 3', CAST(N'2023-12-07T00:38:19.037' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (49, 9, N'Lê Tuấn Anh', N'0944110043', N'letuananh4282@gmail.com', N'B', N'AAAAAAA', CAST(N'2023-12-07T20:19:11.550' AS DateTime), NULL, 0, NULL)
INSERT [dbo].[tb_Contact] ([ContactID], [MaKH], [HoTen], [PhoneNumber], [Email], [LyDo], [NoiDung], [CreateDate], [MaNhanVien], [IsXuLy], [UpdatedDate]) VALUES (50, 9, N'Lê Tuấn Anh', N'0944110043', N'letuananh4282@gmail.com', N'aaaaa', N'bbbbbbb', CAST(N'2023-12-08T02:36:17.383' AS DateTime), NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[tb_Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Customer] ON 

INSERT [dbo].[tb_Customer] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [ImageUser], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [IsAdmin]) VALUES (1, N'Nhật Hào', N'PhanNhatHao', N'4297f44b13955235245b2497399d7a93', N'trochoivuongquyen30072000@gmail.com', N'avt-user.png', N'0918798849', N'36, Ấp 2,Xuân Thới Thượng,Hóc Môn,TP.Hồ Chí Minh', N'Nam', NULL, 1, NULL, CAST(N'2022-12-05T18:53:32.047' AS DateTime), CAST(N'2023-12-12T21:54:46.173' AS DateTime), NULL, NULL)
INSERT [dbo].[tb_Customer] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [ImageUser], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [IsAdmin]) VALUES (4, N'Tran Huy Bão', N'tranhuybao@gmail.com', N'4297f44b13955235245b2497399d7a93', N'tranhuybao@gmail.com', N'avt-user.png', N'0918798849', N'36/5C Ấp 2,Xuân Thới Thượng,Hóc Môn,TP.Hồ Chí Minh', N'Nam', CAST(N'2022-12-14T00:00:00.000' AS DateTime), 1, NULL, CAST(N'2022-12-08T04:37:53.160' AS DateTime), CAST(N'2022-12-08T16:10:07.570' AS DateTime), NULL, 0)
INSERT [dbo].[tb_Customer] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [ImageUser], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [IsAdmin]) VALUES (9, N'Tuấn Anh', N'letuananh', N'e10adc3949ba59abbe56e057f20f883e', N'letuananh4282@gmail.com', N'wall.jfif', N'0944110043', N'82, Đường số 32, Phường Bình Trị Đông B, Quận Bình Tân, TP HCM', N'Nam', NULL, 1, NULL, CAST(N'2023-11-15T16:01:25.837' AS DateTime), CAST(N'2023-12-12T21:56:27.103' AS DateTime), NULL, 0)
INSERT [dbo].[tb_Customer] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [ImageUser], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [IsAdmin]) VALUES (55, N'Lê Tanh', N'letanh', N'202cb962ac59075b964b07152d234b70', N'letuananh4282@gmail.com', N'cv.png', N'0911223344', N'82 ,Đường số 32,BTDB,Quan Binh Tan, TP HCM', NULL, NULL, 1, NULL, CAST(N'2023-12-08T13:01:37.073' AS DateTime), CAST(N'2023-12-08T13:01:37.073' AS DateTime), NULL, 0)
INSERT [dbo].[tb_Customer] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [ImageUser], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [IsAdmin]) VALUES (56, N'Lê Tanh', N'letanh123', N'202cb962ac59075b964b07152d234b70', N'letuananh4282@gmail.com', N'conan.jpg', N'0911223344', N'82 ,Đường số 32,BTDB,Quan Binh Tan, TP HCM', N'Nam', NULL, 1, NULL, CAST(N'2023-12-08T13:13:00.213' AS DateTime), CAST(N'2023-12-08T13:29:31.753' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[tb_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_CustomerCode] ON 

INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (78, 9, 6, 1, CAST(N'2023-12-13T16:18:35.137' AS DateTime), CAST(N'2023-12-13T18:46:08.257' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (82, 1, 6, 1, CAST(N'2023-12-13T16:29:09.850' AS DateTime), CAST(N'2023-12-13T18:53:42.640' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (85, 9, 5, 1, CAST(N'2023-12-13T18:34:09.070' AS DateTime), CAST(N'2023-12-13T18:56:30.237' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (86, 1, 5, 1, CAST(N'2023-12-13T18:34:55.677' AS DateTime), CAST(N'2023-12-13T18:58:40.080' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (87, 9, 6, 1, CAST(N'2023-12-13T18:53:01.913' AS DateTime), CAST(N'2023-12-13T19:05:20.550' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (88, 9, 5, 1, CAST(N'2023-12-13T18:56:55.967' AS DateTime), CAST(N'2023-12-13T19:00:40.303' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (89, 1, 5, 1, CAST(N'2023-12-13T19:01:33.690' AS DateTime), CAST(N'2023-12-13T19:01:55.497' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (90, 1, 6, 1, CAST(N'2023-12-13T19:01:40.177' AS DateTime), CAST(N'2023-12-13T19:06:16.273' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (91, 1, 5, 1, CAST(N'2023-12-14T18:33:45.123' AS DateTime), CAST(N'2023-12-14T18:34:47.817' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (92, 1, 12, 0, CAST(N'2023-12-14T18:33:54.397' AS DateTime), NULL)
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (93, 1, 10, 0, CAST(N'2023-12-14T18:34:00.180' AS DateTime), NULL)
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (94, 1, 11, 0, CAST(N'2023-12-14T18:34:05.003' AS DateTime), NULL)
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (95, 9, 6, 1, CAST(N'2023-12-14T18:47:03.673' AS DateTime), CAST(N'2023-12-14T18:47:13.860' AS DateTime))
INSERT [dbo].[tb_CustomerCode] ([CustomerCodeId], [MaKH], [MaDiscount], [IsSuDung], [CreatedDate], [UseDate]) VALUES (96, 9, 6, 1, CAST(N'2023-12-14T18:49:08.073' AS DateTime), CAST(N'2023-12-14T18:49:30.413' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_CustomerCode] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_DiscountCode] ON 

INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (5, N'Voucher 100k', N'GIAMGIA100KELECTROSHOP', N'Mã khuyến mãi trị giá 100.000 VND .
Tương ứng với 4 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 10, CAST(100000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-11T23:36:49.323' AS DateTime), CAST(N'2023-12-13T18:21:02.237' AS DateTime), NULL, 4)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (6, N'Voucher200k', N'GIAMGIA200KELECTROSHOP', N'Mã khuyến mãi trị giá 200.000 VND. 
Tương ứng với 5 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 14, CAST(200000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T02:25:30.783' AS DateTime), CAST(N'2023-12-13T23:26:47.723' AS DateTime), NULL, 5)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (7, N'Voucher 300k', N'GIAMGIA300KELECTROSHOP', N'Mã khuyến mãi trị giá 300.000 VND .
Tương ứng với 6 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 13, CAST(300000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T04:17:04.260' AS DateTime), CAST(N'2023-12-12T04:17:04.260' AS DateTime), NULL, 6)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (8, N'Voucher 400k', N'GIAMGIA400KELECTROSHOP', N'Mã khuyến mãi trị giá 400.000 VND .
Tương ứng với 7 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 8, CAST(400000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T04:18:00.280' AS DateTime), CAST(N'2023-12-12T04:26:31.427' AS DateTime), NULL, 7)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (9, N'Voucher 500k', N'GIAMGIA500KELECTROSHOP', N'Mã khuyến mãi trị giá 500.000 VND .
Tương ứng với 8 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 5, CAST(500000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T04:27:36.103' AS DateTime), CAST(N'2023-12-13T23:26:55.637' AS DateTime), NULL, 8)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (10, N'Voucher 600k', N'GIAMGIA600KELECTROSHOP', N'Mã khuyến mãi trị giá 600.000 VND .
Tương ứng với 9 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 19, CAST(600000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T20:17:45.150' AS DateTime), CAST(N'2023-12-12T20:17:45.150' AS DateTime), NULL, 9)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (11, N'Voucher 700k', N'GIAMGIA700KELECTROSHOP', N'Mã khuyến mãi trị giá 700.000 VND .
Tương ứng với 9 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 18, CAST(700000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T20:18:28.910' AS DateTime), CAST(N'2023-12-12T20:18:28.910' AS DateTime), NULL, 9)
INSERT [dbo].[tb_DiscountCode] ([MaDiscount], [TenDiscount], [DiscountCode], [Description], [Quantity], [Value], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [SoDiemCanDoi]) VALUES (12, N'Voucher 800k', N'GIAMGIA800KELECTROSHOP', N'Mã khuyến mãi trị giá 800.000 VND .
Tương ứng với 10 điểm để có thể đổi mã.
Có thể áp dụng trực tiếp giỏ hàng', 19, CAST(800000.00 AS Decimal(18, 2)), 1, N'PhanNhatHao', CAST(N'2023-12-12T20:58:58.207' AS DateTime), CAST(N'2023-12-12T20:58:58.207' AS DateTime), NULL, 10)
SET IDENTITY_INSERT [dbo].[tb_DiscountCode] OFF
GO
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (0, 9, 22)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (15, 1, 25)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (17, 56, 23)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (18, 56, 24)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (19, 56, 22)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (21, 56, 25)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (22, 9, 24)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (23, 9, 25)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (24, 9, 32)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (27, 1, 23)
INSERT [dbo].[tb_FavoriteProduct] ([MaYeuThich], [MaKH], [MaSanPham]) VALUES (28, 1, 22)
GO
SET IDENTITY_INSERT [dbo].[tb_Memory] ON 

INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (5, N'2GB', NULL, NULL, CAST(N'2022-11-20T00:20:01.360' AS DateTime), CAST(N'2022-12-09T02:29:02.207' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (6, N'4GB', NULL, NULL, CAST(N'2022-12-09T02:28:43.420' AS DateTime), CAST(N'2022-12-09T02:29:08.523' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (7, N'8GB', NULL, NULL, CAST(N'2022-12-09T02:29:16.597' AS DateTime), CAST(N'2022-12-09T02:29:16.597' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (8, N'16GB', NULL, NULL, CAST(N'2022-12-09T02:29:24.553' AS DateTime), CAST(N'2022-12-09T02:29:24.553' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (9, N'32GB', NULL, NULL, CAST(N'2022-12-09T02:29:41.020' AS DateTime), CAST(N'2022-12-09T02:29:41.020' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (10, N'64GB', NULL, NULL, CAST(N'2022-12-09T02:30:05.867' AS DateTime), CAST(N'2022-12-09T02:30:05.867' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (11, N'128GB', NULL, NULL, CAST(N'2022-12-09T02:30:15.153' AS DateTime), CAST(N'2022-12-09T02:30:15.153' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (12, N'256GB', NULL, NULL, CAST(N'2022-12-09T02:30:25.833' AS DateTime), CAST(N'2022-12-09T02:30:25.833' AS DateTime), NULL)
INSERT [dbo].[tb_Memory] ([MaMemory], [TenMemory], [Description], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (13, N'512GB', NULL, NULL, CAST(N'2022-12-09T02:30:32.767' AS DateTime), CAST(N'2022-12-09T02:30:32.767' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_Memory] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_NhanVien] ON 

INSERT [dbo].[tb_NhanVien] ([MaNhanVien], [TenNhanVien], [TaiKhoan], [MatKhau], [Email], [ImageNhanVien], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [IsQuanTriVien], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Phan Nhật Hào', N'PhanNhatHao', N'4297f44b13955235245b2497399d7a93', N'trochoivuongquyen30072000@gmail.com', NULL, N'0918798849', N'36/5C Ấp 2,Xuân Thới Thượng,Hóc Môn,TP.Hồ Chí Minh', N'Nam', NULL, 1, 1, NULL, CAST(N'2022-12-12T01:28:29.353' AS DateTime), CAST(N'2022-12-12T01:28:29.353' AS DateTime), NULL)
INSERT [dbo].[tb_NhanVien] ([MaNhanVien], [TenNhanVien], [TaiKhoan], [MatKhau], [Email], [ImageNhanVien], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [IsQuanTriVien], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Phan Nhật Huy', N'PhanNhatHuy', N'4297f44b13955235245b2497399d7a93', N'trochoivuongquyen30072000@gmail.com', NULL, N'0918798849', N'36/5C Ấp 2,Xuân Thới Thượng,Hóc Môn,TP.Hồ Chí Minh', N'Nam', NULL, 1, 0, NULL, CAST(N'2022-12-12T03:05:46.607' AS DateTime), CAST(N'2022-12-12T03:05:46.607' AS DateTime), NULL)
INSERT [dbo].[tb_NhanVien] ([MaNhanVien], [TenNhanVien], [TaiKhoan], [MatKhau], [Email], [ImageNhanVien], [Phone], [Address], [GioiTinh], [NgaySinh], [IsActive], [IsQuanTriVien], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (7, N'Tuấn Anh', N'letuananh4282', N'35e01435e36e2918a80690f99ce296b4', N'letuananh@gmail.com', NULL, N'0944110044', N'82, Đường số 32, Phường Bình Trị Đông B, Quận Bình Tân, TP HCM', N'Nam', NULL, 1, 0, NULL, CAST(N'2023-11-17T11:35:11.253' AS DateTime), CAST(N'2023-11-17T11:35:11.253' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Order] ON 

INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2226, 9, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-11T23:18:02.000' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2227, 9, 5, NULL, 0, 0, 0, CAST(47800000.00 AS Decimal(18, 2)), CAST(N'2023-12-01T23:23:33.917' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2228, 9, 5, NULL, 0, 0, 1, CAST(22850000.00 AS Decimal(18, 2)), CAST(N'2023-12-01T23:23:57.960' AS DateTime), CAST(N'2023-12-12T04:22:11.423' AS DateTime), 0, N'Đã hủy', NULL, N'ab', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2229, 1, 5, NULL, 0, 0, 0, CAST(22850000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T03:33:21.600' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2230, 1, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T04:39:26.543' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2231, 1, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T04:55:04.233' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2232, 9, 5, NULL, 0, 0, 0, CAST(50000000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T18:35:03.547' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2233, 9, 5, NULL, 0, 0, 0, CAST(53990000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T18:35:30.160' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2234, 9, 5, NULL, 0, 0, 1, CAST(47800000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T18:35:54.970' AS DateTime), CAST(N'2023-12-12T22:16:17.463' AS DateTime), 0, N'Đã hủy', NULL, N'Tôi đặt nhầm', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2235, 9, 5, NULL, 0, 0, 0, CAST(53990000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T18:37:20.273' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2236, 9, 5, NULL, 0, 0, 0, CAST(125000000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T18:39:22.173' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2237, 9, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:13:33.983' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2238, 9, 5, NULL, 0, 0, 0, CAST(57980000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:14:43.433' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2239, 9, 5, NULL, 0, 0, 0, CAST(125000000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:16:34.223' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2240, 9, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:39:11.630' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2241, 9, 5, NULL, 0, 0, 0, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:41:24.697' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2242, 9, 5, NULL, 0, 0, 0, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:42:43.647' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2243, 9, 5, NULL, 1, 1, 0, CAST(144950000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:43:33.000' AS DateTime), CAST(N'2023-12-14T18:33:01.513' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2244, 1, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:51:51.990' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2245, 1, 5, NULL, 0, 0, 1, CAST(22850000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:53:14.130' AS DateTime), CAST(N'2023-12-13T00:28:34.643' AS DateTime), 0, N'Đã hủy', NULL, N'kkkkkkkkkkkk', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2246, 1, 5, NULL, 0, 0, 1, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:54:05.100' AS DateTime), CAST(N'2023-12-13T00:28:02.717' AS DateTime), 0, N'Đã hủy', NULL, N'alooo', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2247, 1, 5, NULL, 0, 0, 1, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T19:58:28.040' AS DateTime), CAST(N'2023-12-13T00:27:18.260' AS DateTime), 0, N'Đã hủy', NULL, N'Hủy đó', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2250, 1, 5, NULL, 1, 1, 0, CAST(144950000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T20:03:16.000' AS DateTime), CAST(N'2023-12-13T00:13:04.063' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2251, 1, 5, NULL, 1, 1, 0, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T20:07:52.000' AS DateTime), CAST(N'2023-12-13T00:12:33.270' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2252, 1, 5, NULL, 1, 1, 0, CAST(144950000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T20:08:05.000' AS DateTime), CAST(N'2023-12-12T23:59:18.557' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2255, 9, 5, NULL, 1, 1, 0, CAST(22850000.00 AS Decimal(18, 2)), CAST(N'2023-12-12T22:28:00.000' AS DateTime), CAST(N'2023-12-12T22:33:16.423' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2259, 9, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:24:54.453' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2260, 9, 5, NULL, 0, 0, 0, CAST(22750000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:32:18.600' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2261, 9, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:38:05.557' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2262, 9, 5, NULL, 0, 0, 0, CAST(28940000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:39:59.423' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2263, 9, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:42:36.090' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2264, 9, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:45:30.670' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2265, 9, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T17:47:58.627' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2266, 9, 5, NULL, 0, 0, 0, CAST(28840000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T18:46:08.260' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2267, 9, 5, NULL, 0, 0, 0, CAST(24850000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T18:53:42.640' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2268, 9, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T18:56:30.237' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2269, 9, 5, NULL, 0, 0, 1, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T18:58:40.000' AS DateTime), CAST(N'2023-12-14T18:32:17.500' AS DateTime), 0, N'Đã hủy', 5, N'Trời ời', 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2270, 9, 5, NULL, 1, 1, 0, CAST(28940000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T19:00:40.000' AS DateTime), CAST(N'2023-12-14T18:32:55.450' AS DateTime), 1, N'Hoàn thành', 5, N'aaaa', 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2271, 1, 5, NULL, 1, 1, 0, CAST(28940000.00 AS Decimal(18, 2)), CAST(N'2023-12-13T19:01:55.000' AS DateTime), CAST(N'2023-12-14T18:30:37.107' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2274, 1, 5, NULL, 0, 0, 0, CAST(24950000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T18:34:47.817' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2275, 9, 5, NULL, 0, 0, 0, CAST(24850000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T18:47:13.863' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, 95, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2276, 9, 5, NULL, 0, 0, 0, CAST(29040000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T18:48:35.650' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2277, 9, 5, NULL, 1, 1, 0, CAST(28840000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T18:49:30.000' AS DateTime), CAST(N'2023-12-14T18:59:59.617' AS DateTime), 1, N'Hoàn thành', 5, NULL, 1, 1, NULL, 1)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2278, 1, 5, NULL, 0, 0, 0, CAST(22850000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T19:01:15.403' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, 0)
INSERT [dbo].[tb_Order] ([MaDonHang], [MaKH], [MaPhuongThucThanhToan], [GhiChu], [IsThanhToan], [IsHoanThanh], [IsHuyDon], [TotalPayment], [CreateDate], [UpdatedDate], [IsXacNhan], [TrangThai], [MaNhanVien], [LyDoHuyDon], [IsDongGoi], [IsVanChuyen], [CustomerCodeID], [IsNhanDiem]) VALUES (2279, 9, 5, NULL, 0, 0, 0, CAST(25050000.00 AS Decimal(18, 2)), CAST(N'2023-12-14T19:08:59.187' AS DateTime), NULL, 0, N'Chờ xác nhận', NULL, NULL, 0, 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[tb_Order] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_PhuongThucThanhToan] ON 

INSERT [dbo].[tb_PhuongThucThanhToan] ([MaPhuongThucThanhToan], [TenPhuongThucThanhToan], [Description], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (5, N'Cod', N'Trả tiền sau khi nhận hàng', 1, NULL, CAST(N'2022-12-01T03:35:00.577' AS DateTime), CAST(N'2022-12-01T03:35:00.577' AS DateTime), NULL)
INSERT [dbo].[tb_PhuongThucThanhToan] ([MaPhuongThucThanhToan], [TenPhuongThucThanhToan], [Description], [IsActive], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Chuyển khoản', N'Trả tiền trước khi nhận hàng', 1, NULL, CAST(N'2022-12-01T03:35:24.560' AS DateTime), CAST(N'2022-12-01T03:35:24.560' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_PhuongThucThanhToan] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Product] ON 

INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (22, N'MacBook Pro 2022', NULL, NULL, CAST(30000000.00 AS Decimal(18, 2)), CAST(28990000.00 AS Decimal(18, 2)), 3, NULL, N'macbook-pro-2022', 1, 0, 1, 1, 0, N'MacBook Pro 2022', NULL, NULL, NULL, CAST(N'2022-12-09T02:46:34.623' AS DateTime), CAST(N'2023-12-14T18:31:44.563' AS DateTime), NULL, 14, 9, 9, 12)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (23, N'MacBook Air 2022', NULL, NULL, CAST(25000000.00 AS Decimal(18, 2)), CAST(22990000.00 AS Decimal(18, 2)), 2, NULL, N'macbook-air-2022', 1, 0, 0, 1, 1, N'MacBook Air 2022', NULL, NULL, NULL, CAST(N'2022-12-09T03:21:02.920' AS DateTime), CAST(N'2023-11-23T23:25:55.240' AS DateTime), NULL, 14, 9, 7, 13)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (24, N'HP Envy', NULL, NULL, CAST(23800000.00 AS Decimal(18, 2)), CAST(22800000.00 AS Decimal(18, 2)), 6, NULL, N'hp-envy', 1, 0, 1, 1, 0, N'HP Envy', NULL, NULL, NULL, CAST(N'2022-12-09T03:28:31.653' AS DateTime), CAST(N'2023-11-23T23:25:44.400' AS DateTime), NULL, 14, 19, 9, 13)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (25, N'HP Envy 13', NULL, NULL, CAST(24800000.00 AS Decimal(18, 2)), CAST(23800000.00 AS Decimal(18, 2)), 3, NULL, N'hp-envy-13', 1, 0, 1, 0, 0, N'HP Envy 13', NULL, NULL, NULL, CAST(N'2022-12-09T03:45:44.350' AS DateTime), CAST(N'2022-12-09T04:32:16.430' AS DateTime), NULL, 14, 19, 9, 12)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (26, N'Mi 12x', NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), CAST(11800000.00 AS Decimal(18, 2)), 5, NULL, N'mi-12x', 1, 0, 0, 1, 0, N'Mi 12x', NULL, NULL, NULL, CAST(N'2022-12-09T04:03:27.203' AS DateTime), CAST(N'2022-12-09T04:03:27.203' AS DateTime), NULL, 13, 11, 10, 10)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (27, N'Iphone 14 Pro Max', NULL, NULL, CAST(25000000.00 AS Decimal(18, 2)), CAST(24000000.00 AS Decimal(18, 2)), 4, NULL, N'iphone-14-pro-max', 1, 0, 1, 1, 0, N'Iphone 14 Pro Max', NULL, NULL, NULL, CAST(N'2022-12-09T04:14:11.437' AS DateTime), CAST(N'2022-12-09T04:14:11.437' AS DateTime), NULL, 13, 9, 11, 11)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (28, N'Iphone 14', NULL, NULL, CAST(23800000.00 AS Decimal(18, 2)), CAST(22800000.00 AS Decimal(18, 2)), 4, NULL, N'iphone-14', 1, 0, 1, 1, 1, N'Iphone 14', NULL, NULL, NULL, CAST(N'2022-12-09T04:32:04.483' AS DateTime), CAST(N'2022-12-09T04:32:04.483' AS DateTime), NULL, 13, 9, 12, 11)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (29, N'SamSung S22 5G', NULL, NULL, CAST(18000000.00 AS Decimal(18, 2)), CAST(16000000.00 AS Decimal(18, 2)), 7, NULL, N'samsung-s22-5g', 1, 0, 1, 1, 1, N'SamSung S22 5G', NULL, NULL, NULL, CAST(N'2022-12-09T04:35:33.860' AS DateTime), CAST(N'2022-12-09T04:35:33.860' AS DateTime), NULL, 13, 12, 10, 12)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (30, N'Samsung galaxy Z Fold 4 5G', NULL, NULL, CAST(33590000.00 AS Decimal(18, 2)), CAST(32590000.00 AS Decimal(18, 2)), 7, NULL, N'samsung-galaxy-z-fold-4-5g', 1, 0, 1, 1, 1, N'Samsung galaxy Z Fold 4 5G', NULL, NULL, NULL, CAST(N'2022-12-09T11:27:00.120' AS DateTime), CAST(N'2022-12-09T11:27:00.120' AS DateTime), NULL, 13, 12, 10, 12)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (31, N'Tai nghe Bluetooth Apple AirPods 2 ', NULL, NULL, CAST(3990000.00 AS Decimal(18, 2)), CAST(2690000.00 AS Decimal(18, 2)), 1, NULL, N'tai-nghe-bluetooth-apple-airpods-2', 1, 1, 1, 1, 1, N'Tai nghe Bluetooth Apple AirPods 2 ', NULL, NULL, NULL, CAST(N'2022-12-09T11:42:29.350' AS DateTime), CAST(N'2023-11-24T11:06:59.253' AS DateTime), NULL, 15, 9, 13, NULL)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (32, N'Tai nghe không dây Samsung Galaxy Buds2 Pro', NULL, NULL, CAST(4990000.00 AS Decimal(18, 2)), CAST(3790000.00 AS Decimal(18, 2)), 9, NULL, N'tai-nghe-khong-day-samsung-galaxy-buds2-pro', 1, 0, 1, 1, 1, N'Tai nghe không dây Samsung Galaxy Buds2 Pro', NULL, NULL, NULL, CAST(N'2022-12-09T11:48:07.783' AS DateTime), CAST(N'2022-12-09T11:48:07.783' AS DateTime), NULL, 15, 12, 10, NULL)
INSERT [dbo].[tb_Product] ([MaSanPham], [TenSanPham], [Description], [Detail], [Price], [PriceSale], [Quantity], [ImageProduct], [Link], [IsActive], [IsSoldOut], [IsSale], [IsNew], [IsHot], [SeoTitle], [SeoDescription], [SeoKeywords], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy], [MaProductCategory], [MaBrand], [MaColor], [MaMemory]) VALUES (33, N'Tai nghe Có Dây Samsung IA500', NULL, NULL, CAST(300000.00 AS Decimal(18, 2)), CAST(290000.00 AS Decimal(18, 2)), 5, NULL, N'tai-nghe-co-day-samsung-ia500', 1, 0, 1, 1, 1, N'Tai nghe Có Dây Samsung IA500', NULL, NULL, NULL, CAST(N'2022-12-09T15:57:40.940' AS DateTime), CAST(N'2022-12-09T16:33:31.643' AS DateTime), NULL, 15, 12, 10, NULL)
SET IDENTITY_INSERT [dbo].[tb_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ProductCategory] ON 

INSERT [dbo].[tb_ProductCategory] ([MaProductCategory], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (13, N'Điện thoại', NULL, 1, 1, N'dien-thoai', NULL, CAST(N'2022-11-24T12:25:21.737' AS DateTime), CAST(N'2022-11-24T12:25:21.737' AS DateTime), NULL)
INSERT [dbo].[tb_ProductCategory] ([MaProductCategory], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (14, N'Lap top', NULL, 2, 1, N'lap-top', NULL, CAST(N'2022-11-24T12:25:37.047' AS DateTime), CAST(N'2022-11-24T12:25:37.047' AS DateTime), NULL)
INSERT [dbo].[tb_ProductCategory] ([MaProductCategory], [TenDanhMuc], [Description], [Position], [IsActive], [Link], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (15, N'Phụ kiện', NULL, 3, 1, N'phu-kien', NULL, CAST(N'2022-11-25T18:03:51.897' AS DateTime), CAST(N'2022-11-25T18:03:51.897' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ProductImages] ON 

INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (36, N'/Uploads/images/ProductImage/macbook-pro-m1-2021-silver-14-1024x1024.jpg', NULL, 1, 22, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (37, N'/Uploads/images/ProductImage/macbook-pro-m1-2021_1669887580.png', NULL, 0, 22, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (38, N'/Uploads/images/ProductImage/macbook-pro-m2-oneway-silver-1_1662431435.png', NULL, 0, 22, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (39, N'/Uploads/images/ProductImage/mac-512edgfhgh-595x553.jpg', NULL, 1, 23, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (40, N'/Uploads/images/ProductImage/mac1gjhk-595x445.jpg', NULL, 0, 23, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (41, N'/Uploads/images/ProductImage/mac1hjlkl-1-595x462.jpg', NULL, 0, 23, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (42, N'/Uploads/images/ProductImage/HP-ENVY-17t-cg000-Laptop-www_laptopvip_vn-1623487239.jpg', NULL, 1, 24, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (43, N'/Uploads/images/ProductImage/51KiTmQVzAL__SL1000_.jpg', NULL, 0, 24, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (44, N'/Uploads/images/ProductImage/2008_Hpenvy13.jpg', NULL, 0, 25, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (45, N'/Uploads/images/ProductImage/5170_hp_envy_13_aq1047tu_8xs69pa_5.jpg', NULL, 1, 25, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (46, N'/Uploads/images/ProductImage/xiaomi-12x-didongviet_1.jpg', NULL, 1, 26, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (47, N'/Uploads/images/ProductImage/61ib0WL4fjL__AC_SL1500_.jpg', NULL, 0, 26, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (48, N'/Uploads/images/ProductImage/iphone.png', NULL, 1, 27, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (49, N'/Uploads/images/ProductImage/iphone_14_purple.jpg', NULL, 1, 28, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (50, N'/Uploads/images/ProductImage/655e734f88904b7510126a0d9992b2a5.jpg', NULL, 1, 29, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (51, N'/Uploads/images/ProductImage/657eca11baf1bc21508e46784fbb2c03.jpg', NULL, 0, 29, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (52, N'/Uploads/images/ProductImage/10052908-dien-thoai-samsung-galaxy-z-fold-4-5g-256gb-xam-3.jpg', NULL, 1, 30, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (53, N'/Uploads/images/ProductImage/samsung-galaxy-z-fold-4-5g(2).jpg', NULL, 0, 30, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (54, N'/Uploads/images/ProductImage/tai-nghe-airpods-2.jpg', NULL, 1, 31, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (55, N'/Uploads/images/ProductImage/Tai_nghe_Bluetooth_Apple_AirPods_2.jpeg', NULL, 0, 31, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (56, N'/Uploads/images/ProductImage/tai-nghe-bluetooth-samsung-galaxy-buds2-pro-didongviet_1_1.jpg', NULL, 1, 32, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (57, N'/Uploads/images/ProductImage/big_tai-nghe-galaxy-buds2-pro-moi-gia-bao-nhieu.jpg', NULL, 0, 32, NULL, NULL)
INSERT [dbo].[tb_ProductImages] ([MaImages], [Image], [Description], [IsDefault], [MaSanPham], [CreateDate], [CreatedBy]) VALUES (58, N'/Uploads/images/ProductImage/nhet-tai-samsung-ia500-den-thumb-600x600.jpg', NULL, 1, 33, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ProductReview] ON 

INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (20, 24, 9, N'aaaaaaaaaaaaa', 4, CAST(N'2023-12-14T02:52:31.813' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (21, 24, 9, N'bbbbbbbbbbbbb', 2, CAST(N'2023-12-14T02:54:55.323' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (22, 28, 56, N'Trời ơi', 4, CAST(N'2023-12-14T02:56:35.943' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (23, 28, 56, N'jkkkkkkkkkkkkkk', 1, CAST(N'2023-12-14T02:56:54.263' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (24, 24, 56, N'bbbbbbbbbbbbbb', 4, CAST(N'2023-12-14T03:10:49.710' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (25, 24, 56, N'hjjjjjjjjjjjjjjj', 4, CAST(N'2023-12-14T03:11:21.257' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (26, 29, 56, N'KKKKKKKKKKKKKKK', 4, CAST(N'2023-12-14T14:09:56.893' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (27, 22, 56, N'Đáng mua', 5, CAST(N'2023-12-14T14:57:54.280' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (28, 24, 56, N'Đánh giá lên cao', 1, CAST(N'2023-12-14T15:08:36.953' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (29, 24, 56, N'Gì zậy', 5, CAST(N'2023-12-14T15:08:47.993' AS DateTime))
INSERT [dbo].[tb_ProductReview] ([MaReview], [MaSanPham], [MaKH], [NoiDung], [Rating], [NgayDanhGia]) VALUES (30, 24, 56, N'alooo', 5, CAST(N'2023-12-14T15:09:34.733' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_ProductReview] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_TaiKhoanNganHang] ON 

INSERT [dbo].[tb_TaiKhoanNganHang] ([MaSoTaiKhoan], [TenNganHang], [Description], [SoTaiKhoan], [CreatedBy], [CreateDate], [UpdatedDate], [UpdatedBy]) VALUES (6, N'Agribank', N'Chi nhánh bắc sài gòn', N'00000000000', NULL, CAST(N'2022-12-01T03:36:26.090' AS DateTime), CAST(N'2022-12-01T03:36:26.090' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tb_TaiKhoanNganHang] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_TichDiem] ON 

INSERT [dbo].[tb_TichDiem] ([SoDiemCongGanNhat], [TongSoDiem], [MaDonHang], [CreateDate], [UpdatedDate], [MaTichDiem], [MaKH], [MaDiscount]) VALUES (5, 25, 2226, CAST(N'2023-12-11T23:18:01.990' AS DateTime), CAST(N'2023-12-14T19:00:09.793' AS DateTime), 13, 9, 6)
INSERT [dbo].[tb_TichDiem] ([SoDiemCongGanNhat], [TongSoDiem], [MaDonHang], [CreateDate], [UpdatedDate], [MaTichDiem], [MaKH], [MaDiscount]) VALUES (28, 1, 2229, CAST(N'2023-12-12T03:33:21.590' AS DateTime), CAST(N'2023-12-14T18:34:05.003' AS DateTime), 28, 1, 11)
SET IDENTITY_INSERT [dbo].[tb_TichDiem] OFF
GO
ALTER TABLE [dbo].[tb_ChiTietOrder]  WITH CHECK ADD  CONSTRAINT [FK_tb_ChiTietOrder_tb_Order] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[tb_Order] ([MaDonHang])
GO
ALTER TABLE [dbo].[tb_ChiTietOrder] CHECK CONSTRAINT [FK_tb_ChiTietOrder_tb_Order]
GO
ALTER TABLE [dbo].[tb_ChiTietOrder]  WITH CHECK ADD  CONSTRAINT [FK_tb_ChiTietOrder_tb_Product] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[tb_Product] ([MaSanPham])
GO
ALTER TABLE [dbo].[tb_ChiTietOrder] CHECK CONSTRAINT [FK_tb_ChiTietOrder_tb_Product]
GO
ALTER TABLE [dbo].[tb_ChiTietOrder-Traveler]  WITH CHECK ADD  CONSTRAINT [FK_tb_ChiTietOrder-Traveler_tb_Product] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[tb_Product] ([MaSanPham])
GO
ALTER TABLE [dbo].[tb_ChiTietOrder-Traveler] CHECK CONSTRAINT [FK_tb_ChiTietOrder-Traveler_tb_Product]
GO
ALTER TABLE [dbo].[tb_ChiTietOrder-Traveler]  WITH CHECK ADD  CONSTRAINT [FK_tb_ChiTietOrder-Traveler_tb_Traveler] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[tb_Traveler] ([MaDonHang])
GO
ALTER TABLE [dbo].[tb_ChiTietOrder-Traveler] CHECK CONSTRAINT [FK_tb_ChiTietOrder-Traveler_tb_Traveler]
GO
ALTER TABLE [dbo].[tb_Contact]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[tb_Contact]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_CustomerCode]  WITH CHECK ADD  CONSTRAINT [FK_tb_CustomerCode_tb_Customer] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_CustomerCode] CHECK CONSTRAINT [FK_tb_CustomerCode_tb_Customer]
GO
ALTER TABLE [dbo].[tb_CustomerCode]  WITH CHECK ADD  CONSTRAINT [FK_tb_CustomerCode_tb_DiscountCode] FOREIGN KEY([MaDiscount])
REFERENCES [dbo].[tb_DiscountCode] ([MaDiscount])
GO
ALTER TABLE [dbo].[tb_CustomerCode] CHECK CONSTRAINT [FK_tb_CustomerCode_tb_DiscountCode]
GO
ALTER TABLE [dbo].[tb_FavoriteProduct]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[tb_Product] ([MaSanPham])
GO
ALTER TABLE [dbo].[tb_FavoriteProduct]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_CustomerCode] FOREIGN KEY([CustomerCodeID])
REFERENCES [dbo].[tb_CustomerCode] ([CustomerCodeId])
GO
ALTER TABLE [dbo].[tb_Order] CHECK CONSTRAINT [FK_Order_CustomerCode]
GO
ALTER TABLE [dbo].[tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_tb_Order_tb_Customer] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_Order] CHECK CONSTRAINT [FK_tb_Order_tb_Customer]
GO
ALTER TABLE [dbo].[tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_tb_Order_tb_Nhanvien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[tb_Order] CHECK CONSTRAINT [FK_tb_Order_tb_Nhanvien]
GO
ALTER TABLE [dbo].[tb_Order]  WITH CHECK ADD  CONSTRAINT [FK_tb_Order_tb_PhuongThucThanhToan] FOREIGN KEY([MaPhuongThucThanhToan])
REFERENCES [dbo].[tb_PhuongThucThanhToan] ([MaPhuongThucThanhToan])
GO
ALTER TABLE [dbo].[tb_Order] CHECK CONSTRAINT [FK_tb_Order_tb_PhuongThucThanhToan]
GO
ALTER TABLE [dbo].[tb_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_tb_PhanQuyen_tb_ChucNang] FOREIGN KEY([MaChucNang])
REFERENCES [dbo].[tb_ChucNang] ([MaChucNang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_PhanQuyen] CHECK CONSTRAINT [FK_tb_PhanQuyen_tb_ChucNang]
GO
ALTER TABLE [dbo].[tb_PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_tb_PhanQuyen_tb_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_PhanQuyen] CHECK CONSTRAINT [FK_tb_PhanQuyen_tb_NhanVien]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_Brand] FOREIGN KEY([MaBrand])
REFERENCES [dbo].[tb_Brand] ([MaBrand])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_Brand]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_Color1] FOREIGN KEY([MaColor])
REFERENCES [dbo].[tb_Color] ([MaColor])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_Color1]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_Memory] FOREIGN KEY([MaMemory])
REFERENCES [dbo].[tb_Memory] ([MaMemory])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_Memory]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_ProductCategory] FOREIGN KEY([MaProductCategory])
REFERENCES [dbo].[tb_ProductCategory] ([MaProductCategory])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_ProductCategory]
GO
ALTER TABLE [dbo].[tb_ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_tb_ProductImages_tb_Product1] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[tb_Product] ([MaSanPham])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_ProductImages] CHECK CONSTRAINT [FK_tb_ProductImages_tb_Product1]
GO
ALTER TABLE [dbo].[tb_ProductReview]  WITH CHECK ADD FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[tb_Product] ([MaSanPham])
GO
ALTER TABLE [dbo].[tb_ProductReview]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_TichDiem]  WITH CHECK ADD  CONSTRAINT [FK_tb_TichDiem_tb_Customer] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tb_Customer] ([MaKH])
GO
ALTER TABLE [dbo].[tb_TichDiem] CHECK CONSTRAINT [FK_tb_TichDiem_tb_Customer]
GO
ALTER TABLE [dbo].[tb_TichDiem]  WITH CHECK ADD  CONSTRAINT [FK_tb_TichDiem_tb_DiscountCode] FOREIGN KEY([MaDiscount])
REFERENCES [dbo].[tb_DiscountCode] ([MaDiscount])
GO
ALTER TABLE [dbo].[tb_TichDiem] CHECK CONSTRAINT [FK_tb_TichDiem_tb_DiscountCode]
GO
ALTER TABLE [dbo].[tb_TichDiem]  WITH CHECK ADD  CONSTRAINT [FK_tb_TichDiem_tb_Order] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[tb_Order] ([MaDonHang])
GO
ALTER TABLE [dbo].[tb_TichDiem] CHECK CONSTRAINT [FK_tb_TichDiem_tb_Order]
GO
ALTER TABLE [dbo].[tb_Traveler]  WITH CHECK ADD  CONSTRAINT [FK_tb_Traveler_tb_Nhanvien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[tb_Traveler] CHECK CONSTRAINT [FK_tb_Traveler_tb_Nhanvien]
GO
ALTER TABLE [dbo].[tb_Traveler]  WITH CHECK ADD  CONSTRAINT [FK_tb_Traveler_tb_PhuongThucThanhToan] FOREIGN KEY([MaPhuongThucThanhToan])
REFERENCES [dbo].[tb_PhuongThucThanhToan] ([MaPhuongThucThanhToan])
GO
ALTER TABLE [dbo].[tb_Traveler] CHECK CONSTRAINT [FK_tb_Traveler_tb_PhuongThucThanhToan]
GO
USE [master]
GO
ALTER DATABASE [DBQuanLyBanDoCongNghe] SET  READ_WRITE 
GO
