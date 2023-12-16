using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_PhuongThucThanhToanMetaData))]
    public partial class tb_PhuongThucThanhToan
    {
        internal sealed class tb_PhuongThucThanhToanMetaData
        {
            public int MaPhuongThucThanhToan { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên phương thức thanh toán")]
            [StringLength(200, ErrorMessage = "Không nhập quá 200 ký tự")]
            public string TenPhuongThucThanhToan { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}