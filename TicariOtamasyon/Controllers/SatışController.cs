﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatısHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis() {

            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()


                                           }

                                         ).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }
           [HttpPost]
           public ActionResult YeniSatis(SatısHareket s) {
            s.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatısHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult SatısGetir(int id) {

            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()


                                           }

                                         ).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatısHarekets.Find(id);
            return View("SatısGetir",deger);
        
        }
        public ActionResult SatısGuncelle(SatısHareket p) {
            var deger = c.SatısHarekets.Find(p.SatisID);
            deger.Cariid = p.Cariid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.PersonelID = p.PersonelID;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult SatisDetay(int id) {
            var degerler = c.SatısHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        
        }
        public ActionResult SatısListele()
        {
            var degerler = c.SatısHarekets.ToList();
            return View(degerler);
        }
    }
}