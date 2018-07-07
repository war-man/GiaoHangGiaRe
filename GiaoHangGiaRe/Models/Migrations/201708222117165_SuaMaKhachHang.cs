namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaMaKhachHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHang", "MaKhachHang", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHang", "MaKhachHang", c => c.Int());
        }
    }
}
