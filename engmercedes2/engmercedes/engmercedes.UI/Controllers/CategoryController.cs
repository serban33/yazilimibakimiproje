using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.UI.Entity;
using engmercedes.UI.Models;

namespace engmercedes.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ENGMERCEDESEntities db=new ENGMERCEDESEntities();
        public ActionResult PartialKategori()
        {
            var model = new List<KategoriModel>();
            var list = db.Kategori.ToList();
            foreach (var item in list)
            {
                var obj = new KategoriModel();
                obj.ID = item.ID;
                obj.KATEGORIADI = item.KATEGORIADI;
                model.Add(obj);

            }

            if (model!=null)
            {
                return PartialView("PartialCategory", model);
            }
            return PartialView("PartialCategory");
        }
    }
}