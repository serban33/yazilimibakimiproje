 using engmercedes.admin.Entity;
using engmercedes.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("kategori")]
    [Authorize]
    public class CategoryController : Controller
    {
        ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("kategori-liste")]
        public ActionResult CategoryList()
        {
            var list = db.Kategori.ToList();
            var model = new List<KategoriModel>();

            foreach (var item in list)
            {
                var obj = new KategoriModel();
                obj.CREATEDDATE = item.CREATEDDATE;
                obj.KATEGORIADI = item.KATEGORIADI;
                obj.ID = item.ID;
                model.Add(obj);
            }
            return View(model);

        }
        [HttpGet]
        [Route("kategori-ekle")]
        public ActionResult CategoryAdd()
        {
            return View();

        }
        [HttpPost]
        [Route("kategori-ekle")]
        public ActionResult CategoryAdd(KategoriModel kategori)
        {
            kategori.CREATEDDATE = DateTime.Now;
            using (var context = new ENGMERCEDESEntities())
            {
                context.Kategori.Add(new Kategori { CREATEDDATE=kategori.CREATEDDATE,KATEGORIADI=kategori.KATEGORIADI});
                context.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        [Route("kategori-guncelle/{id:int}")]
        public ActionResult CategoryUpdate(int id)
        {
            var model = db.Kategori.FirstOrDefault(i => i.ID == id);
            KategoriModel kategori=new KategoriModel();
            kategori.CREATEDDATE = model.CREATEDDATE;
            kategori.KATEGORIADI = model.KATEGORIADI;
            
            return View(kategori);
        }
        [HttpPost]
        [Route("kategori-guncelle/{id:int}")]
        public ActionResult CategoryUpdate(KategoriModel model,int id)
        {
            Kategori kategori = db.Kategori.Where(i => i.ID == id).SingleOrDefault();
            kategori.KATEGORIADI = model.KATEGORIADI;
            kategori.UPDATEDDATE = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        [Route("kategori-sil/{id:int}")]
        public JsonResult CategoryDelete(int id)
        {
            var model = db.Kategori.SingleOrDefault(i => i.ID == id);
            if (model!=null)
            {
                db.Kategori.Remove(model);
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