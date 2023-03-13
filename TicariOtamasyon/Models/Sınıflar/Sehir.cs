using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Sehir
    {
        public int PlakaID { get; set; }
        public string SehirAd { get; set; }
        public ICollection<İlce> İlces { get; set; }

    }
    }
