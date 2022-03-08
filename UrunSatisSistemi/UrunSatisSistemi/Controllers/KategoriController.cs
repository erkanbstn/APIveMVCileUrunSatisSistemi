using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult AnaKategori()
        {
            var x = Baglanti.db.TKategori.ToList();
            return View(x);
        }
        public PartialViewResult KategoriPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TKategori t)
        {
            Baglanti.db.TKategori.Add(t);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var x = Baglanti.db.TKategori.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(TKategori m)
        {
            var x = Baglanti.db.TKategori.Find(m.KategoriID);
            x.Kategori = m.Kategori;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }
        public ActionResult KategoriSil(int id)
        {
            var x = Baglanti.db.TKategori.Find(id);
            Baglanti.db.TKategori.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaKategori");
        }
    }
}