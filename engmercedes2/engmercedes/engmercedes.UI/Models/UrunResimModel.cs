using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.UI.Models
{
    public class UrunResimModel
    {
        public int ID { get; set; }
        public string RESIMAD { get; set; }
        public byte[] RESIM { get; set; }
        public string RESIMYOL { get; set; }
        public int URUNID { get; set; }
    }
}