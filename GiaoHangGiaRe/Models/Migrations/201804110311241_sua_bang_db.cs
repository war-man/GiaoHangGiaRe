namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_bang_db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "create_by", c => c.String());
            AddColumn("dbo.Image", "create_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Image", "create_at");
            DropColumn("dbo.Image", "create_by");
        }
    }
}
