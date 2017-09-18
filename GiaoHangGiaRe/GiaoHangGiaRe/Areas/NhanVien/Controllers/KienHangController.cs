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
    public class KienHangController : Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: NhanVien/KienHang
        public ActionResult Index()
        {
            return View(db.KienHangs.ToList());
        }

        // GET: NhanVien/KienHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KienHang kienHang = db.KienHangs.Find(id);
            if (kienHang == null)
            {
                return HttpNotFound();
            }
            return View(kienHang);
        }

        // GET: NhanVien/KienHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/KienHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKienHang,MaDonHang,TinhTrang,deleted,GhiChu,TrongLuong,ChieuDai,ChieuRong,MoTa,SoLuong,NoiDung")] KienHang kienHang)
        {
            if (ModelState.IsValid)
            {
                db.KienHangs.Add(kienHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kienHang);
        }

        // GET: NhanVien/KienHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KienHang kienHang = db.KienHangs.Find(id);
            if (kienHang == null)
            {
                return HttpNotFound();
            }
            return View(kienHang);
        }

        // POST: NhanVien/KienHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKienHang,MaDonHang,TinhTrang,deleted,GhiChu,TrongLuong,ChieuDai,ChieuRong,MoTa,SoLuong,NoiDung")] KienHang kienHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kienHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kienHang);
        }

        // GET: NhanVien/KienHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KienHang kienHang = db.KienHangs.Find(id);
            if (kienHang == null)
            {
                return HttpNotFound();
            }
            return View(kienHang);
        }

        // POST: NhanVien/KienHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KienHang kienHang = db.KienHangs.Find(id);
            db.KienHangs.Remove(kienHang);
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
