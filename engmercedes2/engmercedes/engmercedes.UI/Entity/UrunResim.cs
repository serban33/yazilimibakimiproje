//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace engmercedes.UI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunResim
    {
        public int ID { get; set; }
        public string RESIMAD { get; set; }
        public byte[] RESIM { get; set; }
        public string RESIMYOL { get; set; }
        public Nullable<int> URUNID { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
    
        public virtual Urun Urun { get; set; }
    }
}
