using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EntityModel;
using Microsoft.AspNet.Identity;

namespace GiaoHangGiaRe.Controllers
{
    [Authorize]
    public class KienHangController :Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: KienHang
        //public ActionResult Index()
        //{
        //    return View(db.KienHangs.ToList());
        //}

        // GET: KienHang/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    KienHang kienHang = db.KienHangs.Find(id);
          
        //    //if (kienHang == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(kienHang);
        //}
       
        // GET: KienHang/Create
        public ActionResult Create(int? id)
        {
            ViewBag.MaDonHang = id;
            return View();
        }   
        // POST: KienHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKienHang,MaDonHang,TinhTrang,deleted,GhiChu,TrongLuong,ChieuDai,ChieuRong,MoTa,NoiDung,SoLuong")] KienHang kienHang)
        {                                          
            if (ModelState.IsValid)
            {
                if(db.DonHangs.Find(kienHang.MaDonHang).TenTaiKhoan == User.Identity.GetUserName())
                {
                    db.KienHangs.Add(kienHang);
                    db.SaveChanges();
                    return RedirectToAction("Index","DonHang");
                }
                else
                    return View(kienHang);
            }
            return View(kienHang);
        }

        // GET: KienHang/Edit/5
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
            if (kienHang.TinhTrang == "Đang chờ")
            {
                return HttpNotFound();
            }
            return View(kienHang);
        }

        // POST: KienHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKienHang,MaDonHang,SoLuong,TinhTrang,deleted,GhiChu,TrongLuong,ChieuDai,ChieuRong,MoTa,NoiDung")] KienHang kienHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kienHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "DonHang");               
            }
            return View(kienHang);
        }

        // GET: KienHang/Delete/5
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

        // POST: KienHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KienHang kienHang = db.KienHangs.Find(id);
            db.KienHangs.Remove(kienHang);
            db.SaveChanges();
            return RedirectToAction("Index", "DonHang");
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
