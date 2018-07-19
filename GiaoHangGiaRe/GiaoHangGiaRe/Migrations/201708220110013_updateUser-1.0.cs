namespace GiaoHangGiaRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HoTen", c => c.String());
            AddColumn("dbo.AspNetUsers", "DiaChi", c => c.String());
            AddColumn("dbo.AspNetUsers", "TenTaiKhoan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TenTaiKhoan");
            DropColumn("dbo.AspNetUsers", "DiaChi");
            DropColumn("dbo.AspNetUsers", "HoTen");
        }
    }
}
