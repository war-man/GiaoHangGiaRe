namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonHang", "TenTaiKhoan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonHang", "TenTaiKhoan", c => c.String(nullable: false));
        }
    }
}
