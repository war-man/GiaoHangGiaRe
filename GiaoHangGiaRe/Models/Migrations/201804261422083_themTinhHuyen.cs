namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themTinhHuyen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commune",
                c => new
                    {
                        Commune_Id = c.Int(nullable: false, identity: true),
                        Commune_Code = c.String(),
                        Commune_Name = c.String(nullable: false),
                        District_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Commune_Id);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        District_Id = c.Int(nullable: false, identity: true),
                        District_Code = c.String(),
                        District_Name = c.String(nullable: false),
                        Province_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.District_Id);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        Province_Id = c.Int(nullable: false, identity: true),
                        Province_Code = c.String(),
                        Province_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Province_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Province");
            DropTable("dbo.District");
            DropTable("dbo.Commune");
        }
    }
}
