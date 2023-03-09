using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cari p) {
            p.durum = true;


            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        
        }
        public ActionResult CariSil(int id) {
            var dep = c.Caris.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult CariListele()
        {
            var degerler = c.Caris.ToList();
            return View(degerler);
        }
    }
}