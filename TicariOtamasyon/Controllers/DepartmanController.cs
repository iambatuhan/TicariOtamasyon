using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var değerler = c.Departmen.Where(x=>x.Durum==true).ToList();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanGetir(int id) {
            var dpt = c.Departmen.Find(id);
            return View("DepartmanGetir", dpt);
        
        
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dept = c.Departmen.Find(p.DepartmanID);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id) {

            var degerler = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;


            return View(degerler);
        }
        public ActionResult DepartmaPersonelSatis(int id)
        {
            var degerler = c.SatısHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}