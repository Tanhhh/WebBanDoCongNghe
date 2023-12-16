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
    public class OrderCustomerController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: Admin/OrderCustomer
        public ActionResult IndexOrderCustomer()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("IndexLoginAdmin", "LoginAdmin");
            }
            return View();
        }
        public ActionResult OrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsHoanThanh == false && n.IsHuyDon == false && n.IsXacNhan == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult OrderCustomerDetail(int id)
        {

            var item = db.tb_Order.Find(id);
            return View(item);
        }
        public ActionResult Partial_OrderCustomerDetail(int id)
        {
            var item = db.tb_ChiTietOrder.Where(x => x.MaDonHang == id).ToList();
            return PartialView(item);
        }
        public ActionResult ConfirmOrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsXacNhan == true && n.IsHoanThanh == false && n.IsHuyDon == false && n.IsDongGoi == false && n.IsVanChuyen == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult PakageOrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsDongGoi == true && n.IsHoanThanh == false && n.IsHuyDon == false && n.IsVanChuyen == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult TransportOrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsVanChuyen == true && n.IsHoanThanh == false && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult CompleteOrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var item = db.tb_Order.OrderByDescending(n => n.CreateDate).Where(n => n.IsHoanThanh == true && n.IsXacNhan == true && n.IsThanhToan == true && n.IsHuyDon == false).ToPagedList(pageNumber, pageSize);
            return PartialView(item);
        }
        public ActionResult CancelOrderCustomer(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            var item = db.tb_Order
                .OrderByDescending(n => n.CreateDate)
                .Where(n => n.IsHuyDon == true && n.IsHoanThanh == false)
                .ToPagedList(pageNumber, pageSize);

            return PartialView(item);
        }
        public ActionResult EditOrderCustomer(int id)
        {
            var item = db.tb_Order.Find(id);
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
        public ActionResult EditOrderCustomer(tb_Order model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra điều kiện để đảm bảo không xảy ra trường hợp cả Hoàn thành và Hủy đơn cùng được chọn
                    if (model.IsHoanThanh == true && model.IsHuyDon == true)
                    {
                        TempData["ErrorMessage"] = "Không thể chọn cả Hoàn thành và Hủy đơn cùng một lúc.";
                        return RedirectToAction("EditOrderCustomer", new { id = model.MaDonHang });
                    }
                    if (model.IsHoanThanh == true && model.IsThanhToan == false)
                    {
                        TempData["ErrorMessage"] = "Chưa thanh toán không thể hoàn thành.";
                        return RedirectToAction("EditOrderCustomer", new { id = model.MaDonHang });
                    }
                    if (model.IsHoanThanh == true && model.IsXacNhan == false)
                    {
                        TempData["ErrorMessage"] = "Chưa xác nhận không thể hoàn thành.";
                        return RedirectToAction("EditOrderCustomer", new { id = model.MaDonHang });
                    }
                    var userInfo = Session["admin"] as tb_NhanVien;

                    if (userInfo != null)
                    {
                        model.MaNhanVien = userInfo.MaNhanVien;
                    }

                    // Gán ngày cập nhật
                    model.UpdatedDate = DateTime.Now;

                    // Cập nhật các thuộc tính chỉ khi có sự thay đổi
                    db.tb_Order.Attach(model);
                    db.Entry(model).State = EntityState.Modified;

                    if (model.IsXacNhan == true && model.IsDongGoi == false && model.IsHuyDon == false)
                    {
                        if (KiemTraSoLuongSanPham(model.MaDonHang))
                        {
                            model.TrangThai = "Đã xác nhận";
                            CapNhatSoLuongSanPhamSauXacNhanDonHang(model.MaDonHang);
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Sản phẩm trong kho không đủ, vui lòng kiểm tra !";
                            return RedirectToAction("EditOrderCustomer", new { id = model.MaDonHang });
                        }
                    }
                    else if (model.IsDongGoi == true && model.IsXacNhan == true && model.IsVanChuyen == false)
                    {
                        model.TrangThai = "Đã đóng gói"; // Đặt trạng thái khi đơn hàng đã đóng gói
                    }
                    else if (model.IsDongGoi == true && model.IsVanChuyen == true && model.IsHoanThanh == false)
                    {
                        model.TrangThai = "Đang vận chuyển"; // Đặt trạng thái khi đơn hàng đã đóng gói 
                    }
                    else if (model.IsHoanThanh == true && model.IsXacNhan == true && model.IsThanhToan == true && model.IsDongGoi == true && model.IsVanChuyen == true)
                    {
                        model.TrangThai = "Hoàn thành"; // Đặt trạng thái khi đơn hàng đã hoàn thành
                        model.IsNhanDiem = false;

                    }
                    else if (model.IsHuyDon == true)
                    {
                        if (model.IsXacNhan == true)
                        {
                            HoanTraSanPham(model.MaDonHang);
                            model.TrangThai = "Đã hủy"; // Đặt trạng thái khi đơn hàng bị hủy

                        }
                        // Nếu đơn hàng bị hủy, trừ điểm tích lũy tương ứng
                        tb_Customer customer = db.tb_Customer.Find(model.MaKH);

                        // Lấy thông tin điểm tích lũy của khách hàng
                        tb_TichDiem tichDiem = db.tb_TichDiem.Where(x => x.MaKH == customer.MaKH).FirstOrDefault();

                        if (tichDiem != null)
                        {
                            // Trừ điểm tích lũy dựa trên tổng giá trị hóa đơn
                            int diemTru = (int)(model.TotalPayment / 5000000); // 1 điểm cho mỗi 5000 đồng

                            // Giảm điểm tích lũy của khách hàng
                            tichDiem.TongSoDiem -= diemTru;
                            tichDiem.UpdatedDate = DateTime.Now;
                            db.Entry(tichDiem).State = EntityState.Modified;
                            model.TrangThai = "Đã hủy"; // Đặt trạng thái khi đơn hàng bị hủy
                        }
                    }
                    else
                    {
                        model.TrangThai = "Chờ xác nhận"; // Trạng thái mặc định

                    }

                    // Cập nhật các thông tin
                    db.Entry(model).Property(x => x.IsXacNhan).IsModified = true;
                    db.Entry(model).Property(x => x.IsDongGoi).IsModified = true;
                    db.Entry(model).Property(x => x.IsVanChuyen).IsModified = true;
                    db.Entry(model).Property(x => x.IsThanhToan).IsModified = true;
                    db.Entry(model).Property(x => x.IsHoanThanh).IsModified = true;
                    db.Entry(model).Property(x => x.IsHuyDon).IsModified = true;
                    db.Entry(model).Property(x => x.UpdatedDate).IsModified = true;
                    db.Entry(model).Property(x => x.TrangThai).IsModified = true;
                    db.Entry(model).Property(x => x.MaNhanVien).IsModified = true;
                    db.Entry(model).Property(x => x.MaKH).IsModified = true;

                    db.SaveChanges();
                    return RedirectToAction("IndexOrderCustomer");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception occurred in EditOrderCustomer action: {ex}");
                TempData["ErrorMessage"] = $"Có lỗi xảy ra trong quá trình cập nhật đơn hàng. Chi tiết: {ex.Message}";
            }

            // Trả về view với model nếu có lỗi
            return View(model);
        }
        private bool KiemTraSoLuongSanPham(int maDonHang)
        {
            var orderDetails = db.tb_ChiTietOrder.Where(od => od.MaDonHang == maDonHang).ToList();

            foreach (var orderDetail in orderDetails)
            {
                var product = db.tb_Product.Find(orderDetail.MaSanPham);

                if (product != null && orderDetail.Quantity > product.Quantity)
                {
                    // Nếu số lượng đặt hàng lớn hơn số lượng tồn kho, trả về false
                    TempData["ErrorMessage"] = $"Sản phẩm {product.TenSanPham} không đủ số lượng tồn kho.";
                    return false;
                }
            }

            // Nếu số lượng đặt hàng hợp lệ, trả về true
            return true;
        }

        private void CapNhatSoLuongSanPhamSauXacNhanDonHang(int maDonHang)
        {
            var chiTietDonHangs = db.tb_ChiTietOrder.Where(x => x.MaDonHang == maDonHang).ToList();

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
                    RedirectToAction("EditOrderCustomer", new { id = maDonHang });
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
        }
        private void HoanTraSanPham(int maDonHang)
        {
            var chiTietDonHangs = db.tb_ChiTietOrder.Where(x => x.MaDonHang == maDonHang).ToList();

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
                    RedirectToAction("EditOrderCustomer", new { id = maDonHang });
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
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
                        var order = db.tb_Order.Find(orderId);

                        if (order != null)
                        {
                            // Lấy chi tiết đặt hàng của đơn hàng
                            var orderDetails = db.tb_ChiTietOrder.Where(od => od.MaDonHang == orderId).ToList();

                            // Xóa chi tiết đặt hàng
                            foreach (var orderDetail in orderDetails)
                            {
                                db.tb_ChiTietOrder.Remove(orderDetail);
                            }

                            // Xóa đơn hàng
                            db.tb_Order.Remove(order);

                            db.SaveChanges();
                        }
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
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