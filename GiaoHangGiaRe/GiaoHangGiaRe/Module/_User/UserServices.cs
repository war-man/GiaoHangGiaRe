using GiaoHangGiaRe.Models;
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
using GiaoHangGiaRe.Models.TaiKhoan;

namespace GiaoHangGiaRe.Module
{
    class UserServices : IUserServices
    {
        private IdentityRepository<ApplicationUser> _userRepository;
        private IdentityRepository<IdentityUserRole> _userRoleRepository;
        private LichSuServices lichSuServices;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ImageServices _imageServices;
        private IRepository<NhanViens> _nhanvienRepository;
        private IRepository<KhachHang> _khachhangRepository;
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
            _imageServices = new ImageServices();
            _nhanvienRepository = new IRepository<NhanViens>();
            _userRoleRepository = new IdentityRepository<IdentityUserRole>();
            _khachhangRepository = new IRepository<KhachHang>();
            //UserManager = new ApplicationUserManager();
        }

        /// <summary>
        /// Tạo tài khoản và khách hàng
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="input">Input.</param>
        public IdentityResult Create(TaiKhoanCreate input)
        {       
            var user = new ApplicationUser {
                UserName = input.TenTaiKhoan, 
                PhoneNumber = input.SoDienThoai, 
                Email = input.Email, 
                HoTen = input.HoTen, 
                DiaChi = input.DiaChi,
                TenTaiKhoan = input.TenTaiKhoan
            };

            var result = UserManager.Create(user, input.Password);
            if(result.Succeeded == true){
                var currentUser = UserManager.FindByName(user.UserName);
                var kh = new KhachHang
                {
                    TenTaiKhoan = input.TenTaiKhoan,
                    TenKhachHang = input.HoTen,
                    CongTy = input.CongTy,
                    DiaChi = input.DiaChi,
                    Email = input.Email,
                    SoDienThoai = input.SoDienThoai,
                    TrangThai = 1,
                    MaLoaiKH = 1,
                };
                if (kh.CongTy == null)
                {
                    kh.CongTy = "Cong ty";
                }
                _khachhangRepository.Insert(kh);
            }
            return result;
        }

        public IdentityResult Delete(string id)
        {
            //lichSuServices.Create(new LichSu
            //{
            //    TenTaiKhoan = GetCurrentUser().UserName,
            //    HanhDong = Constant.UpdateAction,
            //    ViTriThaoTac = Constant.User,
            //    NoiDung = id
            //});
            var user = UserManager.FindById(id);
            user.isDelete = true;
            return UserManager.Update(user);
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

        public void Update(TaiKhoanUpdate input)
        {
            var curren_user = GetById(input.Id);
            if (!string.IsNullOrEmpty(input.DiaChi))
            {
                curren_user.DiaChi = input.DiaChi;
            }
            if (!string.IsNullOrEmpty(input.HoTen))
            {
                curren_user.HoTen = input.HoTen;
            }
            if (!string.IsNullOrEmpty(input.PhoneNumber))
            {
                curren_user.PhoneNumber = input.PhoneNumber;
            }
            //user.NgaySinh = input.NgaySinh; user chua co thuoc tinh NgaySinh
            UserManager.Update(curren_user);

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
        /// <summary>
        /// Thêm user vào 1 hoặc nhiều Role
        /// </summary>
        public List<string> AddToRole(string UserId, string[] RoleId)
        {
            var user = UserManager.FindById(UserId.ToString());
            if (RoleId != null && RoleId.Length > 0)
            {
                //Nếu chưa có nhân viên nào thuộc tài khoản này thì tự thêm nhân viên mới 
                if (!_nhanvienRepository.GetAll().Any(i=>i.TenTaiKhoan == GetById(UserId).TenTaiKhoan))
                {
                    _nhanvienRepository.Insert(new NhanViens {
                        Email = user.Email,
                        DiaChi = user.DiaChi,
                        SoDienThoai = user.PhoneNumber,
                        TenTaiKhoan = user.TenTaiKhoan,
                        TenNhanVien = user.HoTen,
                        NgayBatDau = DateTime.Now
                    });
                }
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
            var userNameList=_userRoleRepository.GetAll().Where(p=>p.RoleId == role).ToList();
            List<ApplicationUser> listAppUser = new List<ApplicationUser>();
            if(userNameList != null)
            {
                foreach (var user in userNameList)
                {
                    listAppUser.Add(_userRepository.SelectById(user.UserId));
                }
            }

            return listAppUser;
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
        public List<ApplicationUser> GetAll()
        {
            var querys = _userRepository.GetAll().Where(p => p.isDelete == false);
            return querys.ToList();
        }
        public List<ApplicationUser> GetAll(TaiKhoanSearchList taiKhoanSearchList)
        {
            if (!taiKhoanSearchList.page.HasValue) taiKhoanSearchList.page = Constant.DefaultPage;
            if (!taiKhoanSearchList.size.HasValue) taiKhoanSearchList.size = Constant.DefaultSize;

            var querys = _userRepository.GetAll().Where(p=>p.isDelete == false);
            if(!string.IsNullOrEmpty(taiKhoanSearchList.user_name))
            {
                querys = querys.Where(p => (p.UserName.Contains(taiKhoanSearchList.user_name)));
            }
            if (!string.IsNullOrEmpty(taiKhoanSearchList.id))
            {
                querys = querys.Where(p => (p.Id.Contains(taiKhoanSearchList.id)));
            }
            if (!string.IsNullOrEmpty(taiKhoanSearchList.name))
            {
                querys = querys.Where(p => (p.HoTen.Contains(taiKhoanSearchList.name)));
            }
            this.countList = querys.Count();
            querys = querys.Skip(taiKhoanSearchList.size.Value * taiKhoanSearchList.page.Value)
                           .Take(taiKhoanSearchList.size.Value).OrderBy(prop=>prop.Id);
            return querys.ToList();
        }
        public int countList { set; get; }
        public int Count()
        {
            return this.countList;
        }
    }

}
