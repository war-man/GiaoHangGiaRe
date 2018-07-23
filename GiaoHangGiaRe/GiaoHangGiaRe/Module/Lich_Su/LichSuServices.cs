using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiaoHangGiaRe.Models;
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
            return this.count_list;
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

        public List<LichSu> GetAll(LichSuSearchList lichSuSearchList)
        {
            var res = _lichsurepository.GetAll().OrderBy(p => p.ThoiGianThucHien)
                                       .Skip(lichSuSearchList.size.Value * lichSuSearchList.page.Value).Take(lichSuSearchList.size.Value);
            this.count_list = res.Count();
                                             return res.ToList();
        }
        public int count_list { set; get; }
        public LichSu GetById(int id)
        {
            return _lichsurepository.SelectById(id);
        }
    }
}