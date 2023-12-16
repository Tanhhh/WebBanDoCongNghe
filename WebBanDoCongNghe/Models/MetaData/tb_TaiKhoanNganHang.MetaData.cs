using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_TaiKhoanNganHangMetaData))]
    public partial class tb_TaiKhoanNganHang
    {
        internal sealed class tb_TaiKhoanNganHangMetaData
        {
            public int MaSoTaiKhoan { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tên tài khoản ngân hàng")]
            [StringLength(200, ErrorMessage = "Không nhập quá 200 ký tự")]
            public string TenNganHang { get; set; }
            [StringLength(500, ErrorMessage = "Không nhập quá 500 ký tự")]
            public string Description { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập số tài khoản")]
            [StringLength(50, ErrorMessage = "Không nhập quá 50 ký tự")]
            public string SoTaiKhoan { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
}