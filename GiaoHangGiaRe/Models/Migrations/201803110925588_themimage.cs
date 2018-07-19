namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageContent = c.String(),
                        title = c.String(),
                        RoleId = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Image");
        }
    }
}
