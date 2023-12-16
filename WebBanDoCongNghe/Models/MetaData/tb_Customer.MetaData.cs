using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_CustomerMetaData))]
    public partial class tb_Customer
    {
        internal sealed class tb_CustomerMetaData
        {
         
            public int MaKH { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
            [StringLength(200, ErrorMessage = "Không nhập quá 200 ký tự")]
            public string HoTen { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập tài khoản.")]
            [StringLength(100, ErrorMessage = "Không nhập quá 100 ký tự")]
            public string TaiKhoan { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
            [StringLength(100, ErrorMessage = "Không nhập quá 100 ký tự")]
            public string MatKhau { get; set; }
          
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
            [Display(Name = "Email")]
            [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
            public string Email { get; set; }
            public string ImageUser { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
            [Display(Name = "Số điện thoại")]
            [RegularExpression(@"^[0-9]{7,11}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
            [RegularExpression(@"^\d+\s*,\s*[^,]+\s*,\s*[^,]+\s*,\s*[^,]+\s*,\s*[^,]+$", ErrorMessage = "Địa chỉ không hợp lệ.")]
            public string Address { get; set; }
            public string GioiTinh { get; set; }
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> NgaySinh { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public Nullable<bool> IsAdmin { get; set; }
            [NotMapped] // Để không lưu giữ thuộc tính này trong cơ sở dữ liệu
            public HttpPostedFileBase fileUpload { get; set; }

        }
    }
}