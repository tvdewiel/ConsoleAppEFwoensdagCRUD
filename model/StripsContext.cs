using EFcrud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Data
{
    public class StripsContext : DbContext
    {
        public DbSet<Strip> Strips { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Reeks> Reeksen { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=NB21-6CDPYD3\SQLEXPRESS;Initial Catalog=stripsDB2023;Integrated Security=True;TrustServerCertificate=True");
        }
       
    }
}
