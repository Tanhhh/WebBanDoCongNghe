using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class FavoriteProductController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();


        public ActionResult IndexFAV(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            tb_Customer user = Session["taikhoan"] as tb_Customer;
            if (user == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bạn chưa đăng nhập');window.location = '/Login/Login';</script>");
            }
            else
            {
                List<tb_FavoriteProduct> favid = db.tb_FavoriteProduct.Where(x => x.MaKH == user.MaKH).ToList();

                List<tb_Product> favPro = new List<tb_Product>();

                foreach (var item in favid)
                {
                    tb_Product a = db.tb_Product.FirstOrDefault(x => x.MaSanPham == item.MaSanPham);
                    favPro.Add(a);
                }

                ViewData["favoriteproduct"] = favPro;

                Session["taikhoan"] = user;

                var pageList = favPro.ToList().ToPagedList(pageNumber, pageSize);
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == user.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
                return View(pageList);
            }
        }


    }




}

