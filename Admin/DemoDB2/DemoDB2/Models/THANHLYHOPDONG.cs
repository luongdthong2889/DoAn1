//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoDB2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THANHLYHOPDONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THANHLYHOPDONG()
        {
            this.CHITIETTHANHLYHOPDONGs = new HashSet<CHITIETTHANHLYHOPDONG>();
        }
    
        public int MATLHOPDONG { get; set; }
        public int MAHOPDONG { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string HTTT { get; set; }
        public Nullable<int> TONGSOXETHUE { get; set; }
        public Nullable<int> TRATRUOC { get; set; }
        public Nullable<int> TONGTHANHTOAN { get; set; }
        public Nullable<int> SOTIENDANOP { get; set; }
        public string GHICHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHANHLYHOPDONG> CHITIETTHANHLYHOPDONGs { get; set; }
        public virtual HOPDONG HOPDONG { get; set; }
    }
}
