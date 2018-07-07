namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themImageLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageLink");
        }
    }
}
