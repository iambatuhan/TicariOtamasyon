using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class FaturaKalemController : Controller
    {
        // GET: FaturaKalem
        Context c = new Context();
        public ActionResult Index()
        {
            var deger=c.FaturaKalems.ToList();
            return View(deger);
        }
    }
}