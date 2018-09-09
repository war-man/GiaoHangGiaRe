using GiaoHangGiaRe.Models;
using Models.EntityModel;
using System.Collections.Generic;

namespace GiaoHangGiaRe.Module
{
    interface INoServices
    {
        //Cho phuong thuc GET
        List<No> GetAll(NoSearchList noSearchList);
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
