using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemiAPI.Controllers
{
    public class UrunController : ApiController
    {
        // Entity Framework Modelimizi kullanabilmek için Modelden bir nesne türetiyoruz
        UrunSatisDBEntities db = new UrunSatisDBEntities();
        public string Post(TUrun t) // POST API EKLEME İŞLEMİDİR
        {
            // ENTİTY FRAMEWORK kullanarak İlgili tablomuza ekleme yapıyoruz
            db.TUrun.Add(t);
            db.SaveChanges();  // Değişiklikleri kaydederek veritabanına kaydedilmesini sağlıyoruz
            return "Eklendi"; // Methodun dönüş tipi String olduğundan string bir değer döndürüyoruz
        }
        // Normal listeleme
        public IEnumerable<TUrun> Get()  // GET API LİSTELEME İŞLEMİDİR
        {
            // İlgili tabloyu Listeleme
            return Baglanti.db.TUrun.ToList();
        }
        // Parametreli listeleme
        public TUrun Get(int id) // GET API LİSTELEME İŞLEMİDİR
        {
            // Methoda verdiğimiz parametreyi listeletiyoruz 
            return db.TUrun.Find(id);
        }

        public string Put(int id, TUrun t) // PUT API GÜNCELLEME İŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin bilgilerini dışarıdan girdiğimiz bilgilerle değiştiriyoruz
            var x = db.TUrun.Find(id);
            x.Fiyat = t.Fiyat;
            x.Kategori = t.Kategori;
            x.Kod = t.Kod;
            x.Stok = t.Stok;
            x.Urun = t.Urun;
            db.SaveChanges();
            return "Güncellendi";
        }

        public string Delete(int id) // DELETE API SİLMEİŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin ID sini kaldırıyoruz
            var x = db.TUrun.Find(id);
            db.TUrun.Remove(x);
            db.SaveChanges();
            return "Silindi";
        }
    }
}
