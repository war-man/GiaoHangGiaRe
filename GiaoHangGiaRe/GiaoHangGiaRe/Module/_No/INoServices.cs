using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface INoServices
    {
        //Cho phuong thuc GET
        List<No> GetAll(int? page, int? size , string KyHieu);
        List<No> GetNoCurrentUser(int? page, int? size, string KyHieu);
        
        No GetById(int Id);
        List<No> GetNoOfKH(int MaKH);

        //Cho phuong thuc POST
        void Create(No input);

        //Cho phuong thuc PUT
        void SetHoanThanh(int id);
        void Update(No input);

        //Cho phuong thuc DELETE
        void Delete(int id);

        int Count();
        int CountNoCurenUser();
    }
}
