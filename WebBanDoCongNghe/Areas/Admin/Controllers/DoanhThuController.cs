using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;
using System.Data.Entity;
using PagedList;

namespace WebBanDoCongNghe.Areas.Admin.Controllers
{

    public class DoanhThuController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();


        public ActionResult DoanhThuCustomer(DateTime? fromDate, DateTime? toDate, int? employeeId, int? page, string customerUsername, string paymentMethodName)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (!fromDate.HasValue)
            {
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            if (!toDate.HasValue)
            {
                toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }

            var employeeList = db.tb_NhanVien.ToList();
            ViewBag.EmployeeList = new SelectList(employeeList, "MaNhanVien", "TenNhanVien");

            var completedOrders = db.tb_Order.Include(o => o.tb_NhanVien)
                .Where(o => o.UpdatedDate >= fromDate && o.UpdatedDate <= toDate && o.IsHoanThanh == true);

            if (employeeId.HasValue)
            {
                completedOrders = completedOrders.Where(o => o.tb_NhanVien.MaNhanVien == employeeId.Value);
            }

            if (!string.IsNullOrEmpty(customerUsername))
            {
                completedOrders = completedOrders.Where(o => o.tb_Customer.TaiKhoan == customerUsername);
            }

            // Lọc theo tên phương thức thanh toán
            if (!string.IsNullOrEmpty(paymentMethodName))
            {
                var orderIdsWithPaymentMethod = db.tb_Order
                    .Where(ptt => ptt.tb_PhuongThucThanhToan.TenPhuongThucThanhToan.Contains(paymentMethodName))
                    .Select(ptt => ptt.MaDonHang);

                completedOrders = completedOrders.Where(o => orderIdsWithPaymentMethod.Contains(o.MaDonHang));
            }

            var ordersList = completedOrders.ToList();

            decimal totalRevenue = ordersList.Sum(o => Convert.ToDecimal(o.TotalPayment));
            string formattedTotalRevenue = totalRevenue.ToString("N0");

            var dailyRevenue = ordersList.GroupBy(o => o.UpdatedDate.HasValue ? o.UpdatedDate.Value.Date : (DateTime?)null).Select(group => new
            {
                Date = group.Key,
                Revenue = group.Sum(o => Convert.ToDecimal(o.TotalPayment))
            }).OrderBy(x => x.Date).ToList();

            var ordersPagedList = ordersList.ToPagedList(pageNumber, pageSize);

            ViewBag.DailyRevenue = dailyRevenue;
            ViewBag.FromDate = fromDate.Value;
            ViewBag.ToDate = toDate.Value;
            ViewBag.FormattedTotalRevenue = formattedTotalRevenue;

            return View(ordersPagedList);
        }
        public ActionResult DoanhThuTraveler(DateTime? fromDate, DateTime? toDate, int? employeeId, string phoneCus, int? page, string paymentMethodName)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            if (!fromDate.HasValue)
            {
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            if (!toDate.HasValue)
            {
                toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }

            var employeeList = db.tb_NhanVien.ToList();
            ViewBag.EmployeeList = new SelectList(employeeList, "MaNhanVien", "TenNhanVien");

            var completedOrders = db.tb_Traveler.Include(o => o.tb_NhanVien)
                .Where(o => o.UpdatedDate >= fromDate && o.UpdatedDate <= toDate && o.IsHoanThanh == true);

            if (employeeId.HasValue)
            {
                completedOrders = completedOrders.Where(o => o.tb_NhanVien.MaNhanVien == employeeId.Value);
            }

            if (!string.IsNullOrEmpty(phoneCus))
            {
                completedOrders = completedOrders.Where(o => o.PhoneNumber1.Contains(phoneCus));
            }
            // Lọc theo tên phương thức thanh toán
            if (!string.IsNullOrEmpty(paymentMethodName))
            {
                var orderIdsWithPaymentMethod = db.tb_Traveler
                    .Where(ptt => ptt.tb_PhuongThucThanhToan.TenPhuongThucThanhToan.Contains(paymentMethodName))
                    .Select(ptt => ptt.MaDonHang);

                completedOrders = completedOrders.Where(o => orderIdsWithPaymentMethod.Contains(o.MaDonHang));
            }
            var ordersList = completedOrders.ToList();
            decimal totalRevenue = ordersList.Sum(o => Convert.ToDecimal(o.TotalPayment));
            string formattedTotalRevenue = totalRevenue.ToString("N0");

            var dailyRevenue = ordersList.GroupBy(o => o.UpdatedDate.HasValue ? o.UpdatedDate.Value.Date : (DateTime?)null).Select(group => new
            {
                Date = group.Key,
                Revenue = group.Sum(o => Convert.ToDecimal(o.TotalPayment))
            }).OrderBy(x => x.Date).ToList();

            var ordersPagedList = ordersList.ToPagedList(pageNumber, pageSize);

            ViewBag.DailyRevenue = dailyRevenue;
            ViewBag.FromDate = fromDate.Value;
            ViewBag.ToDate = toDate.Value;
            ViewBag.FormattedTotalRevenue = formattedTotalRevenue;

            return View(ordersPagedList);
        }
    }
}