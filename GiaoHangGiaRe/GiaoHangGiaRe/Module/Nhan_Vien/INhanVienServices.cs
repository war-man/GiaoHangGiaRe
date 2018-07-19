using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Models.NhanVien;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface INhanVienServices
    {
        //Cac phuong thuc GET
        List<NhanViens> GetAll(NhanVienSearchList nhanVienSearchList);
        NhanViens GetById(object id);
        NhanViens GetNhanVienByUser(object username);
        NhanViens GetNhanVienCurrentUser();

        //Cac phuong thuc POST
        void Create(NhanVienCreate input);

        //Cac phuong thuc PUT
        void Update(NhanVienUpdate input);

        //Cac phuong thuc DELETE
        void Delete(object id);


        //Khac
        int Count();
    }
}
