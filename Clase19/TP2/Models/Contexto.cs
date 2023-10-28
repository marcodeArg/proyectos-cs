using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Biblioteca
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
            Env.Load();
        }

        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<Prestamo> Prestamos { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));

    }

}

