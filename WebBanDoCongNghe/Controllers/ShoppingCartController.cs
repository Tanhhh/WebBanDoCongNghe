using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class ShoppingCartController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: ShoppingCart
        public ActionResult IndexShoppingCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CartNotEmpty = true;
                return View();
            }

            // Nếu không có sản phẩm trong giỏ hàng, đặt ViewBag.CartNotEmpty là false
            ViewBag.CartNotEmpty = false;
            ViewBag.Error = "Không có sản phẩm trong giỏ hàng! Bạn vui lòng quay lại trang sản phẩm để mua hàng.";
            return View();
        }

        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        public decimal TongTien()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            decimal tongTien = 0;
            foreach (var item in cart.Items)
            {
                tongTien = tongTien + item.iTongGia;
            }
            return tongTien;
        }
        public ActionResult GioHangPartial()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                // Lấy thông tin giảm giá từ session
                var discountCode = (tb_CustomerCode)Session["discount"];

                if (discountCode != null)
                {
                    ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;
                }

                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            ViewBag.PhuongThucThanhToan = new SelectList(db.tb_PhuongThucThanhToan.ToList(), "MaPhuongThucThanhToan", "TenPhuongThucThanhToan");
            return View();
        }

        public int check = 0;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(tb_Traveler model)
        {
            if (ModelState.IsValid)
            {
                if (model.MaPhuongThucThanhToan == 6)
                {
                    PaymentWithPaypal();
                    if (check == 0)
                    {
                        ShoppingCart cart = (ShoppingCart)Session["Cart"];

                        // Kiểm tra xem đối tượng cart có tồn tại và có mục nào không
                        if (cart != null && cart.Items.Any())
                        {
                            // Lưu thông tin đơn hàng vào database
                            model.TotalPayment = cart.Items.Sum(x => x.iGiaSanPham * x.iSoLuong);
                            model.IsXacNhan = false;
                            model.IsThanhToan = false;
                            model.IsHoanThanh = false;
                            model.IsHuyDon = false;
                            model.IsDongGoi = false;
                            model.IsVanChuyen = false;
                            model.TrangThaiDon = "Chờ xác nhận";
                            model.CreateDate = DateTime.Now;

                            // Lưu đơn hàng vào database
                            db.tb_Traveler.Add(model);
                            db.SaveChanges();

                            // Lấy MaDonHang của đơn hàng vừa lưu
                            int maDonHang = model.MaDonHang;

                            // Lưu thông tin chi tiết đơn hàng vào database
                            foreach (var item in cart.Items)
                            {
                                tb_ChiTietOrder_Traveler chiTietOrder = new tb_ChiTietOrder_Traveler();
                                chiTietOrder.MaDonHang = maDonHang;
                                chiTietOrder.MaSanPham = item.iMaSanPham;
                                chiTietOrder.Quantity = item.iSoLuong;
                                chiTietOrder.Price = (decimal)item.iGiaSanPham;
                                db.tb_ChiTietOrder_Traveler.Add(chiTietOrder);
                            }
                            decimal shippingFee;

                            if (model.TotalPayment > 30000000)
                            {
                                shippingFee = 0;
                            }
                            else
                            {
                                shippingFee = 50000;
                            }
                            model.IsThanhToan = true;
                            // Gán giá trị cho MaKH tại đây
                            model.TotalPayment += shippingFee;
                            // Lưu thay đổi vào database
                            db.SaveChanges();

                            // Xóa giỏ hàng
                            cart.ClearCart();

                            // Lưu MaDonHang vào TempData để sử dụng trong hành động sau này
                            TempData["MaDonHang"] = maDonHang;

                            return Redirect(HttpUtility.UrlEncode(Url.Action("CheckOutTravelerSuccess", "ShoppingCart")));
                        }

                    }
                    check = 0;

                }
                if (model.MaPhuongThucThanhToan == 5)
                {

                    ShoppingCart cart = (ShoppingCart)Session["Cart"];

                    // Kiểm tra xem đối tượng cart có tồn tại và có mục nào không
                    if (cart != null && cart.Items.Any())
                    {
                        // Lưu thông tin đơn hàng vào database
                        model.TotalPayment = cart.Items.Sum(x => x.iGiaSanPham * x.iSoLuong);
                        model.IsXacNhan = false;
                        model.IsThanhToan = false;
                        model.IsHoanThanh = false;
                        model.IsHuyDon = false;
                        model.TrangThaiDon = "Chờ xác nhận";
                        model.CreateDate = DateTime.Now;

                        // Lưu đơn hàng vào database
                        db.tb_Traveler.Add(model);
                        db.SaveChanges();

                        // Lấy MaDonHang của đơn hàng vừa lưu
                        int maDonHang = model.MaDonHang;

                        // Lưu thông tin chi tiết đơn hàng vào database
                        foreach (var item in cart.Items)
                        {
                            tb_ChiTietOrder_Traveler chiTietOrder = new tb_ChiTietOrder_Traveler();
                            chiTietOrder.MaDonHang = maDonHang;
                            chiTietOrder.MaSanPham = item.iMaSanPham;
                            chiTietOrder.Quantity = item.iSoLuong;
                            chiTietOrder.Price = (decimal)item.iGiaSanPham;
                            db.tb_ChiTietOrder_Traveler.Add(chiTietOrder);
                        }

                        // Lưu thay đổi vào database
                        db.SaveChanges();

                        // Xóa giỏ hàng
                        cart.ClearCart();

                        // Lưu MaDonHang vào TempData để sử dụng trong hành động sau này
                        TempData["MaDonHang"] = maDonHang;

                        return RedirectToAction("CheckOutTravelerSuccess");
                    }
                }
            }

            // Trả về view với model nếu có lỗi
            return View(model);
        }
        public ActionResult CheckOutUser()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            ViewBag.PhuongThucThanhToan = new SelectList(db.tb_PhuongThucThanhToan.ToList(), "MaPhuongThucThanhToan", "TenPhuongThucThanhToan");
            return View();
        }

        public int check1 = 0;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutUser(tb_Order model)
        {
            if (ModelState.IsValid)
            {
                if (model.MaPhuongThucThanhToan == 6)
                {
                    PaymentWithPaypalCustomer();
                    if (check1 == 0)
                    {
                        ShoppingCart cart = (ShoppingCart)Session["Cart"];
                        if (cart != null)
                        {
                            decimal shippingFee;

                            if (Session["MaKH"] != null)
                            {
                                tb_Customer customer = (tb_Customer)Session["taikhoan"];

                                foreach (var item in cart.Items)
                                {
                                    tb_ChiTietOrder chiTietOrder = new tb_ChiTietOrder
                                    {
                                        MaDonHang = model.MaDonHang,
                                        MaSanPham = item.iMaSanPham,
                                        Quantity = item.iSoLuong,
                                        Price = (decimal)item.iGiaSanPham
                                    };
                                    db.tb_ChiTietOrder.Add(chiTietOrder);
                                }

                                // Tính tổng giá trị đơn hàng trước khi giảm giá
                                model.TotalPayment = cart.Items.Sum(x => x.iGiaSanPham * x.iSoLuong);

                                // Kiểm tra xem có mã giảm giá được áp dụng hay không
                                var discountCode = (tb_CustomerCode)Session["discount"];

                                if (discountCode != null)
                                {
                                    // Giảm giá từ mã giảm giá
                                    model.TotalPayment -= discountCode.tb_DiscountCode.Value;
                                    discountCode.IsSuDung = true;
                                    discountCode.UseDate = DateTime.Now;

                                    // Retrieve the existing tb_CustomerCode from the database and update it
                                    var existingCustomerCode = db.tb_CustomerCode.FirstOrDefault(cc => cc.CustomerCodeId == discountCode.CustomerCodeId);
                                    if (existingCustomerCode != null)
                                    {
                                        // Update the properties of existingCustomerCode
                                        existingCustomerCode.IsSuDung = discountCode.IsSuDung;
                                        existingCustomerCode.UseDate = discountCode.UseDate;
                                        model.CustomerCodeID = discountCode.CustomerCodeId;

                                        // Update other properties as needed
                                    }
                                }

                                if (model.TotalPayment > 30000000)
                                {
                                    shippingFee = 0;
                                }
                                else
                                {
                                    shippingFee = 50000;
                                }
                                model.TotalPayment += shippingFee;

                                // Gán giá trị cho MaKH tại đây
                                model.IsNhanDiem = false;
                                model.MaKH = customer.MaKH;
                                model.IsXacNhan = false;
                                model.IsThanhToan = true;
                                model.IsHoanThanh = false;
                                model.IsHuyDon = false;
                                model.IsDongGoi = false;
                                model.IsVanChuyen = false;
                                model.TrangThai = "Chờ xác nhận";
                                model.CreateDate = DateTime.Now;
                                db.tb_Order.Add(model);
                                db.SaveChanges();

                                cart.ClearCart();
                                return RedirectToAction("CheckOutSuccess");
                            }
                        }
                    }
                }
                if (model.MaPhuongThucThanhToan == 5)
                {
                    ShoppingCart cart = (ShoppingCart)Session["Cart"];
                    if (cart != null)
                    {
                        decimal shippingFee;

                        if (Session["MaKH"] != null)
                        {
                            tb_Customer customer = (tb_Customer)Session["taikhoan"];

                            foreach (var item in cart.Items)
                            {
                                tb_ChiTietOrder chiTietOrder = new tb_ChiTietOrder
                                {
                                    MaDonHang = model.MaDonHang,
                                    MaSanPham = item.iMaSanPham,
                                    Quantity = item.iSoLuong,
                                    Price = (decimal)item.iGiaSanPham
                                };
                                db.tb_ChiTietOrder.Add(chiTietOrder);
                            }

                            // Tính tổng giá trị đơn hàng trước khi giảm giá
                            model.TotalPayment = cart.Items.Sum(x => x.iGiaSanPham * x.iSoLuong);

                            // Kiểm tra xem có mã giảm giá được áp dụng hay không
                            var discountCode = (tb_CustomerCode)Session["discount"];

                            if (discountCode != null)
                            {
                                // Giảm giá từ mã giảm giá
                                model.TotalPayment -= discountCode.tb_DiscountCode.Value;
                                discountCode.IsSuDung = true;
                                discountCode.UseDate = DateTime.Now;

                                // Retrieve the existing tb_CustomerCode from the database and update it
                                var existingCustomerCode = db.tb_CustomerCode.FirstOrDefault(cc => cc.CustomerCodeId == discountCode.CustomerCodeId);
                                if (existingCustomerCode != null)
                                {
                                    // Update the properties of existingCustomerCode
                                    existingCustomerCode.IsSuDung = discountCode.IsSuDung;
                                    existingCustomerCode.UseDate = discountCode.UseDate;
                                    model.CustomerCodeID = discountCode.CustomerCodeId;

                                    // Update other properties as needed
                                }
                            }

                            if (model.TotalPayment > 30000000)
                            {
                                shippingFee = 0;
                            }
                            else
                            {
                                shippingFee = 50000;
                            }
                            model.TotalPayment += shippingFee;

                            // Gán giá trị cho MaKH tại đây
                            model.IsNhanDiem = false;
                            model.MaKH = customer.MaKH;
                            model.IsXacNhan = false;
                            model.IsThanhToan = false;
                            model.IsHoanThanh = false;
                            model.IsHuyDon = false;
                            model.IsDongGoi = false;
                            model.IsVanChuyen = false;
                            model.TrangThai = "Chờ xác nhận";
                            model.CreateDate = DateTime.Now;
                            db.tb_Order.Add(model);
                            db.SaveChanges();

                            cart.ClearCart();
                            return RedirectToAction("CheckOutSuccess");
                        }
                    }
                }
            }

            ViewBag.PhuongThucThanhToan = new SelectList(db.tb_PhuongThucThanhToan.ToList(), "MaPhuongThucThanhToan", "TenPhuongThucThanhToan");
            return View(model);
        }
        public ActionResult CheckOutSuccess()
        {
            // Lấy thông tin khách hàng từ session
            tb_Customer customer = (tb_Customer)Session["taikhoan"];

            // Kiểm tra nếu khách hàng không đăng nhập, chuyển hướng về trang chủ hoặc trang quản lý đơn hàng
            if (customer == null)
            {
                return RedirectToAction("CheckOutSuccess");
            }


            // Lấy thông tin đơn hàng gần đây nhất của khách hàng
            var latestOrder = db.tb_Order
                .Include("tb_Customer") // Đảm bảo Include để lấy thông tin khách hàng
                .Where(order => order.MaKH == customer.MaKH && order.IsXacNhan == false)
                .OrderByDescending(order => order.CreateDate)
                .FirstOrDefault();

            // Kiểm tra nếu không tìm thấy đơn hàng, chuyển hướng về trang chủ hoặc trang quản lý đơn hàng
            if (latestOrder == null)
            {
                return RedirectToAction("CheckOutSuccess");
            }

            // Lấy thông tin chi tiết đơn hàng từ CSDL
            var orderDetails = db.tb_ChiTietOrder
                .Include("tb_Product") // Đảm bảo Include để lấy thông tin sản phẩm
                .Where(detail => detail.MaDonHang == latestOrder.MaDonHang)
                .ToList();


            // Cập nhật đường dẫn ảnh cho mỗi sản phẩm

            foreach (var detail in orderDetails)
            {
                var product = detail.tb_Product;
                var defaultImage = product.tb_ProductImages.FirstOrDefault(n => n.IsDefault == true);
                product.ImageProduct = defaultImage?.Image;
            }
            var tichDiem = db.tb_TichDiem.Where(x => x.MaKH == customer.MaKH).FirstOrDefault();
            Session["latestOrder"] = latestOrder;
            Session["orderDetails"] = orderDetails;
            Session["tichDiem"] = tichDiem;
            ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            var discountCode = (tb_CustomerCode)Session["discount"];

            if (discountCode != null)
            {
                ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;
            }

            return View();
        }
        public ActionResult CheckOutTravelerSuccess()
        {
            // Lấy MaDonHang từ TempData
            if (TempData["MaDonHang"] is int maDonHang)
            {
                // Truy vấn thông tin đơn hàng từ database
                var order = db.tb_Traveler
                                .Include("tb_ChiTietOrder_Traveler")  // Thêm các bảng cần include vào đây
                                .Where(o => o.MaDonHang == maDonHang)
                                .FirstOrDefault();

                // Nếu đơn hàng tồn tại, thực hiện các xử lý khác
                if (order != null)
                {
                    // Lưu thông tin đơn hàng vào ViewBag để sử dụng trong view
                    ViewBag.LatestOrder = order;

                    // Truy vấn thông tin chi tiết đơn hàng từ database
                    var orderDetails = db.tb_ChiTietOrder_Traveler
                                            .Include("tb_Product")  // Thêm các bảng cần include vào đây
                                            .Where(detail => detail.MaDonHang == maDonHang)
                                            .ToList();
                    foreach (var detail in orderDetails)
                    {
                        var product = detail.tb_Product;
                        var defaultImage = product.tb_ProductImages.FirstOrDefault(n => n.IsDefault == true);
                        product.ImageProduct = defaultImage?.Image;
                    }
                    // Lưu thông tin chi tiết đơn hàng vào ViewBag để sử dụng trong view
                    ViewBag.OrderDetails = orderDetails;

                    return View();
                }
            }

            // Nếu không có MaDonHang trong TempData hoặc có lỗi truy vấn, chuyển hướng về trang chủ hoặc trang quản lý đơn hàng
            return RedirectToAction("CheckOutTravelerSuccess");
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.GetTotalQuantity() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var checkProduct = db.tb_Product.FirstOrDefault(x => x.MaSanPham == id);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    iMaSanPham = checkProduct.MaSanPham,
                    iTenSanPham = checkProduct.TenSanPham,
                    iLink = checkProduct.Link,
                    iSoLuong = quantity

                };
                if (checkProduct.tb_ProductImages.FirstOrDefault(x => x.IsDefault == true) != null)
                {
                    item.iHinhAnh = db.tb_Product.FirstOrDefault(x => x.MaSanPham == id).tb_ProductImages.FirstOrDefault(x => x.IsDefault == true).Image;
                }
                if (checkProduct.IsSale == true)
                {
                    item.iGiaSanPham = (decimal)checkProduct.PriceSale;
                }
                else
                {
                    item.iGiaSanPham = (decimal)checkProduct.Price;
                }

                item.iTongGia = item.iSoLuong * item.iGiaSanPham;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Đã thêm sản phẩm vào giỏ hàng!", code = 1, Count = cart.GetTotalQuantity() };
            }
            return Json(code);
        }
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.iMaSanPham == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }
        public ActionResult MaGiamGia(FormCollection form)
        {
            var MaGiamGia = form["txtMaGiamGia"].ToString();

            tb_Customer customer = (tb_Customer)Session["taikhoan"];
            if (customer != null)
            {
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == customer.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;
            }
            // Kiểm tra xem mã giảm giá có tồn tại không
            var discountCode = db.tb_CustomerCode.FirstOrDefault(n => n.tb_DiscountCode.DiscountCode == MaGiamGia && n.IsSuDung == false);

            if (discountCode != null)
            {
                if (discountCode.tb_DiscountCode.IsActive == true)
                {
                    ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;

                    decimal soTienGiamGia = (decimal)discountCode.tb_DiscountCode.Value;
                    decimal tienSauKhiGiam = TongTien() - soTienGiamGia;
                    ViewBag.tienSauKhiGiam = tienSauKhiGiam;
                    ViewBag.GiamGia = discountCode.tb_DiscountCode.Value;


                    // Lưu thông tin giảm giá vào Session
                    Session["discount"] = discountCode;

                    ShoppingCart cart = (ShoppingCart)Session["Cart"];
                    if (cart != null)
                    {
                        return PartialView(cart.Items);
                    }

                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Mã giảm giá không dùng được nữa";
                    return RedirectToAction("IndexShoppingCart", "ShoppingCart");


                }
            }
            else
            {
                // Mã giảm giá không tồn tại, xử lý theo ý của bạn (ví dụ: thông báo lỗi)
                ViewBag.ErrorMessage = "Mã giảm giá không hợp lệ";
                return RedirectToAction("IndexShoppingCart", "ShoppingCart");

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
        public void PaymentWithPaypal()
        {
            // Getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                // A resource representing a Payer that funds a payment Payment Method as PayPal  
                // Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    // This section will be executed first because PayerID doesn't exist  
                    // It is returned by the create function call of the payment class  
                    // Creating a payment  
                    // BaseURL is the URL on which PayPal sends back the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPayPal?";
                    // Here we are generating guid for storing the paymentID received in session  
                    // which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    // CreatePayment function gives us the payment approval URL  
                    // on which payer is redirected for PayPal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    // Get links returned from PayPal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            // Saving the PayPal redirect URL to which the user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // Saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    Response.Redirect(paypalRedirectUrl, true);
                }
                else
                {
                    // This function executes after receiving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    // If executed payment failed, redirect to the shopping cart page
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        check = 1;
                        Response.Redirect(Url.Action("IndexShoppingCart", "ShoppingCart"));
                    }
                    else
                    {
                        // Redirect to the successful payment page
                        Response.Redirect(Url.Action("CheckOutTravelerSuccess", "ShoppingCart"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePayment: {ex.Message}");
                check = 1;
                // Redirect to the shopping cart page in case of an exception
                Response.Redirect(Url.Action("ShoppingCart", "ShoppingCart"));
            }
        }
        public void PaymentWithPaypalCustomer()
        {
            // Getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                // A resource representing a Payer that funds a payment Payment Method as PayPal  
                // Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    // This section will be executed first because PayerID doesn't exist  
                    // It is returned by the create function call of the payment class  
                    // Creating a payment  
                    // BaseURL is the URL on which PayPal sends back the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPayPalCustomer?";
                    // Here we are generating guid for storing the paymentID received in session  
                    // which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    // CreatePayment function gives us the payment approval URL  
                    // on which payer is redirected for PayPal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    // Get links returned from PayPal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            // Saving the PayPal redirect URL to which the user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // Saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    Response.Redirect(paypalRedirectUrl, true);
                }
                else
                {
                    // This function executes after receiving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    // If executed payment failed, redirect to the shopping cart page
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        check1 = 1;
                        Response.Redirect(Url.Action("IndexShoppingCart", "ShoppingCart"));
                    }
                    else
                    {
                        // Redirect to the successful payment page
                        Response.Redirect(Url.Action("CheckOutSuccess", "ShoppingCart"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreatePayment: {ex.Message}");
                check1 = 1;
                // Redirect to the shopping cart page in case of an exception
                Response.Redirect(Url.Action("ShoppingCart", "ShoppingCart"));
            }
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            try
            {
                decimal sum = decimal.Zero;
                ShoppingCart cart = (ShoppingCart)Session["Cart"];

                foreach (var item in cart.Items)
                {
                    sum += item.iTongGia;
                }
                string x = (sum / 23820).ToString();
                double doubleValue = double.Parse(x);
                int integerValue = (int)doubleValue;
                //create itemlist and add item objects to it  
                var itemList = new ItemList()
                {
                    items = new List<Item>()
                };
                //Adding Item Details like name, currency, price etc  
                itemList.items.Add(new Item()
                {
                    name = "Item Name comes here",
                    currency = "USD",
                    price = integerValue.ToString(),
                    quantity = "1",
                    sku = "sku"
                });
                var payer = new Payer()
                {
                    payment_method = "paypal"
                };
                // Configure Redirect Urls here with RedirectUrls object  
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&Cancel=true",
                    return_url = redirectUrl
                };
                // Adding Tax, shipping and Subtotal details  
                var details = new Details()
                {
                    tax = "1",
                    shipping = "1",
                    subtotal = integerValue.ToString(),
                };
                //Final amount with details  
                var amount = new Amount()
                {
                    currency = "USD",
                    total = (integerValue + 1 + 1).ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
                    details = details
                };
                var transactionList = new List<Transaction>();
                // Adding description about the transaction  
                var paypalOrderId = DateTime.Now.Ticks;
                transactionList.Add(new Transaction()
                {
                    description = $"Invoice #{paypalOrderId}",
                    invoice_number = paypalOrderId.ToString(), //Generate an Invoice No    
                    amount = amount,
                    item_list = itemList
                });
                this.payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = transactionList,
                    redirect_urls = redirUrls
                };
                // Create a payment using a APIContext  
                return this.payment.Create(apiContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing APIContext: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw new Exception();
            }
        }
    }
}