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
            List<SelectListItem> deger3 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.SehirAd,
                                               Value = x.PlakaID.ToString()


                                           }).ToList();
            List<SelectListItem> deger4 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()


                                           }).ToList();
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            ViewBag.dg4 = deger4;




           


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
        
        public ActionResult SehirGetir() {

            List<SelectListItem> deger1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.SehirAd,
                                               Value = x.PlakaID.ToString()


                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.İlces.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.İlceAd,
                                               Value = x.İlceID.ToString()


                                           }).ToList();
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;


            return View ();

        }
        public JsonResult İlceGetir(int p)
        {
            //(from x in c.Uruns orderby x.SatısFiyat ascending select x.UrunAd).FirstOrDefault();
            var ilceler = (from x in c.İlces
                           join y in c.Sehirs on x.PlakaID equals y.PlakaID
                           where x.PlakaID == p
                           select new
                           {
                               Text = x.İlceAd,
                               Value = x.İlceID.ToString()

                           }

                           ).ToList() ;
            return Json(ilceler, JsonRequestBehavior.AllowGet);
        }
      
    }
}