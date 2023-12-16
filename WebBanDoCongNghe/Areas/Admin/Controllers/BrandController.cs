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
    public class BrandController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Brand
        public ActionResult IndexBrand(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Brand.OrderBy(n => n.MaBrand).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddBrand()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBrand(tb_Brand model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_Brand.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexBrand");
            }
            return View(model);
        }

        public ActionResult EditBrand(int id)
        {
            var item = db.tb_Brand.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBrand(tb_Brand model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Brand.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.TenBrand).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexBrand");
            }
            return View(model);
        }
        public ActionResult DeleteBrand(int id)
        {
            var item = db.tb_Brand.Find(id);
            db.tb_Brand.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexBrand");
        }

        [HttpPost]
        public ActionResult DeleteAllBrand(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_DiscountCode.Find(Convert.ToInt32(item));
                        db.tb_DiscountCode.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(db!=null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}