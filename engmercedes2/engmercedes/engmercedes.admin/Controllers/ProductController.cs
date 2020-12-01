using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using engmercedes.admin.Entity;
using engmercedes.admin.Models;
using PagedList;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("urun")]
    [Authorize]
    public class ProductController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("urun-ekle")]
        public ActionResult ProductAdd()
        {
            ViewBag.Kategoriler = new SelectList(db.Kategori, "ID", "KATEGORIADI");
            
            ViewBag.Markalar = new SelectList(db.Marka, "ID", "MARKAADI");
            return View();
        }

        [HttpPost]
        [Route("urun-ekle")]
        public ActionResult ProductAdd(UrunModel model)
        {
            var file = model.URUNRESIMDOSYASI;
            byte[] Imagebyte = null;
            if (file != null)
            {

                file.SaveAs(Server.MapPath("~/Content/ProductImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);

            }

            model.CREATEDDATE = DateTime.Now;
            using (var context = new ENGMERCEDESEntities())
            {

                context.Urun.Add(new Urun
                {
                    CREATEDDATE = model.CREATEDDATE,
                    KATEGORIID = model.KATEGORIID,
                    ISAPPROVED = true,
                    URUNILKRESIM = Imagebyte,
                    URUNILKRESIMYOL = "~/Content/ProductImage/" + file.FileName,
                    URUNACIKLAMA = model.URUNACIKLAMA,
                    URUNAD = model.URUNAD,
                    URUNFIYAT = model.URUNFIYAT,
                    URUNMARKA = model.MARKAID,
                    URUNKODU = model.URUNKODU.ToLower(),
                    URUNOEMKOD = model.URUNOEMKODU.ToLower()
                });
                context.SaveChanges();
            }
            Thread.Sleep(2000);
            return Redirect("/urun/urun-liste");
        }
        [HttpGet]
        [Route("urun-liste")]
        public ActionResult ProductList()
        {
            var list = db.vw_UrunList.ToList();
            
            var model = new List<UrunModel>();

            foreach (var item in list)
            {
                var obj = new UrunModel();
                obj.KATEGORIID = item.KATEGORIID;
                obj.KATEGORIAD = item.KATEGORIADI;
                obj.URUNFIYAT = item.URUNFIYAT;
                obj.ID = item.ID;
                obj.URUNOEMKODU = item.URUNOEMKOD;
                obj.URUNKODU = item.URUNKODU;
                obj.MARKAADI = item.MARKAADI;
                obj.URUNACIKLAMA = item.URUNACIKLAMA;
                obj.URUNAD = item.URUNAD;
                obj.ISAPPROVED = item.ISAPPROVED;
                obj.CREATEDDATE = item.CREATEDDATE;
                obj.UPDATEDDATE = item.UPDATEDDATE;
                obj.URUNILKRESIM = item.URUNILKRESIM;
                obj.URUNILKRESIMYOL = item.URUNILKRESIMYOL;
                model.Add(obj);

            }
            return View(model);
        }
    
        [HttpPost]
        [Route("urun-sil/{id:int}")]
        public JsonResult ProductDelete(int id)
        {
            var model = db.Urun.SingleOrDefault(i => i.ID == id);
            if (model != null)
            {
                var obj = db.UrunResim.Where(i => i.URUNID == model.ID);
                db.UrunResim.RemoveRange(obj);
                db.Urun.Remove(model);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("urun-detay/{id:int}")]
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            var item = db.vw_UrunList.SingleOrDefault(i => i.ID == id);
            TempData["UrunId"] = id;

            var obj = new UrunModel();
            obj.ID = item.ID;
            obj.KATEGORIAD = item.KATEGORIADI;
            obj.MARKAADI = item.MARKAADI;
            obj.URUNAD = item.URUNAD;
            obj.URUNACIKLAMA = item.URUNACIKLAMA;
            obj.URUNOEMKODU = item.URUNOEMKOD;
            obj.URUNKODU = item.URUNKODU;
            obj.URUNFIYAT = item.URUNFIYAT;
            obj.CREATEDDATE = item.CREATEDDATE;
            obj.UPDATEDDATE = item.UPDATEDDATE;
            obj.URUNILKRESIMYOL = item.URUNILKRESIMYOL;
            obj.URUNILKRESIM = item.URUNILKRESIM;
            obj.ISAPPROVED = item.ISAPPROVED;

            if (obj != null)
            {
                return View(obj);
            }

            return View();
        }
        public ActionResult PartialProductImage()
        {
            int id = Convert.ToInt32(TempData["UrunId"]);
            var model = new List<UrunResimModel>();
            var list = db.UrunResim.Where(i => i.URUNID == id).ToList();
            foreach (var item in list)
            {
                var obj = new UrunResimModel();
                obj.ID = item.ID;
                obj.RESIM = item.RESIM;
                obj.RESIMYOL = item.RESIMYOL;
                model.Add(obj);

            }
            return PartialView("PartialProductImage", model);
        }

        [Route("urun-guncelle/{id:int}")]
        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            ViewBag.Kategoriler = new SelectList(db.Kategori, "ID", "KATEGORIADI");

            ViewBag.Markalar = new SelectList(db.Marka, "ID", "MARKAADI");
            var item = db.Urun.SingleOrDefault(i => i.ID == id);
            TempData["UrunId"] = id;

            var obj = new UrunModel();
            obj.ID = item.ID;
            obj.KATEGORIAD = item.Kategori.KATEGORIADI;
            obj.URUNAD = item.URUNAD;
            obj.MARKAADI = item.Marka.MARKAADI;
            obj.URUNACIKLAMA = item.URUNACIKLAMA;
            obj.URUNFIYAT = item.URUNFIYAT;
            obj.URUNOEMKODU = item.URUNOEMKOD;
            obj.URUNKODU = item.URUNKODU;
            obj.URUNILKRESIMYOL = item.URUNILKRESIMYOL;
            obj.URUNILKRESIM = item.URUNILKRESIM;
            obj.ISAPPROVED = item.ISAPPROVED;

            if (obj != null)
            {
                return View(obj);
            }
            return View();
        }
        [Route("urun-guncelle/{id:int}")]
        [HttpPost]
        public ActionResult ProductUpdate(UrunModel model)
        {
            var file = model.URUNRESIMDOSYASI;
            byte[] Imagebyte = null;
            if (file != null)
            {

                file.SaveAs(Server.MapPath("~/Content/ProductImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);

            }

            int id = Convert.ToInt32(TempData["UrunId"]);
            var item = db.Urun.SingleOrDefault(i => i.ID == id);
            item.URUNKODU = model.URUNKODU;
            item.URUNOEMKOD = model.URUNOEMKODU;
            item.URUNACIKLAMA = model.URUNACIKLAMA;
            item.URUNFIYAT = model.URUNFIYAT;
            item.KATEGORIID = model.KATEGORIID;
            item.UPDATEDDATE = DateTime.Now;
            item.URUNMARKA = model.MARKAID;
            item.URUNILKRESIM = Imagebyte;
            item.URUNILKRESIMYOL = "~/Content/ProductImage/" + file.FileName;
            db.SaveChanges();
            return Redirect("/urun/urun-liste");
        }

        public JsonResult CorrectActive(int id)
        {
            var model = db.Urun.FirstOrDefault(i => i.ID == id);
            if (model!=null)
            {
                if (model.ISAPPROVED == true)
                {
                    model.ISAPPROVED = false;
                    db.SaveChanges();
                }
                else
                {
                    model.ISAPPROVED = true;
                    db.SaveChanges();
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);

        }

    }
}