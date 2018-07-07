namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_bang_no : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.No", "MaKhachHang", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.No", "MaKhachHang", c => c.Int(nullable: false));
        }
    }
}
