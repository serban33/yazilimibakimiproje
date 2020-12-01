using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace engmercedes.admin.Models
{
    public class SliderModel
    {
        public int ID { get; set; }
        public string SLIDERAD { get; set; }
        public string SLIDERYOL { get; set; }
        public byte[] SLIDERIMAGE { get; set; }
        public  Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<DateTime> UPDATEDDATE { get; set; }
        public Nullable<bool> ISAPPROVED { get; set; }

        public HttpPostedFileWrapper RESIMDOSYASI { get; set; }
    }
}