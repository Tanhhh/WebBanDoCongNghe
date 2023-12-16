using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanDoCongNghe.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set;}
        public ShoppingCart()
        {
           this.Items = new List<ShoppingCartItem>();
        }
        public void AddToCart(ShoppingCartItem item,int quantity)
        {   
            //Kiểm tra xem sản phẩm có trong giỏ hàng hay chưa
            var checkExits = Items.FirstOrDefault(n => n.iMaSanPham == item.iMaSanPham);
            if(checkExits!=null)
            {
                checkExits.iSoLuong += quantity;
                checkExits.iTongGia = checkExits.iGiaSanPham * checkExits.iSoLuong;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.iMaSanPham == id);
            if(checkExits!=null)
            {
                Items.Remove(checkExits);
               
            }
          
        }
        public void UpdateQuantity(int id,int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.iMaSanPham == id);
            if (checkExits != null)
            {
                checkExits.iSoLuong = quantity;
                checkExits.iTongGia = checkExits.iGiaSanPham * checkExits.iSoLuong;
              
            }
        }
        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.iTongGia);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.iSoLuong);
        }
        public void ClearCart()
        {
            Items.Clear();
        }
    }

        public class ShoppingCartItem
    {
        public int iMaSanPham { get; set; }
        public string iTenSanPham { get; set; }
        public string iHinhAnh { get; set; }
        public int iSoLuong { get; set; }
        public string iLink { get; set; }
        public decimal iGiaSanPham { get; set; }
        public decimal iTongGia { get; set; }


    }
}