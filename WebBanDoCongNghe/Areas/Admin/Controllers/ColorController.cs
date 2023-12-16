using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class ColorController : Controller
    {
        // GET: Admin/Color
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Brand
        public ActionResult IndexColor(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Color.OrderBy(n => n.MaColor).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddColor()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddColor(tb_Color model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_Color.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexColor");
            }
            return View(model);
        }

        public ActionResult EditColor(int id)
        {
            var item = db.tb_Color.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditColor(tb_Color model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Color.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.ImageColor).IsModified = true;
                db.Entry(model).Property(x => x.TenColor).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexColor");
            }
            return View(model);
        }
        public ActionResult DeleteColor(int id)
        {
            var item = db.tb_Color.Find(id);
            db.tb_Color.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexColor");
        }

        [HttpPost]
        public ActionResult DeleteAllColor(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_Color.Find(Convert.ToInt32(item));
                        db.tb_Color.Remove(obj);
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