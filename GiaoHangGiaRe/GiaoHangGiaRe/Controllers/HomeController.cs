using Models.EntityModel;
using System.Linq;
using System.Web.Mvc;

namespace GiaoHangGiaRe.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        GiaoHangGiaReDbContext db;
        public HomeController()
        {
            db = new GiaoHangGiaReDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thông tin về chúng tôi.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Liên hệ.";

            return View();
        }
        public ActionResult BangGia()
        {
            ViewBag.Message = "Bảng giá.";
            return View(db.BangGias.ToList());
        }
    }
}