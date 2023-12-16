using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class MemoryController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Brand
        public ActionResult IndexMemory(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Memory.OrderBy(n => n.MaMemory).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddMemory()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMemory(tb_Memory model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_Memory.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexMemory");
            }
            return View(model);
        }

        public ActionResult EditMemory(int id)
        {
            var item = db.tb_Memory.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMemory(tb_Memory model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Memory.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.TenMemory).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexMemory");
            }
            return View(model);
        }
        public ActionResult DeleteMemory(int id)
        {
            var item = db.tb_Memory.Find(id);
            db.tb_Memory.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexMemory");
        }

        [HttpPost]
        public ActionResult DeleteAllMemory(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_Memory.Find(Convert.ToInt32(item));
                        db.tb_Memory.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}