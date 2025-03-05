using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet] //Viewi çalıştırdığımda burayı çalıştırır.
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost] //Bir butona tıkladığımda burayı çalıştırır.
        public ActionResult KategoriEkle(Kategori k) //'k' view tarafına göndereceğim parametreleri tutar.
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index"); //Bu işlemler bitince beni index aksiyonuna yönlendirir.
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var ktgr = c.Kategoris.Find(id);
            return View(ktgr);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = c.Kategoris.Find(kategori.KategoriID);
            ktgr.KategoriAd =kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}