using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class KullaniciModel
    {
        public string KULLANICIADI { get; set; }
        public string KULLANICISIFRE { get; set; }
        public byte[] KULLANICIRESIM { get; set; }
        public string KULLANICITELEFON { get; set; }
        public string KULLANICIMAİL { get; set; }
    }
}