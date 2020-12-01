using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class SirketModel
    {
        public int ID { get; set; }
        public string HAKKIMIZDA { get; set; }
        public string MISYONUMUZ { get; set; }
        public string VIZYONUMUZ { get; set; }
        public byte[] RESIM1 { get; set; }
        public byte[] RESIM2 { get; set; }
        public byte[] RESIM3 { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI1 { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI2 { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI3 { get; set; }
    }
}