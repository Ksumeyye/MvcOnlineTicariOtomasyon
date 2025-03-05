using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1=c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
           
            var deger2=c.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3=c.Personels.Count().ToString();
            ViewBag.d3 = deger3;          

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Urunlers.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in c.Urunlers select x.Marka).Distinct().Count().ToString(); //Ürünler tablosu içinden markayı seç, seçilen markaları tekrarsız olarak say.
            ViewBag.d6 = deger6;

            var deger7 = c.Urunlers.Count(x => x.Stok <= 49).ToString();
            ViewBag.d7 = deger7;
            
            var deger8 = (from x in c.Urunlers orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault(); //Ürünler tablosundan satış fiyatı en yüksek olan 3 ürünü bana sırala,en yüksek olanın ismini bana getir.
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Urunlers orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault(); //Ürünler tablosundan satış fiyatı en düşük olan 3 ürünü bana sırala,en düşük olanın ismini bana getir.
            ViewBag.d9 = deger9;

            var deger10 = c.Urunlers.GroupBy(x => x.Kategori.KategoriAd).OrderByDescending(z => z.Count()).Select(k => k.Key).FirstOrDefault(); //Kategori tablosunda kategori Adlarını bana grupla. Tekrar eden isimli ve tekrar etmeyen isimli kategori adlarını bana say bunu anahtar yap ve bu kategori adını bana seç.
            ViewBag.d10 = deger10;

            var deger11 = c.Kategoris.Count(x => x.KategoriAd == "Bilgisayarlar").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Urunlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            
            var deger13 = (from x in c.SatisHarekets orderby x.Adet descending select x.Urunler.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14=c.SatisHarekets.Sum(x => x.ToplamTutar);
            ViewBag.d14 = deger14;

            DateTime bugun= DateTime.Today;
            var deger15 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y=>y.Adet).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString(); //Tarihi bugun olan satışların toplam tutarını bana getir.
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new GrupSinifi
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new GrupSinifi2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Carilers.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu4 = c.Urunlers.ToList();
            return PartialView(sorgu4);
        }
        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in c.Urunlers
                         group x by x.Marka into g
                         select new GrupSinifi3
                         {
                              Marka= g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu5.ToList());
        }
        public PartialViewResult Partial5()
        {
            var sorgu6 = from x in c.Kategoris
                         group x by x.KategoriAd into g
                         select new GrupSinifi4
                         {
                             KategoriAd = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu6.ToList());
        }
    }
}