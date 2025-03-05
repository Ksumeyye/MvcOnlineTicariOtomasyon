using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departman = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanID.ToString()
                                             }).ToList();
            ViewBag.Departman = departman;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if(Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //Dosya adını alıyoruz.
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //Dosyanın uzantısını alıyoruz.
                string yol = "~/Image/" + dosyaadi + uzanti; //Dosyanın yolu.
                Request.Files[0].SaveAs(Server.MapPath(yol)); //Dosyayı kaydediyoruz.
                personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti; //Dosyanın yolu veritabanına kaydedilecek.
            }
            c.Personels.Add(personel);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departman = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanID.ToString()
                                             }).ToList();
            ViewBag.Departman = departman;
            var prsnl = c.Personels.Find(id);
            return View("PersonelGetir",prsnl);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personeller)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //Dosya adını alıyoruz.
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //Dosyanın uzantısını alıyoruz.
                string yol = "~/Image/" + dosyaadi + uzanti; //Dosyanın yolu.
                Request.Files[0].SaveAs(Server.MapPath(yol)); //Dosyayı kaydediyoruz.
                personeller.PersonelGorsel = "/Image/" + dosyaadi + uzanti; //Dosyanın yolu veritabanına kaydedilecek.
            }
            var prsn=c.Personels.Find(personeller.PersonelID);
            prsn.PersonelAd = personeller.PersonelAd;
            prsn.PersonelSoyad = personeller.PersonelSoyad;
            prsn.PersonelGorsel = personeller.PersonelGorsel;
            prsn.Departman.DepartmanAd = personeller.Departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
    }
}