using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.UI.Models
{
    public class UrunModel
    {
        public int ID { get; set; }
        public string URUNAD { get; set; }
        public string URUNACIKLAMA { get; set; }
        public string MARKAADI { get; set; }
        public Nullable<decimal> URUNFIYAT { get; set; }
        public byte[] URUNRESIM { get; set; }
        public string URUNKODU { get; set; }
        public string URUNOEMKODU { get; set; }

        public Nullable<bool> ISAPPROVED { get; set; }

    }
}