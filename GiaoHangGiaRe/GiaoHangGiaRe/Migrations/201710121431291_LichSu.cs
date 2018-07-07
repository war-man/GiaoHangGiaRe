namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LichSu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LichSu",
                c => new
                {
                    Ma = c.Int(nullable: false, identity: true),
                    HanhDong = c.String(),
                    TenTaiKhoan = c.String(),
                    NoiDung = c.String(),
                    ViTriThaoTac = c.String(),
                })
                .PrimaryKey(t => t.Ma);
        }
        
        public override void Down()
        {
            DropTable("dbo.LichSu");
        }
    }
}
