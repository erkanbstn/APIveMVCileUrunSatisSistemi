using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    [AllowAnonymous]
    public class GirisController : Controller
    {
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TAdmin u)
        {
            var uye = Baglanti.db.TAdmin.FirstOrDefault(c => c.Kullanici == u.Kullanici && c.Sifre == u.Sifre);
            if (uye != null)
            {
                FormsAuthentication.SetAuthCookie(uye.Kullanici, false);
                return RedirectToAction("AnaMusteri", "Musteri");
            }
            else
            {
                return View();
            }
        }
    }
}