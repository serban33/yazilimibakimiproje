using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class MarkaModel
    {
        public int ID { get; set; }
        public string MARKAADI { get; set; }
        public string MARKARESIMYOL { get; set; }
        public byte[] MARKARESIM { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI { get; set; }
    }
}