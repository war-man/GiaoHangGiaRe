using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IImageServices
    {
        //Cho phuong thuc GET

        Image GetById(int Id);

        //Cho phuong thuc POST
        bool Create(Image input);

        //Cho phuong thuc PUT
        void Update(Image input);

        //Cho phuong thuc DELETE
        void Delete(int id);

        int Count();
    }
}
