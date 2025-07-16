using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Tarea4DylanEspinozaPereira.Models {
    public class CRContext : DbContext {
        // Definición de las tablas
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "data", "CR.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cambiar nombres de columnas "Nombre" a "ProvinciaNombre", "CantonNombre", "DistritoNombre"
            modelBuilder.Entity<Provincia>()
                .Property(p => p.Nombre)
                .HasColumnName("ProvinciaNombre");

            modelBuilder.Entity<Canton>()
                .Property(c => c.Nombre)
                .HasColumnName("CantonNombre");

            modelBuilder.Entity<Distrito>()
                .Property(d => d.Nombre)
                .HasColumnName("DistritoNombre");
        }
    }

}
