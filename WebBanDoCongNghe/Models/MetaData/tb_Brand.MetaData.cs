using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_BrandMetaData))]
    public partial class tb_Brand
    {
        internal sealed class tb_BrandMetaData
        {
            public int MaBrand { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên thương hiệu")]
            [StringLength(150, ErrorMessage = "Không nhập quá 150 ký tự")]
            public string TenBrand { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}