﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public string UrunGorsel1 { get; set; }
        public string UrunGorsel2 { get; set; }
        public string UrunGorsel3 { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string urunBilgi { get; set; }
        public int Kategoriid { get; set; }   
        public virtual Kategori Kategori { get; set; } //Kategori sınıfına bağlı olan bir tane property(Sütun) oluşturdum.
        public ICollection<SatisHareket> SatisHarekets  { get; set; }
    }
}