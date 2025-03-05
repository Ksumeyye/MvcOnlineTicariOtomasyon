using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            c.Departmans.Add(departman);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dprtmn = c.Departmans.Find(id);
                dprtmn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var dpt = c.Departmans.Find(id);
                return View(dpt);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var deger = c.Departmans.Find(departman.DepartmanID);
                deger.DepartmanAd = departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt=c.Departmans.Where(x=>x.DepartmanID == id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.dprtmnad = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.Personelid==id).ToList();
            var prsnl = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.prsnlad = prsnl;
            return View(degerler);
        }
    }
}