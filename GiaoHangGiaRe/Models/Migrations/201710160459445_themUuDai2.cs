namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themUuDai2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UuDai",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        NoiDung = c.String(),
                        DoiTuongApDung = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ma);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UuDai");
        }
    }
}
