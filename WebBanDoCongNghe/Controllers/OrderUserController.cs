using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class OrderUserController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: OrderUser
        public ActionResult IndexOrderUser()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            return View();
        }
        public ActionResult OrderUser(int? page)
        {
            if (Session["MaKH"] != null)
            {
                var discountCode = (tb_CustomerCode)Session["discount"];

                if (discountCode != null)
                {
                    ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;
                }   
                tb_Customer customer = (tb_Customer)Session["taikhoan"];
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.MaKH == customer.MaKH && n.IsHoanThanh == false && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);

                return PartialView(item);
            }
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatDiemCong(int orderId)
        {
            var orderToAdd = db.tb_Order.Find(orderId);
            int soDiemTang = (int)(orderToAdd.TotalPayment / 5000000);

            // Kiểm tra xem đơn hàng đã nhận điểm hay chưa
            if (orderToAdd.IsNhanDiem == false)
            {
                var customer = db.tb_Customer.Find(orderToAdd.MaKH);
                if (customer != null)
                {
                    var tichDiem = db.tb_TichDiem.Where(x => x.MaKH == customer.MaKH).FirstOrDefault();

                    if (tichDiem != null)
                    {
                        tichDiem.SoDiemCongGanNhat = soDiemTang;
                        tichDiem.TongSoDiem += soDiemTang;
                        tichDiem.UpdatedDate = DateTime.Now;
                        db.Entry(tichDiem).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        tichDiem = new tb_TichDiem
                        {
                            SoDiemCongGanNhat = soDiemTang,
                            TongSoDiem = soDiemTang,
                            CreateDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            MaKH = customer.MaKH
                        };
                        db.tb_TichDiem.Add(tichDiem);
                        db.SaveChanges();
                    }

                    // Cập nhật trạng thái đã nhận điểm
                    orderToAdd.IsNhanDiem = true;
                    db.Entry(orderToAdd).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "Tích điểm thành công", soDiemTang = soDiemTang });
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                // Đã nhận điểm, trả về thông báo hoặc xử lý khác nếu cần
                return Json(new { success = false, message = "Đơn hàng đã nhận điểm trước đó" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessCancelOrder(int orderId, string cancelReason)
        {
            try
            {
                var orderToCancel = db.tb_Order.Find(orderId);

                if (orderToCancel != null && orderToCancel.CreateDate >= DateTime.Now.Date.AddDays(-1))
                {
                    // Kiểm tra xem trạng thái có phải là "Chưa xác nhận" không
                    if (string.Equals(orderToCancel.TrangThai, "Chờ xác nhận", StringComparison.OrdinalIgnoreCase))
                    {
                        orderToCancel.IsHuyDon = true;

                        // Lưu lý do hủy đơn vào cơ sở dữ liệu
                        orderToCancel.LyDoHuyDon = cancelReason;

                        // Kiểm tra xem ngày hủy đơn đã được cập nhật hay chưa
                        if (orderToCancel.UpdatedDate == null)
                        {
                            orderToCancel.UpdatedDate = DateTime.Now;
                            orderToCancel.TrangThai = "Đã hủy";

                            // Cập nhật đối tượng trong cơ sở dữ liệu
                            db.Entry(orderToCancel).State = EntityState.Modified;

                            // Lưu thay đổi vào cơ sở dữ liệu
                            db.SaveChanges();

                            return Json(new { success = true, message = "Đơn hàng đã được hủy thành công" });
                        }
                    }
                    else
                    {
                        // Trạng thái không phải là "Chưa xác nhận", không thể hủy đơn
                        return Json(new { success = false, message = "Đơn hàng đã xác nhận không thể hủy" });
                    }
                }

                // Trả về một phản hồi không thành công nếu không thể hủy đơn hàng
                return Json(new { success = false, message = "Đã qua thời hạn hủy đơn hàng" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }

        public ActionResult OrderUserDetail(int id)
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var discountCode = (tb_CustomerCode)Session["discount"];

                if (discountCode != null)
                {
                    ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;
                }
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
         

            var item = db.tb_Order.Find(id);
            return View(item);
        }
        public ActionResult Partial_OrderUserDetail(int id)
        {
            var item = db.tb_ChiTietOrder.Where(x => x.MaDonHang == id).ToList();
            return PartialView(item);
        }
        public ActionResult Partial_SoTaiKhoan()
        {
            var item = db.tb_TaiKhoanNganHang.OrderBy(n => n.MaSoTaiKhoan).ToList();
            return PartialView(item);
        }
        public ActionResult CompleteOrderUser(int? page)
        {
            if (Session["MaKH"] != null)
            {
                tb_Customer customer = (tb_Customer)Session["taikhoan"];
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.MaKH == customer.MaKH && n.IsHoanThanh == true && n.IsXacNhan == true && n.IsThanhToan == true && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);
                return PartialView(item);
            }
            return PartialView();
        }
        public ActionResult CancelOrderUser(int? page)
        {
            if (Session["MaKH"] != null)
            {
                tb_Customer customer = (tb_Customer)Session["taikhoan"];
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsHuyDon == true && n.IsHoanThanh == false).ToPagedList(pageNumber, pageSize);
                return PartialView(item);
            }
            return PartialView();

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