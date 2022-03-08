using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        // GET: Musteri
        public ActionResult AnaMusteri()
        {
            var x = Baglanti.db.TMusteri.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TMusteri t)
        {
            Baglanti.db.TMusteri.Add(t);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaMusteri");
        }
        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var x = Baglanti.db.TMusteri.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(TMusteri m)
        {
            var x = Baglanti.db.TMusteri.Find(m.MusteriID);
            x.Musteri = m.Musteri;
            x.Cinsiyet = m.Cinsiyet;
            x.DogumTarih = m.DogumTarih;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaMusteri");
        }
        public ActionResult MusteriSil(int id)
        {
            var x = Baglanti.db.TMusteri.Find(id);
            Baglanti.db.TMusteri.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaMusteri");
        }
    }
}