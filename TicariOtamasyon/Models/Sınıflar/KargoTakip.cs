using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        public int KargoTakipID { get; set; }
        public string TakipKodu { get; set; }
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }

    }
}