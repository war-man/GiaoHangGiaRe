using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class DashBoardServices : IDashBoardServices
    {
        private readonly IRepository<BangGia> _banggiarepository;
        private readonly IRepository<DonHang> _donhangrepository;
        private readonly IRepository<NhanViens> _nhanvienrepository;
        private  LichSuServices lichSuServices;
        public DashBoardServices()
        {
            _banggiarepository = new IRepository<BangGia>();
            _donhangrepository = new IRepository<DonHang>();
            _nhanvienrepository = new IRepository<NhanViens>();
        }

        public int getSoNhanVien()
        {
            return _nhanvienrepository.GetAll().Where(p => p.TrangThai == NhanVienConstant.Active).Count();
        }

        public int getSoDonHangCho()
        {
            return _donhangrepository.GetAll().Where(p => p.TinhTrang == DonHangConstant.DangCho).Count();
        }

        public int getSoDonHangDangGiao()
        {
            return _donhangrepository.GetAll().Where(p => p.TinhTrang == DonHangConstant.DangGiao).Count();
        }
        public int getSoDonHangDangLayHang()
        {
            return _donhangrepository.GetAll().Where(p => p.TinhTrang == DonHangConstant.DangLayHang).Count();
        }

        public int getSoDonHangVaoKho()
        {
            return _donhangrepository.GetAll().Where(p => p.TinhTrang == DonHangConstant.GuiVaoKho).Count();
        }

        public IEnumerable<NhanViens> getListNhanVien()
        {
            return _nhanvienrepository.GetAll().Where(p => p.TrangThai == NhanVienConstant.Active);
        }
    }
}