﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int Cariid { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set;  }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Password { get; set; }

        public bool durum { get; set; }
        public ICollection<SatısHareket> SatısHarekets { get; set; }
        public ICollection<KargoDetay> KargoDetays { get; set; }
    }
}