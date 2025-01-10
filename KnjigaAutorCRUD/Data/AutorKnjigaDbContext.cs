using KnjigaAutorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Data
{
    public class AutorKnjigaDbContext : DbContext
    {
        public AutorKnjigaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorKnjiga>().HasKey(ak => new { ak.KnjigaId, ak.AutorId });

            modelBuilder.Entity<AutorKnjiga>().HasOne(ak => ak.Knjiga).WithMany(k => k.AutoriKnjige).HasForeignKey(k => k.KnjigaId);
            modelBuilder.Entity<AutorKnjiga>().HasOne(ak => ak.Autor).WithMany(a => a.AutoriKnjige).HasForeignKey(a => a.AutorId);
        }

        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Autor> Autori { get; set; }
        public DbSet<AutorKnjiga> AutoriKnjige { get; set; }
        public DbSet<Izdavac> Izdavaci { get; set; }
    }
}
