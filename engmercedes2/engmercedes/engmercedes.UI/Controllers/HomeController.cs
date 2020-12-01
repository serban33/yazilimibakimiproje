using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using engmercedes.UI.Entity;
using engmercedes.UI.Models;

namespace engmercedes.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        public ActionResult Index()
        {
            var obj = db.Ayarlar.FirstOrDefault();
            if (obj != null)
            {

                TempData["SiteBaslik"] = obj.SITEBASLIK;
                TempData["SiteAciklama"] = obj.SITEACIKLAMA;
                TempData["SiteMail"] = obj.SITEMAIL;
                TempData["Telefon1"] = obj.SITETELEFON;
                TempData["Telefon2"] = obj.SITETELEFON2;
                TempData["SiteAdres"] = obj.SITEADRES;
            }


            return View();
        }
        [Route("Hakkimizda")]
        public ActionResult About()
        {
            var model = db.Sirket.FirstOrDefault();

            if (model != null)
            {
                var obj = new SirketModel();
                obj.MISYONUMUZ = model.MISYONUMUZ;
                obj.HAKKIMIZDA = model.HAKKIMIZDA;
                obj.VIZYONUMUZ = model.VIZYONUMUZ;
                obj.RESIM1 = model.RESIM1;
                obj.RESIM2 = model.RESIM2;
                obj.RESIM3 = model.RESIM3;
                return View(obj);

            }
            return View();
        }
        [Route("Iletisim")]
        [HttpGet]
        public ActionResult Contact()
        {
            var obj = db.Ayarlar.FirstOrDefault();
            if (obj != null)
            {

             
                TempData["SiteMail"] = obj.SITEMAIL;
                TempData["Telefon1"] = obj.SITETELEFON;
                TempData["Telefon2"] = obj.SITETELEFON2;
                TempData["SiteAdres"] = obj.SITEADRES;
            }

            return View();
        }

        [HttpPost]
        [Route("Iletisim")]
        public async Task<JsonResult> Contact(MailModel model)
        {
            SendMailModel sendMail = new SendMailModel();
            try
            {
                bool result = sendMail.Message(model);
                if (result == true)
                {

                    return Json(new { response = "success", responseText = "success" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                return Json(new { success = false, responseText = "Suanlık Mesajınız Gönderilmiyor Lütfen Tekrar Deneyiniz." }, JsonRequestBehavior.AllowGet);
            }


            return Json(new { success = false, responseText = "Mail Sunucusuna Ulaşılamadı." }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PartialSlider()
        {
            var model = new List<SliderModel>();
            var list = db.Slider.ToList();
            foreach (var item in list)
            {
                var obj = new SliderModel();
                obj.ID = item.ID;
                obj.SLIDERAD = item.SLIDERAD;
                obj.SLIDERIMAGE = item.SLIDERIMAGE;
                obj.SLIDERYOL = item.SLIDERYOL;
                model.Add(obj);

            }
            return PartialView("PartialSlider", model);
        }
        public ActionResult PartialTop5Product()
        {
            var model = new List<UrunModel>();
            var list = (from u in db.Urun where u.ISAPPROVED == true orderby u.ID select u).Take(5);
            foreach (var item in list)
            {
                var obj = new UrunModel();
                obj.URUNAD = item.URUNAD;
                obj.URUNFIYAT = item.URUNFIYAT;
                obj.URUNRESIM = item.URUNILKRESIM;
                obj.ID = item.ID;
                model.Add(obj);

            }

            return PartialView("PartialTop5Product", model);
        }
        public ActionResult PartialPromo()
        {
            var model = new ReklamModel();
            var list =
                (from u in db.Reklam orderby u.ID select u).Take(3);
            foreach (var item in list)
            {
                model.REKLAMRESIM1 = item.REKLAMRESIM1;
                model.REKLAMRESIM2 = item.REKLAMRESIM2;
                model.REKLAMRESIM3 = item.REKLAMRESIM3;
                model.ID = item.ID;


            }
 
            return PartialView("PartialPromo",model);
        }
    }
}