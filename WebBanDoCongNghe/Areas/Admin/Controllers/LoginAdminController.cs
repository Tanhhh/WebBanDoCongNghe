using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/Login
        public ActionResult IndexLoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexLoginAdmin(string taikhoan, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var Password = GetMD5(matkhau);
                var admin = db.tb_NhanVien.Where(x => x.TaiKhoan.Equals(taikhoan) && x.MatKhau.Equals(Password)).ToList();
                tb_NhanVien nhanvien = db.tb_NhanVien.SingleOrDefault(x => x.TaiKhoan.Equals(taikhoan) && x.MatKhau.Equals(Password));
                if (admin.Count > 0)
                {
                    if (nhanvien.IsActive == true)
                    {
                        Session["Admin"] = nhanvien;
                        Session["HoTenAdmin"] = admin.FirstOrDefault().TenNhanVien;
                        Session["IsQuanTriVien"] = admin.FirstOrDefault().IsQuanTriVien;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Tài khoản của bạn đã bị khóa";
                        return this.IndexLoginAdmin();
                    }

                }
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu không đúng";
                    return this.IndexLoginAdmin();
                }

            }
            ViewBag.error = "Đăng nhập thất bại xin vui lòng thử lại";
            return this.IndexLoginAdmin();
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
        public ActionResult Logout()
        {
            Session.Remove("Admin");
            Session.Remove("HoTenAdmin");
            return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
        }
    }
}