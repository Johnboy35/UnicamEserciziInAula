using Database.Modello;
using Microsoft.EntityFrameworkCore;

namespace Database.Servizi {
    public class MioDbContext : DbContext {
        public MioDbContext() : base()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Persona> Persone {get;set;}
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             optionsBuilder.UseSqlite(@"Data Source=..\..\..\Database.db");
         }
         protected override void OnModelCreating(ModelBuilder modelBuilder) {
             modelBuilder.Entity<Persona>().ToTable("Persone").HasKey(p => p.Id);
         }
    }
}