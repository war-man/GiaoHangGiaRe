using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Models
{
    public class DonHangKienHang
    {
        public List<KienHang> listKienHang { set; get; }
        public DonHang DonHang { set; get; }
    }
}