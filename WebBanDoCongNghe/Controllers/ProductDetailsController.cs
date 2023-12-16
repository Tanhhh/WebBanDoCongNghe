using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoCongNghe.Models;

namespace WebBanDoCongNghe.Controllers
{
    public class ProductDetailsController : Controller
    {
        DBQuanLyBanDoCongNgheEntities db = new DBQuanLyBanDoCongNgheEntities();
        // GET: ProductDetails
        public ActionResult ProductDetailsIndex(int id)
        {
            var item = db.tb_Product.Find(id);
            var averageRating = db.tb_ProductReview.Where(r => r.MaSanPham == id).Average(r => (double?)r.Rating);
            ViewBag.AverageRating = averageRating ?? 0; // Nếu averageRating là null thì gán giá trị mặc định là 0
            int categoryId = item.tb_ProductCategory?.MaProductCategory ?? 0;
            // Đếm số lượng sản phẩm cùng danh mục
            int similarProductCount = db.tb_Product.Count(p => p.tb_ProductCategory.MaProductCategory == categoryId && p.MaSanPham != item.MaSanPham && p.IsSoldOut == false && p.IsActive == true);

            ViewBag.SimilarProductCount = similarProductCount;
            tb_Customer user = Session["taikhoan"] as tb_Customer;
            if (user != null)
            {
                Session["taikhoan"] = user;
                tb_FavoriteProduct findpr = db.tb_FavoriteProduct.FirstOrDefault(x => x.MaKH == user.MaKH && x.MaSanPham == id);
                if (findpr != null)//active
                {
                    ViewData["FavCheck"] = 1;
                }
                else//un active
                {
                    ViewData["FavCheck"] = 0;
                }
                var tichDiem = db.tb_TichDiem.SingleOrDefault(td => td.MaKH == user.MaKH);
                ViewBag.TongDiem = tichDiem != null ? tichDiem.TongSoDiem : 0;

            }
             
            return View(item);
        }
        public ActionResult ProductReviews(int id, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;

            var item = db.tb_ProductReview.OrderByDescending(n => n.NgayDanhGia).Where(n => n.MaSanPham == id).ToPagedList(pageNumber, pageSize);

            return PartialView(item);
        }
        [HttpPost]
        public ActionResult AddReview(tb_ProductReview review)
        {
            if (ModelState.IsValid)
            {
                tb_Customer user = Session["taikhoan"] as tb_Customer;

                try
                {
                    // Lưu đánh giá vào cơ sở dữ liệu
                    var newReview = new tb_ProductReview
                    {
                        Rating = review.Rating,
                        NoiDung = review.NoiDung,
                        MaSanPham = review.MaSanPham,
                        MaKH = user.MaKH,
                        NgayDanhGia = DateTime.Now
                    };

                    db.tb_ProductReview.Add(newReview);
                    db.SaveChanges();



                    // Sau khi thêm đánh giá, bạn có thể redirect hoặc trả về JSON để xử lý tùy theo yêu cầu của bạn
                    return RedirectToAction("ProductDetailsIndex", new { id = review.MaSanPham });
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    ModelState.AddModelError("", "Error saving review: " + ex.Message);
                }
            }

            // Nếu có lỗi, trả về view mà bạn muốn, chẳng hạn là ProductDetailsIndex với ID của sản phẩm
            // Tránh truyền đối tượng review vào view
            return RedirectToAction("ProductDetailsIndex", new { id = review.MaSanPham });
        }

        public ActionResult addorremoveFavorit(int id)
        {
            tb_Customer user = Session["taikhoan"] as tb_Customer;

            Session["taikhoan"] = user;
            tb_FavoriteProduct findpr = db.tb_FavoriteProduct.FirstOrDefault(x => x.MaKH == user.MaKH && x.MaSanPham == id);

            // Kiểm tra xem có FavoriteProduct nào hay không trước khi thực hiện OrderByDescending
            tb_FavoriteProduct lastid = db.tb_FavoriteProduct.OrderByDescending(x => x.MaSanPham).FirstOrDefault();

            // kiểm tra lastid là kiểm tra có dữ liệu nào trong database ko tại database ko set auto primary key 
            if (lastid != null) //kiểm tra có data 
            {
                if (findpr == null)//kiểm tra product hiện tại có đc yêu thích ko 
                {
                    var newFavorite = new tb_FavoriteProduct();


                    newFavorite.MaYeuThich = GetNextIdentityValue();


                    newFavorite.MaKH = user.MaKH;
                    newFavorite.MaSanPham = id;


                    db.tb_FavoriteProduct.Add(newFavorite);


                    db.SaveChanges();

                    return RedirectToAction("ProductDetailsIndex", new { id = id });
                }
                else
                {
                    db.tb_FavoriteProduct.Remove(findpr);
                    db.SaveChanges();
                }

                return RedirectToAction("ProductDetailsIndex", new { id = id });
            }
            else //kiểm tra ko data 
            {
                if (findpr == null)
                {
                    var newFavorite = new tb_FavoriteProduct();

                    newFavorite.MaYeuThich = 0;//tạo primary nếu ko có data nào 


                    newFavorite.MaKH = user.MaKH;
                    newFavorite.MaSanPham = id;


                    db.tb_FavoriteProduct.Add(newFavorite);


                    db.SaveChanges();

                    return RedirectToAction("ProductDetailsIndex", new { id = id });
                }
                else
                {
                    db.tb_FavoriteProduct.Remove(findpr);
                    db.SaveChanges();
                }

                return RedirectToAction("ProductDetailsIndex", new { id = id });

            }
        }
        private int GetNextIdentityValue()
        {
            var lastId = db.tb_FavoriteProduct.OrderByDescending(x => x.MaYeuThich).FirstOrDefault();
            return (lastId != null) ? lastId.MaYeuThich + 1 : 1;
        }
        public ActionResult removeFavorit(int id)
        {
            tb_Customer user = Session["taikhoan"] as tb_Customer;


            Session["taikhoan"] = user;
            tb_FavoriteProduct findpr = db.tb_FavoriteProduct.FirstOrDefault(x => x.MaKH == user.MaKH && x.MaSanPham == id);
            tb_FavoriteProduct lastid = db.tb_FavoriteProduct.OrderByDescending(x => x.MaSanPham).FirstOrDefault();

            if (findpr == null)//active
            {
                var newFavorite = new tb_FavoriteProduct();

                if (lastid == null)
                {
                    newFavorite.MaYeuThich = 0;
                }
                else
                {
                    newFavorite.MaYeuThich = lastid.MaYeuThich + 1;
                }

                newFavorite.MaKH = user.MaKH;
                newFavorite.MaSanPham = id;


                db.tb_FavoriteProduct.Add(newFavorite);


                db.SaveChanges();

                return RedirectToAction("ProductDetailsIndex", new { id = id });
            }
            else//un active
            {
                db.tb_FavoriteProduct.Remove(findpr);
                db.SaveChanges();
                return RedirectToAction("IndexFAV", "FavoriteProduct");


            }
        }

        public ActionResult RelatedProducts(int productId)
        {

            var currentProduct = db.tb_Product.Find(productId);

            if (currentProduct != null && currentProduct.tb_ProductCategory != null)
            {
                var relatedProducts = db.tb_Product
                    .Where(p => p.tb_ProductCategory.MaProductCategory == currentProduct.tb_ProductCategory.MaProductCategory && p.MaSanPham != productId && p.IsSoldOut == false && p.IsActive == true)
                    .ToList();


                return PartialView(relatedProducts);
            }

            return HttpNotFound();
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