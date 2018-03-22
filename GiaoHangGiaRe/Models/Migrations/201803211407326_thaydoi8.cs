namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thaydoi8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVien", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "TrangThai", c => c.String(maxLength: 50));
        }
    }
}
