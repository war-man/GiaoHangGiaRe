﻿using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GiaoHangGiaRe.Module
{
    class UserServices : IUserServices
    {
        private IdentityRepository<ApplicationUser> _userRepository;
        private LichSuServices lichSuServices;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public UserServices(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserServices()
        {
            _userRepository = new IdentityRepository<ApplicationUser>();
            lichSuServices = new LichSuServices();
            //UserManager = new ApplicationUserManager();
        }
        public IdentityResult Create(RegisterViewModel input)
        {       
            var user = new ApplicationUser { UserName = input.TenTaiKhoan, PhoneNumber = input.SoDienThoai, Email = input.Email, HoTen = input.HoTen, DiaChi = input.DiaChi, TenTaiKhoan = input.TenTaiKhoan };             
            var result = UserManager.Create(user, input.Password);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = GetCurrentUser().UserName,
                HanhDong = Constant.CreateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = Constant.CvtToString(input)
            });

            return result;
        }

        public IdentityResult Delete(string id)
        {
            lichSuServices.Create(new LichSu {
                TenTaiKhoan = GetCurrentUser().UserName,
                HanhDong = Constant.DeleteAction,
                ViTriThaoTac = Constant.User,
                NoiDung = id
            });
            var user = UserManager.FindById(id);
           return UserManager.Delete(user);
        }
        public ApplicationUser GetCurrentUser()
        {
            var user = GetById(HttpContext.Current.User.Identity.GetUserId());
            return user;
        }
        

        public ApplicationUser GetById(string id)
        {
            var user = UserManager.FindById(id);
            return user;
        }

        public void Update(UpdateAccountViewModel input)
        {
            var user = GetById(input.Id);
            user.HoTen = input.HoTen;
            user.DiaChi = input.DiaChi;
            user.PhoneNumber = input.SoDienThoai;
            //user.NgaySinh = input.NgaySinh; user chua co thuoc tinh NgaySinh
            UserManager.Update(user);

            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = GetCurrentUser().UserName,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = input.Id
            });
        }

        public List<string> GetRoleByUserId(string userid)
        {
            var user = UserManager.FindById(userid.ToString());
            var role = UserManager.GetRoles(user.Id);
            return role.ToList();
        }

        public IdentityRole EditRole(IdentityRole input)
        {
            throw new NotImplementedException();
        }

        public List<string> AddToRole(string UserId, string[] RoleId)
        {
            var user = UserManager.FindById(UserId.ToString());
            if (RoleId != null && RoleId.Count() > 0)
            {
                foreach (string item in RoleId)
                {
                    UserManager.AddToRole(UserId, item);
                }           
            }
            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = GetCurrentUser().UserName,
                HanhDong = Constant.UpdateAction,
                ViTriThaoTac = Constant.User,
                NoiDung = UserId+RoleId
            });
            return GetRoleByUserId(UserId);
        }

        public List<string> RemoveUserRole(string UserId, string[] RoleId)
        {
            var user = UserManager.FindById(UserId.ToString());
            if (RoleId != null && RoleId.Count() > 0)
            {
                foreach (string item in RoleId)
                {
                    UserManager.RemoveFromRole(UserId, item);
                }
            }
            lichSuServices.Create(new LichSu
            {
                TenTaiKhoan = GetCurrentUser().UserName,
                HanhDong = Constant.DeleteAction,
                ViTriThaoTac = Constant.User,
                NoiDung = UserId + RoleId
            });
            return GetRoleByUserId(UserId);
        }

        public List<ApplicationUser> GetUserOfRole(string role)
        {
            var userlist=_userRepository.GetAll().Where(p=>p.Roles.ToString() == role).ToList();
            return userlist;
        }

        public List<Claim> Claims(string userId)
        {
            var res = UserManager.GetClaims(userId).ToList();          
            return res;
        }

        public ApplicationUser GetuserByUsername(object username)
        {
            return _userManager.FindByName(username.ToString());
        }

        public List<ApplicationUser> GetAll(int? page=null, int? size =null, string user_name ="", string user_id = "", string name = "")
        {
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) size = Constant.DefaultSize;
            if (user_name == null)
                user_name = "";
            if (user_id == null)
                user_id = "";
            if (name == null)
                name = "";
            List<ApplicationUser> users = _userRepository.GetAll().Where(p=>p.UserName.Contains(user_name) && p.Id.Contains(user_id) && p.HoTen.Contains(name))
                .OrderBy(p => p.Id)
                .Take(size.Value)
                .Skip(size.Value * (size.Value * (page.Value - 1))).ToList();
            return users;
        }

        public int Count()
        {
            return _userRepository.GetAll().Count();
        }
    }

}