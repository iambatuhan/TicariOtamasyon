﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }


    }
}