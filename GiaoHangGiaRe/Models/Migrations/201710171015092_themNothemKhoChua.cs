namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themNothemKhoChua : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhoChua",
                c => new
                    {
                        MaKhoChua = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 50),
                        DienTich = c.Single(nullable: false),
                        SoDienThoai = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaKhoChua);
            
            CreateTable(
                "dbo.No",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        KyHieu = c.String(),
                        MoTa = c.String(),
                        SoTien = c.Int(nullable: false),
                        MaKhachHang = c.String(),
                        ThoiGian = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma);
            
            AddColumn("dbo.NhanVien", "ChucVu", c => c.String());
            AlterColumn("dbo.KhachHang", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHang", "TrangThai", c => c.String(maxLength: 50));
            DropColumn("dbo.NhanVien", "ChucVu");
            DropTable("dbo.No");
            DropTable("dbo.KhoChua");
        }
    }
}
