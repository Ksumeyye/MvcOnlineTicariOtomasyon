using Antlr.Runtime;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Degerler",xValue:new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98}).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList(); //Burada xvalue, grafik için kullanılacak olan X eksenindeki değerleri tutacak. Yani, bu koleksiyon, grafik için "kategori" veya "etiket" olarak kullanılacak verileri saklayacak.
            ArrayList yvalue = new ArrayList();//yvalue, grafikte Y eksenindeki değerleri tutacak. Yani, bu koleksiyon, her X eksenindeki veriye karşılık gelen sayısal değerleri (örneğin stok miktarını) saklayacak.
            var sonuclar=c.Urunlers.ToList(); //ntity Framework DbContext'i ile ilişkilidir. Bu koleksiyon, Urunler tablosundaki verileri temsil eder.
           // ToList() metodu, Urunlers koleksiyonunu bir listeye dönüştürür ve sonuclar adlı bir değişkene atar.
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));//ForEach(), liste üzerinde her bir öğe için belirtilen işlemi uygulamak için kullanılır. Burada her öğe x olarak tanımlanmış.
            //x.UrunAd, her bir öğe(yani her ürün) üzerinde UrunAd özelliğini alır ve bunu xvalue koleksiyonuna ekler.Yani X ekseni için ürün adları toplanır.
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok)); //Bu satır, ikinci bir ForEach() döngüsü kullanarak sonuclar listesindeki her öğe (yani her ürün) üzerinde işlem yapar.
            //y.Stok, her ürünün stok miktarını temsil eder ve bu değer yvalue koleksiyonuna eklenir. Yani Y ekseni için stok sayıları toplanır.
            var grafik=new Chart(width: 500, height: 500) //Chart, ASP.NET MVC'deki bir sınıftır ve grafikleri oluşturmak için kullanılır. Burada, 500x500 piksel boyutlarında bir grafik nesnesi oluşturulmaktadır.
                .AddTitle("Stoklar") //Bu metod, grafiğe başlık ekler. Burada başlık "Stoklar" olarak belirlenmiş.
                .AddSeries(chartType: "Column",name:"Stok", xValue: xvalue, yValues: yvalue); //AddSeries metodu, grafiğe bir veri serisi ekler. Burada:
       //chartType: "Column": Grafik türü olarak Column(sütun grafik) seçilmiştir.
       //name: "Stok": Grafik serisinin adı "Stok" olarak belirlenmiştir.
//xValue: xvalue: X ekseni için xvalue koleksiyonu(yani ürün adları) kullanılır.
//yValues: yvalue: Y ekseni için yvalue koleksiyonu(yani stok miktarları) kullanılır.
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg"); //ToWebImage(), oluşturulan grafiği bir web görüntüsü (image) formatına dönüştürür.
            //GetBytes(), görüntüyü byte dizisine çevirir.
           // File(), byte dizisini bir dosya olarak geri döndürür ve bu dosyanın içerik tipi image / jpeg olarak belirtilir. Bu, grafiğin tarayıcıya bir resim olarak sunulmasını sağlar.
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(),JsonRequestBehavior.AllowGet); //Google charttaki ürün görselliğine ulaşabilmek için uyguladım.
        }
        public List<Sinif1>Urunlistesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
                {
                urunAd="Bilgisayarlar",
                Stok=120
                });
            snf.Add(new Sinif1()
            {
                urunAd= "Beyaz Eşyalar",
                Stok=150
            });
            snf.Add(new Sinif1()
            {
                urunAd = "Mobilyalar",
                Stok = 70
            });
            snf.Add(new Sinif1()
            {
                urunAd = "Küçük Ev Aletleri",
                Stok = 180
            });
            snf.Add(new Sinif1()
            {
                urunAd = "Mobil Cihazlar",
                Stok = 90
            });
            return snf;
        }
        public ActionResult Index5() 
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet); //Google charttaki ürün görselliğine ulaşabilmek için uyguladım.
        }
        public List<Sinif2> UrunListesi2() //UrunListesi2 adlı bir metodu içeriyor ve bu metodun amacı, veritabanında bulunan Urunler adlı bir tablodan verileri çekmek ve bunları bir listeye (List) dönüştürmek.
        {
            List<Sinif2> snf = new List<Sinif2>(); //Burada snf adında bir liste oluşturuluyor. Bu liste, Sinif2 tipinde nesneler tutacak. Başlangıçta boş bir liste oluşturuluyor.
            using (var context = new Context()) //Veritabanıyla bağlantı kurmak için context kullandım. using anahtar kelimesi, context nesnesinin işini bitirdikten sonra düzgün bir şekilde temizlenmesini ve kapatılmasını sağlar. Bu, bellek sızıntılarının ve bağlantı sorunlarının önüne geçmek için önemlidir.
            {
                snf=c.Urunlers.Select(x=>new Sinif2
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();
            }//using bloğunun sonu. Bu blok tamamlandığında, context nesnesi otomatik olarak kapanacak ve veritabanı bağlantısı sonlandırılacaktır.
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}