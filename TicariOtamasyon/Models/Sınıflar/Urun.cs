using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlısFiyat { get; set; }
        public decimal SatısFiyat { get; set; }
        public bool Durum { get; set; }
        public string UrunGorsel { get; set; }
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatısHareket> SatısHarekets { get; set; }
    }
}