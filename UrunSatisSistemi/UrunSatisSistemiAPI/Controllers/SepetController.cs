using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemiAPI.Controllers
{
    public class SepetController : ApiController
    {
        // Entity Framework Modelimizi kullanabilmek için Modelden bir nesne türetiyoruz
        UrunSatisDBEntities db = new UrunSatisDBEntities();
        public string Post(TSepet t) // POST API EKLEME İŞLEMİDİR
        {
            // ENTİTY FRAMEWORK kullanarak İlgili tablomuza ekleme yapıyoruz
            db.TSepet.Add(t);
            db.SaveChanges();  // Değişiklikleri kaydederek veritabanına kaydedilmesini sağlıyoruz
            return "Eklendi"; // Methodun dönüş tipi String olduğundan string bir değer döndürüyoruz
        }
        // Normal listeleme
        public IEnumerable<TSepet> Get()  // GET API LİSTELEME İŞLEMİDİR
        {
            // İlgili tabloyu Listeleme
            return Baglanti.db.TSepet.ToList();
        }
        // Parametreli listeleme
        public TSepet Get(int id) // GET API LİSTELEME İŞLEMİDİR
        {
            // Methoda verdiğimiz parametreyi listeletiyoruz 
            return db.TSepet.Find(id);
        }

        public string Put(int id, TSepet t) // PUT API GÜNCELLEME İŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin bilgilerini dışarıdan girdiğimiz bilgilerle değiştiriyoruz
            var x = db.TSepet.Find(id);
            x.ToplamMiktar = t.ToplamMiktar;
            x.Musteri = t.Musteri;
            x.Adet = t.Adet;
            x.Urun = t.Urun;
            db.SaveChanges();
            return "Güncellendi";
        }

        public string Delete(int id) // DELETE API SİLMEİŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin ID sini kaldırıyoruz
            var x = db.TSepet.Find(id);
            db.TSepet.Remove(x);
            db.SaveChanges();
            return "Silindi";
        }
    }
}
