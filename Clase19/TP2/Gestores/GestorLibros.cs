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

    public List<Libro> ObtenerLibros()
    {
      return contexto.Libros.ToList();
    }

    public List<Prestamo> ObtenerPrestamos(int id)
    {
      var libro = contexto.Libros.Include(l => l.Prestamos).FirstOrDefault(l => l.Id == id);

      if (libro != null)
      {
        return libro.Prestamos;
      }
      return new();
    }

    public Libro? ObtenerLibro(int id)
    {
      return contexto.Libros.Include(p => p.Prestamos).FirstOrDefault(l => l.Id == id);
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
  }
}