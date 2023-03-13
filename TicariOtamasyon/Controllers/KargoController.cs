using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.KargoDetays.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKargo() {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd+" "+x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
           


            return View();
        
        
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kd) {
            Random rnd = new Random();
            kd.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            kd.TakipKodu = rnd.Next(100000000, 2000000000);
            c.KargoDetays.Add(kd);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}