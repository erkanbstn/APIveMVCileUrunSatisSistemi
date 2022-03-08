using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        // GET: Sepet
        public ActionResult AnaSepet()
        {
            var x = Baglanti.db.TSepet.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniSepet()
        {
            List<SelectListItem> deger = (from x in Baglanti.db.TMusteri.ToList() select new SelectListItem { Text = x.Musteri, Value = x.MusteriID.ToString() }).ToList();
            ViewBag.dgr = deger;
            List<SelectListItem> deger2 = (from x in Baglanti.db.TUrun.ToList() select new SelectListItem { Text = x.Urun, Value = x.UrunID.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSepet(TSepet t)
        {
            Baglanti.db.TSepet.Add(t);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSepet");
        }
        [HttpGet]
        public ActionResult SepetGuncelle(int id)
        {
            List<SelectListItem> deger = (from x in Baglanti.db.TMusteri.ToList() select new SelectListItem { Text = x.Musteri, Value = x.MusteriID.ToString() }).ToList();
            ViewBag.dgr = deger;
            List<SelectListItem> deger2 = (from x in Baglanti.db.TUrun.ToList() select new SelectListItem { Text = x.Urun, Value = x.UrunID.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            var x2 = Baglanti.db.TSepet.Find(id);
            return View(x2);
        }
        [HttpPost]
        public ActionResult SepetGuncelle(TSepet m)
        {
            var x = Baglanti.db.TSepet.Find(m.SepetID);
            var urun = Baglanti.db.TUrun.Where(c => c.UrunID == m.TUrun.UrunID).FirstOrDefault();
            var musteri = Baglanti.db.TMusteri.Where(c => c.MusteriID == m.TMusteri.MusteriID).FirstOrDefault();
            x.Urun = urun.UrunID;
            x.Musteri = musteri.MusteriID;
            x.Adet = m.Adet;
            x.ToplamMiktar = m.ToplamMiktar;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSepet");
        }
        public ActionResult SepetSil(int id)
        {
            var x = Baglanti.db.TSepet.Find(id);
            Baglanti.db.TSepet.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSepet");
        }
    }
}