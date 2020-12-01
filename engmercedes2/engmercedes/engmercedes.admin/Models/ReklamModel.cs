using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class ReklamModel
    {
        public int ID { get; set; }
        public string REKLAMADI { get; set; }
        public byte[] REKLAMRESIM1 { get; set; }
        public byte[] REKLAMRESIM2 { get; set; }
        public byte[] REKLAMRESIM3 { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<DateTime> UPDATEDDATE { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI1 { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI2 { get; set; }
        public HttpPostedFileWrapper RESIMDOSYASI3 { get; set; }
    }
}