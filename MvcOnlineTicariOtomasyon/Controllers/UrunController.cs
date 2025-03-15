using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();

        //Arama İçin
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Urunlers select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategori = (from x in c.Kategoris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.KategoriAd,
                                                Value = x.KategoriID.ToString()
                                            }).ToList();
            ViewBag.Kategori = kategori;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler urunler)
        {
            urunler.Durum = true;
            c.Urunlers.Add(urunler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Urunlers.Find(id);
            urun.Durum=false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> kategori = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.Kategori = kategori;
            var urun = c.Urunlers.Find(id);
            return View(urun);
        }
   
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urunler)
        {
            var urun = c.Urunlers.Find(urunler.UrunID);
            urun.UrunAd=urunler.UrunAd;
            urun.Marka = urunler.Marka;
            urun.Stok = urunler.Stok;
            urun.AlisFiyat = urunler.AlisFiyat;
            urun.SatisFiyat = urunler.SatisFiyat;
            urun.Kategoriid = urunler.Kategoriid;
            urun.UrunGorsel=urunler.UrunGorsel;
            urun.Durum = urunler.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Urunlers.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","SatisHareket");
        }
        public ActionResult UrunDetayy(int id)
        {
            var degerler = c.Urunlers.Where(x => x.UrunID == id).ToList();
            return View(degerler);
        }

    }
}