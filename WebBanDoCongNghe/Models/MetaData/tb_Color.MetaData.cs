using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_ColorMetaData))]
    public partial class tb_Color
    {
        internal sealed class tb_ColorMetaData
        {
            public int MaColor { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên màu sắc")]
            [StringLength(150, ErrorMessage = "Không nhập quá 150 ký tự")]
            public string TenColor { get; set; }
            [Required(ErrorMessage = "Vui lòng chọn ảnh màu sắc")]
            public string ImageColor { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}