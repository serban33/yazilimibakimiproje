using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class UrunResimModel
    {
        public int ID { get; set; }
        public string RESIMAD { get; set; }
        public byte[] RESIM { get; set; }
        public string RESIMYOL { get; set; }
        public int URUNID { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<DateTime> UPDATEDDATE { get; set; }

        public IEnumerable<HttpPostedFileBase> RESIMDOSYASI { get; set; }
    }
}