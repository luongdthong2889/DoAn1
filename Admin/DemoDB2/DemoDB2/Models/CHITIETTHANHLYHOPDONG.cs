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
    
    public partial class CHITIETTHANHLYHOPDONG
    {
        public int MACTTLHOPDONG { get; set; }
        public int MATLHOPDONG { get; set; }
        public int MAXE { get; set; }
        public Nullable<System.DateTime> NGAYNHANXE { get; set; }
        public Nullable<System.DateTime> NGAYTRAXE { get; set; }
        public Nullable<double> GIA { get; set; }
        public Nullable<int> THANHTIEN { get; set; }
    
        public virtual THANHLYHOPDONG THANHLYHOPDONG { get; set; }
        public virtual XE XE { get; set; }
    }
}
