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
    [RoutePrefix("sirket")]
    [Authorize]
    public class CompanyController : Controller
    {
        private ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        [HttpGet]
        [Route("sirket-bilgisi-ekle")]
        public ActionResult CompanyAdd()
        {
            return View();
        }
        [HttpPost]
        [Route("sirket-bilgisi-ekle")]
        public ActionResult CompanyAdd(SirketModel model)
        {
            var file = model.RESIMDOSYASI1;
            var file2 = model.RESIMDOSYASI2;
            var file3 = model.RESIMDOSYASI3;
            byte[] Imagebyte = null;
            byte[] Imagebyte2 = null;
            byte[] Imagebyte3 = null;
            if (file != null)
            {

                file.SaveAs(Server.MapPath("~/Content/CompanyImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                Imagebyte = reader.ReadBytes(file.ContentLength);

            }
            if (file2 != null)
            {

                file2.SaveAs(Server.MapPath("~/Content/CompanyImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file2.InputStream);
                Imagebyte2 = reader.ReadBytes(file2.ContentLength);

            }
            if (file3 != null)
            {

                file3.SaveAs(Server.MapPath("~/Content/CompanyImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file3.InputStream);
                Imagebyte3 = reader.ReadBytes(file3.ContentLength);

            }
            using (var context = new ENGMERCEDESEntities())
            {

                context.Sirket.Add(new Sirket
                {
                    HAKKIMIZDA = model.HAKKIMIZDA,
                    MISYONUMUZ = model.MISYONUMUZ,
                    VIZYONUMUZ = model.VIZYONUMUZ,
                    RESIM1 = Imagebyte,
                    RESIM2 = Imagebyte2,
                    RESIM3 = Imagebyte3
                });
                context.SaveChanges();
            }
            Thread.Sleep(2000);
            return Redirect("/sirket/sirket-detay");
        }
        [Route("sirket-detay")]
        public ActionResult CompanyDetail()
        {
            var model = db.Sirket.FirstOrDefault();
            var obj=new SirketModel();
            if (model!=null)
            {
                obj.RESIM1 = model.RESIM1;
                obj.RESIM2 = model.RESIM2;
                obj.RESIM3 = model.RESIM3;
                obj.HAKKIMIZDA = model.HAKKIMIZDA;
                obj.MISYONUMUZ = model.MISYONUMUZ;
                obj.VIZYONUMUZ = model.VIZYONUMUZ;
                return View(obj);
            }
            return View();
        }
    }
}