using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq.Models
{
    public class SkolaDbContext : DbContext
    {
        public DbSet<Elev> Elever { get; set; }
        public DbSet<Klass> Klasser { get; set; }
        public DbSet<Kurs> Kurser { get; set; }
        public DbSet<Lärare> Lärare { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = LAPTOP-2TN3GN8G;Initial Catalog=Labb2Linq;Integrated Security = True;");
        }
    }
}
