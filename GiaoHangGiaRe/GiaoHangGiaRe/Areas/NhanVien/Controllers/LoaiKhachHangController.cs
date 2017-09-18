using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EntityModel;

namespace GiaoHangGiaRe.Areas.NhanVien.Controllers
{
    public class LoaiKhachHangController : Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: NhanVien/LoaiKhachHang
        public ActionResult Index()
        {
            return View(db.LoaiKhachHangs.ToList());
        }

        // GET: NhanVien/LoaiKhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhachHang loaiKhachHang = db.LoaiKhachHangs.Find(id);
            if (loaiKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhachHang);
        }

        // GET: NhanVien/LoaiKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/LoaiKhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiKH,TenLoaiKH,MoTa")] LoaiKhachHang loaiKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiKhachHangs.Add(loaiKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiKhachHang);
        }

        // GET: NhanVien/LoaiKhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhachHang loaiKhachHang = db.LoaiKhachHangs.Find(id);
            if (loaiKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhachHang);
        }

        // POST: NhanVien/LoaiKhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiKH,TenLoaiKH,MoTa")] LoaiKhachHang loaiKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiKhachHang);
        }

        // GET: NhanVien/LoaiKhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiKhachHang loaiKhachHang = db.LoaiKhachHangs.Find(id);
            if (loaiKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiKhachHang);
        }

        // POST: NhanVien/LoaiKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiKhachHang loaiKhachHang = db.LoaiKhachHangs.Find(id);
            db.LoaiKhachHangs.Remove(loaiKhachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
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
