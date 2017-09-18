using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EntityModel;

namespace GiaoHangGiaRe.Controllers
{
    public class HanhTrinhController : Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: HanhTrinh
        public ActionResult Index()
        {
            return View(db.HanhTrinhs.ToList());
        }

        // GET: HanhTrinh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HanhTrinh hanhTrinh = db.HanhTrinhs.Find(id);
            if (hanhTrinh == null)
            {
                return HttpNotFound();
            }
            return View(hanhTrinh);
        }

        // GET: HanhTrinh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HanhTrinh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHanhTrinh,HanhTrinh1,DiemBatDau,DiemKetThuc,QuangDuong,ThoiGian,deleted")] HanhTrinh hanhTrinh)
        {
            if (ModelState.IsValid)
            {
                db.HanhTrinhs.Add(hanhTrinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hanhTrinh);
        }

        // GET: HanhTrinh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HanhTrinh hanhTrinh = db.HanhTrinhs.Find(id);
            if (hanhTrinh == null)
            {
                return HttpNotFound();
            }
            return View(hanhTrinh);
        }

        // POST: HanhTrinh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHanhTrinh,HanhTrinh1,DiemBatDau,DiemKetThuc,QuangDuong,ThoiGian,deleted")] HanhTrinh hanhTrinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanhTrinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hanhTrinh);
        }

        // GET: HanhTrinh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HanhTrinh hanhTrinh = db.HanhTrinhs.Find(id);
            if (hanhTrinh == null)
            {
                return HttpNotFound();
            }
            return View(hanhTrinh);
        }

        // POST: HanhTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HanhTrinh hanhTrinh = db.HanhTrinhs.Find(id);
            db.HanhTrinhs.Remove(hanhTrinh);
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
