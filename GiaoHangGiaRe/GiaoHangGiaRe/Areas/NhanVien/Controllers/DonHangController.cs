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
    public class DonHangController : Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: NhanVien/DonHang
        public ActionResult Index()
        {
            return View(db.DonHangs.ToList());
        }
        public ActionResult DanhSachHangCho()
        {
            var dshangcho = from dh in db.DonHangs where dh.TinhTrang == 0 select dh;
            return View(dshangcho.ToList());
        }
        // GET: NhanVien/DonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: NhanVien/DonHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/DonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,NguoiGui,DiaChiGui,SoDienThoaiNguoiGui,NguoiNhan,DiaChiNhan,SoDienThoaiNguoiNhan,MaNhanVienGiao,TinhTrang,ThoiDiemDatDonHang,ThoiDiemTiepNhanDon,ThoiDiemHoanThanhDH,ThanhTien,deleted,TenTaiKhoan,MaHanhTrinh,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: NhanVien/DonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: NhanVien/DonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,NguoiGui,DiaChiGui,SoDienThoaiNguoiGui,NguoiNhan,DiaChiNhan,SoDienThoaiNguoiNhan,MaNhanVienGiao,TinhTrang,ThoiDiemDatDonHang,ThoiDiemTiepNhanDon,ThoiDiemHoanThanhDH,ThanhTien,deleted,TenTaiKhoan,MaHanhTrinh,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        // GET: NhanVien/DonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: NhanVien/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
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
