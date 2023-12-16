using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_ProductCategoryMetaData))]
    public partial class tb_ProductCategory
    {
        internal sealed class tb_ProductCategoryMetaData
        {
            public int MaProductCategory { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
            [StringLength(150, ErrorMessage = "Không nhập quá 150 ký tự")]
            public string TenDanhMuc { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập vị trí")]
            public Nullable<int> Position { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public string Link { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}