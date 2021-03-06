USE [GiaoHangGiaRe]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/14/2018 10:48:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/14/2018 10:48:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/14/2018 10:48:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
	[ImageLink] [nvarchar](max) NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[BaoGia] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.BangGia] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commune]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commune](
	[Commune_Id] [int] IDENTITY(1,1) NOT NULL,
	[Commune_Code] [nvarchar](max) NULL,
	[Commune_Name] [nvarchar](max) NOT NULL,
	[District_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Commune] PRIMARY KEY CLUSTERED 
(
	[Commune_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[District_Id] [int] IDENTITY(1,1) NOT NULL,
	[District_Code] [nvarchar](max) NULL,
	[District_Name] [nvarchar](max) NOT NULL,
	[Province_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.District] PRIMARY KEY CLUSTERED 
(
	[District_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[NguoiGui] [nvarchar](50) NULL,
	[DiaChiGui] [nvarchar](50) NULL,
	[SoDienThoaiNguoiGui] [nvarchar](50) NULL,
	[NguoiNhan] [nvarchar](50) NULL,
	[DiaChiNhan] [nvarchar](50) NULL,
	[SoDienThoaiNguoiNhan] [nvarchar](50) NULL,
	[MaNhanVienGiao] [int] NULL,
	[GhiChu] [varchar](max) NULL,
	[TinhTrang] [int] NOT NULL,
	[ThoiDiemDatDonHang] [datetime] NULL,
	[ThoiDiemTiepNhanDon] [datetime] NULL,
	[ThoiDiemHoanThanhDH] [datetime] NULL,
	[ThanhTien] [int] NULL,
	[deleted] [bit] NULL,
	[MaHanhTrinh] [int] NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HanhTrinh]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HanhTrinh](
	[MaHanhTrinh] [int] IDENTITY(1,1) NOT NULL,
	[HanhTrinh1] [varchar](max) NULL,
	[DiemBatDau] [nvarchar](50) NULL,
	[DiemKetThuc] [nvarchar](50) NULL,
	[QuangDuong] [int] NULL,
	[ThoiGian] [int] NULL,
	[deleted] [bit] NULL,
 CONSTRAINT [PK_dbo.HanhTrinh] PRIMARY KEY CLUSTERED 
(
	[MaHanhTrinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] NOT NULL,
	[MaDonHang] [int] NULL,
	[ThanhTien] [money] NULL,
	[MaKhachHang] [int] NULL,
	[MaNhanVienGH] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageContent] [nvarchar](max) NULL,
	[title] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL,
	[create_by] [nvarchar](max) NULL,
	[create_at] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Image] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[CongTy] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[MaLoaiKH] [int] NULL,
	[NgaySinh] [datetime] NULL,
	[TrangThai] [int] NOT NULL,
	[deleted] [bit] NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoChua]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoChua](
	[MaKhoChua] [int] NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienTich] [real] NOT NULL,
	[SoDienThoai] [nvarchar](20) NULL,
 CONSTRAINT [PK_dbo.KhoChua] PRIMARY KEY CLUSTERED 
(
	[MaKhoChua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KienHang]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KienHang](
	[MaKienHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NULL,
	[TinhTrang] [nvarchar](50) NULL,
	[deleted] [bit] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TrongLuong] [int] NULL,
	[ChieuDai] [int] NULL,
	[ChieuRong] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoLuong] [int] NULL,
	[NoiDung] [nvarchar](50) NULL,
	[MaKhoChua] [int] NOT NULL,
 CONSTRAINT [PK_dbo.KienHang] PRIMARY KEY CLUSTERED 
(
	[MaKienHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSu]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSu](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[HanhDong] [nvarchar](max) NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ViTriThaoTac] [nvarchar](max) NULL,
	[ThoiGianThucHien] [datetime] NULL,
 CONSTRAINT [PK_dbo.LichSu] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKhachHang]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhachHang](
	[MaLoaiKH] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiKH] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.LoaiKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[NgayBatDau] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[PhanQuen_MaPhanQuen] [int] NULL,
	[SoDienThoai] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[TrangThai] [int] NOT NULL,
	[deleted] [bit] NULL,
	[TenTaiKhoan] [nvarchar](max) NULL,
	[ChucVu] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[No]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[No](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[KyHieu] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoTien] [int] NOT NULL,
	[MaKhachHang] [nvarchar](max) NULL,
	[ThoiGian] [datetime] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_dbo.No] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Province_Id] [int] IDENTITY(1,1) NOT NULL,
	[Province_Code] [nvarchar](max) NULL,
	[Province_Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Province] PRIMARY KEY CLUSTERED 
(
	[Province_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinNhan]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinNhan](
	[MaTinNhan] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [varchar](max) NULL,
	[ThoiGian] [datetime] NULL,
	[MaKienHang] [int] NULL,
 CONSTRAINT [PK_dbo.TinNhan] PRIMARY KEY CLUSTERED 
(
	[MaTinNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UuDai]    Script Date: 7/14/2018 10:48:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UuDai](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[DoiTuongApDung] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UuDai] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [isDelete]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT ('') FOR [TenTaiKhoan]
GO
ALTER TABLE [dbo].[Image] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [create_at]
GO
ALTER TABLE [dbo].[KienHang] ADD  DEFAULT ((0)) FOR [MaKhoChua]
GO
ALTER TABLE [dbo].[No] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
