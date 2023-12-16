using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Category
        public ActionResult IndexCategory(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Category.OrderBy(n => n.Position).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddCategory()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory( tb_Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.Link = WebBanDoCongNghe.Models.Common.Filter.FilterChar(model.TenDanhMuc);
                db.tb_Category.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexCategory");
            }
            return View(model);
        }

        public ActionResult EditCategory(int id)
        {
            var item = db.tb_Category.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(tb_Category model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Category.Attach(model);
                model.UpdatedDate = DateTime.Now;
                model.Link = WebBanDoCongNghe.Models.Common.Filter.FilterChar(model.TenDanhMuc);
                db.Entry(model).Property(x => x.TenDanhMuc).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Position).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();
                
                return RedirectToAction("IndexCategory");
            }
            return View(model);
        }
        public ActionResult DeleteCategory(int id)
        {
            var item = db.tb_Category.Find(id);
            db.tb_Category.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexCategory");
        }

        [HttpPost]
        public ActionResult DeleteAllCategory(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_Category.Find(Convert.ToInt32(item));
                        db.tb_Category.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success =true});
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