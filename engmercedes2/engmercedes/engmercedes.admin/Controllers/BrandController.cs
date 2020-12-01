using engmercedes.admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.admin.Entity;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("marka")]
    [Authorize]
    public class BrandController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("marka-liste")]
        public ActionResult BrandList()
        {

            var list = db.Marka.ToList().OrderBy(x => x.CREATEDDATE);
            var model = new List<MarkaModel>();
            foreach (var item in list)
            {
                var obj = new MarkaModel();
                obj.MARKARESIM = item.MARKARESIM;
                obj.CREATEDDATE = item.CREATEDDATE;
                obj.MARKAADI = item.MARKAADI;
                obj.MARKARESIMYOL = item.MARKARESIMYOL;
                obj.ID = item.ID;

                model.Add(obj);
            }

            return View(model );
        }
        [HttpPost]
        [Route("marka-ekle")]
        public ActionResult BrandAdd(MarkaModel marka)
        {
            var file = marka.RESIMDOSYASI;
            byte[] Imagebyte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("~/Content/Brand/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);
                Marka dbMarka = new Marka();
                dbMarka.CREATEDDATE = DateTime.Now;
                dbMarka.MARKAADI = marka.MARKAADI;
                dbMarka.MARKARESIM = Imagebyte;
                dbMarka.MARKARESIMYOL = "~/Content/Brand/" + file.FileName;
                db.Marka.Add(dbMarka);
                db.SaveChanges();
            }
            return Redirect("/marka/marka-liste");
            
        }
        [HttpGet]
        [Route("marka-ekle")]
        public ActionResult BrandAdd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult BrandDelete(int id)
        {
            var model = db.Marka.SingleOrDefault(i => i.ID == id);
            if (model != null)
            {
                db.Marka.Remove(model);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}