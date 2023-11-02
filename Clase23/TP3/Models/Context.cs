using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public BibliotecaContext()
        {
            Env.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
    }
}