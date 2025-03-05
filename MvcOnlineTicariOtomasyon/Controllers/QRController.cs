using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web;
using System.Web.Mvc;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod) //Bu satırda, Index adlı bir ActionResult türünde metod tanımlanıyor. kod parametresi, dışarıdan gelen bir string parametresidir. Bu parametre, QR kodunun içeriğini belirleyecek veriyi taşır.
        {
            using (MemoryStream ms = new MemoryStream()) //Burada bir MemoryStream nesnesi oluşturuluyor. MemoryStream, verilerin hafızada tutulmasını sağlar, yani dosya sistemi üzerinde bir dosya oluşturulmaz, ancak veriler bellekte tutulur. using ifadesi, MemoryStream'in kullanım sonrasında otomatik olarak temizlenmesini sağlar.
            {
                QRCodeGenerator koduret = new QRCodeGenerator(); //Bu satırda, QRCodeGenerator türünde bir koduret nesnesi oluşturuluyor. QRCodeGenerator, QR kodları oluşturmak için kullanılan bir sınıftır. Bu nesne, QR kodunu üretmek için kullanılacaktır.
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q); //koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q) metodu, kod parametresindeki veriyi bir QR koduna dönüştürür. QRCodeGenerator.ECCLevel.Q ise QR kodunun hata düzeltme seviyesini belirtir. Bu seviyeler, QR kodunun daha az bozulmasına ve okunabilirliğinin artmasına yardımcı olur (bu örnekte Q seviyesi seçilmiş).

                using (Bitmap resim = karekod.GetGraphic(10)) //Burada, oluşturulan QR kodunun grafiksel temsilini almak için karekod.GetGraphic(10) metodu kullanılıyor. Bu metot, QR kodunu bir Bitmap resmine dönüştürür. 10 sayısı, QR kodunun ne kadar büyüklükte olacağını belirler (örneğin, 10, her bir modülün boyutunun 10 piksel olmasını sağlar).
                   // using ifadesi yine, Bitmap nesnesinin kullanım sonrası otomatik olarak bellekten temizlenmesini sağlar.
                {
                    resim.Save(ms, ImageFormat.Png); //resim.Save(ms, ImageFormat.Png) metodu, oluşturulan QR kodunu PNG formatında MemoryStream'e kaydeder. Bu işlem, QR kodunun görsel verilerini bellek üzerinde tutmaya devam etmemizi sağlar.
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray()); //Bu satırda, MemoryStream'teki veriler ToArray() metodu ile bir byte dizisine dönüştürülür. Ardından, bu byte dizisi Convert.ToBase64String ile Base64 formatına dönüştürülür. Son olarak, QR kodu verisi, HTML'de görüntülemek için uygun bir data URL formatına dönüştürülür. ViewBag.karekodimage, bu Base64 kodlu veriyi içeren bir string değerine atanır. Bu, görselin HTML'de görüntülenmesini sağlar.
                }
            }
                return View(); //Son olarak, Index metodunun sonucu olarak bir View döndürülür. Bu View, ViewBag.karekodimage değerine erişebilecektir ve bu değer sayesinde QR kodu görüntülenebilir.

            //Özetle, Bu metod, gelen kod parametresini kullanarak bir QR kodu oluşturur, bu QR kodunu bir Bitmap nesnesine dönüştürür, ardından bu resmi bellek içinde bir MemoryStream aracılığıyla PNG formatında saklar. Son olarak, QR kodunu Base64 formatında bir string'e dönüştürüp, bu string'i ViewBag aracılığıyla View'a gönderir. View, bu veriyi bir img etiketi içinde kullanarak QR kodunu kullanıcıya gösterir.
        }
    }
}