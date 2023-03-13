using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelGörsel { get; set; }
        public DateTime BaslangıcTarihi{ get; set; }
        public decimal Maas { get; set; }

        public ICollection<SatısHareket> SatısHarekets { get; set; }
        public ICollection<KargoDetay> KargoDetays { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}