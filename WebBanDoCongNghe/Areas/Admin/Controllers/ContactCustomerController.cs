using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{
    public class ContactCustomerController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();

        // GET: Admin/LienHe
        public ActionResult IndexContactCustomer()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }
        public ActionResult ContactCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Contact.OrderByDescending(n => n.CreateDate).Where(n => n.IsXuLy == false && n.MaKH != null).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult ContactCustomerDetail(int id)
        {

            var item = db.tb_Contact.Find(id);
            return View(item);
        }

        public ActionResult CompleteContactCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Contact.OrderByDescending(n => n.CreateDate).Where(n => n.IsXuLy == true && n.MaKH != null).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult EditContactCustomer(int id)
        {
            var item = db.tb_Contact.Find(id);
            var userInfo = Session["admin"] as tb_NhanVien;
            if (userInfo != null)
            {
                var maNhanVien = userInfo.MaNhanVien; // Lấy MaNhanVien của nhân viên đăng nhập
                ViewBag.MaNhanVien = maNhanVien;
                ViewBag.HoTenNhanVien = userInfo.TenNhanVien;
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContactCustomer(tb_Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var userInfo = Session["admin"] as tb_NhanVien;

                    if (userInfo != null)
                    {
                        model.MaNhanVien = userInfo.MaNhanVien;
                    }

                    // Gán ngày cập nhật
                    model.UpdatedDate = DateTime.Now;

                    // Cập nhật các thuộc tính chỉ khi có sự thay đổi
                    db.tb_Contact.Attach(model);
                    db.Entry(model).State = EntityState.Modified;




                    // Cập nhật các thông tin
                    db.Entry(model).Property(x => x.IsXuLy).IsModified = true;
                    db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                    db.Entry(model).Property(x => x.MaNhanVien).IsModified = true;
                    db.Entry(model).Property(x => x.MaKH).IsModified = true;

                    db.SaveChanges();
                    return RedirectToAction("IndexContactCustomer");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception occurred in EditOrderCustomer action: {ex}");
                TempData["ErrorMessage"] = $"Có lỗi xảy ra trong quá trình cập nhật liên hệ. Chi tiết: {ex.Message}";
            }

            // Trả về view với model nếu có lỗi
            return View(model);

        }
    }
}