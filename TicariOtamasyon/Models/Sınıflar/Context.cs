using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TicariOtamasyon.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<Fatura> Faturas { get;  set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<İlce> İlces { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatısHareket> SatısHarekets { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Yapılacak> Yapılacaks { get; set; }
 
    }
}