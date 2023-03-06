using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        public int AcıklamaId { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }


    }
}