using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class CustomerDiscountController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        public ActionResult IndexCustomerCode(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            tb_Customer customer = (tb_Customer)Session["taikhoan"];

            // Kiểm tra nếu user là null
            if (customer == null)
            {
                ViewBag.ErrorMessage = "Chưa đăng nhập. Vui lòng đăng nhập để xem thông tin.";
                return RedirectToAction("Login", "Login");
            }

            // Nếu user không null, tiếp tục thực hiện các công việc khác
            var discountCodes = db.tb_DiscountCode
       .Where(dc => dc.IsActive == true && dc.Quantity > 0 &&
                    (!db.tb_CustomerCode.Any(cc => cc.MaDiscount == dc.MaDiscount && cc.MaKH == customer.MaKH && cc.IsSuDung == false) ||
                     !db.tb_CustomerCode.Any(cc => cc.MaDiscount == dc.MaDiscount && cc.MaKH == customer.MaKH)))
       .ToList()
       .ToPagedList(pageNumber, pageSize);
            var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
            ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;


            ViewBag.MaKhachHang = customer.MaKH;
            return View(discountCodes);
        }
        [HttpPost]
        public ActionResult RedeemDiscountCode()
        {
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            string maKhuyenMai = Request.Form["MaKhuyenMai"];

            var discountCode = db.tb_DiscountCode.SingleOrDefault(dc => dc.DiscountCode == maKhuyenMai);

            if (customer != null && discountCode != null && discountCode.IsActive.GetValueOrDefault() && discountCode.Quantity.GetValueOrDefault() > 0)
            {
                // Giảm số điểm còn lại của tb_DiscountCode
                discountCode.Quantity--;
                if (discountCode.Quantity == 0)
                {
                    discountCode.IsActive = false;
                }

                // Truy vấn thông tin điểm tích lũy của khách hàng từ cơ sở dữ liệu
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                if (tichDiem != null)
                {
                    // Kiểm tra xem có đủ điểm để đổi mã không
                    int soDiemCanDoi = discountCode.SoDiemCanDoi ?? 0;
                    if (tichDiem.TongSoDiem >= soDiemCanDoi && (tichDiem.TongSoDiem - soDiemCanDoi) >= 0)
                    {
                        // Giảm TongSoDiem trong tb_TichDiem
                        tichDiem.TongSoDiem -= soDiemCanDoi;
                        tichDiem.UpdatedDate = DateTime.Now;
                        tichDiem.MaDiscount = discountCode.MaDiscount;

                        var redeemedCode = new tb_CustomerCode
                        {
                            MaKH = customer.MaKH,
                            MaDiscount = discountCode.MaDiscount,
                            CreatedDate = DateTime.Now,
                            UseDate = null,
                            IsSuDung = false
                        };

                        // Bước 7: Lưu các thay đổi vào cơ sở dữ liệu
                        db.tb_CustomerCode.Add(redeemedCode);
                        db.Entry(tichDiem).State = EntityState.Modified;
                        db.Entry(discountCode).State = EntityState.Modified;
                        db.SaveChanges();

                        return RedirectToAction("IndexCustomerCode", "CustomerDiscount");
                    }
                    else
                    {
                        // Xử lý trường hợp không đủ điểm để đổi mã
                        ModelState.AddModelError("", "Điểm không đủ để đổi.");
                    }
                }
                else
                {
                    // Xử lý trường hợp thông tin điểm của khách hàng không tồn tại
                    ModelState.AddModelError("", "Không tìm thấy thông tin của khách hàng.");
                }
            }

            return RedirectToAction("IndexCustomerCode", "CustomerDiscount");
        }

        public ActionResult MyVoucher(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            tb_Customer customer = (tb_Customer)Session["taikhoan"];

            // Kiểm tra nếu user là null
            if (customer == null)
            {
                ViewBag.ErrorMessage = "Chưa đăng nhập. Vui lòng đăng nhập để xem thông tin.";
                return RedirectToAction("Login", "Login");
            }

            // Nếu user không null, tiếp tục thực hiện các công việc khác
            var discountCodes = db.tb_CustomerCode.Where(dc => dc.IsSuDung == false && dc.MaKH == customer.MaKH).ToList().ToPagedList(pageNumber, pageSize);
            var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
            ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;

            ViewBag.MaKhachHang = customer.MaKH;
            return View(discountCodes);
        }
     

    }
}