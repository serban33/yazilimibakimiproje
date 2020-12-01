using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class SiteAyarModel
    {
        public int ID { get; set; }
        public string SITEBASLIK { get; set; }
        public byte[] SITELOGO { get; set; }
        public string SITEACIKLAMA { get; set; }
        public string SITEMAIL { get; set; }
        public string SITELOGOYOL { get; set; }
        public string SITETELEFON { get; set; }
        public string SITETELEFON2 { get; set; }
        public string SITEADRES { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public HttpPostedFileWrapper LOGORESIM { get; set; }
    }
}