using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engmercedes.admin.Controllers
{
    [RoutePrefix("error")]
    public class ErrorController : Controller
    {
        [Route("503")]
        public ActionResult ServiceNot(string aspxerrorpath)
        {
            ViewBag.ErrorMessage = "Şuan Servis Dışı.Lütfen Tekrar Deneyiniz";
            ViewBag.ErrorCode = 503;
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                Response.StatusCode = 503;
                
                return RedirectToAction("ServiceNot");
            }

            return View();
        }
        [Route("404")]
        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewBag.ErrorCode = 404;
            ViewBag.ErrorMessage = "İstediğiniz sayfa bulunamadı";
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                Response.StatusCode = 404;
                
                return RedirectToAction("NotFound");
            }

            return View();
        }
        [Route("500")]
        public ActionResult NotWorking(string aspxerrorpath)
        {
            ViewBag.ErrorCode = 500;
            ViewBag.ErrorMessage = "Beklenmedik Bir Hata Oluştu.Lütfen Tekrar Deneyiniz";
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                Response.StatusCode = 500;
           
                return RedirectToAction("NotWorking");
            }

            return View();
        }
        [Route("403")]
        public ActionResult NotForbidden(string aspxerrorpath)
        {
            ViewBag.ErrorCode = 403;
            ViewBag.ErrorMessage = "Bu sayfaya erişiminz yasak";
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                Response.StatusCode = 403;
              
                return RedirectToAction("NotForbidden");
            }

            return View();
        }
    }
}