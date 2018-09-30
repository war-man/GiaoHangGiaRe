namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suahoadon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDon", "MaDonHang", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoaDon", "MaDonHang", c => c.Int());
        }
    }
}
