using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtamasyon.Models.Sınıflar;
namespace TicariOtamasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.ma = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim() {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();//Sistene giriş yapan mailin adresi
            var degerler = c.SatısHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult Yazdır()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();//Sistene giriş yapan mailin adresi
            var degerler = c.SatısHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult FaturaGörüntüle(int id)
        {
            var degerler = c.SatısHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);

        }
        public ActionResult GelenMesajlar() {
            var mail = (string)Session["CariMail"];
            var mesajlar= c.Mesajlars.Where(x => x.Alici == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
         
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;

            return View(mesajlar);
        }
    }
}