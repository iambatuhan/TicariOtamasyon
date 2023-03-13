using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class İlce
    {
        public int İlceID { get; set; }
        public string İlceAd { get; set; }
        public int PlakaID { get; set; }
        public virtual Sehir Sehir{ get; set; }
        
    }
}