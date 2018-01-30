﻿using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IKhachHangServices
    {
        //su dung cho phuong thuc GET
        List<KhachHang> GetAll(int?page,int?size);
        KhachHang GetById(int id);
        KhachHang GetCurrentKhacHang();
        KhachHang GetKhacHangOfUser(object username);


        //su dung cho phuong thuc CREATE
        void Create(KhachHang input);

        //su dung cho phuong thuc UPDATE
        void Update(KhachHang input);
        void Setlock_Unlock(object username);

        //su dung cho phuong thuc DELETE
        void Delete(int id);

        //su dung cho phuong thuc khac
        int Count();
    }
}