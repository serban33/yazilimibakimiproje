using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.UI.Models
{
    public class UrunDetayModel
    {
        public int ID { get; set; }
        public string KATEGORIADI { get; set; }
        public string ALTKATEGORIADI { get; set; }
        public string URUNACIKLAMA { get; set; }
        public Nullable<decimal> URUNFIYAT { get; set; }
        public string URUNAD { get; set; }
        public string URUNILKRESIMYOL { get; set; }
        public byte[] URUNILKRESIM { get; set; }
        public string URUNOEMKODU { get; set; }
        public string URUNKODU { get; set; }
        public Nullable<bool> ISAPPROVED { get; set; }

    }
}