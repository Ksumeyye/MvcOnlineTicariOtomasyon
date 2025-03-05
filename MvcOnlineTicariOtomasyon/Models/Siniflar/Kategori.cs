using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urunler> Urunlers { get; set; } //Birden fazla ürünü bir arada tutabilmesi için ICollection kullandım. Tutacağım sınıf <Urunler> dir.  Veritabanında Urunlers olarak oluşur.
    }
}