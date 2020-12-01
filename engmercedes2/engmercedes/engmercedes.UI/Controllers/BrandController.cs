using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.UI.Entity;
using engmercedes.UI.Models;

namespace engmercedes.UI.Controllers
{
    public class BrandController : Controller
    {
        private ENGMERCEDESEntities db=new ENGMERCEDESEntities();
        [Route("Markalar")]
        public ActionResult BrandList()
        {
            var model = new List<MarkaModel>();
            var list = db.Marka.ToList();
            foreach (var item in list)
            {
                var obj = new MarkaModel();
                obj.MARKAADI = item.MARKAADI;
                obj.MARKARESIM = item.MARKARESIM;
                obj.MARKARESIMYOL = item.MARKARESIMYOL;
                model.Add(obj);

            }
            return View(model);
        }
    }
}