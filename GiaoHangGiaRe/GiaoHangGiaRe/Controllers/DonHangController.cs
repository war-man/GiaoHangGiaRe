using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EntityModel;
using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity;
using GiaoHangGiaRe.Hub;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    public class DonHangController : Controller
    {
        private GiaoHangGiaReDbContext db;     
        public  DonHangController()//Cau tu
        {
            db = new GiaoHangGiaReDbContext();         
        }
        // GET: DonHang
        public ActionResult Index() // Danh sach đơn hàng
        {
            var userName = User.Identity.GetUserName();
            var query = from dh in db.DonHangs where dh.TenTaiKhoan == userName select dh;
            return View(query.ToList());
        }
        
        // GET: DonHang/Details/5
        public ActionResult Details(int? id)// Hiển thị danh sách kiện hàng thuộc đơn hàng có mã là id
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var query = from kh in db.KienHangs where kh.MaDonHang == id select kh;
            DonHang donhang = db.DonHangs.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            if (donhang!=null)
            {
                if(donhang.TenTaiKhoan != null || donhang.TenTaiKhoan == User.Identity.GetUserName())
                {
                    ChiTietDonHang chitietdonhang = new ChiTietDonHang();                 
                    chitietdonhang.DonHang = donhang;
                    chitietdonhang.KienHang = query.ToList();
                    return View(chitietdonhang);
                }         
                else
                    return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
        // GET: DonHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,DiaChiGui,SoDienThoaiNguoiGui,NguoiNhan,DiaChiNhan,SoDienThoaiNguoiNhan,NguoiGui," +
            "GhiChu,ThanhTien,TinhTrang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
               
                donHang.TenTaiKhoan = User.Identity.GetUserName();
                donHang.TinhTrang = "Đang chờ";
                donHang.ThoiDiemDatDonHang = DateTime.Now;
                db.DonHangs.Add(donHang);
                db.SaveChanges();             
                return RedirectToAction("Create", "KienHang", new { id = donHang.MaDonHang });
            }

            return View(donHang);
           // return RedirectToAction("Create", "KienHang", new { id = id });
        }
        // GET: DonHang/XacNhan/5
        public ActionResult XacNhan(int? id)// Hiển thị danh sách kiện hàng thuộc đơn hàng có mã là id
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = from kh in db.KienHangs where kh.MaDonHang == id select kh;
            DonHang donhang = db.DonHangs.Find(id);
            ChiTietDonHang chitietdonhang = new ChiTietDonHang();
            if (query == null)
            {
                return HttpNotFound();
            }
            chitietdonhang.DonHang = donhang;
            chitietdonhang.KienHang = query.ToList();
            return View(chitietdonhang);
        }
        // POST: DonHang/XacNhan/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhan([Bind(Include = "TenTaiKhoan,MaDonHang,NguoiGui,DiaChiGui,SoDienThoaiNguoiGui,NguoiNhan,DiaChiNhan,SoDienThoaiNguoiNhan,NguoiGui,TinhTrang,ThanhTien," +
            "ThoiDiemDatDonHang,ThoiDiemHoanThanhDH,ThoiDiemTiepNhanDon,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                donHang.TinhTrang = "Đã khóa yêu cầu";
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DonHang");
            }
            return View(donHang);
        }

        // GET: DonHang/Edit/5
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

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTaiKhoan,MaDonHang,NguoiGui,DiaChiGui,SoDienThoaiNguoiGui,NguoiNhan,DiaChiNhan,SoDienThoaiNguoiNhan,NguoiGui,TinhTrang,ThanhTien," +
            "ThoiDiemDatDonHang,ThoiDiemHoanThanhDH,ThoiDiemTiepNhanDon,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","DonHang");
            }
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        [Authorize(Roles = "admin")]
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

        // POST: DonHang/Delete/5
        [Authorize(Roles = "admin")]
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
