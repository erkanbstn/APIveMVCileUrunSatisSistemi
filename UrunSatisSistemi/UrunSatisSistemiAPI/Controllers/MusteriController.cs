using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemiAPI.Controllers
{
    public class MusteriController : ApiController
    {
        // Entity Framework Modelimizi kullanabilmek için Modelden bir nesne türetiyoruz
        UrunSatisDBEntities db = new UrunSatisDBEntities();
        public string Post(TMusteri t) // POST API EKLEME İŞLEMİDİR
        {
            // ENTİTY FRAMEWORK kullanarak İlgili tablomuza ekleme yapıyoruz
            db.TMusteri.Add(t);
            db.SaveChanges();  // Değişiklikleri kaydederek veritabanına kaydedilmesini sağlıyoruz
            return "Eklendi"; // Methodun dönüş tipi String olduğundan string bir değer döndürüyoruz
        }
        // Normal listeleme
        public IEnumerable<TMusteri> Get()  // GET API LİSTELEME İŞLEMİDİR
        {
            // İlgili tabloyu Listeleme
            return Baglanti.db.TMusteri.ToList();
        }
        // Parametreli listeleme
        public TMusteri Get(int id) // GET API LİSTELEME İŞLEMİDİR
        {
            // Methoda verdiğimiz parametreyi listeletiyoruz 
            return db.TMusteri.Find(id);
        }

        public string Put(int id, TMusteri t) // PUT API GÜNCELLEME İŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin bilgilerini dışarıdan girdiğimiz bilgilerle değiştiriyoruz
            var x = db.TMusteri.Find(id);
            x.Musteri = t.Musteri;
            x.DogumTarih = t.DogumTarih;
            x.Cinsiyet = t.Cinsiyet;
            db.SaveChanges();
            return "Güncellendi";
        }

        public string Delete(int id) // DELETE API SİLMEİŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin ID sini kaldırıyoruz
            var x = db.TMusteri.Find(id);
            db.TMusteri.Remove(x);
            db.SaveChanges();
            return "Silindi";
        }
    }
}
