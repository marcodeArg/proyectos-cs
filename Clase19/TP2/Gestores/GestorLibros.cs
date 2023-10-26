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

    public Libro? ObtenerLibro(int id)
    {
      return contexto.Libros.FirstOrDefault(l => l.Id == id);
    }

    public bool AgregarLibro(Libro l)
    {
      using (var transaction = contexto.Database.BeginTransaction())
      {
        try
        {
          contexto.Libros.Add(l);
          contexto.SaveChanges();

          transaction.Commit();
          return true;
        }
        catch (Exception e)
        {
          transaction.Rollback();
          Console.WriteLine(e.Message);
          return false;
        }
      }
    }

    public bool ActualizarLibro(int id, Libro l)
    {
      using (var transaction = contexto.Database.BeginTransaction())
      {
        try
        {
          Libro? encontrado = ObtenerLibro(id);

          if (encontrado != null)
          {
            encontrado.Titulo = l.Titulo;
            encontrado.PrecioReposicion = l.PrecioReposicion;
            encontrado.BibliotecaId = l.BibliotecaId;
            encontrado.EstadoId = l.EstadoId;

            contexto.SaveChanges();
            transaction.Commit();
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

    public bool EliminarLibro(int id)
    {
      try
      {
        Libro? encontrado = ObtenerLibro(id);

        if (encontrado != null)
        {
          contexto.Libros.Remove(encontrado);
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