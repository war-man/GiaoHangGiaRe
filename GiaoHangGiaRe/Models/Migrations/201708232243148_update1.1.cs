namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHang", "TenTaiKhoan", c => c.String(nullable: false));
            DropColumn("dbo.DonHang", "MoTa");
            DropColumn("dbo.DonHang", "MaKhachHang");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonHang", "MaKhachHang", c => c.String());
            AddColumn("dbo.DonHang", "MoTa", c => c.String(maxLength: 50));
            DropColumn("dbo.DonHang", "TenTaiKhoan");
        }
    }
}
