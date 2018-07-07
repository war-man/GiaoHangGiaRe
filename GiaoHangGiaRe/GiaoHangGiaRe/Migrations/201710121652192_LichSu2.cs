namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LichSu2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichSu", "ThoiGianThucHien", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichSu", "ThoiGianThucHien");
        }
    }
}
