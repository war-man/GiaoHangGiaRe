using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoHangGiaRe.Models
{
    public class ChiTietDonHang
    {
        public DonHang DonHang { set; get; }
        public List<KienHang> KienHang { set; get; }
      
    }
}