using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanDoCongNghe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "CheckOut",
             url: "thanh-toan",
             defaults: new { controller = "ShoppingCart", action = "CheckOut", id = UrlParameter.Optional },
             namespaces: new[] { "WebBanDoCongNghe.Controllers" }
        );
            routes.MapRoute(
            name: "CheckOutUser",
            url: "thanh-toan-user",
            defaults: new { controller = "ShoppingCart", action = "CheckOutUser", id = UrlParameter.Optional },
            namespaces: new[] { "WebBanDoCongNghe.Controllers" }
       );
            routes.MapRoute(
             name: "ProductDetails",
             url: "chi-tiet/{link}-p{id}",
             defaults: new { controller = "ProductDetails", action = "ProductDetailsIndex", id = UrlParameter.Optional },
             namespaces: new[] { "WebBanDoCongNghe.Controllers" }
        );
            routes.MapRoute(
              name: "ProductCategory",
              url: "san-pham",
              defaults: new { controller = "ListProduct", action = "IndexListProduct", id = UrlParameter.Optional },
              namespaces: new[] { "WebBanDoCongNghe.Controllers" }
         );
            routes.MapRoute(
             name: "Home",
             url: "trang-chu",
             defaults: new { controller = "Home", action = "IndexHome", id = UrlParameter.Optional },
             namespaces: new[] { "WebBanDoCongNghe.Controllers" }
         );

            routes.MapRoute(
             name: "Introduction",
             url: "gioi-thieu",
             defaults: new { controller = "Home", action = "Introduction", id = UrlParameter.Optional },
             namespaces: new[] { "WebBanDoCongNghe.Controllers" }
         );
            //    routes.MapRoute(
            //    name: "ProductCategoryPhone",
            //    url: "dien-thoai",
            //    defaults: new { controller = "ListProduct", action = "ListProductByCategory", id = 13 }, // Đặt id cho điện thoại
            //    namespaces: new[] { "WebBanDoCongNghe.Controllers" }
            //);
            //    routes.MapRoute(
            //    name: "ProductCategoryLaptop",
            //    url: "lap-top",
            //    defaults: new { controller = "ListProduct", action = "ListProductByCategory", id = 14 }, // Đặt id cho điện thoại
            //    namespaces: new[] { "WebBanDoCongNghe.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "IndexHome", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanDoCongNghe.Controllers" }
         );

        }
    }
}
