namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sualinhtinh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KienHang", "MaKhoChua", c => c.Int(nullable: false));
            AddColumn("dbo.No", "TrangThai", c => c.Int(nullable: false));
            AlterColumn("dbo.No", "MaKhachHang", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.No", "MaKhachHang", c => c.String());
            DropColumn("dbo.No", "TrangThai");
            DropColumn("dbo.KienHang", "MaKhoChua");
        }
    }
}
