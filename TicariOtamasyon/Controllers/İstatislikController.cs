using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class İstatislikController : Controller
    {
        // GET: İstatislik
        Context c = new Context();
        SatısHareket s=new SatısHareket();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.dg4 = deger4;
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.dg5 = deger5;
            var deger6 = c.Uruns.Count(x => x.Stok <= 50).ToString();
            ViewBag.dg6 = deger6;
            var deger7 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.dg7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.SatısFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.dg8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.SatısFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.dg9 = deger9;


            var deger10 = c.SatısHarekets.Where(x => x.TeslimAlınma == true).Sum(y => (decimal?)y.ToplamTutar).ToString();
             ViewBag.dg10 = deger10;
            
            DateTime bugun = DateTime.Today;
            var deger11 = c.SatısHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.dg11 = deger11;

            var deger14 = c.SatısHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d14 = deger14; 
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.dg12 = deger12;
            //En çok satan ürün
            var deger13 = c.Uruns.Where(u => u.Urunid == (c.SatısHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()
              )).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.dg13 = deger13;
            return View(); 
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariSehir into g
                        select new SınıfGrup
                        {
                            Sehir = g.Key,
                            sayi = g.Count()


                        };
            return View(sorgu.ToList()); ;
        }
        public PartialViewResult Partial()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SınıfGrup2
                         {

                             Departman = g.Key,
                             Sayi = g.Count()

                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu = c.Caris.ToList();
            return PartialView(sorgu); 
        }
        public PartialViewResult Partia2()
        {
            var sorgu2 = from x in c.Uruns
                         group x by x.Marka into g
                         select new SınıfGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
            //return PartialView(sorgu2.ToList());
        }
    }
}