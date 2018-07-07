namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangGia",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        NoiDung = c.String(),
                        BaoGia = c.String(),
                    })
                .PrimaryKey(t => t.Ma);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BangGia");
        }
    }
}
