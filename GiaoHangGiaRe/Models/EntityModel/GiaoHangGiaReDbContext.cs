namespace Models.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GiaoHangGiaReDbContext : DbContext
    {
        public GiaoHangGiaReDbContext()
            : base("name=GiaoHangGiaReDbContext")
        {
        }

        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<HanhTrinh> HanhTrinhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KienHang> KienHangs { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<NhanViens> NhanViens { get; set; }
        //public virtual DbSet<PhanQuen> PhanQuens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
       // public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinNhan> TinNhans { get; set; }
        public virtual DbSet<BangGia> BangGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<HanhTrinh>()
                .Property(e => e.HanhTrinh1)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            //modelBuilder.Entity<NhanViens>()
            //    .Property(e => e.MatKhau)
            //    .IsFixedLength();

            //modelBuilder.Entity<PhanQuen>()
            //    .HasMany(e => e.NhanViens)
            //    .WithOptional(e => e.PhanQuen)
            //    .HasForeignKey(e => e.MaPhanQuyen);

            //modelBuilder.Entity<PhanQuen>()
            //    .HasMany(e => e.TaiKhoans)
            //    .WithOptional(e => e.PhanQuen)
            //    .HasForeignKey(e => e.MaPhanQuyen);

            modelBuilder.Entity<TinNhan>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);
        }
    }
}
