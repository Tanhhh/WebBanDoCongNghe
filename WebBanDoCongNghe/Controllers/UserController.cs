using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class UserController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: User
        public ActionResult IndexUser()
        {
            if (Session["MaKH"] != null)
            {
                tb_Customer customer = (tb_Customer)Session["taikhoan"];
                var item = db.tb_Customer.FirstOrDefault(x => x.MaKH == customer.MaKH);

                Session["taikhoan"] = customer;

                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;

                return View(item);
            }
            return View();
        }
        public ActionResult EditUser(int id)
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            var item = db.tb_Customer.Find(id);
            return View(item);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(tb_Customer model, HttpPostedFileBase ImageUser)
        {
            // Lấy thông tin khách hàng từ cơ sở dữ liệu để có đường dẫn ảnh hiện tại
            tb_Customer existingCustomer = db.tb_Customer.Find(model.MaKH);

            // Kiểm tra xem đã chọn ảnh mới chưa
            if (ImageUser != null)
            {
                //lấy file name trước 
                string pic = System.IO.Path.GetFileName(ImageUser.FileName);

                //đường dẫn đến file 
                string _path = Path.Combine(Server.MapPath("~/Uploads/images_users"), pic);

                ImageUser.SaveAs(_path);

                // Lưu đường dẫn ảnh mới
                existingCustomer.ImageUser = pic;
            }

            // Cập nhật thông tin khác
            existingCustomer.HoTen = model.HoTen;
            existingCustomer.Email = model.Email;
            existingCustomer.Phone = model.Phone;
            existingCustomer.Address = model.Address;
            existingCustomer.GioiTinh = model.GioiTinh;
            existingCustomer.NgaySinh = model.NgaySinh;
            existingCustomer.UpdatedDate = DateTime.Now;

            // Cập nhật thông tin trong cơ sở dữ liệu
            db.Entry(existingCustomer).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("EditUser");
        }

        [HttpPost]
        public ActionResult UpdateImage(HttpPostedFileBase ImageUser)
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];

            tb_Customer existingCustomer = db.tb_Customer.FirstOrDefault(x => x.MaKH == customer.MaKH);

            // Kiểm tra xem đã chọn ảnh mới chưa
            if (ImageUser != null)
            {
                // Kiểm tra xem file cũ có tồn tại không trước khi xóa
                if (!string.IsNullOrEmpty(customer.ImageUser))
                {
                    string imgxoafilecu = Server.MapPath("~/Uploads/images_users/" + customer.ImageUser);

                    if (System.IO.File.Exists(imgxoafilecu))
                    {
                        System.IO.File.Delete(imgxoafilecu);
                    }
                }

                //lấy file name trước 
                string pic = System.IO.Path.GetFileName(ImageUser.FileName);

                //đường dẫn đến file 
                string _path = Path.Combine(Server.MapPath("~/Uploads/images_users"), pic);

                ImageUser.SaveAs(_path);

                // Lưu đường dẫn ảnh mới
                existingCustomer.ImageUser = pic;

                // Cập nhật thông tin trong cơ sở dữ liệu
                db.Entry(existingCustomer).State = EntityState.Modified;
                db.SaveChanges();

                Session["Images"] = pic;
                Session["taikhoan"] = customer;
                return Content("<script language='javascript' type='text/javascript'>alert('Ảnh đã được cập nhật thành công');window.location = '/User/IndexUser';</script>");
            }

            return RedirectToAction("IndexUser");
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