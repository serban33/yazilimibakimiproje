using engmercedes.admin.Entity;
using engmercedes.admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("site-ayarlari")]
    [Authorize]
    public class SettingController : Controller
    {
        ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("ayar")]
        public ActionResult Setting()
        {
            return View();
        }
        [HttpPost]
        [Route("ayar")]
        public ActionResult Setting(SiteAyarModel ayar)
        {
            var model = db.Ayarlar.FirstOrDefault();
            if (model==null)
            {
                var file = ayar.LOGORESIM;
                byte[] Imagebyte = null;
                if (file != null)
                {
                    file.SaveAs(Server.MapPath("~/Content/Logo/" + file.FileName));
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    Imagebyte = reader.ReadBytes(file.ContentLength);
                    Ayarlar dbAyarlar = new Ayarlar();
                    dbAyarlar.CREATEDDATE = DateTime.Now;
                    dbAyarlar.SITEACIKLAMA = ayar.SITEACIKLAMA;
                    dbAyarlar.SITEBASLIK = ayar.SITEBASLIK;
                    dbAyarlar.SITEMAIL = ayar.SITEMAIL;
                    dbAyarlar.SITETELEFON = ayar.SITETELEFON;
                    dbAyarlar.SITETELEFON2 = ayar.SITETELEFON2;
                    dbAyarlar.SITEADRES = ayar.SITEADRES;
                    dbAyarlar.SITELOGO = Imagebyte;
                    dbAyarlar.SITELOGOYOL = "~/Content/Logo/" + file.FileName;
                    db.Ayarlar.Add(dbAyarlar);
                    db.SaveChanges();
                }
                return View();
            }
            else
            {
                var file = ayar.LOGORESIM;
                byte[] Imagebyte = null;
                if (file != null)
                {
                    file.SaveAs(Server.MapPath("~/Content/Logo/" + file.FileName));
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    Imagebyte = reader.ReadBytes(file.ContentLength);
                    model.CREATEDDATE = DateTime.Now;
                    model.SITEACIKLAMA = ayar.SITEACIKLAMA;
                    model.SITEBASLIK = ayar.SITEBASLIK;
                    model.SITEMAIL = ayar.SITEMAIL;
                    model.SITELOGO = Imagebyte;
                    model.SITETELEFON = ayar.SITETELEFON;
                    model.SITETELEFON2 = ayar.SITETELEFON2;
                    model.SITEADRES = ayar.SITEADRES;
                    model.SITELOGOYOL = "~/Content/Logo/" + "newLogo"+file.FileName;
                    db.SaveChanges();
                }

                return View();
            }
            
        }

        [HttpGet]
        [Route("detay")]
        public ActionResult SettingDetail()
        {
            var model = db.Ayarlar.FirstOrDefault();
            if (model!=null)
            {
                SiteAyarModel obj = new SiteAyarModel
                {
                    ID = model.ID,
                    CREATEDDATE = model.CREATEDDATE,
                    SITEACIKLAMA = model.SITEACIKLAMA,
                    SITELOGO = model.SITELOGO,
                    SITETELEFON2 = model.SITETELEFON2,
                    SITETELEFON = model.SITETELEFON,
                    SITEADRES = model.SITEADRES,
                    SITEBASLIK = model.SITEBASLIK,
                    SITELOGOYOL = model.SITELOGOYOL,
                    SITEMAIL = model.SITEMAIL
                };
                return View(obj);
            }

            return View();
        }
        [HttpPost]
        [Route("sil/{id:int}")]
        public JsonResult ProductDelete(int id)
        {
            var model = db.Ayarlar.FirstOrDefault(i => i.ID == id);
            if (model != null)
            {
                db.Ayarlar.Remove(model);
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
