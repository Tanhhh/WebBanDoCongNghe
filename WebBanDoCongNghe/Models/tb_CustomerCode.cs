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
    
    public partial class tb_CustomerCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_CustomerCode()
        {
            this.tb_Order = new HashSet<tb_Order>();
        }
    
        public int CustomerCodeId { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<int> MaDiscount { get; set; }
        public Nullable<bool> IsSuDung { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UseDate { get; set; }
    
        public virtual tb_Customer tb_Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Order> tb_Order { get; set; }
        public virtual tb_DiscountCode tb_DiscountCode { get; set; }
    }
}
