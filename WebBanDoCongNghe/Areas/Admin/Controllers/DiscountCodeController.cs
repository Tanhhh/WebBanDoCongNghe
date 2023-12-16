using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class DiscountCodeController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/DiscountCode
        public ActionResult IndexDiscountCode(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_DiscountCode.OrderBy(n => n.MaDiscount).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddDiscountCode()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscountCode(tb_DiscountCode model)
        {
            if (ModelState.IsValid)
            {
                var userInfo = Session["admin"] as tb_NhanVien;
                model.CreatedBy = userInfo.TaiKhoan;
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_DiscountCode.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexDiscountCode");
            }
            return View(model);
        }

        public ActionResult EditDiscountCode(int id)
        {
            var item = db.tb_DiscountCode.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDiscountCode(tb_DiscountCode model)
        {
            if (ModelState.IsValid)
            {
                db.tb_DiscountCode.Attach(model);
                model.UpdatedDate = DateTime.Now;
                var userInfo = Session["admin"] as tb_NhanVien;
                model.CreatedBy = userInfo.TaiKhoan;
                db.Entry(model).Property(x => x.SoDiemCanDoi).IsModified = true;
                db.Entry(model).Property(x => x.TenDiscount).IsModified = true;
                db.Entry(model).Property(x => x.DiscountCode).IsModified = true;
                db.Entry(model).Property(x => x.Value).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Quantity).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexDiscountCode");
            }
            return View(model);
        }
        public ActionResult DeleteDiscountCode(int id)
        {
            var item = db.tb_DiscountCode.Find(id);
            db.tb_DiscountCode.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexDiscountCode");
        }

        [HttpPost]
        public ActionResult DeleteAllDiscountCode(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_TaiKhoanNganHang.Find(Convert.ToInt32(item));
                        db.tb_TaiKhoanNganHang.Remove(obj);
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