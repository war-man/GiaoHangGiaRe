using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IRoleServices
    {
        List<IdentityRole> GetAll(int? page,int? size);
        IdentityRole GetById(string id);

        void Create(IdentityRole input);
        void Update(IdentityRole input);

        IdentityRole Delete(string id);

        int Count();

        bool IsExit(string id);

    }
}
