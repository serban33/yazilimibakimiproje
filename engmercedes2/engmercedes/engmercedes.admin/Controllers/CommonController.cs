using engmercedes.admin.Entity;
using engmercedes.admin.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("genel")]
    [Authorize]
    public class CommonController : Controller
    {

        ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [Route("slider-liste")]
        public ActionResult SliderList()
        {
            var list = db.Slider.ToList();
            var model = new List<SliderModel>();

            foreach (var item in list)
            {
                var obj = new SliderModel();
                obj.CREATEDDATE = item.CREATEDDATE;
                obj.ISAPPROVED = item.ISAPPROVED;
                obj.SLIDERIMAGE = item.SLIDERIMAGE;
                obj.SLIDERYOL = item.SLIDERYOL;
                obj.SLIDERAD = item.SLIDERAD;
                obj.ID = item.ID;
                obj.UPDATEDDATE = item.UPDATEDDATE;
                model.Add(obj);
            }
            return View(model);
        }
        [Route("slider-ekle")]
        [HttpGet]
        public ActionResult SliderAdd()
        {
            return View();
        }
        [Route("slider-ekle")]
        [HttpPost]
        public ActionResult SliderAdd(SliderModel slider)
        {

            var file = slider.RESIMDOSYASI;
            byte[] Imagebyte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("~/Content/UploadImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);
                Slider db_slider = new Slider();
                db_slider.CREATEDDATE = DateTime.Now;
                db_slider.SLIDERAD = file.FileName;
                db_slider.ISAPPROVED = true;
                db_slider.SLIDERIMAGE = Imagebyte;
                db_slider.SLIDERYOL = "~/Content/UploadImage/" + file.FileName;
                db.Slider.Add(db_slider);
                db.SaveChanges();
            }

            return Redirect("/genel/slider-liste");
        }
        [HttpPost]
        [Route("slider-sil/{id:int}")]
        public JsonResult SliderDelete(int id)
        {
            var model = db.Slider.SingleOrDefault(i => i.ID == id);
            if (model != null)
            {
                db.Slider.Remove(model);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        [Route("slider-guncelle/{id:int}")]
        public ActionResult SliderUpdate(int ID)
        {
            var obj = db.Slider.FirstOrDefault(i => i.ID == ID);
            SliderModel model=new SliderModel();
            model.ISAPPROVED = obj.ISAPPROVED;
            model.SLIDERAD = obj.SLIDERAD;
            model.SLIDERIMAGE = obj.SLIDERIMAGE;
            model.SLIDERYOL = obj.SLIDERYOL;
            return View(model);
        }
        [HttpPost]
        public ActionResult SliderUpdate(SliderModel model)
        {
            return View();
        }
        
         
        [Route("sosyal-medya")]
        [HttpGet]
        public ActionResult SocialMedia()
        {
            var obj = db.SosyalMedya.FirstOrDefault();
            if (obj != null)
            {
                var sosyal = new SosyalMedyaModel
                {
                    FACEBOOK = obj.FACEBOOK,
                    INSTAGRAM = obj.INSTAGRAM,
                    LINKEDIN = obj.LINKEDIN,
                    TWITTER = obj.TWITTER,
                    WHATSAPP = obj.WHATSAPP,
                    YOUTUBE = obj.YOUTUBE
                };
                return View(sosyal);
            }

            return View();
        }
        [Route("sosyal-medya-ekle")]
        [HttpPost]
        public ActionResult SocialMediaAdd(SosyalMedyaModel model)
        {
            SosyalMedya medya=new SosyalMedya();
            medya.FACEBOOK = model.FACEBOOK;
            medya.INSTAGRAM = model.INSTAGRAM;
            medya.LINKEDIN = model.LINKEDIN;
            medya.TWITTER = model.TWITTER;
            medya.WHATSAPP = model.WHATSAPP;
            medya.YOUTUBE = model.YOUTUBE;
            db.SosyalMedya.Add(medya);
            db.SaveChangesAsync();

            return View();
        }
    }
}
