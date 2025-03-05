using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler cariler)
        {
            cariler.Durum = true;
            c.Carilers.Add(cariler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var crlr = c.Carilers.Find(id);
            crlr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var cri=c.Carilers.Find(id);
            return View(cri);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid) //Model state'n geçerliliği doğru değilse
            {
                return View("CariGuncelle"); //Bana cariGuncelleyi geri döndür.
            }
            var cri = c.Carilers.Find(cariler.CariID);
            cri.CariAd = cariler.CariAd;
            cri.CariSoyad= cariler.CariSoyad;
            cri.CariSehir = cariler.CariSehir;
            cri.CariMail = cariler.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");         
        }
        public ActionResult CariDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cri = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd+" "+y.CariSoyad).FirstOrDefault();
            ViewBag.criad = cri;
            return View(degerler);
        }
    }
}