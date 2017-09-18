namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaNhanVienXoaTaiKhoan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaiKhoan", "MaPhanQuyen", "dbo.PhanQuen");
            DropIndex("dbo.TaiKhoan", new[] { "MaPhanQuyen" });
            RenameColumn(table: "dbo.NhanVien", name: "MaPhanQuyen", newName: "PhanQuen_MaPhanQuen");
            RenameIndex(table: "dbo.NhanVien", name: "IX_MaPhanQuyen", newName: "IX_PhanQuen_MaPhanQuen");
            AddColumn("dbo.NhanVien", "MaTaiKhoan", c => c.String());
            DropColumn("dbo.NhanVien", "MatKhau");
            DropColumn("dbo.NhanVien", "TenTaiKhoan");
            DropTable("dbo.TaiKhoan");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        MaTaiKhoan = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(maxLength: 50),
                        MatKhau = c.String(maxLength: 50),
                        MaPhanQuyen = c.Int(),
                    })
                .PrimaryKey(t => t.MaTaiKhoan);
            
            AddColumn("dbo.NhanVien", "TenTaiKhoan", c => c.String(maxLength: 50));
            AddColumn("dbo.NhanVien", "MatKhau", c => c.String(maxLength: 20, fixedLength: true));
            DropColumn("dbo.NhanVien", "MaTaiKhoan");
            RenameIndex(table: "dbo.NhanVien", name: "IX_PhanQuen_MaPhanQuen", newName: "IX_MaPhanQuyen");
            RenameColumn(table: "dbo.NhanVien", name: "PhanQuen_MaPhanQuen", newName: "MaPhanQuyen");
            CreateIndex("dbo.TaiKhoan", "MaPhanQuyen");
            AddForeignKey("dbo.TaiKhoan", "MaPhanQuyen", "dbo.PhanQuen", "MaPhanQuen");
        }
    }
}
