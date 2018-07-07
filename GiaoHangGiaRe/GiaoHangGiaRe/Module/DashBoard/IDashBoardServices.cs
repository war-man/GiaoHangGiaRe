using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IDashBoardServices
    {
        /// <summary>
        /// Lay so nhan vien dang hoat dong
        /// </summary>
        /// <returns></returns>
        int getSoNhanVien();
        /// <summary>
        /// Lay so don hang dang cho
        /// </summary>
        /// <returns></returns>
        int getSoDonHangCho();
        /// <summary>
        /// Lay so don hang dang giao
        /// </summary>
        /// <returns></returns>
        int getSoDonHangDangGiao();

        /// <summary>
        /// Lay so don hang vao kho
        /// </summary>
        /// <returns></returns>
        int getSoDonHangVaoKho();
        IEnumerable<NhanViens> getListNhanVien();
    }
}
