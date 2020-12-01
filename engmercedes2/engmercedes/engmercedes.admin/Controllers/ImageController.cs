using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using engmercedes.admin.Entity;
using engmercedes.admin.Models;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("resim")]
    [Authorize]
    public class ImageController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [Route("resim-ekle")]
        [HttpGet]
        public ActionResult ImageAdd()
        {

            return View();
        }
        [Route("resim-ekle")]
        [HttpPost]
        public ActionResult ImageAdd(UrunResimModel model)
        {
            UrunResim resim=new UrunResim();
             
            
            try
            {
                foreach (var item in model.RESIMDOSYASI)
                {
                    if (item.ContentLength>0)
                    {
                        
                        var image = Path.GetFileName(item.FileName);
                        byte[] data;
                        using (Stream inputStream = item.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        var path = Path.Combine(Server.MapPath("~/Content/Product"), image);
                        item.SaveAs(path);
                        resim.RESIM = data;
                        resim.RESIMYOL = "~/Content/Product/"+image;
                        resim.CREATEDDATE=DateTime.Now;
                        resim.RESIMAD = image;
                        resim.URUNID = Convert.ToInt32(TempData["ID"]);
                        db.UrunResim.Add(resim);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
               
            }
            int id= Convert.ToInt32(TempData["ID"]);
            return Redirect("/resim/resim-liste/"+id);
        }


        [Route("resim-liste/{id:int}")]
        [HttpGet]
        public ActionResult ImageList(int id)
        {
            TempData["ID"] = id;
            var model = db.UrunResim.Where(i => i.URUNID == id).Select(p => new UrunResimModel
            {
                RESIMAD = p.RESIMAD,
                RESIM = p.RESIM,
                RESIMYOL = p.RESIMYOL,
                CREATEDDATE = p.CREATEDDATE,
                UPDATEDDATE = p.UPDATEDDATE,
                ID = p.ID
            }).ToList();
            if (model!=null)
            {
                return View(model);
            }
            return View();
        }
        [HttpPost]
        [Route("resim-sil/{id:int}")]
        public JsonResult ImageDelete(int id)
        {
            var model = db.UrunResim.SingleOrDefault(i => i.ID == id);
            if (model != null)
            {
                db.UrunResim.Remove(model);
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