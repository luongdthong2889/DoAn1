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
    
    public partial class CHITIETDONDAT
    {
        public int MACTDONDAT { get; set; }
        public int MADATXE { get; set; }
        public int MAXE { get; set; }
        public string MOTACT { get; set; }
    
        public virtual DONDATXE DONDATXE { get; set; }
        public virtual XE XE { get; set; }
    }
}
