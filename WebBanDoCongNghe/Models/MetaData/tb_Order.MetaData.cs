using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanDoCongNghe.Models.MetaData
{
    [MetadataTypeAttribute(typeof(tb_OrderMetaData))]
    public partial class tb_Order
    {
        internal sealed class tb_OrderMetaData
        {
            [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán")]
            public Nullable<int> MaPhuongThucThanhToan { get; set; }
        }
    }
}