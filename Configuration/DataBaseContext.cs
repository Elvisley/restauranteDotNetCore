

using Microsoft.EntityFrameworkCore;
using restaurante.Models;

namespace restaurante.Configuration{
    public class DataBaseContext : DbContext{
        
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=restaurante.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           modelBuilder.Entity<Restaurante>().ToTable("tb_restaurante");
           modelBuilder.Entity<Restaurante>().HasKey(t => t.Id);

           modelBuilder.Entity<Prato>().ToTable("tb_prato");
           modelBuilder.Entity<Prato>().HasKey(t => t.Id);

        }
        
    }
}