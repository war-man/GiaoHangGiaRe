namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhanVien", "PhanQuen_MaPhanQuen", "dbo.PhanQuen");
            DropIndex("dbo.NhanVien", new[] { "PhanQuen_MaPhanQuen" });
            DropColumn("dbo.DonHang", "NgayTao");
            DropColumn("dbo.NhanVien", "PhanQuen_MaPhanQuen");
            DropTable("dbo.PhanQuen");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhanQuen",
                c => new
                    {
                        MaPhanQuen = c.Int(nullable: false, identity: true),
                        TenPhanQuen = c.String(maxLength: 50),
                        ThongTin = c.String(),
                    })
                .PrimaryKey(t => t.MaPhanQuen);
            
            AddColumn("dbo.NhanVien", "PhanQuen_MaPhanQuen", c => c.Int());
            AddColumn("dbo.DonHang", "NgayTao", c => c.DateTime());
            CreateIndex("dbo.NhanVien", "PhanQuen_MaPhanQuen");
            AddForeignKey("dbo.NhanVien", "PhanQuen_MaPhanQuen", "dbo.PhanQuen", "MaPhanQuen");
        }
    }
}
