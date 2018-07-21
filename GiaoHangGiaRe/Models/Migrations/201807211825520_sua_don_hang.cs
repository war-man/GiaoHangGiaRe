namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_don_hang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHang", "MaKhachHang", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHang", "MaKhachHang");
        }
    }
}
