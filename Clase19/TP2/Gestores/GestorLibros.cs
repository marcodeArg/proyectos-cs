using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
  public class GestorLibros
  {

    private BibliotecaContext contexto;

    public GestorLibros()
    {
      contexto = new();
    }

    public int CantidadLibros()
    {
      return contexto.Libros.Count();
    }

    // Obtener libro por id
    public Libro? ObtenerLibro(int id)
    {
      return contexto.Libros.Include(p => p.Prestamos).FirstOrDefault(l => l.Id == id);
    }

    // Obtener libros
    public List<Libro> ObtenerLibros()
    {
      return contexto.Libros.ToList();
    }

    // Obtener libros por nombre
    public List<Libro> ObtenerLibros(string nombre)
    {
      return contexto.Libros.Where(l => l.Titulo.Contains(nombre)).ToList();
    }

    // Obtener prestamos de un libro
    public List<Prestamo> ObtenerPrestamos(int id)
    {
      var libro = contexto.Libros.Include(l => l.Prestamos).FirstOrDefault(l => l.Id == id);

      if (libro != null)
      {
        return libro.Prestamos;
      }
      return new();
    }

    public bool AgregarLibro(Libro l)
    {
      try
      {
        contexto.Libros.Add(l);
        contexto.SaveChanges();

        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }

    public bool ActualizarLibro(int id, Libro l)
    {
      try
      {
        Libro? encontrado = ObtenerLibro(id);

        if (encontrado != null)
        {

          l.Id = encontrado.Id;
          contexto.Libros.Entry(encontrado).CurrentValues.SetValues(l);

          contexto.SaveChanges();
          return true;
        }
        System.Console.WriteLine("Nola");
        return false;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e.Message);
        return false;
      }

    }

    public bool EliminarLibro(int id)
    {
      try
      {
        Libro? encontrado = ObtenerLibro(id);

        if (encontrado != null)
        {
          foreach (var p in encontrado.Prestamos)
          {
            contexto.Prestamos.Remove(p);
          }

          contexto.Libros.Remove(encontrado);
          contexto.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    // Cantidad de libros por estado
    public (int, int, int) CantidadPorEstado()
    {
      var query = from l in contexto.Libros
                  group l by l.EstadoId into g
                  select new { Estado = g.Key, Cantidad = g.Count() };

      var listaGrupos = query.ToList();

      int cantDisponible = listaGrupos.FirstOrDefault(g => g.Estado == 1)?.Cantidad ?? 0;
      int cantPrestados = listaGrupos.FirstOrDefault(g => g.Estado == 2)?.Cantidad ?? 0;
      int cantExtraviados = listaGrupos.FirstOrDefault(g => g.Estado == 3)?.Cantidad ?? 0;

      return (cantDisponible, cantPrestados, cantExtraviados);
    }

    // Sumatoria del precio de reposición de todos los libros extraviados
    public decimal TotalExtraviados()
    {
      return contexto.Libros.Where(l => l.EstadoId == 3).Sum(l => l.PrecioReposicion);
    }

  }
}