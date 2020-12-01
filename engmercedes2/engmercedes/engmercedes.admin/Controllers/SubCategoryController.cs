using engmercedes.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.admin.Entity;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("altkategori")]
    [Authorize]
    public class SubCategoryController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("altkategori-liste")]
        public ActionResult SubCategoryList()
        {
            var model = db.vw_AltKatAndKat.ToList();
            var list=new List<AltKategoriModel>();
            foreach (var item in model)
            {
                 AltKategoriModel altKat=new AltKategoriModel();
                 altKat.CREATEDDATE = (DateTime) item.CREATEDDATE;
                 altKat.ALTKATEGORIADI = item.ALTKATEGORIADI;
                 altKat.KATEGORIADI = item.KATEGORIADI;
                 altKat.ID = item.ID;
                 list.Add(altKat);
            }
            return View(list);
        }
        [HttpGet]
        [Route("altkategori-ekle")]
        public ActionResult SubCategoryAdd()
        {

            ViewBag.Kategoriler = new SelectList(db.Kategori, "ID", "KATEGORIADI");

            return View();
        }
        [HttpPost]
        [Route("altkategori-ekle")]
        public ActionResult SubCategoryAdd(AltKategoriModel altKategori)
        {
            if (ModelState.IsValid)
            {
                altKategori.CREATEDDATE = DateTime.Now;
                using (var context = new ENGMERCEDESEntities())
                {
                    context.AltKategori.Add(new AltKategori { CREATEDDATE = altKategori.CREATEDDATE, KATEGORIID = altKategori.KATEGORIID, ALTKATEGORIADI = altKategori.ALTKATEGORIADI });
                    context.SaveChanges();
                }
                return Redirect("/altkategori/altkategori-liste");
            }

            return View();
        }

        [HttpPost]
        [Route("alt-kategori-sil/{id:int}")]
        public JsonResult SubCategoryDelete(int id)
        {
            var model = db.AltKategori.SingleOrDefault(i => i.ID == id);
            if (model!=null)
            {
                db.AltKategori.Remove(model);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);


            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
        [Route("alt-kategori-guncelle/{id:int}")]
        [HttpGet]
        public ActionResult SubCategoryUpdate(int id)
        {
            var model = db.AltKategori.FirstOrDefault(i => i.ID == id);
            AltKategoriModel obj=new AltKategoriModel();
            obj.KATEGORIID = (int)model.KATEGORIID;
            obj.ALTKATEGORIADI = model.ALTKATEGORIADI;
            obj.ID = model.ID;
            ViewBag.Kategoriler = new SelectList(db.Kategori, "ID", "KATEGORIADI");

            return View(obj);
        }
        [Route("alt-kategori-guncelle/{id:int}")]
        [HttpPost]
        public ActionResult SubCategoryUpdate(AltKategoriModel model)
        {
            AltKategori obj = db.AltKategori.SingleOrDefault(i => i.ID == model.ID);
            obj.KATEGORIID = model.KATEGORIID;
            obj.ALTKATEGORIADI = model.ALTKATEGORIADI;
            obj.UPDATEDDATE = DateTime.Now;
            db.SaveChanges();
            return Redirect("/altkategori/altkategori-liste");
        }
    }
}