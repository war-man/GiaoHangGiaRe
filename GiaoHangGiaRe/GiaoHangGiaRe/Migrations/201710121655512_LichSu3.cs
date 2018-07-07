namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LichSu3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichSu", "ThoiGianThucHien", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.LichSu", "ThoiGianThucHien", c => c.String());
        }
    }
}
