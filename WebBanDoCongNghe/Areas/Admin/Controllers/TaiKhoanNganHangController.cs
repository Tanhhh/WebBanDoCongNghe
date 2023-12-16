using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class TaiKhoanNganHangController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/TaiKhoanNganHang
        public ActionResult IndexTaiKhoanNganHang(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_TaiKhoanNganHang.OrderBy(n => n.MaSoTaiKhoan).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult AddTaiKhoanNganHang()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTaiKhoanNganHang(tb_TaiKhoanNganHang model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_TaiKhoanNganHang.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexTaiKhoanNganHang");
            }
            return View(model);
        }

        public ActionResult EditTaiKhoanNganHang(int id)
        {
            var item = db.tb_TaiKhoanNganHang.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTaiKhoanNganHang(tb_TaiKhoanNganHang model)
        {
            if (ModelState.IsValid)
            {
                db.tb_TaiKhoanNganHang.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.TenNganHang).IsModified = true;
                db.Entry(model).Property(x => x.SoTaiKhoan).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("IndexTaiKhoanNganHang");
            }
            return View(model);
        }
        public ActionResult DeleteTaiKhoanNganHang(int id)
        {
            var item = db.tb_TaiKhoanNganHang.Find(id);
            db.tb_TaiKhoanNganHang.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexTaiKhoanNganHang");
        }

        [HttpPost]
        public ActionResult DeleteAllTaiKhoanNganHang(string ids)
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