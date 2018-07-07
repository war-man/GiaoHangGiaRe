
using GiaoHangGiaRe.Module;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    [RoutePrefix("api/dashBoard")]
    public class DashBoardController : ApiController
    {
        private DashBoardServices _dashBoardServices;
        public DashBoardController()
        {
            _dashBoardServices = new DashBoardServices();
        }
        [HttpGet]
        [Route("get-so-nhanvien")]
        public IHttpActionResult getSoNhanVien()
        {
            return Ok(_dashBoardServices.getSoNhanVien());
        }
        [HttpGet]
        [Route("get-nhanvien")]
        public IHttpActionResult getListNhanVien()
        {
            return Ok(_dashBoardServices.getListNhanVien());
        }
        [HttpGet]
        [Route("get-so-donhangcho")]
        public IHttpActionResult getSoDonHangCho()
        {
            return Ok(_dashBoardServices.getSoDonHangCho());
        }
        [HttpGet]
        [Route("get-so-donhangdanggiao")]
        public IHttpActionResult getSoDonHangDangGiao()
        {
            return Ok(_dashBoardServices.getSoDonHangDangGiao());
        }
        [HttpGet]
        [Route("get-so-donhanglayhang")]
        public IHttpActionResult getSoDonHangDangLayHang()
        {
            return Ok(_dashBoardServices.getSoDonHangDangLayHang());
        }
        [HttpGet]
        [Route("get-so-donhangvaokho")]
        public IHttpActionResult getSoDonHangVaoKho()
        {
            return Ok(_dashBoardServices.getSoDonHangVaoKho());
        }
    }
}
