using PagedList;
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
    public class UserAdminController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/UserAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Customer.OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult EditCustomer(int id)
        {
            var item = db.tb_Customer.Find(id);
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(tb_Customer model)
        {
            if (ModelState.IsValid)
            {
                db.tb_Customer.Attach(model);
                model.UpdatedDate = DateTime.Now;
               
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.IsAdmin).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("Customer");
            }
            return View(model);
        }

        public ActionResult Admin(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_NhanVien.OrderBy(n => n.MaNhanVien).ToPagedList(pageNumber, pageSize);
            return View(item);
        }
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(tb_NhanVien model)
        {
            if (ModelState.IsValid)
            {
                model.MatKhau = GetMD5(model.MatKhau);
                model.IsActive = true;
                model.IsQuanTriVien =false;
                model.CreateDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                db.tb_NhanVien.Add(model);
                db.SaveChanges();

                return RedirectToAction("Admin");
            }
            return View(model);
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
        public ActionResult EditAdmin(int id)
        {
            var item = db.tb_NhanVien.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(tb_NhanVien model)
        {
            if (ModelState.IsValid)
            {
                db.tb_NhanVien.Attach(model);
                model.UpdatedDate = DateTime.Now;
                db.Entry(model).Property(x => x.TenNhanVien).IsModified = true;
                db.Entry(model).Property(x => x.TaiKhoan).IsModified = true;
                db.Entry(model).Property(x => x.MatKhau).IsModified = true;
                db.Entry(model).Property(x => x.Email).IsModified = true;
                db.Entry(model).Property(x => x.Phone).IsModified = true;
                db.Entry(model).Property(x => x.Address).IsModified = true;
                db.Entry(model).Property(x => x.GioiTinh).IsModified = true;
                db.Entry(model).Property(x => x.NgaySinh).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedBy).IsModified = true;
                db.SaveChanges();

                return RedirectToAction("Admin");
            }
            return View(model);
        }
        public ActionResult DeleteAdmin(int id)
        {
            var item = db.tb_NhanVien.Find(id);
            if(item.IsQuanTriVien==true)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                db.tb_NhanVien.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
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