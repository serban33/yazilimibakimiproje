using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using engmercedes.admin.Entity;
using engmercedes.admin.Models;

namespace engmercedes.admin.Controllers
{
    public class LoginController : Controller
    {
        ENGMERCEDESEntities db = new ENGMERCEDESEntities();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(KullaniciModel user)
        {
            if (ModelState.IsValid)
            {
                var IsValidUser = db.Kullanici.
                    FirstOrDefault(i => i.KULLANICIADI == user.KULLANICIADI 
                                        && i.KULLANICISIFRE == user.KULLANICISIFRE);

                if (IsValidUser!=null)
                {
                     
                    db.LogInDate(1, DateTime.Now);
                    FormsAuthentication.SetAuthCookie(user.KULLANICIADI, false);
                    Thread.Sleep(2000);
                    return RedirectToAction("Index", "Home");
                }
            }
            Thread.Sleep(1000);
            ViewBag.LoginError = "Kullanıcı Adı veya Şifre Hatalı!";
            return View(user);
        }
        [HttpGet]
        [Route("Cikis")]
        public ActionResult LogOut()
        {
            
            FormsAuthentication.SignOut();
            Session.Abandon();
            db.LogOutDate(1, DateTime.Now);
            Thread.Sleep(1000);
            return View("Login");
        }
    }
}
