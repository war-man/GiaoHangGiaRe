namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecsdl10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        NguoiGui = c.String(maxLength: 50),
                        DiaChiGui = c.String(maxLength: 50),
                        SoDienThoaiNguoiGui = c.String(maxLength: 50),
                        NguoiNhan = c.String(maxLength: 50),
                        DiaChiNhan = c.String(maxLength: 50),
                        SoDienThoaiNguoiNhan = c.String(maxLength: 50),
                        MaNhanVienGiao = c.Int(),
                        GhiChu = c.String(unicode: false, storeType: "text"),
                        TinhTrang = c.String(maxLength: 50),
                        ThoiDiemDatDonHang = c.DateTime(),
                        ThoiDiemTiepNhanDon = c.DateTime(),
                        ThoiDiemHoanThanhDH = c.DateTime(),
                        NgayTao = c.DateTime(),
                        MoTa = c.String(maxLength: 50),
                        ThanhTien = c.Int(),
                        deleted = c.Boolean(),
                        MaKhachHang = c.Int(),
                        MaHanhTrinh = c.Int(),
                    })
                .PrimaryKey(t => t.MaDonHang);
            
            CreateTable(
                "dbo.HanhTrinh",
                c => new
                    {
                        MaHanhTrinh = c.Int(nullable: false, identity: true),
                        HanhTrinh = c.String(unicode: false, storeType: "text"),
                        DiemBatDau = c.String(maxLength: 50),
                        DiemKetThuc = c.String(maxLength: 50),
                        QuangDuong = c.Int(),
                        ThoiGian = c.Int(),
                        deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaHanhTrinh);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false),
                        MaDonHang = c.Int(),
                        ThanhTien = c.Decimal(storeType: "money"),
                        MaKhachHang = c.Int(),
                        MaNhanVienGH = c.Int(),
                        GhiChu = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKhachHang = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(maxLength: 50),
                        CongTy = c.String(maxLength: 50),
                        SoDienThoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        MaLoaiKH = c.Int(),
                        NgaySinh = c.DateTime(),
                        TrangThai = c.String(maxLength: 50),
                        deleted = c.Boolean(),
                        MaTaiKhoan = c.Int(),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.KienHang",
                c => new
                    {
                        MaKienHang = c.Int(nullable: false, identity: true),
                        MaDonHang = c.Int(),
                        TinhTrang = c.String(maxLength: 50),
                        deleted = c.Boolean(),
                        GhiChu = c.String(maxLength: 50),
                        TrongLuong = c.Int(),
                        ChieuDai = c.Int(),
                        ChieuRong = c.Int(),
                        MoTa = c.String(),
                        SoLuong = c.Int(),
                        NoiDung = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKienHang);
            
            CreateTable(
                "dbo.LoaiKhachHang",
                c => new
                    {
                        MaLoaiKH = c.Int(nullable: false, identity: true),
                        TenLoaiKH = c.String(maxLength: 50),
                        MoTa = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiKH);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(),
                        NgayBatDau = c.DateTime(),
                        DiaChi = c.String(maxLength: 50),
                        MaPhanQuyen = c.Int(),
                        MatKhau = c.String(maxLength: 20, fixedLength: true),
                        SoDienThoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        TrangThai = c.String(maxLength: 50),
                        deleted = c.Boolean(),
                        TenTaiKhoan = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.PhanQuen", t => t.MaPhanQuyen)
                .Index(t => t.MaPhanQuyen);
            
            CreateTable(
                "dbo.PhanQuen",
                c => new
                    {
                        MaPhanQuen = c.Int(nullable: false, identity: true),
                        TenPhanQuen = c.String(maxLength: 50),
                        ThongTin = c.String(),
                    })
                .PrimaryKey(t => t.MaPhanQuen);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        MaTaiKhoan = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 50),
                        MaPhanQuyen = c.Int(),
                    })
                .PrimaryKey(t => t.MaTaiKhoan)
                .ForeignKey("dbo.PhanQuen", t => t.MaPhanQuyen)
                .Index(t => t.MaPhanQuyen);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TinNhan",
                c => new
                    {
                        MaTinNhan = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(unicode: false, storeType: "text"),
                        ThoiGian = c.DateTime(),
                        MaKienHang = c.Int(),
                    })
                .PrimaryKey(t => t.MaTinNhan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoan", "MaPhanQuyen", "dbo.PhanQuen");
            DropForeignKey("dbo.NhanVien", "MaPhanQuyen", "dbo.PhanQuen");
            DropIndex("dbo.TaiKhoan", new[] { "MaPhanQuyen" });
            DropIndex("dbo.NhanVien", new[] { "MaPhanQuyen" });
            DropTable("dbo.TinNhan");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.PhanQuen");
            DropTable("dbo.NhanVien");
            DropTable("dbo.LoaiKhachHang");
            DropTable("dbo.KienHang");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.HanhTrinh");
            DropTable("dbo.DonHang");
        }
    }
}
