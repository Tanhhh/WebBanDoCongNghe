using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class ProductImagesController : Controller
    {

        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/ProductImages
        public ActionResult IndexProductImages(int id)
        {
            ViewBag.MaSanPham = id;
            var items = db.tb_ProductImages.Where(x => x.MaSanPham == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddProductImages(int MaSanPham, string url)
        {

            db.tb_ProductImages.Add(new tb_ProductImages
            {
                MaSanPham = MaSanPham,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new {success=true});
        }

        [HttpPost]
        public ActionResult DeleteProductImages(int id)
        {
            var item = db.tb_ProductImages.Find(id);
            db.tb_ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
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