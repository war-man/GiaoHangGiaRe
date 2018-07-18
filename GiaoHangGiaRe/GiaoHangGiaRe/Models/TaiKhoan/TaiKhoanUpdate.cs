using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiaoHangGiaRe.Models
{
    public class TaiKhoanUpdate
    {
        public string Id { set; get; }
        public string DiaChi { set; get; }
        public string HoTen { set; get; }
        public string PhoneNumber { set; get; }
    }
}