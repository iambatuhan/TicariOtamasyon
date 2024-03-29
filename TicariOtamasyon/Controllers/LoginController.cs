﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p) {
            p.durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        
        }
        [HttpGet]
        public ActionResult CariLogin1() {
            return  View();
        
        
        }
        [HttpPost]
        public ActionResult CariLogin1(Cari p)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == p.CariMail && x.Password ==p.Password);
            if (bilgiler != null) {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail,false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");


            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin() {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p) {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullanıcıAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");



            }
            else {

                return RedirectToAction("Index", "Login");
            
            }

        
        
        
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}