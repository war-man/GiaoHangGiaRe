namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Bang_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isDelete");
        }
    }
}
