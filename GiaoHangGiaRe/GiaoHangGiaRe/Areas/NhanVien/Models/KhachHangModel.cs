using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Areas.NhanVien.Models
{
    public  class KhachHangModel
    {

        [Key]
        [Display(Name = "Mã khách hàng")]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Công ty")]
        public string CongTy { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public int? MaLoaiKH { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }

        public bool? deleted { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string TenTaiKhoan { get; set; }
    }

    public class KhachHangEditModel
    {
        public LoaiKhachHang LoaiKhachHang { set; get; }
        public List<LoaiKhachHang> DSLoaiKhachHang{ set;get; }

        //UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //var user = UserManager.FindById(User.Identity.GetUserId());
        public List<ApplicationUser> DSTaiKhoan { set; get; }
        public KhachHang KhachHang { set; get; }
        public ApplicationUser TaiKhoan { set; get; }
    }
}