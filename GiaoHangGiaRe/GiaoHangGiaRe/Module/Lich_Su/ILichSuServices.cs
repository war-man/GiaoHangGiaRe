using GiaoHangGiaRe.Models;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface ILichSuServices
    {
        List<LichSu> GetAll(LichSuSearchList lichSuSearchList);
        LichSu GetById(int id);

        void Create(LichSu input);
        int Count();
    }
}
