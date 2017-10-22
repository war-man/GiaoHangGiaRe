using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface ITinNhanServices
    {
        List<TinNhan> GetAll(int? page, int? size);
        TinNhan GetById(object id);

        void Create(TinNhan input);
        void Update(TinNhan input);
        void Delete(object id);

        int Count();
    }
}
