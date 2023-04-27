using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;

namespace TicariOtamasyon.Controllers
{
    public class UrunCariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        public ActionResult UrunDetay(int id)
        {
            var degerler = c.Uruns.Where(x => x.Urunid == id).ToList();
            return View(degerler);

        }




















    }
    
}