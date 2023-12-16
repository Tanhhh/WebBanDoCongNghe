using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{

    public class HomeController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        public ActionResult IndexHome()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            return View();
        }
        public ActionResult ProductByCategory()
        {
            var items = db.tb_Product.Where(n => n.IsSoldOut == false && n.IsActive == true && n.IsNew == true).ToList();
            return PartialView(items);
        }
        public ActionResult DiscountProduct()
        {
            var items = db.tb_Product.Where(n => n.IsSoldOut == false && n.IsActive == true && n.IsSale == true).ToList();
            return PartialView(items);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Introduction()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if(customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            return View();
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