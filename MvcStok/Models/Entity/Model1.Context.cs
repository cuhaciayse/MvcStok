﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDbStokEntities1 : DbContext
    {
        public MvcDbStokEntities1()
            : base("name=MvcDbStokEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Kategoriler> Tbl_Kategoriler { get; set; }
        public virtual DbSet<Tbl_Musteriler> Tbl_Musteriler { get; set; }
        public virtual DbSet<Tbl_Satislar> Tbl_Satislar { get; set; }
        public virtual DbSet<Tbl_Urunler> Tbl_Urunler { get; set; }
    }
}