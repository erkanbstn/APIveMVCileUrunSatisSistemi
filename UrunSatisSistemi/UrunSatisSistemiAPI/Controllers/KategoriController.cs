using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrunSatisSistemi.Models;
namespace UrunSatisSistemiAPI.Controllers
{
    public class KategoriController : ApiController
    {
        // Entity Framework Modelimizi kullanabilmek için Modelden bir nesne türetiyoruz
        UrunSatisDBEntities db = new UrunSatisDBEntities();
        public string Post(TKategori t) // POST API EKLEME İŞLEMİDİR
        {
            // ENTİTY FRAMEWORK kullanarak İlgili tablomuza ekleme yapıyoruz
            db.TKategori.Add(t);
            db.SaveChanges();  // Değişiklikleri kaydederek veritabanına kaydedilmesini sağlıyoruz
            return "Eklendi"; // Methodun dönüş tipi String olduğundan string bir değer döndürüyoruz
        }
        // Normal listeleme
        public IEnumerable<TKategori> Get()  // GET API LİSTELEME İŞLEMİDİR
        {
            // İlgili tabloyu Listeleme
            return Baglanti.db.TKategori.ToList();
        }
        // Parametreli listeleme
        public TKategori Get(int id) // GET API LİSTELEME İŞLEMİDİR
        {
            // Methoda verdiğimiz parametreyi listeletiyoruz 
            return db.TKategori.Find(id);
        }

        public string Put(int id, TKategori t) // PUT API GÜNCELLEME İŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin bilgilerini dışarıdan girdiğimiz bilgilerle değiştiriyoruz
            var x = db.TKategori.Find(id);
            x.Kategori = t.Kategori;
            x.Aciklama = t.Aciklama;
            db.SaveChanges();
            return "Güncellendi";
        }

        public string Delete(int id) // DELETE API SİLMEİŞLEMİDİR
        {
            // İlgili ID yi methoda parametre olarak verdikten sonra burada 
            // Entity Framework yardımıyla buluyoruz
            // Bulduğumuz değerin ID sini kaldırıyoruz
            var x = db.TKategori.Find(id);
            db.TKategori.Remove(x);
            db.SaveChanges();
            return "Silindi";
        }
    }
}
