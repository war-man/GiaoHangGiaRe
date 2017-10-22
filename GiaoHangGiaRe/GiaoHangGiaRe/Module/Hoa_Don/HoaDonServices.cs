using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;
using System.Web.Script.Serialization;

namespace GiaoHangGiaRe.Module
{
    public class HoaDonServices : IHoaDonServices
    {
        private IRepository<HoaDon> _hoadonrepository;
        private LichSuServices lichSuServices;
        private UserServices userServices;
        private KhachHangServices khachHangServices;
        public HoaDonServices()
        {
            _hoadonrepository = new IRepository<HoaDon>();
            lichSuServices = new LichSuServices();
            userServices = new UserServices();
            khachHangServices = new KhachHangServices();
        }
        public int Count()
        {
            return _hoadonrepository.GetAll().Count();
        }

        public void Create(HoaDon input)
        {
            _hoadonrepository.Insert(input);

            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.CreateAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = new JavaScriptSerializer().Serialize(input),
                ViTriThaoTac = "HoaDon"
            });
        }

        public void Delete(int id)
        {
            _hoadonrepository.Delete(id);

            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.DeleteAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = id.ToString(),
                ViTriThaoTac = "HoaDon"
            });
        }

        public List<HoaDon> GetAll(int? size,int? page)
        {
            if (!page.HasValue)
                page=Constant.DefaultPage;
            if (!size.HasValue)
                return _hoadonrepository.GetAll().ToList();
           var res= _hoadonrepository.GetAll().OrderBy(p => p.MaHoaDon)
                .Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public HoaDon GetById(int id)
        {
            return _hoadonrepository.SelectById(id);
        }

        public List<HoaDon> GetDonHangByMaKhachHang(int MaKH)
        {
            return _hoadonrepository.GetAll().Where(p => p.MaKhachHang == MaKH).ToList();
        }

        public List<HoaDon> GetHoaDonOfCurrnetuser() // cho nguoi dung muon xem DonHang cua chinh ho
        {
            var res = _hoadonrepository.GetAll().Where(p => p.MaKhachHang == khachHangServices.GetCurrentKhacHang().MaKhachHang)
                .ToList();
            return res;
        }

        public List<HoaDon> GetHoaDonOfUser(object username)// cho nguoi dung xem DonHang cua 1 user (KhachHang, NhanVienGiaoHang)
        {
            var res = _hoadonrepository.GetAll().Where(p => p.MaKhachHang == khachHangServices.GetKhacHangOfUser(username.ToString()).MaKhachHang)
                .ToList();
            return res;
        }

        public void Update(HoaDon input)
        {
            _hoadonrepository.Update(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = userServices.GetCurrentUser().UserName,
                NoiDung = new JavaScriptSerializer().Serialize(input),
                ViTriThaoTac = "HoaDon"
            });
        }
    }
}