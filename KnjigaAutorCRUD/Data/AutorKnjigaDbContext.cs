using KnjigaAutorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Data
{
    public class AutorKnjigaDbContext : DbContext
    {
        public AutorKnjigaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Knjiga> Knjige { get; set; }
    }
}
