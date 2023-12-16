using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDoCongNghe.Models
{
    [MetadataTypeAttribute(typeof(tb_TravelerMetaData))]
    public partial class tb_Traveler
    {

        internal sealed class tb_TravelerMetaData
        {
            public int MaDonHang { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
            [StringLength(100, ErrorMessage = "Không nhập quá 100 ký tự")]
            public string HoTen { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
            [Display(Name = "Email")]
            [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
            [Display(Name = "Số điện thoại")]
            [RegularExpression(@"^[0-9]{7,11}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
            public string PhoneNumber1 { get; set; }
            [RegularExpression(@"^[0-9]{7,11}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
            public string PhoneNumber2 { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
            [RegularExpression(@"^\d+\s*,\s*[^,]+\s*,\s*[^,]+\s*,\s*[^,]+\s*,\s*[^,]+$", ErrorMessage = "Địa chỉ không hợp lệ.")]
            public string Address { get; set; }
            public string Ghichu { get; set; }
            public Nullable<decimal> TotalPayment { get; set; }
            [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán")]
            public Nullable<int> MaPhuongThucThanhToan { get; set; }
            public Nullable<bool> IsThanhToan { get; set; }
            public Nullable<bool> IsHoanThanh { get; set; }
            public Nullable<bool> IsHuyDon { get; set; }
            public Nullable<bool> IsXacNhan { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> UpdatedDate { get; set; }
            public string TrangThaiDon { get; set; }

        }
    }
}