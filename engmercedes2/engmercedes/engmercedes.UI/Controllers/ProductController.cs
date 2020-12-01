using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.UI.Entity;
using engmercedes.UI.Models;
using PagedList;

namespace engmercedes.UI.Controllers
{
    public class ProductController : Controller
    {
        ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [Route("Urunler")]
        public ActionResult ProductList(int page = 1, int pageSize = 10)
        {
            var list = db.Urun.ToList();
            var model = new List<UrunModel>();
            foreach (var item in list)
            {
                var obj = new UrunModel();
                obj.URUNRESIM = item.URUNILKRESIM;
                obj.URUNACIKLAMA = item.URUNACIKLAMA;
                obj.URUNAD = item.URUNAD;
                obj.ID = item.ID;
                obj.URUNOEMKODU = item.URUNOEMKOD;
                obj.URUNKODU = item.URUNKODU;
                obj.MARKAADI = item.Marka.MARKAADI;
                obj.ISAPPROVED = item.ISAPPROVED;
                obj.URUNFIYAT = item.URUNFIYAT;

                model.Add(obj);
            }
            PagedList<UrunModel> pagedListItem = new PagedList<UrunModel>(model, page, pageSize);
            return View(pagedListItem);
        }
        [Route("Urunler/{catid:int}")]
        public ActionResult ProductListWithCat(int catid, int page = 1, int pageSize = 10)
        {
            var list = db.Urun.Where(i => i.KATEGORIID == catid).ToList();
            var model = new List<UrunModel>();
            foreach (var item in list)
            {
                var obj = new UrunModel();
                obj.URUNRESIM = item.URUNILKRESIM;
                obj.URUNACIKLAMA = item.URUNACIKLAMA;
                obj.URUNAD = item.URUNAD;
                obj.ID = item.ID;
                obj.URUNOEMKODU = item.URUNOEMKOD;
                obj.URUNKODU = item.URUNKODU;
                obj.MARKAADI = item.Marka.MARKAADI;
                obj.ISAPPROVED = item.ISAPPROVED;
                obj.URUNFIYAT = item.URUNFIYAT;

                model.Add(obj);
            }
            PagedList<UrunModel> pagedListItem = new PagedList<UrunModel>(model, page, pageSize);
            return View(pagedListItem);
        }
        [HttpPost]
        public ActionResult ProductListProductCode(string searchString, int page = 1, int pageSize = 10)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                var list = db.Urun.Where(i => i.URUNOEMKOD.Contains(searchString) || i.URUNKODU.Contains(searchString)).ToList();
                var model = new List<UrunModel>();
                foreach (var item in list)
                {
                    var obj = new UrunModel();
                    obj.URUNRESIM = item.URUNILKRESIM;
                    obj.URUNACIKLAMA = item.URUNACIKLAMA;
                    obj.URUNAD = item.URUNAD;
                    obj.ID = item.ID;
                    obj.URUNOEMKODU = item.URUNOEMKOD;
                    obj.URUNKODU = item.URUNKODU;
                    obj.MARKAADI = item.Marka.MARKAADI;
                    obj.ISAPPROVED = item.ISAPPROVED;
                    obj.URUNFIYAT = item.URUNFIYAT;

                    model.Add(obj);
                }

                if (model==null || model.Count()==0)
                {
                    TempData["HataMesajı"]= "Aradagığınız kriterde ürün bulunamadı! Lütfen Urun Kodunu ya da OEM Kodunu Düzgün Girdiğinizden Emin Olun!"; 
                }
                PagedList<UrunModel> pagedListItem = new PagedList<UrunModel>(model, page, pageSize);
                return View(pagedListItem);
            }

            return Redirect("/urunler");
        }
        [Route("urun/{urunad}/{id:int}")]
        public ActionResult ProductDetail(int id)
        {
            var model = db.Urun.SingleOrDefault(i => i.ID == id);
            TempData["UrunId"] = id;
            if (model != null)
            {
                var obj = new UrunDetayModel();
                obj.URUNFIYAT = model.URUNFIYAT;
                obj.ID = model.ID;
                obj.URUNOEMKODU = model.URUNOEMKOD;
                obj.URUNKODU = model.URUNKODU;
                obj.KATEGORIADI = model.Kategori.KATEGORIADI;
                obj.ISAPPROVED = model.ISAPPROVED;
                obj.URUNAD = model.URUNAD;
                obj.URUNACIKLAMA = model.URUNACIKLAMA;
                obj.URUNILKRESIM = model.URUNILKRESIM;
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

        public ActionResult PartialProductImages()
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
            return PartialView("PartialProductImages", model);
        }
    }
}