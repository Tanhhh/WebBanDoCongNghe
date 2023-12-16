using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebBanDoCongNghe.Models;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Net;
using System.Data.Entity;

namespace WebBanDoCongNghe.Controllers
{
    public class ContactController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();

        public ActionResult Index()
        {

            return View();
        }



        // GET: /Contact    
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(tb_Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Không cần kiểm tra thông tin tài khoản ở đây vì đây là trường hợp điền thông tin liên hệ
                    model.CreateDate = DateTime.Now;
                    model.IsXuLy = false;
                    db.tb_Contact.Add(model);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Gửi thành công";
                    return RedirectToAction("Contact");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
            }

            return View(model);
        }

        public ActionResult ContactCustomer()
        {
            if (Session["MaKH"] != null)
            {
                var userInfo = Session["taikhoan"] as tb_Customer;
                ViewBag.UserInfo = userInfo;
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == userInfo.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;

            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactCustomer(tb_Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userInfo = Session["taikhoan"] as tb_Customer;

                    if (userInfo != null)
                    {
                        model.MaKH = userInfo.MaKH;
                        model.HoTen = userInfo.HoTen;
                        model.PhoneNumber = userInfo.Phone;
                        model.Email = userInfo.Email;

                    }
                    model.CreateDate = DateTime.Now;
                    model.IsXuLy = false;
                    db.tb_Contact.Add(model);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Gửi thành công";
                    return RedirectToAction("ContactCustomer");
                }
                else
                {
                    TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng trong Session";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
            }
           
            return View(model);
        }
    }
}