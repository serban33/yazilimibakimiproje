using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class UrunModel
    {
        public int ID { get; set; }
        public string KATEGORIAD { get; set; }
        public string ALTKATEGORIADI { get; set; }
        public string MARKAADI { get; set; }
        public int MARKAID { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<DateTime> UPDATEDDATE { get; set; }
        public string URUNAD { get; set; }
        public string URUNACIKLAMA { get; set; }
        public Nullable<decimal> URUNFIYAT { get; set; }
        public Nullable<int> KATEGORIID { get; set; }
        public Nullable<int> ALTKATEGORIID { get; set; }
        public byte[] URUNILKRESIM { get; set; }
        public Nullable<bool> ISAPPROVED { get; set; }
        public string URUNILKRESIMYOL { get; set; }
        public string URUNOEMKODU { get; set; }
        public string URUNKODU { get; set; }
        public HttpPostedFileWrapper URUNRESIMDOSYASI { get; set; }
    }
}