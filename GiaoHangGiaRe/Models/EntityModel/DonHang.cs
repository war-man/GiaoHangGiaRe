namespace Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Người gửi")]
        public string NguoiGui { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ gửi")]
        public string DiaChiGui { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại gửi")]
        public string SoDienThoaiNguoiGui { get; set; }

        [StringLength(50)]
        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ nhận")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại nhận")]
        public string SoDienThoaiNguoiNhan { get; set; }

        public int? MaNhanVienGiao { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Tình trạng")]
        public int TinhTrang { get; set; }

        [Display(Name = "Thời điểm đặt hàng")]
        public DateTime? ThoiDiemDatDonHang { get; set; }

        [Display(Name = "Thời điểm tiếp nhận")]
        public DateTime? ThoiDiemTiepNhanDon { get; set; }

        [Display(Name = "Thời điểm hoàn thành")]
        public DateTime? ThoiDiemHoanThanhDH { get; set; }

        [Display(Name = "Thành tiền")]
        public int? ThanhTien { get; set; }

        public bool? deleted { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string TenTaiKhoan { get; set; }

        [Display(Name = "Mã hành trình")]
        public int? MaHanhTrinh { get; set; }
    }
}
