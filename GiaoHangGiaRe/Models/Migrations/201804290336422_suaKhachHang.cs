namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaKhachHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHang", "TenKhachHang", c => c.String());
            AlterColumn("dbo.KhachHang", "CongTy", c => c.String());
            AlterColumn("dbo.KhachHang", "Email", c => c.String());
            AlterColumn("dbo.KhachHang", "DiaChi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHang", "DiaChi", c => c.String(maxLength: 50));
            AlterColumn("dbo.KhachHang", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.KhachHang", "CongTy", c => c.String(maxLength: 50));
            AlterColumn("dbo.KhachHang", "TenKhachHang", c => c.String(maxLength: 50));
        }
    }
}
