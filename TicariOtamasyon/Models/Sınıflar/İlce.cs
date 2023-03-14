using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class İlce
    {
        [Key]
        public int İlceID { get; set; }
        public string İlceAd { get; set; }
        public int PlakaID { get; set; }
        public virtual Sehir Sehir { get; set; }
        public ICollection<KargoDetay> KargoDetays { get; set; }

    }
}