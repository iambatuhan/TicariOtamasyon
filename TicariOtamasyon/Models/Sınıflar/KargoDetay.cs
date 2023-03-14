using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        public int KargoDetayID { get; set; }
        public string Acıklama { get; set; }
        public int TakipKodu { get; set; }
        public int PersonelID { get; set; }
        public int CariID { get; set; }
        public int? PlakaID { get; set; }
        public int İlceID { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual  Cari Cari{ get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual İlce İlce { get; set; }
        
        public DateTime Tarih { get; set; }
    }
}