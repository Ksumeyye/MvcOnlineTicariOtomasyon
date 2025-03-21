﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int Urunid { get; set; }
        public virtual Urunler Urunler { get; set; }
        public int Cariid { get; set; }
        public virtual Cariler Cariler { get; set; }
        public int Personelid { get; set; }
        public virtual Personel Personel { get; set; }
    }
}