﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindBus.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class findbusEntities : DbContext
    {
        public findbusEntities()
            : base("name=findbusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tblbairro> tblbairro { get; set; }
        public DbSet<tblbairrorua> tblbairrorua { get; set; }
        public DbSet<tblcidade> tblcidade { get; set; }
        public DbSet<tblcidadebairro> tblcidadebairro { get; set; }
        public DbSet<tbletinerario> tbletinerario { get; set; }
        public DbSet<tbllogin> tbllogin { get; set; }
        public DbSet<tblponto> tblponto { get; set; }
        public DbSet<tblrota> tblrota { get; set; }
        public DbSet<tblrotaetinerario> tblrotaetinerario { get; set; }
        public DbSet<tblrotaponto> tblrotaponto { get; set; }
        public DbSet<tblrua> tblrua { get; set; }
        public DbSet<tblruaponto> tblruaponto { get; set; }
        public DbSet<tblusuario> tblusuario { get; set; }
        public DbSet<tblaplicativo> tblaplicativo { get; set; }
        public DbSet<tblbase> tblbase { get; set; }
        public DbSet<tblversao> tblversao { get; set; }
    }
}
