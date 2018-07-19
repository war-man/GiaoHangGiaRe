namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaTinhTrang_donHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHang", "TinhTrang", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHang", "TinhTrang", c => c.String(maxLength: 50));
        }
    }
}
