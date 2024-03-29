﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class SatısHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        //ürün
        //cari
        //personel
        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int PersonelID { get; set; }
        public bool TeslimAlınma { get; set; }
        public virtual Urun Urun{ get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }


    }
} 