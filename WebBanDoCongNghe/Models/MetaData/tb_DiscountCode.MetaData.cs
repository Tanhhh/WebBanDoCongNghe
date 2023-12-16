using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_DiscountCodeMetaData))]
    public partial class tb_DiscountCode
    {
        internal sealed class tb_DiscountCodeMetaData
        {
            public int MaDiscount { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên mã giảm giá")]
            [StringLength(150, ErrorMessage = "Không nhập quá 150 ký tự")]
            public string TenDiscount { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập mã giảm giá")]
            [StringLength(100, ErrorMessage = "Không nhập quá 100 ký tự")]
            public string DiscountCode { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập số lượng")]
            public Nullable<int> Quantity { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập giá trị")]
            public Nullable<decimal> Value { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}