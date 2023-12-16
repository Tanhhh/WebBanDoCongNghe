using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using WebBanDoCongNghe.Models;
using System.Data.Entity;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Product
        public ActionResult IndexProduct(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var item = db.tb_Product.OrderByDescending(n => n.MaSanPham).ToPagedList(pageNumber, pageSize);
            return View(item);
        }
        public ActionResult AddProduct()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "MaProductCategory", "TenDanhMuc");
            ViewBag.Brand = new SelectList(db.tb_Brand.ToList(), "MaBrand", "TenBrand");
            ViewBag.Color = new SelectList(db.tb_Color.ToList(), "MaColor", "TenColor");
            ViewBag.Memory = new SelectList(db.tb_Memory.ToList(), "MaMemory", "TenMemory");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(tb_Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.tb_ProductImages.Add(new tb_ProductImages
                            {
                                MaSanPham = model.MaSanPham,
                                Image = Images[i],
                                IsDefault = true,
                            });
                        }
                        else
                        {
                            model.tb_ProductImages.Add(new tb_ProductImages
                            {
                                MaSanPham = model.MaSanPham,
                                Image = Images[i],
                                IsDefault = false,
                            });
                        }
                    }
                }

                model.IsSoldOut = model.Quantity == 0;
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.Link = WebBanDoCongNghe.Models.Common.Filter.FilterChar(model.TenSanPham);
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.TenSanPham;
                }
                db.tb_Product.Add(model);
                db.SaveChanges();

                return RedirectToAction("IndexProDuct");
            }
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "MaProductCategory", "TenDanhMuc");
            ViewBag.Brand = new SelectList(db.tb_Brand.ToList(), "MaBrand", "TenBrand");
            ViewBag.Color = new SelectList(db.tb_Color.ToList(), "MaColor", "TenColor");
            ViewBag.Memory = new SelectList(db.tb_Memory.ToList(), "MaMemory", "TenMemory");
            return View(model);
        }
        public ActionResult EditProduct(int id)
        {

            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "MaProductCategory", "TenDanhMuc");
            ViewBag.Brand = new SelectList(db.tb_Brand.ToList(), "MaBrand", "TenBrand");
            ViewBag.Color = new SelectList(db.tb_Color.ToList(), "MaColor", "TenColor");
            ViewBag.Memory = new SelectList(db.tb_Memory.ToList(), "MaMemory", "TenMemory");
            var item = db.tb_Product.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(tb_Product model)
        {
            {
                if (ModelState.IsValid)
                {
                    model.IsSoldOut = model.Quantity == 0;

                    db.tb_Product.Attach(model);
                    model.UpdatedDate = DateTime.Now;
                    model.Link = WebBanDoCongNghe.Models.Common.Filter.FilterChar(model.TenSanPham);
                    db.Entry(model).Property(x => x.TenSanPham).IsModified = true;
                    db.Entry(model).Property(x => x.Description).IsModified = true;
                    db.Entry(model).Property(x => x.Detail).IsModified = true;
                    db.Entry(model).Property(x => x.MaProductCategory).IsModified = true;
                    db.Entry(model).Property(x => x.MaBrand).IsModified = true;
                    db.Entry(model).Property(x => x.MaColor).IsModified = true;
                    db.Entry(model).Property(x => x.MaMemory).IsModified = true;
                    db.Entry(model).Property(x => x.Quantity).IsModified = true;
                    db.Entry(model).Property(x => x.Price).IsModified = true;
                    db.Entry(model).Property(x => x.PriceSale).IsModified = true;
                    db.Entry(model).Property(x => x.IsActive).IsModified = true;
                    db.Entry(model).Property(x => x.IsSoldOut).IsModified = true;
                    db.Entry(model).Property(x => x.IsSale).IsModified = true;
                    db.Entry(model).Property(x => x.IsNew).IsModified = true;
                    db.Entry(model).Property(x => x.IsHot).IsModified = true;
                    db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                    db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                    db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                    db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                    db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                    db.SaveChanges();

                    return RedirectToAction("IndexProDuct");
                }
                return View(model);
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            var item = db.tb_Product.Find(id);
            db.tb_Product.Remove(item);
            db.SaveChanges();
            return RedirectToAction("IndexProduct");
        }
        [HttpPost]
        public ActionResult DeleteAllProduct(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.tb_Product.Find(Convert.ToInt32(item));
                        db.tb_Product.Remove(obj);
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