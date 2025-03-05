using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c=new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FaturalarGuncelle(int id)
        {
            var ftr=c.Faturalars.Find(id);
            return RedirectToAction("FaturalarGuncelle",ftr);
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar faturalar)
        {
            var deger=c.Faturalars.Find(faturalar.FaturaID);
            deger.FaturaSeriNo= faturalar.FaturaSeriNo;
            deger.FaturaSıraNo = faturalar.FaturaSıraNo;
            deger.Tarih= faturalar.Tarih;
            deger.VergiDairesi = faturalar.VergiDairesi;
            deger.Saat = faturalar.Saat;
            deger.TeslimEden = faturalar.TeslimEden;
            deger.TeslimAlan = faturalar.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            c.FaturaKalems.Add(faturaKalem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}