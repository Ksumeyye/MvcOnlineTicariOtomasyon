﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Context:DbContext //DbContext sınıfından miras aldım.(Kalıtım)
    {
        public DbSet<Admin> Admins { get; set; } //Tablo bazlı çalışacağım için ve veritabanına yansıltılanacağı için DbSet kullandım.
        public DbSet <Cariler> Carilers { get; set; }
        public DbSet <Departman> Departmans { get; set; }
        public DbSet <FaturaKalem> FaturaKalems { get; set; }
        public DbSet <Faturalar> Faturalars { get; set; }
        public DbSet <SatisHareket> SatisHarekets { get; set; }
        public DbSet <Giderler> Giderlers { get; set; }
        public DbSet <Personel> Personels { get; set; }
        public DbSet <Urunler> Urunlers { get; set; }
        public DbSet <Kategori> Kategoris { get; set; }
        public DbSet <Detay> Detays { get; set;}
        public DbSet <Yapilacak> Yapilacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
    }
}