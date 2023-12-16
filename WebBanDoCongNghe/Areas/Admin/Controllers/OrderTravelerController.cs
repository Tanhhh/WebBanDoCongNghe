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
    public class OrderTravelerController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();

        public ActionResult IndexOrderTraveler()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }
        public ActionResult OrderTraveler(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Traveler.OrderByDescending(n => n.CreateDate).Where(n => n.IsHoanThanh == false && n.IsHuyDon == false && n.IsXacNhan == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult OrderTravelerDetail(int id)
        {
            var item = db.tb_Traveler.Find(id);
            if (item == null)
            {
                // Xử lý trường hợp không tìm thấy đơn hàng
                return HttpNotFound();
            }
            return View(item);
        }
        public ActionResult Partial_OrderTravelerDetail(int id)
        {
            var item = db.tb_ChiTietOrder_Traveler.Where(x => x.MaDonHang == id).ToList();
            return PartialView(item);
        }
     
    public ActionResult ConfirmOrderTraveler(int? page)
    {
        int pageNumber = (page ?? 1);
        int pageSize = 5;
        var item = db.tb_Traveler.OrderByDescending(n => n.CreateDate).Where(n => n.IsXacNhan == true && n.IsHoanThanh == false && n.IsHuyDon == false && n.IsDongGoi == false && n.IsVanChuyen == false).ToPagedList(pageNumber, pageSize);
        return PartialView(item);
    }
    public ActionResult PakageOrderTraveler(int? page)
    {
        int pageNumber = (page ?? 1);
        int pageSize = 5;
        var item = db.tb_Traveler.OrderByDescending(n => n.CreateDate).Where(n => n.IsDongGoi == true && n.IsHoanThanh == false && n.IsHuyDon == false && n.IsVanChuyen == false).ToPagedList(pageNumber, pageSize);
        return PartialView(item);
    }
    public ActionResult TransportOrderTraveler(int? page)
    {
        int pageNumber = (page ?? 1);
        int pageSize = 5;
        var item = db.tb_Traveler.OrderByDescending(n => n.CreateDate).Where(n => n.IsVanChuyen == true && n.IsHoanThanh == false && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);
        return PartialView(item);
    }
    public ActionResult CompleteOrderTraveler(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Traveler.OrderByDescending(n => n.CreateDate).Where(n => n.IsHoanThanh == true && n.IsXacNhan == true && n.IsThanhToan == true && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }

        public ActionResult CancelOrderTraveler(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            var item = db.tb_Traveler
                .OrderByDescending(n => n.CreateDate)
                .Where(n => n.IsHuyDon == true && n.IsHoanThanh == false)
                .ToPagedList(pageNumber, pageSize);
            return PartialView(item);

        }
        public ActionResult EditOrderTraveler(int id)
        {
            var item = db.tb_Traveler.Find(id);
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
        public ActionResult EditOrderTraveler(tb_Traveler model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Kiểm tra điều kiện để đảm bảo không xảy ra trường hợp cả Hoàn thành và Hủy đơn cùng được chọn
                    if (model.IsHoanThanh == true && model.IsHuyDon == true)
                    {
                        TempData["ErrorMessage"] = "Không thể chọn cả Hoàn thành và Hủy đơn cùng một lúc.";
                        return RedirectToAction("EditOrderTraveler", new { id = model.MaDonHang });
                    }

                    if (model.IsHoanThanh == true && model.IsThanhToan == false)
                    {
                        TempData["ErrorMessage"] = "Chưa thanh toán không thể hoàn thành.";
                        return RedirectToAction("EditOrderTraveler", new { id = model.MaDonHang });
                    }
                    if (model.IsHoanThanh == true && model.IsXacNhan == false)
                    {
                        TempData["ErrorMessage"] = "Chưa xác nhận không thể hoàn thành.";
                        return RedirectToAction("EditOrderTraveler", new { id = model.MaDonHang });
                    }
                    var userInfo = Session["admin"] as tb_NhanVien;

                    if (userInfo != null)
                    {
                        model.MaNhanVien = userInfo.MaNhanVien;
                    }
                    model.UpdatedDate = DateTime.Now;
                    db.tb_Traveler.Attach(model);
                    db.Entry(model).State = EntityState.Modified;

                    if (model.IsXacNhan == true && model.IsDongGoi == false && model.IsHuyDon == false)
                    {
                        // Nếu đơn hàng được xác nhận hoặc cả xác nhận và thanh toán, đánh dấu trạng thái là "Đang giao hàng"
                        model.TrangThaiDon = "Đã xác nhận";
                        CapNhatSoLuongSanPhamSauXacNhanDonHang(model.MaDonHang);
                    }
                    else if (model.IsDongGoi == true && model.IsXacNhan == true && model.IsVanChuyen == false)
                    {
                        model.TrangThaiDon = "Đã đóng gói"; // Đặt trạng thái khi đơn hàng đã đóng gói
                    }

                    else if (model.IsDongGoi == true && model.IsVanChuyen == true && model.IsHoanThanh == false)
                    {
                        model.TrangThaiDon = "Đang vận chuyển"; // Đặt trạng thái khi đơn hàng đã đóng gói 
                    }
                    else if (model.IsHoanThanh == true && model.IsXacNhan == true && model.IsThanhToan == true && model.IsDongGoi == true && model.IsVanChuyen == true)
                    {
                        model.TrangThaiDon = "Hoàn thành"; // Đặt trạng thái khi đơn hàng đã hoàn thành
                    }
                    else if (model.IsHuyDon == true)
                    {
                        if (model.IsXacNhan == true)
                        {
                            HoanTraSanPham(model.MaDonHang);
                            model.TrangThaiDon = "Đã hủy"; // Đặt trạng thái khi đơn hàng bị hủy

                        }
                        model.TrangThaiDon = "Đã hủy"; // Đặt trạng thái khi đơn hàng bị hủy
                    }
                    else
                    {
                        model.TrangThaiDon = "Chờ xác nhận"; // Trạng thái mặc định
                    }

                    // Cập nhật các thông tin
                    db.Entry(model).Property(x => x.IsXacNhan).IsModified = true;
                    db.Entry(model).Property(x => x.IsVanChuyen).IsModified = true;
                    db.Entry(model).Property(x => x.IsDongGoi).IsModified = true;
                    db.Entry(model).Property(x => x.IsThanhToan).IsModified = true;
                    db.Entry(model).Property(x => x.IsHoanThanh).IsModified = true;
                    db.Entry(model).Property(x => x.IsHuyDon).IsModified = true;
                    db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                    db.Entry(model).Property(x => x.TrangThaiDon).IsModified = true;
                    db.Entry(model).Property(x => x.MaNhanVien).IsModified = true;

                    db.SaveChanges();

                    return RedirectToAction("IndexOrderTraveler");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi log
                System.Diagnostics.Debug.WriteLine($"Exception occurred in EditOrderTraveler action: {ex}");
                TempData["ErrorMessage"] = "Có lỗi xảy ra trong quá trình cập nhật đơn hàng.";
            }

            // Trả về view với model nếu có lỗi
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteAllProduct(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        int orderId = Convert.ToInt32(item);

                        // Lấy đơn hàng
                        var order = db.tb_Traveler.Find(orderId);

                        if (order != null)
                        {
                            // Lấy chi tiết đặt hàng của đơn hàng
                            var orderDetails = db.tb_ChiTietOrder_Traveler.Where(od => od.MaDonHang == orderId).ToList();

                            // Xóa chi tiết đặt hàng
                            foreach (var orderDetail in orderDetails)
                            {
                                db.tb_ChiTietOrder_Traveler.Remove(orderDetail);
                            }

                            // Xóa đơn hàng
                            db.tb_Traveler.Remove(order);

                            db.SaveChanges();
                        }
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        private void CapNhatSoLuongSanPhamSauXacNhanDonHang(int maDonHang)
        {
            var chiTietDonHangs = db.tb_ChiTietOrder_Traveler.Where(x => x.MaDonHang == maDonHang).ToList();

            foreach (var chiTietDonHang in chiTietDonHangs)
            {
                // Lấy thông tin sản phẩm tương ứng
                var sanPham = db.tb_Product.Find(chiTietDonHang.MaSanPham);

                // Kiểm tra xem sản phẩm có tồn tại và có đủ số lượng không
                if (sanPham != null && sanPham.Quantity >= chiTietDonHang.Quantity)
                {
                    // Trừ số lượng đã đặt mua từ số lượng tồn kho
                    //db.Entry(sanPham).Property(x => x.Quantity).CurrentValue -= chiTietDonHang.Quantity;
                    sanPham.Quantity -= chiTietDonHang.Quantity;

                    // Cập nhật thông tin sản phẩm trong cơ sở dữ liệu
                    db.Entry(sanPham).State = EntityState.Modified;
                }
                else
                {
                    // Xử lý trường hợp sản phẩm không tìm thấy hoặc có số lượng không đủ
                    TempData["ErrorMessage"] = "Lỗi cập nhật số lượng sản phẩm. Vui lòng kiểm tra sự có sẵn của sản phẩm.";
                    RedirectToAction("EditOrderTraveler", new { id = maDonHang });
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
        }
        private void HoanTraSanPham(int maDonHang)
        {
            var chiTietDonHangs = db.tb_ChiTietOrder_Traveler.Where(x => x.MaDonHang == maDonHang).ToList();

            foreach (var chiTietDonHang in chiTietDonHangs)
            {
                // Lấy thông tin sản phẩm tương ứng
                var sanPham = db.tb_Product.Find(chiTietDonHang.MaSanPham);

                // Kiểm tra xem sản phẩm có tồn tại
                if (sanPham != null)
                {
                    // Trừ số lượng đã đặt mua từ số lượng tồn kho
                    //db.Entry(sanPham).Property(x => x.Quantity).CurrentValue -= chiTietDonHang.Quantity;
                    sanPham.Quantity += chiTietDonHang.Quantity;

                    // Cập nhật thông tin sản phẩm trong cơ sở dữ liệu
                    db.Entry(sanPham).State = EntityState.Modified;
                }
                else
                {
                    // Xử lý trường hợp sản phẩm không tìm thấy hoặc có số lượng không đủ
                    TempData["ErrorMessage"] = "Lỗi cập nhật số lượng sản phẩm. Vui lòng kiểm tra sự có sẵn của sản phẩm.";
                    RedirectToAction("EditOrderTraveler", new { id = maDonHang });
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
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