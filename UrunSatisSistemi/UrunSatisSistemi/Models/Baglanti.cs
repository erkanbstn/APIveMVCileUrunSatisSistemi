using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunSatisSistemi.Models
{
    public static class Baglanti
    {
        public static UrunSatisDBEntities db = new UrunSatisDBEntities(); // Modeldeki tablolara kolay yoldan erişim için nesneyi statik hale getirmek
    }
}