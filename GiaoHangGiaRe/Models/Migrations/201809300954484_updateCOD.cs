namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCOD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHang", "cod", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHang", "cod");
        }
    }
}
