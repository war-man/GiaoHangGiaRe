using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiaoHangGiaRe.Module
{
    interface IUserServices
    {
        //cho cac phuong thuc GET
        ApplicationUser GetById(string id);
        List<ApplicationUser> GetAll(int?page,int?size, string user_name, string user_id, string name);
        List<ApplicationUser> GetUserOfRole(string role);
        List<string> GetRoleByUserId(string userid);
        List<Claim> Claims(string userId);
        ApplicationUser GetuserByUsername(object username);

        //cho cac phuong thuc POST
        IdentityResult Create(RegisterViewModel input);
        List<string> AddToRole(string UserId, string[] RoleId);

        //cho cac phuong thuc PUT
        void Update(UpdateAccountViewModel input);
        IdentityRole EditRole(IdentityRole input);
        List<string> RemoveUserRole(string UserId, string[] RoleId);

        //cho cac phuong thuc DELETE
        IdentityResult Delete(string id);

        //Khac

        int Count();  
    }
}
