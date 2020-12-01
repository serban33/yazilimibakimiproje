using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using engmercedes.admin.Models;

namespace engmercedes.admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            GetData();

            return View();
        }

        public void GetData()
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal Euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
            decimal dolarBuying = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", "USD")).InnerText.Replace('.', ','));
            decimal EuroBuying = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", "EUR")).InnerText.Replace('.', ','));
            TempData["Dolar"] = dolar.ToString();
            TempData["Euro"] = Euro.ToString();
            TempData["DolarBuying"] = dolarBuying.ToString();
            TempData["EuroBuying"] = EuroBuying.ToString();
        }

    }
}