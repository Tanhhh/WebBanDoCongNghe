using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class ListProductController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Product
        public ActionResult IndexListProduct()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            var items = db.tb_Product.Where(n => n.IsSoldOut == false && n.IsActive == true).ToList();
            return View(items);
        }
        public ViewResult ListProductByCategory(int id)
        {   //kiem tra có loại này hay ko

            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            tb_ProductCategory Category = db.tb_ProductCategory.SingleOrDefault(n => n.MaProductCategory == id);
            if (Category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<tb_Product> Product = db.tb_Product.Where(n => n.IsSoldOut == false && n.IsActive == true && n.MaProductCategory == id).ToList();
            var cate = db.tb_ProductCategory.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.TenDanhMuc;
            }
            ViewBag.cateId = id;
            return View(Product);
        }
        public ViewResult ListProductByBrand(int id)
        {   //kiem tra có loại này hay ko
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            tb_Brand Brand = db.tb_Brand.SingleOrDefault(n => n.MaBrand == id);
            if (Brand == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<tb_Product> Product = db.tb_Product.Where(n => n.IsSoldOut == false && n.IsActive == true && n.MaBrand == id).ToList();
            var brand = db.tb_Brand.Find(id);
            if (brand != null)
            {
                ViewBag.brandName = brand.TenBrand;
            }
            ViewBag.brandId = id;
            return View(Product);
        }
        public ActionResult MenuCategoryListProduct(int? id)
        {

            if (id != null)
            {
                ViewBag.cateId = id;
            }
            var items = db.tb_ProductCategory.OrderBy(n => n.Position).ToList();
            return PartialView(items);
        }
        public ActionResult MenuBrandListProduct(int? id)
        {
            if (id != null)
            {
                ViewBag.cateId = id;
            }
            var items = db.tb_Brand.OrderBy(n => n.MaBrand).ToList();
            return PartialView(items);
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