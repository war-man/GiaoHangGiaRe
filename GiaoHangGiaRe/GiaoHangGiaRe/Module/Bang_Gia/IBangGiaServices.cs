using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IBangGiaServices
    {
        List<BangGia> GetAll(int?page, int? size);
        BangGia GetById(object id);

        void Create(BangGia input);
        void Update(BangGia input);
        BangGia Delete(object id);

        int Count();
        bool IsExit(object id);
    }
}
