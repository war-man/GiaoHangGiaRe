using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class LichSuServices : ILichSuServices
    {
        private IRepository<LichSu> _lichsurepository;
        GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();
        public LichSuServices()
        {
            _lichsurepository = new IRepository<LichSu>();
        }
        public int Count()
        {
            return _lichsurepository.GetAll().Count();
        }
        /// <summary>
        /// Tạo lịch sử lưu lại thay đổi
        /// </summary>
        /// <param name="input"></param>
        public void Create(LichSu input)
        {
            if (input.TenTaiKhoan == "") input.TenTaiKhoan = "Không đăng nhập";
            input.ThoiGianThucHien = DateTime.Now;
            _lichsurepository.Insert(input);
        }
        /// <summary>
        /// Lấy tất cả thay đổi
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<LichSu> GetAll(int? page, int? size)
        {
            if (!page.HasValue) page = page = Constant.DefaultPage;
            if (!size.HasValue) return _lichsurepository.GetAll().ToList();
            var res = _lichsurepository.GetAll().OrderBy(p => p.ThoiGianThucHien).Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();

            return res;
        }

        public LichSu GetById(int id)
        {
            return _lichsurepository.SelectById(id);
        }
    }
}