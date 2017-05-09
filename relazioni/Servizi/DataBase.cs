using Microsoft.EntityFrameworkCore;
using Relazioni.Modello;

namespace Relazioni.Servizi {
    public class DataBase : DbContext {
        
        public DbSet<Tavolo> Tavoli {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlite(@"Data Source=../../../database.db;");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            //Mappiamo le classi di entità a tabelle del database
            builder.Entity<Mossa>().ToTable("Mosse").HasKey(mossa => mossa.Id);
            builder.Entity<Tavolo>().ToTable("Tavoli").HasKey(tavolo => tavolo.Id);
            builder.Entity<Orologio>().ToTable("Orologi").HasKey(orologio => orologio.Id);

            //Mappiamo le relazioni
            builder
                .Entity<Tavolo>()
                .HasMany(tavolo => tavolo.Mosse)
                .WithOne(mossa => mossa.Tavolo)
                .IsRequired();

            builder
                .Entity<Tavolo>()
                .HasOne(tavolo => tavolo.Orologio)
                .WithOne(orologio => orologio.Tavolo)
                .HasForeignKey<Orologio>(orologio => orologio.Id)
                .IsRequired();

        }

    }
}