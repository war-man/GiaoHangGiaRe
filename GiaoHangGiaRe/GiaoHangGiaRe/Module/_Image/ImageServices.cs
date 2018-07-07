using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityModel;
using System.IO;

namespace GiaoHangGiaRe.Module
{
    public class ImageServices : IImageServices
    {
        private IRepository<Image> _imageRepository;
        private LichSuServices lichSuServices;
        //private UserServices _userServices;
        public ImageServices()
        {
            _imageRepository = new IRepository<Image>();
            lichSuServices = new LichSuServices();
            //_userServices = new UserServices();
        }
        public int Count()
        {
            return _imageRepository.GetAll().Count();
        }

        public bool Create(Image input)
        {
            string img = input.ImageContent;
            if(img != "")
            {
                byte[] contents = Convert.FromBase64String(img);
                //string subpath = "~/images/users";
                //bool exists = Directory.Exists(HttpContext.Current.Server.MapPath(subpath));
                //if (!exists)
                //{
                //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(subpath));
                //}
                string fileName = input.create_by + DateTime.Now.ToString("yyyyMMdd-HHMMss") + ".png";
                var path = Path.Combine(HttpRuntime.AppDomainAppPath + "/data/images", Path.GetFileName(fileName));

                File.WriteAllBytes(path, contents);

                input.ImageContent = path;
                _imageRepository.Insert(input);

                lichSuServices.Create(new LichSu
                {
                    HanhDong = Constant.CreateAction,
                    TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                    NoiDung = Constant.CvtToString(input),
                    ViTriThaoTac = Constant.No
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            _imageRepository.Delete(id);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.DeleteAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = id.ToString(),
                ViTriThaoTac = Constant.No
            });
        }


        public Image GetById(int Id)
        {
            return _imageRepository.SelectById(Id);
        }
   


        public void Update(Image input)
        {
            _imageRepository.Update(input);
            lichSuServices.Create(new LichSu
            {
                HanhDong = Constant.UpdateAction,
                TenTaiKhoan = HttpContext.Current.User.Identity.Name,
                NoiDung = Constant.CvtToString(input),
                ViTriThaoTac = Constant.No
            });
        }

    }
}