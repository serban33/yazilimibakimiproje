using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace engmercedes.UI.Controllers
{
    [RoutePrefix("error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public ActionResult NotFound(string aspxerrorpath)
        {
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
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                Response.StatusCode = 500;
                return RedirectToAction("NotWorking");
            }

            return View();
        }
    }
}