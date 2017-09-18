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
    public class BangGiaController : Controller
    {
        private GiaoHangGiaReDbContext db = new GiaoHangGiaReDbContext();

        // GET: NhanVien/BangGia
        public ActionResult Index()
        {
            return View(db.BangGias.ToList());
        }

        // GET: NhanVien/BangGia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // GET: NhanVien/BangGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/BangGia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma,Ten,NoiDung,BaoGia")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                db.BangGias.Add(bangGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangGia);
        }

        // GET: NhanVien/BangGia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // POST: NhanVien/BangGia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma,Ten,NoiDung,BaoGia")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangGia);
        }

        // GET: NhanVien/BangGia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // POST: NhanVien/BangGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangGia bangGia = db.BangGias.Find(id);
            db.BangGias.Remove(bangGia);
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
