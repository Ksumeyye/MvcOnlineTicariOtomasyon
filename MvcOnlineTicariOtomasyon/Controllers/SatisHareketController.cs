using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisHareketController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisHareketEkle()
        {
            List<SelectListItem> urunler = (from x in c.Urunlers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UrunAd,
                                                  Value = x.UrunID.ToString()
                                              }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd+" "+x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd+" "+x.PersonelSoyad,
                                             Value = x.PersonelID.ToString()
                                         }).ToList();
      
            ViewBag.Personel = personel;
            ViewBag.Cariler = cariler;
            ViewBag.Urunler = urunler;
            return View();
        }
        [HttpPost]
        public ActionResult SatisHareketEkle(SatisHareket satis)
        {
            satis.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisHareketGuncelle(int id)
        {
            List<SelectListItem> urunler = (from x in c.Urunlers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.Personel = personel;
            ViewBag.Cariler = cariler;
            ViewBag.Urunler = urunler;
            var satisHrkt=c.SatisHarekets.Find(id);
            return View("SatisHareketGuncelle",satisHrkt);
        }
        [HttpPost]
        public ActionResult SatisHareketGuncelle(SatisHareket satisHareket)
        {
         var satisH=c.SatisHarekets.Find(satisHareket.SatisID);
            satisH.Urunid = satisHareket.Urunid;
            satisH.Cariid=satisHareket.Cariid;
            satisH.Adet = satisHareket.Adet;
            satisH.Fiyat = satisHareket.Fiyat;
            satisH.ToplamTutar = satisHareket.ToplamTutar;
            satisH.Tarih = satisHareket.Tarih;
            satisH.Personelid = satisHareket.Personelid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisHareketDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View (degerler);
        }
    }
}