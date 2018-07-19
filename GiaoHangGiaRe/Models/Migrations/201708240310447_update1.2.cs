namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HanhTrinh", name: "HanhTrinh", newName: "HanhTrinh1");
            AlterColumn("dbo.DonHang", "GhiChu", c => c.String(unicode: false));
            AlterColumn("dbo.HanhTrinh", "HanhTrinh1", c => c.String(unicode: false));
            AlterColumn("dbo.TinNhan", "NoiDung", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TinNhan", "NoiDung", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.HanhTrinh", "HanhTrinh1", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.DonHang", "GhiChu", c => c.String(unicode: false, storeType: "text"));
            RenameColumn(table: "dbo.HanhTrinh", name: "HanhTrinh1", newName: "HanhTrinh");
        }
    }
}
