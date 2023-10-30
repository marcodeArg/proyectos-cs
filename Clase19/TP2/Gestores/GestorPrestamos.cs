using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
  public class GestorPrestamos
  {

    private BibliotecaContext contexto;

    public GestorPrestamos()
    {
      contexto = new();
    }

    public int CantidadPrestamos()
    {
      return contexto.Prestamos.Count();
    }

    public List<Prestamo> ObtenerPrestamosConLibros()
    {
      return contexto.Prestamos.Include(p => p.Libro).ToList();
    }

    public Prestamo? ObtenerPrestamo(int id)
    {
      return contexto.Prestamos.Find(id);
    }

    public bool AgregarPrestamo(Prestamo p)
    {
      try
      {
        contexto.Prestamos.Add(p);
        contexto.SaveChanges();

        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }


    public bool ActualizarPrestamo(int id, Prestamo p)
    {
      try
      {
        Prestamo? encontrado = ObtenerPrestamo(id);

        if (encontrado != null)
        {
          p.Id = encontrado.Id;
          contexto.Prestamos.Entry(encontrado).CurrentValues.SetValues(p);

          contexto.SaveChanges();
          return true;
        }

        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }

    }
  }
}