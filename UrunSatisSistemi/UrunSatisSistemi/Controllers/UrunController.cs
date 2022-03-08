using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        public ActionResult AnaUrun()
        {
            // Modeldeki bağlantımızın bulunduğu Baglanti sınıfı aracılığı ile tablomuza eriştik
            // Ve listeleme işlemi yaptık
            var x = Baglanti.db.TUrun.ToList();
            return View(x);
        }

        [HttpGet] // Sayfa yüklendiğinde ekran gelsin diye GET attribute ile YeniUrun methodumuzu oluşturduk
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from x in Baglanti.db.TKategori.ToList() select new SelectListItem { Text = x.Kategori, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr = deger; // Kategori bilgilerimizin sayfada listelenebilmesi için DropDownListe özel komutumuzu Arayüze Viewbag aracılığı ile taşıdık.
            return View();
        }

        [HttpPost] // Butona basınca bir şeyleri tetiklemek için POST attribute ile YeniUrun methodumuzu oluşturduk
        public ActionResult YeniUrun(TUrun u)
        {
            Baglanti.db.TUrun.Add(u); // Urun tablosuna ilgili değerleri eklettikten sonra Anasayfaya geri döndürdük
            Baglanti.db.SaveChanges(); // Değişiklikleri kaydederek veritabanına eklemeyi sağlıyoruz
            return RedirectToAction("AnaUrun");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            var x2 = Baglanti.db.TUrun.Find(id); // Guncelleme sayfasına ilgili değerlerin getirilmesi için Tabloda taşınan IDyi buluyoruz ve geri döndürüyoruz

            List<SelectListItem> deger = (from x in Baglanti.db.TKategori.ToList() select new SelectListItem { Text = x.Kategori, Value = x.KategoriID.ToString() }).ToList();
            ViewBag.dgr = deger;

            return View(x2);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(TUrun t)
        {
            var kategori = Baglanti.db.TKategori.Where(c => c.KategoriID == t.TKategori.KategoriID).FirstOrDefault(); // Dropdownda seçtiğimiz değerin ID sini alıp Urun tablosundaki kategoriye ekliyoruz
            var x = Baglanti.db.TUrun.Find(t.UrunID);
            x.Kod = t.Kod; // Bulunan ID ye sayfadan gelen verileri atıyoruz ve değişiklikleri kaydediyoruz
            x.Urun = t.Urun; // Guncelleme işlemi sağlanmış oluyor
            x.Kategori = kategori.KategoriID;
            x.Fiyat = t.Fiyat;
            x.Stok = t.Stok;  // Sayfadan gelen ID değerine göre aldığımız satır bilgilerini yine Sayfadan gelen yeni değerlerimizle değiştirmek için atama yapıyoruz
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaUrun");
        }
        public ActionResult UrunSil(int id)
        {
            var x = Baglanti.db.TUrun.Find(id); // İlgili ID yi yakaladıktan sonra veritabanından siliyoruz.
            Baglanti.db.TUrun.Remove(x);
            Baglanti.db.SaveChanges(); // Değişiklikleri kaydedince veritabanından silme işlemi bitmiş oluyor
            return RedirectToAction("AnaUrun");
        }
    }
}