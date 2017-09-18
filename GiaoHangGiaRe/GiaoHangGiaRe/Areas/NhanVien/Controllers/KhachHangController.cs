using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EntityModel;
using GiaoHangGiaRe.Areas.NhanVien.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GiaoHangGiaRe.Areas.NhanVien.Controllers
{
    public class KhachHangController : Controller
    {
        private GiaoHangGiaReDbContext db ;
        public KhachHangController()
        {
            db = new GiaoHangGiaReDbContext();
        }
        // GET: NhanVien/KhachHang
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: NhanVien/KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: NhanVien/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/KhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,TenKhachHang,CongTy,SoDienThoai,Email,DiaChi,MaLoaiKH,NgaySinh,TrangThai,deleted,MaTaiKhoan")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: NhanVien/KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: NhanVien/KhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,TenKhachHang,CongTy,SoDienThoai,Email,DiaChi,MaLoaiKH,NgaySinh,TrangThai,deleted,MaTaiKhoan")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: NhanVien/KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: NhanVien/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: NhanVien/KhachHang/PhanLoai/5
        public ActionResult PhanLoai(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            KhachHangEditModel khachhangedit = new KhachHangEditModel
            {
                KhachHang = khachHang,
                DSLoaiKhachHang = db.LoaiKhachHangs.ToList(),
                DSTaiKhoan = UserManager.Users.ToList()
        };


            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachhangedit);
        }

        // POST: NhanVien/KhachHang/PhanLoai/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhanLoai([Bind(Include = "KhachHang.MaKhachHang,KhachHang.TenKhachHang,KhachHang.CongTy,KhachHang.SoDienThoai,KhachHang.Email,KhachHang.DiaChi," +
            "KhachHang.MaLoaiKH,KhachHang.NgaySinh,KhachHang.TrangThai,KhachHang.deleted,KhachHang.MaTaiKhoan,LoaiKhachHang.TenLoaiKH")] KhachHangEditModel khachHangedit)
        {
            KhachHang khachHang = new KhachHang();
            khachHang = khachHangedit.KhachHang;
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
