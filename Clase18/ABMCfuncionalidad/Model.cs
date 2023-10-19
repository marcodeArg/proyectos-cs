using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Veterinaria
{
  public class VeterinariaContext : DbContext
  {
    public DbSet<AtencionMedica> AtencionMedicas { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }

    public string DbPath { get; private set; }
    public VeterinariaContext()
    {
      Env.Load();
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = Path.Join(path, "veterinaria2.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
  }
}