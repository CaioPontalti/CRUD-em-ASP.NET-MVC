using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcCrud_1N.Models
{
    public class LojaContext:DbContext
    {
        public LojaContext():base("Loja")
        {
            Database.Log = i => System.Diagnostics.Debug.WriteLine(i);
            //Database.CreateIfNotExists();
        }

        public DbSet<Clientes> Clietes { get; set; }
        public DbSet<Consultores> Consultores { get; set; }
        public DbSet<Telefones> Telefones { get; set; }

        //Na criação da base para criar as colunas das tabelas como Varchar ao invés de Nvarchar
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
        }

    }
}