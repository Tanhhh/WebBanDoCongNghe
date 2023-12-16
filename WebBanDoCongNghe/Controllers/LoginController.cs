using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;
using System.Data.Entity;
using System.Linq;

namespace WebBanDoCongNghe.Controllers
{
    public class LoginController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tb_Customer model, string ReMatKhau)
        {
            if (ModelState.IsValid)
            {
                var check = db.tb_Customer.FirstOrDefault(x => x.TaiKhoan == model.TaiKhoan);
                if (check == null)
                {
                    // Kiểm tra mật khẩu và mật khẩu nhập lại
                    if (model.MatKhau != ReMatKhau)
                    {
                        TempData["ErrorMessage"] = "Mật khẩu không khớp.";
                        return View("Register", model);
                    }

                    model.MatKhau = GetMD5(model.MatKhau);
                    model.IsAdmin = false;
                    model.IsActive = true;
                    model.CreateDate = DateTime.Now;
                    model.UpdatedDate = DateTime.Now;
                    model.ImageUser = "avt-user.png";
                    db.tb_Customer.Add(model);
                    db.SaveChanges();

                    // Đặt thông điệp vào TempData
                    TempData["SuccessMessage"] = "Đăng ký thành công!";

                    ModelState.Clear(); // Làm mới ModelState

                    return RedirectToAction("Register");
                }
                else
                {
                    TempData["ErrorMessage"] = "Tài khoản đã tồn tại";
                    return View("Register", model);
                }
            }
            TempData["ErrorMessage"] = "Tạo tài khoản thất bại xin vui lòng thử lại";
            return View("Register", model);
        }

        public static string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string taikhoan, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var Password = GetMD5(matkhau);
                var customer = db.tb_Customer.Where(x => x.TaiKhoan.Equals(taikhoan) && x.MatKhau.Equals(Password)).ToList();
                tb_Customer kh = db.tb_Customer.SingleOrDefault(x => x.TaiKhoan.Equals(taikhoan) && x.MatKhau.Equals(Password));
                if (customer.Count > 0)
                {
                    if (kh.IsActive == true)
                    {
                        Session["taikhoan"] = kh;
                        Session["MaKH"] = customer.FirstOrDefault().MaKH;
                        Session["HoTen"] = customer.FirstOrDefault().HoTen;
                        Session["Email"] = customer.FirstOrDefault().Email;
                        Session["Images"] = customer.FirstOrDefault().ImageUser;



                        //luu user vao tempdata 
                        TempData["user"] = kh;

                        return RedirectToAction("IndexHome", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Tài khoản của bạn đã bị khóa";
                        return this.Login();
                    }

                }
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";
                    return this.Login();
                }

            }
            ViewBag.error = "Đăng nhập thất bại xin vui lòng thử lại";
            return this.Login();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("indexHome", "Home");
        }

        public ActionResult ChangePassWord()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassWord(String matkhaucu , String matkhaumoi , String matkhaumoiconfirm)
        {
            if (ModelState.IsValid)
            {
                tb_Customer detailCus = TempData["user"] as tb_Customer;
                var Password = GetMD5(matkhaucu);

                var customer = db.tb_Customer.Where(x => x.TaiKhoan.Equals(detailCus.TaiKhoan) && x.MatKhau.Equals(Password)).ToList().First();

                tb_Customer kh = db.tb_Customer.FirstOrDefault(x => x.TaiKhoan.Equals(detailCus.TaiKhoan) && x.MatKhau.Equals(Password));

                if (customer!=null)
                {
                    if (matkhaumoi != matkhaumoiconfirm)
                    {
                        TempData["user"] = kh;
                        ViewBag.error = "Mật khẩu confirm không chính xác";
                        return this.ChangePassWord();
                    }
                    else if (kh.IsActive == true)
                    {
                        Session["taikhoan"] = kh;
                        Session["MaKH"] = customer.MaKH;
                        Session["HoTen"] = customer.HoTen;
                        Session["Email"] = customer.Email;

                        //luu user vao tempdata 
                        TempData["user"] = kh;


                        //update lai mat khau moi 
                        var newPassword = GetMD5(matkhaumoi);

                        customer.MatKhau = newPassword;
                        //customer.ImageUser = null;
                        //customer.CreatedBy = null;
                        //customer.UpdatedBy = null;






                        db.Entry(kh).State = EntityState.Modified;

                        db.SaveChanges();

                        return Content("<script language='javascript' type='text/javascript'>alert('đổi mật khẩu thành công');window.location = '/Home/IndexHome';</script>");

                        //return RedirectToAction("ChangePassWord", "Login");
                    }
                   
                    else
                    {
                        TempData["user"] = kh;
                        ViewBag.error = "Tài khoản của bạn đã bị khóa";
                        return this.ChangePassWord();
                    }
                }
                else
                {
                    TempData["user"] = kh;
                    ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";
                    return this.ChangePassWord();
                }
           
            }
            ViewBag.error = "Đăng nhập thất bại xin vui lòng thử lại";
            return this.ChangePassWord();
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