using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using engmercedes.admin.Entity;

namespace engmercedes.admin.Models
{
    public class AltKategoriModel
    {
        public int ID { get; set; }
        public int KATEGORIID { get; set; }
        public string KATEGORIADI { get; set; }
        public string ALTKATEGORIADI { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<DateTime> UPDATEDDATE { get; set; }

    }
}