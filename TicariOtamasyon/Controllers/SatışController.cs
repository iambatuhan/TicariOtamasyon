using System;
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
    }
}