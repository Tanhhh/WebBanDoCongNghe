//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanDoCongNghe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_ProductReview
    {
        public int MaReview { get; set; }
        public Nullable<int> MaSanPham { get; set; }
        public Nullable<int> MaKH { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> NgayDanhGia { get; set; }
    
        public virtual tb_Customer tb_Customer { get; set; }
        public virtual tb_Product tb_Product { get; set; }
    }
}
