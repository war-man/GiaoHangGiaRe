using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IUuDaiServices
    {
        //Cho phuong thuc GET
        List<UuDai> GetAll(int? page, int? size);
        UuDai GetById(int Id);
        List<UuDai> GetUuDaiOfKH(int MaKH);
        List<UuDai> GetUuDaiOfUser(object username);
        List<UuDai> GetUuDaiOfCurrentUser();

        //Cho phuong thuc POST
        void Create(UuDai input);

        //Cho phuong thuc PUT
        void Update(UuDai input);

        //Cho phuong thuc DELETE
        void Delete(int id);

        int Count();

    }
}
