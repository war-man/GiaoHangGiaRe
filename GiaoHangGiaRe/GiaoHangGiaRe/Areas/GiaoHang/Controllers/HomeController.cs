using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoHangGiaRe.Areas.GiaoHang.Controllers
{
    [Authorize (Roles = "Nhân viên giao hàng")]
    public class HomeController : Controller
    {
        // GET: GiaoHang/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}