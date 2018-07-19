using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Models.TaiKhoan;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;

namespace GiaoHangGiaRe.Module
{
    interface IUserServices
    {
       
        //cho cac phuong thuc GET
        ApplicationUser GetById(string id);
        List<ApplicationUser> GetAll(TaiKhoanSearchList taiKhoanSearchList);
        List<ApplicationUser> GetUserOfRole(string role);
        List<string> GetRoleByUserId(string userid);
        List<Claim> Claims(string userId);
        ApplicationUser GetuserByUsername(object username);

        //cho cac phuong thuc POST
        IdentityResult Create(TaiKhoanCreate input);
        List<string> AddToRole(string UserId, string[] RoleId);

        //cho cac phuong thuc PUT
        void Update(TaiKhoanUpdate input);
        IdentityRole EditRole(IdentityRole input);
        List<string> RemoveUserRole(string UserId, string[] RoleId);

        //cho cac phuong thuc DELETE
        IdentityResult Delete(string id);

        //Khac

        int Count();  
    }
}
