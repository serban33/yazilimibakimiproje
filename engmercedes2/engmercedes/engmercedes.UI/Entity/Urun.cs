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
    
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            this.UrunResim = new HashSet<UrunResim>();
        }
    
        public int ID { get; set; }
        public string URUNAD { get; set; }
        public string URUNACIKLAMA { get; set; }
        public Nullable<int> URUNMARKA { get; set; }
        public Nullable<decimal> URUNFIYAT { get; set; }
        public Nullable<int> KATEGORIID { get; set; }
        public Nullable<int> ALTKATEGORIID { get; set; }
        public Nullable<bool> ISAPPROVED { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string MARKAADI { get; set; }
        public byte[] URUNILKRESIM { get; set; }
        public string URUNILKRESIMYOL { get; set; }
        public string URUNOEMKOD { get; set; }
        public string URUNKODU { get; set; }
    
        public virtual AltKategori AltKategori { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Marka Marka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunResim> UrunResim { get; set; }
    }
}
