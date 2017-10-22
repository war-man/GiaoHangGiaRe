using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Diagnostics;
using System.Web.Script.Serialization;

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

        public void Update(RegisterViewModel input)
        {
            throw new NotImplementedException();
            //GetuserByUsername(input.TenTaiKhoan);
            //_userRepository.Update(input);
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
                    //IdentityRole role = _userRepository.Roles.Find(RoleId);
                    //user.Roles.Add(new IdentityUserRole() { UserId = UserId.ToString(), RoleId = item });
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

        public List<ApplicationUser> GetAll(int? page, int? size)
        {       
            if (!page.HasValue) page = Constant.DefaultPage;
            if (!size.HasValue) return _userRepository.GetAll().ToList();
            List<ApplicationUser> users = _userRepository.GetAll()
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
