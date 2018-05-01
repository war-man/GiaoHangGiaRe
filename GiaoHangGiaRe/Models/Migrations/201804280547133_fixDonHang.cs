namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDonHang : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HoaDon");
            AlterColumn("dbo.HoaDon", "MaHoaDon", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.HoaDon", "MaHoaDon");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.HoaDon");
            AlterColumn("dbo.HoaDon", "MaHoaDon", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.HoaDon", "MaHoaDon");
        }
    }
}
