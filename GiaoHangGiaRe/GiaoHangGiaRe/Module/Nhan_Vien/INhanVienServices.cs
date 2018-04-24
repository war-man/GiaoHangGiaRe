using GiaoHangGiaRe.Models;
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
        List<NhanViens> GetAll(int? page, int? size);
        NhanViens GetById(object id);
        NhanViens GetNhanVienByUser(object username);
        NhanViens GetNhanVienCurrentUser();

        //Cac phuong thuc POST
        void Create(NhanVienCreate input);

        //Cac phuong thuc PUT
        void Update(NhanViens input);

        //Cac phuong thuc DELETE
        void Delete(object id);


        //Khac
        int Count();
    }
}
