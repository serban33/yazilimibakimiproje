using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using engmercedes.admin.Entity;
using engmercedes.admin.Models;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("reklam")]
    [Authorize]
    public class PromoController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("reklam-ekle")]
        public ActionResult PromoAdd()
        {
            var obj = db.Reklam.FirstOrDefault();
            if (obj!=null)
            {
                ViewBag.Hata = "Reklam Ekleme İşleminize Devam Edebilmek İçin Lütfen Mevcut Reklamınızı Siliniz";
            }
            return View();
        }

        [HttpPost]
        [Route("reklam-ekle")]
        public ActionResult PromoAdd(ReklamModel model)
        {
            var file = model.RESIMDOSYASI1;
            var file2 = model.RESIMDOSYASI2;
            var file3 = model.RESIMDOSYASI3;
            byte[] Imagebyte = null;
            byte[] Imagebyte2 = null;
            byte[] Imagebyte3 = null;
            if (file != null)
            {

                file.SaveAs(Server.MapPath("~/Content/PromoImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);

            }
            if (file2 != null)
            {

                file2.SaveAs(Server.MapPath("~/Content/PromoImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file2.InputStream);
                Imagebyte2 = reader.ReadBytes(file2.ContentLength);

            }
            if (file3 != null)
            {

                file3.SaveAs(Server.MapPath("~/Content/PromoImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file3.InputStream);
                Imagebyte3 = reader.ReadBytes(file3.ContentLength);

            }
            model.CREATEDDATE = DateTime.Now;
            using (var context = new ENGMERCEDESEntities())
            {

                context.Reklam.Add(new Reklam
                {
                    CREATEDDATE = model.CREATEDDATE,

                    REKLAMRESIM1 = Imagebyte,
                    REKLAMRESIM2= Imagebyte2,
                    REKLAMRESIM3 = Imagebyte3,
                    REKLAMADI = model.REKLAMADI,
                    

                });
                context.SaveChanges();
            }
            Thread.Sleep(2000);
            return Redirect("/reklam/reklam-liste");
        }
        [Route("reklam-liste")]
        public ActionResult PromoList()
        {
            var model = db.Reklam.ToList();
            var obj = new List<ReklamModel>();
            foreach (var item in model)
            {
                var promo=new ReklamModel();
                promo.REKLAMRESIM1 = item.REKLAMRESIM1;
                promo.REKLAMRESIM2 = item.REKLAMRESIM2;
                promo.REKLAMRESIM3 = item.REKLAMRESIM3;
                promo.CREATEDDATE = item.CREATEDDATE;
                promo.ID = item.ID;
                obj.Add(promo);

            }

            return View(obj);
        }
        [HttpPost]
        public JsonResult PromoDelete(int id)
        {
            var model = db.Reklam.SingleOrDefault(i => i.ID == id);
            if (model != null)
            {
                db.Reklam.Remove(model);
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