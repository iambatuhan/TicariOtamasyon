﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Fatura
    {
        [Key]
        public int Faturaid { get; set; }

        public string FaturaSeriNo { get; set; }
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> faturaKalems { get; set; }
        //not=burada bir faturanın birden fazla kalemi olabilir
    }
}