using GiaoHangGiaRe.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoHangGiaRe.Areas.NhanVien.Controllers
{
    public class ManageRoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: NhanVien/ManageRole
        public ActionResult Index()
        {
            var listRole= context.Roles.ToList();
          
            return View(listRole.ToList());
        }
        //CREATE
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }

        //DELETE
        public ActionResult Delete(string Id)
        {
            var model = context.Roles.Find(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            IdentityRole model = null;
            try
            {
                model = context.Roles.Find(Id);
                context.Roles.Remove(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Rất tiếc đã xảy ra lỗi, hãy thao tác lại!", ex.Message);
            }
            return View(model);
        }
    }
}