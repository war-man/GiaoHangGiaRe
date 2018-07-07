using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using GiaoHangGiaRe.Models;
using Models.EntityModel;

namespace GiaoHangGiaRe.Module
{
    public class RoleServices : IRoleServices
    {
        IdentityRepository<IdentityRole> _roleRepository;
        UserServices userServices;
        LichSuServices lichSuServices;
        public RoleServices()
        {
            _roleRepository = new IdentityRepository<IdentityRole>();
            lichSuServices = new LichSuServices();
            userServices = new UserServices();
        }
        public int Count()
        {
           return _roleRepository.GetAll().Count();
        }

        public void Create(IdentityRole input)
        {
            _roleRepository.InsertRole(input);

            lichSuServices.Create(new LichSu {
                HanhDong = Constant.CreateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac=Constant.Role
            });
        }

        public IdentityRole Delete(string id)
        {
             var res=_roleRepository.SelectById(id);
            _roleRepository.Delete(id);


            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.DeleteAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = id.ToString(),
                ViTriThaoTac = Constant.Role
            });
            return res;
        }

        public List<IdentityRole> GetAll(int? page,int? size)
        {
            if (!page.HasValue) page = 1;
            if (!size.HasValue) return _roleRepository.GetAll().OrderBy(p => p.Id).ToList();
           var res= _roleRepository.GetAll().OrderBy(p => p.Id).Take(size.Value)
                .Skip(size.Value * (page.Value - 1)).ToList();
            return res;
        }

        public IdentityRole GetById(string id)
        {
            return _roleRepository.SelectById(id);
        }

        public bool IsExit(string id)
        {
            if (_roleRepository.SelectById(id) == null)
                return false;
            return true;
        }

        public void Update(IdentityRole input)
        {
            _roleRepository.Update(input);

            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.Role
            });
        }

    }
}