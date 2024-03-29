﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun() {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                       select new SelectListItem
                                       {

                                           Text = x.KategoriAd,
                                           Value = x.KategoriID.ToString()


                                       }).ToList()  ;
            ViewBag.dgr1 = deger1;

            return View();
        
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            if (Request.Files.Count > 0) {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Image/";
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Image/" + dosyaadi + uzanti;
            
            
            
            
            }
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()


                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun p) {
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlısFiyat = p.AlısFiyat;
            urn.Durum = p.Durum;
            urn.KategoriID = p.KategoriID;
            urn.Marka = p.Marka;
            urn.SatısFiyat = p.SatısFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            //urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        
        
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        public ActionResult UrunDetay(int id) {
            var degerler = c.Uruns.Where(x => x.Urunid == id).ToList();
            return View(degerler);
        
        }
   
    }
}