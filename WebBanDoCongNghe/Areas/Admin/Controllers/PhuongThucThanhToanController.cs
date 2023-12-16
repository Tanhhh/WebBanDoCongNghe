using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class PhuongThucThanhToanController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/PhuongThucThanhToan
        public ActionResult IndexPhuongThucThanhToan(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_PhuongThucThanhToan.OrderBy(n => n.MaPhuongThucThanhToan).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddPhuongThucThanhToan()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPhuongThucThanhToan(tb_PhuongThucThanhToan model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_PhuongThucThanhToan.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexPhuongThucThanhToan");
            }
            return View(model);
        }

        public ActionResult EditPhuongThucThanhToan(int id)
        {
            var item = db.tb_PhuongThucThanhToan.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhuongThucThanhToan(tb_PhuongThucThanhToan model)
        {
            if (ModelState.IsValid)
            {
                db.tb_PhuongThucThanhToan.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.TenPhuongThucThanhToan).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexPhuongThucThanhToan");
            }
            return View(model);
        }
        public ActionResult DeletePhuongThucThanhToan(int id)
        {
            var item = db.tb_PhuongThucThanhToan.Find(id);
            db.tb_PhuongThucThanhToan.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexPhuongThucThanhToan");
        }

        [HttpPost]
        public ActionResult DeleteAllPhuongThucThanhToan(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_PhuongThucThanhToan.Find(Convert.ToInt32(item));
                        db.tb_PhuongThucThanhToan.Remove(obj);
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