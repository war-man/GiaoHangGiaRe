namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaNhanVienSuaKhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "TenTaiKhoan", c => c.String());
            AddColumn("dbo.NhanVien", "TenTaiKhoan", c => c.String());
            DropColumn("dbo.KhachHang", "MaTaiKhoan");
            DropColumn("dbo.NhanVien", "MaTaiKhoan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanVien", "MaTaiKhoan", c => c.String());
            AddColumn("dbo.KhachHang", "MaTaiKhoan", c => c.Int());
            DropColumn("dbo.NhanVien", "TenTaiKhoan");
            DropColumn("dbo.KhachHang", "TenTaiKhoan");
        }
    }
}
